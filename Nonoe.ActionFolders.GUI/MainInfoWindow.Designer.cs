namespace Nonoe.ActionFolders.GUI
{
    partial class MainInfoWindow
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
            this.btnFolderBrowser = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblActionFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScriptLocation = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgActionFolders = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgActionFolders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFolderBrowser
            // 
            this.btnFolderBrowser.Location = new System.Drawing.Point(96, 9);
            this.btnFolderBrowser.Name = "btnFolderBrowser";
            this.btnFolderBrowser.Size = new System.Drawing.Size(27, 21);
            this.btnFolderBrowser.TabIndex = 0;
            this.btnFolderBrowser.Text = "...";
            this.btnFolderBrowser.UseVisualStyleBackColor = true;
            this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(129, 9);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(152, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "c:\\temp\\";
            // 
            // txtFileType
            // 
            this.txtFileType.Location = new System.Drawing.Point(96, 36);
            this.txtFileType.Name = "txtFileType";
            this.txtFileType.Size = new System.Drawing.Size(185, 20);
            this.txtFileType.TabIndex = 2;
            this.txtFileType.Text = "*.txt";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(150, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 26);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&Add";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblActionFolder
            // 
            this.lblActionFolder.AutoSize = true;
            this.lblActionFolder.Location = new System.Drawing.Point(12, 9);
            this.lblActionFolder.Name = "lblActionFolder";
            this.lblActionFolder.Size = new System.Drawing.Size(66, 13);
            this.lblActionFolder.TabIndex = 5;
            this.lblActionFolder.Text = "Action folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File extension";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Script location";
            // 
            // txtScriptLocation
            // 
            this.txtScriptLocation.Location = new System.Drawing.Point(96, 62);
            this.txtScriptLocation.Name = "txtScriptLocation";
            this.txtScriptLocation.Size = new System.Drawing.Size(185, 20);
            this.txtScriptLocation.TabIndex = 7;
            this.txtScriptLocation.Text = "Scripts/OpenProgram.py";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(218, 88);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(62, 26);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblActionFolder);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnFolderBrowser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.txtScriptLocation);
            this.panel1.Controls.Add(this.txtFileType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 127);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgActionFolders);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 447);
            this.panel2.TabIndex = 11;
            // 
            // dgActionFolders
            // 
            this.dgActionFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActionFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgActionFolders.Location = new System.Drawing.Point(0, 0);
            this.dgActionFolders.Name = "dgActionFolders";
            this.dgActionFolders.Size = new System.Drawing.Size(601, 447);
            this.dgActionFolders.TabIndex = 0;
            // 
            // MainInfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 574);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainInfoWindow";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgActionFolders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFolderBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtFileType;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScriptLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblActionFolder;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgActionFolders;
    }
}

