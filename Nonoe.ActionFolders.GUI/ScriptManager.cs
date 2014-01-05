// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptManager.cs" company="Nonoe">
//   JOK 2013
// </copyright>
// <summary>
//   The script manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nonoe.ActionFolders.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Nonoe.ActionFolders.BusinessLogic.Core;

    /// <summary>The script manager.</summary>
    public partial class ScriptManager : Form
    {
        #region Fields

        /// <summary>The scripts logic.</summary>
        private readonly ScriptLogic scriptLogic;

        /// <summary>The scripts.</summary>
        private BindingList<ScriptModel> scripts;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ScriptManager"/> class.</summary>
        public ScriptManager()
        {
            this.InitializeComponent();
            this.scriptLogic = new ScriptLogic();
            this.RefreshGrid();
            this.saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        #endregion

        #region Methods

        /// <summary>The refresh grid method.</summary>
        private void RefreshGrid()
        {
            this.scripts = new BindingList<ScriptModel>(this.scriptLogic.BuildScriptModels().ToList());
            this.grdScripts.DataSource = this.scripts;
        }

        /// <summary>The export button click event handler.</summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event argument.</param>
        private void BtnExportClick(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var files = new Collection<string>();
            foreach (DataGridViewRow row in this.grdScripts.SelectedRows)
            {
                files.Add(row.Cells["ScriptName"].Value.ToString());
            }

            this.scriptLogic.ExportScriptsToZipFile(this.saveFileDialog1.FileName, files);
        }

        /// <summary>The import button click event handler.</summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event argument.</param>
        private void BtnImportClick(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var logic = ScriptLogicFactory.GetHandler(Path.GetExtension(this.openFileDialog1.FileName));
            if (logic == null || !logic.IsScriptProperlyFormatted(this.openFileDialog1.FileName))
            {
                MessageBox.Show(
                    "The script isn't properly formatted. Try a new one.",
                    "Error importing script",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                File.Copy(this.openFileDialog1.FileName, Path.Combine(Directory.GetCurrentDirectory(), "SCRIPTS", Path.GetFileName(this.openFileDialog1.FileName)));
            }
            this.BtnImportClick(sender, e);
        }

        /// <summary>
        /// The user deleting row event handler for the scripts grid
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Data grid view row cancel event argument</param>
        private void GrdScriptsUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var scriptPath = e.Row.Cells["ScriptLocation"].Value.ToString();
            File.Delete(scriptPath);
        }

        #endregion
    }
}