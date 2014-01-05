// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionFolderLogic.cs" company="">
//   
// </copyright>
// <summary>
//   The action folder logic.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Nonoe.ActionFolders.BusinessLogic.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using Nonoe.ActionFolders.DAL;
    using Nonoe.ActionFolders.Objects;
    using Nonoe.ActionFolders.Runners;

    /// <summary>
    ///     The action folder logic.
    /// </summary>
    public class ActionFolderLogic
    {
        /// <summary>
        ///     The action folder dal.
        /// </summary>
        private readonly ActionFolderDAL actionFolderDAL;

        /// <summary>
        ///     All ActionFolders the system is monitoring
        /// </summary>
        private BindingList<ActionFolder> actionFolders;

        /// <summary>
        /// The running script delegate
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="item">Action folder being run</param>
        /// <param name="running">Flag to indicate whether the script is being run or not</param>
        public delegate void RunningScript(object sender, ActionFolder item, bool running);

        /// <summary>
        /// The running script event
        /// </summary>
        public event RunningScript Running;

        public delegate void ScriptErrorOccured(object sender, string scriptLocation);

        public event ScriptErrorOccured ScriptError;

        /// <summary>
        /// The Failed script delegate
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="item">The action folder item that failed</param>
        public delegate void FailedScript(object sender, ActionFolder item);

        /// <summary>
        /// The failed script event
        /// </summary>
        public event FailedScript Failure;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActionFolderLogic" /> class.
        /// </summary>
        public ActionFolderLogic()
            : this(new ActionFolderDAL())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ActionFolderLogic"/> class.
        ///     Constructor</summary>
        /// <param name="mockActionFolderDAL">The mock Action Folder DAL.</param>
        private ActionFolderLogic(ActionFolderDAL mockActionFolderDAL)
        {
            this.actionFolderDAL = mockActionFolderDAL;
            this.ActionFolders = new BindingList<ActionFolder>(this.actionFolderDAL.GetAllActionFolders());

            // I have to create new fileSystemWatchers for all the action folders
            foreach (var actionFolder in this.ActionFolders)
            {
                if (!File.Exists(actionFolder.ScriptLocation) || !Directory.Exists(actionFolder.Folder))
                {
                    actionFolder.Active = false;
                    this.actionFolderDAL.UpdateActionFolder(actionFolder);
                }
                else
                {
                    // Create a new item
                    var tempFileSystemWatcher = new FileSystemWatcher { Path = actionFolder.Folder, Filter = actionFolder.FileType, EnableRaisingEvents = true };
                    tempFileSystemWatcher.Created += this.FileSystemWatcherCreated;
                    tempFileSystemWatcher.Renamed += this.FileSystemWatcherCreated;

                    actionFolder.FileSystemWatcher = tempFileSystemWatcher;
                }
            }
        }
 
        /// <summary>
        ///     Gets the action folders.
        /// </summary>
        public BindingList<ActionFolder> ActionFolders
        {
            get
            {
                return this.actionFolders;
            }

            private set
            {
                this.actionFolders = value;
            }
        }

        /// <summary>Adds an action folder both into the xml file and into the file system watching mechanism
        ///     This method removes an Action Folder if one currently exists for a path/file type combo.</summary>
        /// <param name="item">What item to add</param>
        public void AddActionFolder(ActionFolder item)
        {
            // Remove the item if it currently exists.
            ActionFolder existingItem = this.ActionFolders.FirstOrDefault(x => x.Folder == item.Folder && x.FileType == item.FileType);
            if (existingItem != null)
            {
                this.ActionFolders.Remove(existingItem);
            }

            // Create a new item
            var tempFileSystemWatcher = new FileSystemWatcher { Path = item.Folder, Filter = item.FileType, EnableRaisingEvents = true };
            tempFileSystemWatcher.Created += this.FileSystemWatcherCreated;
            tempFileSystemWatcher.Renamed += this.FileSystemWatcherCreated;

            item.FileSystemWatcher = tempFileSystemWatcher;

            // Add it into the watch of the system
            this.actionFolders.Add(item);

            // Also save down to the XML file
            this.actionFolderDAL.Insert(item);
        }

        /// <summary>Removes an action folder from the file system watcher.</summary>
        /// <param name="actionFolderId">Path to action folder</param>
        public void RemoveActionFolder(int actionFolderId)
        {
            // There should exist only one action folder for a given path/filetype combo.
            ActionFolder existingItem = this.ActionFolders.SingleOrDefault(x => x.Id == actionFolderId);
            if (existingItem == null)
            {
                return;
            }

            this.actionFolders.Remove(existingItem);
            this.actionFolderDAL.Delete(actionFolderId);
        }

        /// <summary>The event handler for all file system watchers.
        ///     It searches for the monitored item for the file that raised the event and runs the appropriate script</summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">File system event arguments</param>
        private void FileSystemWatcherCreated(object sender, FileSystemEventArgs e)
        {
            ActionFolder item =
                this.actionFolders.Single(
                    x =>
                    Path.GetExtension(x.FileType) == Path.GetExtension(e.FullPath)
                    && Path.GetDirectoryName(x.Folder) == Path.GetDirectoryName(e.FullPath)
                    && x.Active);

            this.Running(this, item, true);

            IScriptRunner runner = RunnerFactory.GetHandler(item.Type.ToString());
            runner.Error += RunnerError;
            runner.ScriptLocation = item.ScriptLocation;
            runner.FilePath = e.FullPath;
            runner.JsonConfigurations = item.JsonConfigs;
            runner.CreateEventHandler();

            this.Running(this, item, false);
        }

        private void RunnerError(object sender, System.EventArgs e)
        {
            var scriptEventArgs = (ScriptEventArgs)e;
            this.ScriptError(this, scriptEventArgs.ScriptLocation);
        }
    }
}