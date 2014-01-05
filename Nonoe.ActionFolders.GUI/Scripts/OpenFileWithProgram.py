# This script opens the file with any program.
# Configs are path to the executable of the program.
# The program has to accept the file as a command line parameter to work.

from System.Diagnostics import Process
class Script(object):
    def __init__(self, jsonConfigs):
       self._jsonConfigs = jsonConfigs

	# Every property is used as a config for the script
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