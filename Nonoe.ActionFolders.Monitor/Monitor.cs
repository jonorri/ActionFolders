using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Reflection;
using System.IO;
using Microsoft.Scripting.Utils;
using Microsoft.Scripting;

namespace Nonoe.ActionFolders.Base
{
    public class Monitor
    {
        Collection<MonitoredItem> _monitors;
        private ScriptEngine _pyEngine = null;
        private ScriptScope _pyScope = null;

        public Monitor()
        {
            _monitors = new Collection<MonitoredItem>();
            if (_pyEngine == null)
            {
                _pyEngine = Python.CreateEngine();
                _pyScope = _pyEngine.CreateScope();
            }
        }

        public void AddMonitoredItem(MonitoredItem monitoredItem)
        {
            _monitors.Add(monitoredItem);
        }

        public void CreateEventHandler(string filePath)
        {
            MonitoredItem item = _monitors.Where(x => Path.GetExtension(x.FileType) == Path.GetExtension(filePath) && Path.GetDirectoryName(x.Path) == Path.GetDirectoryName(filePath)).Single();

            var runtime = Python.CreateRuntime();
            dynamic test = runtime.UseFile(item.ScriptLocation);

            // The Python 'x' instance is called passing parameter dictionary
            var result = test.x.OpenFileInProgram(filePath, "C:/Program Files (x86)/Notepad++/notepad++.exe");
        }

        public Collection<MonitoredItem> Monitors
        {
            get { return _monitors; }
            set { _monitors = value; }
        }
    }
}
