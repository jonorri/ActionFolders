using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Nonoe.ActionFolders.Base;
using System.Collections.ObjectModel;

namespace Nonoe.ActionFolders.GUI
{
    class Main : Form
    {
        private NotifyIcon  trayIcon;
        private ContextMenu trayMenu;
        private Monitor _monitor;
        private Collection<FileSystemWatcher> _fileSystemWatchers;

        public Main()
        {
            SetDisplay();

            // Set global variables
            _monitor = new Monitor();
            _fileSystemWatchers = new Collection<FileSystemWatcher>();
        }

        private void SetDisplay()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("&Control room", OnControlRoom);
            trayMenu.MenuItems.Add("&Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "MyTrayApp";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible       = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnControlRoom(object sender, EventArgs e)
        {
            MainInfoWindow frm = new MainInfoWindow(_monitor.Monitors);
            frm.ShowDialog();

            _monitor.Monitors = frm.TempMonitors;

            _fileSystemWatchers.Clear();
            foreach (MonitoredItem monitoredItem in _monitor.Monitors)
            {
                FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
                fileSystemWatcher.Path = monitoredItem.Path;
                fileSystemWatcher.Filter = monitoredItem.FileType;
                fileSystemWatcher.EnableRaisingEvents = true;
                fileSystemWatcher.SynchronizingObject = this;
                fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
                fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_Renamed);

                _fileSystemWatchers.Add(fileSystemWatcher);
            }

            frm.Dispose();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }

        private void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            _monitor.CreateEventHandler(e.FullPath);
        }

        private void fileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            _monitor.CreateEventHandler(e.FullPath);
        }
    }
}
