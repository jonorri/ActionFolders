using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nonoe.ActionFolders.Base;
using System.IO;
using System.Collections.ObjectModel;

namespace Nonoe.ActionFolders.GUI
{
    public partial class MainInfoWindow : Form
    {
        Collection<MonitoredItem> _tempMonitors;
        public Collection<MonitoredItem> TempMonitors
        {
            get { return _tempMonitors; }
            set { _tempMonitors = value; }
        }

        public MainInfoWindow(Collection<MonitoredItem> monitors)
        {
            InitializeComponent();
            _tempMonitors = monitors;
            dgActionFolders.DataSource = _tempMonitors;
        }

        private void btnFolderBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtScriptLocation.Text))
                return;

            MonitoredItem item = _tempMonitors.Where(x => x.Path == txtPath.Text && x.FileType == txtFileType.Text).FirstOrDefault();
            if (item != null)
            {
                _tempMonitors.Remove(item);
            }
            _tempMonitors.Add(new MonitoredItem { Path = txtPath.Text, ScriptLocation = txtScriptLocation.Text, FileType = txtFileType.Text });

            dgActionFolders.DataSource = null;
            dgActionFolders.DataSource = _tempMonitors;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
