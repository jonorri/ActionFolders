using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nonoe.ActionFolders.Runners
{
    public class ScriptEventArgs : EventArgs
    {
        public string ScriptLocation { get; set; }

        public ScriptEventArgs(string scriptLocation)
        {
            this.ScriptLocation = scriptLocation;
        }
    }
}
