using System.Collections.Generic;
using System.IO;

namespace Nonoe.ActionFolders.Objects
{
    /// <summary>
    /// Action folder object
    /// </summary>
    public class ActionFolder
    {
        /// <summary>
        /// Identity field
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// What folder to watch out for
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// What file extension to watch out for
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// Points to the scripts location
        /// </summary>
        public string ScriptLocation { get; set; }

        /// <summary>
        /// Stores the config for the script in json format
        /// </summary>
        public string JsonConfigs { get; set; }

        /// <summary>
        /// Declares which type of script runner needs to be used
        /// </summary>
        public RunnerType Type { get; set; }

        /// <summary>
        /// Declares whether the ActionFolder is active or not
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Stores the FileSystemWatcher of the ActionFolder
        /// </summary>
        public FileSystemWatcher FileSystemWatcher { get; set; }

        /// <summary>
        /// Stores the config for the script
        /// </summary>
        public Dictionary<string, string> Configs { get {

            return null;
        } }
    }
}
