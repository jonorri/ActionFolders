namespace Nonoe.ActionFolders.GUI
{
    partial class ScriptManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptManager));
            this.grdScripts = new System.Windows.Forms.DataGridView();
            this.ScriptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScriptDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScriptContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grdScripts)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdScripts
            // 
            this.grdScripts.AllowUserToAddRows = false;
            this.grdScripts.AllowUserToResizeColumns = false;
            this.grdScripts.AllowUserToResizeRows = false;
            this.grdScripts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdScripts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScriptName,
            this.ScriptDescription,
            this.ScriptContent});
            this.grdScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScripts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdScripts.Location = new System.Drawing.Point(0, 0);
            this.grdScripts.Name = "grdScripts";
            this.grdScripts.ReadOnly = true;
            this.grdScripts.RowHeadersVisible = false;
            this.grdScripts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdScripts.ShowEditingIcon = false;
            this.grdScripts.Size = new System.Drawing.Size(1012, 611);
            this.grdScripts.TabIndex = 0;
            this.grdScripts.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.GrdScriptsUserDeletingRow);
            // 
            // ScriptName
            // 
            this.ScriptName.DataPropertyName = "ScriptName";
            this.ScriptName.HeaderText = "Name";
            this.ScriptName.Name = "ScriptName";
            this.ScriptName.ReadOnly = true;
            this.ScriptName.Width = 60;
            // 
            // ScriptDescription
            // 
            this.ScriptDescription.DataPropertyName = "ScriptDescription";
            this.ScriptDescription.HeaderText = "Description";
            this.ScriptDescription.Name = "ScriptDescription";
            this.ScriptDescription.ReadOnly = true;
            this.ScriptDescription.Width = 85;
            // 
            // ScriptContent
            // 
            this.ScriptContent.DataPropertyName = "ScriptContent";
            this.ScriptContent.HeaderText = "Content";
            this.ScriptContent.Name = "ScriptContent";
            this.ScriptContent.ReadOnly = true;
            this.ScriptContent.Width = 69;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 24);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.BtnImportClick);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(90, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 24);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.BtnExportClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 42);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdScripts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 611);
            this.panel2.TabIndex = 4;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Zip Files|*.zip";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ScriptManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScriptManager";
            this.Text = "ScriptManager";
            ((System.ComponentModel.ISupportInitialize)(this.grdScripts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdScripts;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScriptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScriptDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScriptContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}