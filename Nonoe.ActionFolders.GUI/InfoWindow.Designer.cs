namespace Nonoe.ActionFolders.GUI
{
    partial class InfoWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoWindow));
            this.grdConfigs = new System.Windows.Forms.DataGridView();
            this.KeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grdActionFolders = new System.Windows.Forms.DataGridView();
            this.lblFileType = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.lblScriptLocation = new System.Windows.Forms.Label();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cboScript = new System.Windows.Forms.ComboBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtActionFolderId = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdConfigs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdActionFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdConfigs
            // 
            this.grdConfigs.AllowUserToAddRows = false;
            this.grdConfigs.AllowUserToDeleteRows = false;
            this.grdConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConfigs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyColumn,
            this.ValueColumn});
            this.grdConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConfigs.Location = new System.Drawing.Point(0, 0);
            this.grdConfigs.Name = "grdConfigs";
            this.grdConfigs.RowHeadersVisible = false;
            this.grdConfigs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdConfigs.Size = new System.Drawing.Size(388, 126);
            this.grdConfigs.TabIndex = 4;
            // 
            // KeyColumn
            // 
            this.KeyColumn.HeaderText = "Key";
            this.KeyColumn.Name = "KeyColumn";
            this.KeyColumn.ReadOnly = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "IronPython (*.py)|*.py|IronRuby (*.rb)|*.rb";
            // 
            // grdActionFolders
            // 
            this.grdActionFolders.AllowUserToAddRows = false;
            this.grdActionFolders.AllowUserToDeleteRows = false;
            this.grdActionFolders.AllowUserToResizeRows = false;
            this.grdActionFolders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.grdActionFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdActionFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdActionFolders.Location = new System.Drawing.Point(0, 0);
            this.grdActionFolders.MultiSelect = false;
            this.grdActionFolders.Name = "grdActionFolders";
            this.grdActionFolders.ReadOnly = true;
            this.grdActionFolders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdActionFolders.RowHeadersVisible = false;
            this.grdActionFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdActionFolders.Size = new System.Drawing.Size(690, 156);
            this.grdActionFolders.TabIndex = 3;
            this.grdActionFolders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdActionFoldersCellFormatting);
            this.grdActionFolders.SelectionChanged += new System.EventHandler(this.GrdActionFoldersSelectionChanged);
            // 
            // lblFileType
            // 
            this.lblFileType.Location = new System.Drawing.Point(13, 39);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(59, 20);
            this.lblFileType.TabIndex = 8;
            this.lblFileType.Text = "File type";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(111, 10);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(26, 20);
            this.btnFolder.TabIndex = 6;
            this.btnFolder.Text = "...";
            this.btnFolder.Click += new System.EventHandler(this.BtnFolderBrowserClick);
            // 
            // lblScriptLocation
            // 
            this.lblScriptLocation.Location = new System.Drawing.Point(13, 68);
            this.lblScriptLocation.Name = "lblScriptLocation";
            this.lblScriptLocation.Size = new System.Drawing.Size(67, 13);
            this.lblScriptLocation.TabIndex = 9;
            this.lblScriptLocation.Text = "Script location";
            // 
            // txtFileType
            // 
            this.txtFileType.Location = new System.Drawing.Point(111, 39);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(172, 20);
            this.txtFileType.TabIndex = 4;
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(143, 10);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(140, 20);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(111, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(200, 95);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(83, 28);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(13, 14);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(59, 16);
            this.lblFolder.TabIndex = 7;
            this.lblFolder.Text = "Folder";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 126;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdActionFolders);
            this.splitContainer1.Size = new System.Drawing.Size(690, 286);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 13;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cboScript);
            this.splitContainer2.Panel1.Controls.Add(this.chkActive);
            this.splitContainer2.Panel1.Controls.Add(this.txtActionFolderId);
            this.splitContainer2.Panel1.Controls.Add(this.lblFolder);
            this.splitContainer2.Panel1.Controls.Add(this.lblScriptLocation);
            this.splitContainer2.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer2.Panel1.Controls.Add(this.btnFolder);
            this.splitContainer2.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer2.Panel1.Controls.Add(this.txtFileType);
            this.splitContainer2.Panel1.Controls.Add(this.lblFileType);
            this.splitContainer2.Panel1.Controls.Add(this.txtFolder);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel1MinSize = 298;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdConfigs);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(690, 126);
            this.splitContainer2.SplitterDistance = 298;
            this.splitContainer2.TabIndex = 0;
            // 
            // cboScript
            // 
            this.cboScript.FormattingEnabled = true;
            this.cboScript.Location = new System.Drawing.Point(111, 68);
            this.cboScript.Name = "cboScript";
            this.cboScript.Size = new System.Drawing.Size(172, 21);
            this.cboScript.TabIndex = 15;
            this.cboScript.SelectedValueChanged += new System.EventHandler(this.CboScriptSelectedValueChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(16, 95);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 14;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtActionFolderId
            // 
            this.txtActionFolderId.Enabled = false;
            this.txtActionFolderId.Location = new System.Drawing.Point(78, 91);
            this.txtActionFolderId.Name = "txtActionFolderId";
            this.txtActionFolderId.Size = new System.Drawing.Size(10, 20);
            this.txtActionFolderId.TabIndex = 13;
            this.txtActionFolderId.Visible = false;
            // 
            // InfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 286);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 320);
            this.Name = "InfoWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "InfoWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoWindowFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdConfigs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdActionFolders)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView grdConfigs;
        private System.Windows.Forms.DataGridView grdActionFolders;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label lblScriptLocation;
        private System.Windows.Forms.TextBox txtFileType;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.TextBox txtActionFolderId;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboScript;
    }
}