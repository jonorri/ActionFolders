using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Nonoe.ActionFolders.Objects
{
    /// <summary>
    /// Action folder xml object
    /// </summary>
    [Serializable]
    [XmlRoot("ActionFolders")]
    public class ActionFolders
    {
        /// <summary>
        /// Keeps all ActionFolders in this XML
        /// </summary>
        [XmlArray("ActionFolder")]
        [XmlArrayItem("ActionFolder", typeof(ActionFolder))]
        public Collection<ActionFolder> ActionFolder { get; set; }
    }
}
