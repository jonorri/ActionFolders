// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfoWindow.cs" company="">
//   
// </copyright>
// <summary>
//   The info window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Nonoe.ActionFolders.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using System.Windows.Forms;

    using log4net;

    using Nonoe.ActionFolders.BusinessLogic.Core;
    using Nonoe.ActionFolders.Objects;

    /// <summary>
    ///     The info window.
    /// </summary>
    public partial class InfoWindow : Form
    {
        #region Static Fields

        /// <summary>
        ///     Log4Net logger.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(InfoWindow));

        #endregion

        #region Fields

        /// <summary>The action folder logic.</summary>
        private readonly ActionFolderLogic actionControl;

        /// <summary>
        /// The script logic.
        /// </summary>
        private readonly ScriptLogic scriptLogic;

        /// <summary>The tray icon.</summary>
        private NotifyIcon trayIcon;

        /// <summary>The tray menu.</summary>
        private ContextMenu trayMenu;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="InfoWindow" /> class.
        /// </summary>
        public InfoWindow()
        {
            this.InitializeComponent();

            this.actionControl = new ActionFolderLogic();
            this.actionControl.Running += this.actionControl_Running;
            this.actionControl.ScriptError += this.ActionControlScriptError;
            this.grdActionFolders.DataSource = this.actionControl.ActionFolders;
            this.grdActionFolders.ReadOnly = true;

            this.scriptLogic = new ScriptLogic();

            this.cboScript.DataSource = this.scriptLogic.BuildScriptModels().Select(x => x.ScriptName).ToList();

            // Set up the delays for the ToolTip.
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            this.toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            this.toolTip1.SetToolTip(this.btnAdd, "Create an action folder");
            this.toolTip1.SetToolTip(this.btnRemove, "Remove the selected action folder");
            this.toolTip1.SetToolTip(this.txtFolder, "What folder to monitor for added files?");
            this.toolTip1.SetToolTip(this.txtFileType, "What kind of file type to monitor?");
            this.toolTip1.SetToolTip(this.cboScript, "What script to run against the newly added file?");
            this.toolTip1.SetToolTip(this.grdConfigs, "Here are all the config values for the script to run.");
            this.toolTip1.SetToolTip(this.chkActive, "Is the action folder active or not?");

            this.SetDisplay();
            this.Hide();
        }

        private void ActionControlScriptError(object sender, string scriptLocation)
        {
            this.trayIcon.ShowBalloonTip(5000, scriptLocation, scriptLocation + " errored out check the logs for further information.", ToolTipIcon.Error);
        }

        /// <summary>
        /// The action control running event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="item">Action folder being run</param>
        /// <param name="running">The running flag.</param>
        private void actionControl_Running(object sender, ActionFolder item, bool running)
        {
            string scriptName = Path.GetFileName(item.ScriptLocation);
            if (running)
            {
                this.trayIcon.ShowBalloonTip(int.MaxValue, scriptName, scriptName + " is being run.", ToolTipIcon.Info);
            }
            else
            {
                this.trayIcon.ShowBalloonTip(5000, scriptName, scriptName + " is done running", ToolTipIcon.Info);
            }
        }


        #endregion

        #region Methods

        /// <summary>
        ///     Clears all input boxes.
        /// </summary>
        private void ClearInputBoxes()
        {
            this.txtActionFolderId.Text = string.Empty;
            this.txtFileType.Text = string.Empty;
            this.txtFolder.Text = string.Empty;
            this.cboScript.SelectedItem = 0;
            this.grdConfigs.Rows.Clear();
        }

        /// <summary>
        /// This function fills the configuration grid.
        /// </summary>
        /// <param name="properties">
        /// The properties to input into the configuration grid.
        /// </param>
        private void FillConfigSpread(Dictionary<string, string> properties)
        {
            this.grdConfigs.Rows.Clear();
            foreach (var pair in properties.ToArray())
            {
                int i = this.grdConfigs.Rows.Add(new DataGridViewRow());

                DataGridViewCell keyCell = new DataGridViewTextBoxCell();
                keyCell.Value = pair.Key;
                this.grdConfigs.Rows[i].Cells["KeyColumn"] = keyCell;

                DataGridViewCell valueCell = new DataGridViewTextBoxCell();
                valueCell.Value = pair.Value;
                valueCell.ReadOnly = false;
                this.grdConfigs.Rows[i].Cells["ValueColumn"] = valueCell;
            }
        }

        /// <summary>
        /// The info window form closing event handler.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The form closing event argument</param>
        private void InfoWindowFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// The on about menu item click event handler.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event argument</param>
        private void OnAbout(object sender, EventArgs e)
        {
            var frm = new AboutBox();
            frm.ShowDialog();

            frm.Dispose();
        }

        /// <summary>
        /// The on control room menu item click event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender object
        /// </param>
        /// <param name="e">
        /// The event argument
        /// </param>
        private void OnControlRoom(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// The on exit menu item click event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender object
        /// </param>
        /// <param name="e">
        /// The event argument.
        /// </param>
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// The on script manager menu item click event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender object
        /// </param>
        /// <param name="e">
        /// The event argument
        /// </param>
        private void OnScriptManager(object sender, EventArgs e)
        {
            var frm = new ScriptManager();
            frm.ShowDialog();

            frm.Dispose();
        }

        /// <summary>The set display method.</summary>
        private void SetDisplay()
        {
            this.trayMenu = new ContextMenu();
            this.trayMenu.MenuItems.Add("&Control room", this.OnControlRoom);
            this.trayMenu.MenuItems.Add("&Script manager", this.OnScriptManager);
            this.trayMenu.MenuItems.Add("&About", this.OnAbout);
            this.trayMenu.MenuItems.Add("&Exit", this.OnExit);

            this.trayIcon = new NotifyIcon
                                {
                                    Text = "Action Folders", 
                                    Icon = new Icon("Resources/afico.ico"), 
                                    ContextMenu = this.trayMenu, 
                                    Visible = true
                                };
        }

        /// <summary>
        /// The add button click event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender parameter.
        /// </param>
        /// <param name="e">
        /// The event argument.
        /// </param>
        private void BtnAddClick(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> configs =
                    (from DataGridViewRow r in this.grdConfigs.Rows where r.Cells["KeyColumn"].Value != null select r)
                        .ToDictionary(
                            r => r.Cells["KeyColumn"].Value.ToString(), r => r.Cells["ValueColumn"].Value.ToString());

                var serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(configs);

                this.actionControl.AddActionFolder(
                    new ActionFolder
                        {
                            Folder = this.txtFolder.Text, 
                            ScriptLocation = this.cboScript.SelectedItem.ToString(), 
                            FileType = this.txtFileType.Text, 
                            JsonConfigs = json, 
                            Active = this.chkActive.Checked, 
                            Type =
                                Path.GetExtension(this.cboScript.SelectedText) == ".rb"
                                    ? RunnerType.Ruby
                                    : RunnerType.Python
                        });
            }
            catch (Exception ex)
            {
                Log.Error("An error occured adding an action folder to xml file: " + ex);
            }
            finally
            {
                this.ClearInputBoxes();
            }
        }

        /// <summary>
        /// The folder browser button click event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender object.
        /// </param>
        /// <param name="e">
        /// The event argument.
        /// </param>
        private void BtnFolderBrowserClick(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.txtFolder.Text = this.folderBrowserDialog1.SelectedPath;
        }

        /// <summary>
        /// The remove button click event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender object
        /// </param>
        /// <param name="e">
        /// The event argument
        /// </param>
        private void BtnRemoveClick(object sender, EventArgs e)
        {
            int actionFolderId;
            if (!int.TryParse(this.txtActionFolderId.Text, out actionFolderId))
            {
                return;
            }

            this.ClearInputBoxes();
            this.actionControl.RemoveActionFolder(actionFolderId);
        }

        /// <summary>
        /// SelectedValueChanged handler on the script combo box.
        ///     Finds all properties needed to run the script and displays them in the grid.
        ///     Should also check the script and see whether the script is properly formatted.
        /// </summary>
        /// <param name="sender">
        /// Sender object
        /// </param>
        /// <param name="e">
        /// Event Arguments
        /// </param>
        private void CboScriptSelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Check whether the script is properly formatted and that the file exists.
                IScriptLogic logic = ScriptLogicFactory.GetHandler(Path.GetExtension(this.cboScript.Text));
                string scriptLocation = Path.Combine(Environment.CurrentDirectory, "Scripts", this.cboScript.Text);
                if (!logic.IsScriptProperlyFormatted(scriptLocation))
                {
                    return;
                }

                // Get properties needed to parse from script file.
                Dictionary<string, string> properties = logic.GetPropertiesFromScript(scriptLocation);
                this.FillConfigSpread(properties);
            }
            catch (Exception ex)
            {
                Log.Error("An error occured when fetching the properties from the script: " + ex);
            }
        }

        /// <summary>
        /// The action folders grid cell formatting event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender object
        /// </param>
        /// <param name="e">
        /// The event argument
        /// </param>
        private void GrdActionFoldersCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Set the background to red for negative values in the Balance column. 
            if (!this.grdActionFolders.Columns[e.ColumnIndex].Name.Equals("Active"))
            {
                return;
            }

            bool boolValue;
            if (bool.TryParse(e.Value.ToString(), out boolValue) && (boolValue == false))
            {
                this.grdActionFolders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                this.grdActionFolders.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        /// <summary>
        /// The action folders grid selection changed event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender object
        /// </param>
        /// <param name="e">
        /// The event argument.
        /// </param>
        private void GrdActionFoldersSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int rowNumber = this.grdActionFolders.SelectedRows[0].Index;
                this.txtActionFolderId.Text = this.grdActionFolders.Rows[rowNumber].Cells["Id"].Value.ToString();
                this.txtFolder.Text = this.grdActionFolders.Rows[rowNumber].Cells["Folder"].Value.ToString();
                this.cboScript.Text =
                    Path.GetFileName(this.grdActionFolders.Rows[rowNumber].Cells["ScriptLocation"].Value.ToString());
                this.txtFileType.Text = this.grdActionFolders.Rows[rowNumber].Cells["FileType"].Value.ToString();
                this.chkActive.Checked =
                    bool.Parse(this.grdActionFolders.Rows[rowNumber].Cells["Active"].Value.ToString());

                var serializer = new JavaScriptSerializer();
                var dict =
                    serializer.Deserialize<Dictionary<string, string>>(
                        this.grdActionFolders.Rows[rowNumber].Cells["JsonConfigs"].Value.ToString());
                this.FillConfigSpread(dict);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (Exception ex)
            {
                Log.Error("An error occured adding an action folder to xml file: " + ex);
            }
        }

        #endregion
    }
}