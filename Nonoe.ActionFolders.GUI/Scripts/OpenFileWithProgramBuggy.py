from System.Diagnostics import Process
class Script(object):
    def __init__(self, jsonConfigs):
       self._jsonConfigs = jsonConfigs
    @property
    def programPath(self):
        return self._jsonConfigs["programPath"]
	
    # The function the C# code calls.
    def Run(self, filename):
        p = Process()
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.FileName = self.programPath
        p.StartInfo.Arguments = "\"" + filename.replace("\\", "/") + "\""
        p.Start()