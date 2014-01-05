// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IronRubyRunner.cs" company="Nonoe">
//   Copyright JOK
// </copyright>
// <summary>
//   The iron ruby runner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nonoe.ActionFolders.Runners
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    using IronRuby;

    using log4net;

    using Microsoft.Scripting.Hosting;

    /// <summary>The iron ruby runner.</summary>
    [Export("Ruby", typeof(IScriptRunner))]
    public class IronRubyRunner : IScriptRunner
    {
        #region Fields

        /// <summary>The logger.</summary>
        private readonly ILog logger = LogManager.GetLogger(typeof(IronRubyRunner));

        /// <summary>The script engine.</summary>
        private ScriptEngine engine;

        /// <summary>
        /// What script to run
        /// </summary>
        public string ScriptLocation { get; set; }

        /// <summary>
        /// File path for the script to execute
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// JSON config for the script
        /// </summary>
        public string JsonConfigurations { get; set; }

        public event EventHandler Error;

        #endregion

        protected virtual void OnError(ScriptEventArgs e)
        {
            if (this.Error != null)
            {
                this.Error(this, e);
            }
        }

        #region Public Methods and Operators

        /// <summary>
        /// The create event handler method.
        /// This method runs the script on the file with the appropriate JSON configurations.
        /// </summary>
        public void CreateEventHandler()
        {
            if (!File.Exists(this.FilePath) || !File.Exists(this.ScriptLocation))
            {
                return;
            }

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(this.bw_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(this.bw_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // handle completion here
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // handle progress updates here
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Serialize the configs
            var serializer = new JavaScriptSerializer();
            var dict =
                (Dictionary<string, string>)
                serializer.Deserialize(this.JsonConfigurations, typeof(Dictionary<string, string>));

            this.engine = Ruby.CreateEngine();
            ScriptSource scripts = this.engine.CreateScriptSourceFromFile(this.ScriptLocation);
            CompiledCode code = scripts.Compile();
            ScriptScope scope = this.engine.CreateScope();
            code.Execute(scope);

            dynamic globals = this.engine.Runtime.Globals;
            dynamic script = globals.Script.@new(dict);

            // Call the Run method in the script.
            try
            {
                dynamic result = script.Run(this.FilePath);
                this.logger.Info((string)result);
            }
            catch (Exception ex)
            {
                this.logger.Error(
                    string.Format("An error occured running Ruby script {0} :", this.ScriptLocation) + ex);
                var logFileName = DateTime.UtcNow.ToString("yyyy-MM-dd") + ".log";
                File.Copy(
                    Environment.CurrentDirectory + "\\Log\\" + logFileName,
                    Path.GetDirectoryName(this.FilePath) + "\\" + logFileName,
                    true);
                this.OnError(new ScriptEventArgs(this.ScriptLocation));
            }
        }

        #endregion
    }
}