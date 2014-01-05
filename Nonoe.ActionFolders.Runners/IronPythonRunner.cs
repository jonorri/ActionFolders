// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IronPythonRunner.cs" company="Nonoe">
//   Copyright JOK
// </copyright>
// <summary>
//   The iron python runner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Nonoe.ActionFolders.Runners
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Web.Script.Serialization;
    using IronPython.Hosting;
    using log4net;
    using Microsoft.Scripting.Hosting;

    /// <summary>
    /// The iron python runner.
    /// </summary>
    [Export("Python", typeof(IScriptRunner))]
    public class IronPythonRunner : IScriptRunner
    {
        #region Static Fields

        /// <summary>
        /// The log4net log.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(IronPythonRunner));

        /// <summary>
        /// Gets or sets which script to run
        /// </summary>
        public string ScriptLocation { get; set; }

        /// <summary>
        /// Gets or sets the file path for the script to execute
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the JSON config for the script
        /// </summary>
        public string JsonConfigurations { get; set; }

        /// <summary>
        /// The error.
        /// </summary>
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
        /// The create event handler.
        /// </summary>
        public void CreateEventHandler()
        {
            if (!File.Exists(this.FilePath) || !File.Exists(this.ScriptLocation))
            {
                return;
            }

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += this.BwDoWork;
            worker.ProgressChanged += this.BwProgressChanged;
            worker.RunWorkerCompleted += this.BwRunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// The background worker run worker completed event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // handle completion here
        }

        /// <summary>
        /// The background worker progress changed event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void BwProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // handle progress updates here
        }

        /// <summary>
        /// The background worker do work event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void BwDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // The Python 'x' instance is called passing parameter dictionary
                var serializer = new JavaScriptSerializer();
                var dict = (Dictionary<string, string>)serializer.Deserialize(this.JsonConfigurations, typeof(Dictionary<string, string>));

                var engine = Python.CreateEngine();

                ScriptSource scripts = engine.CreateScriptSourceFromFile(this.ScriptLocation);
                CompiledCode code = scripts.Compile();
                ScriptScope scope = engine.CreateScope();
                code.Execute(scope);

                var script = ((dynamic)scope).Script(dict);
                script.Run(this.FilePath);
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("An error occured running Python script {0} :", this.ScriptLocation) + ex);
                var logFileName = DateTime.UtcNow.ToString("yyyy-MM-dd") + ".log";
                File.Copy(System.Environment.CurrentDirectory + "\\Log\\" + logFileName, Path.GetDirectoryName(this.FilePath) + "\\" + logFileName, true);
                this.OnError(new ScriptEventArgs(this.ScriptLocation));
            }
        }

        #endregion
    }
}