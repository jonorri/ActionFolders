from System.Diagnostics import Process
import re

class Expression(object):
    @property
    def programPath(self):
		return self._jsonConfigs["programPath"]

    # A property that holds all the config's needed to run this script
    @property
    def jsonConfigs(self):
        return self._jsonConfigs
    @jsonConfigs.setter
    def jsonConfigs(self, value):
        self._jsonConfigs = value

    # The function the C# code calls.
    def Runner(self, filename):
        p = Process()
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.FileName = self.programPath
        p.StartInfo.Arguments = "\"" + filename.replace("\\", "/") + "\""
        p.Start()

# Class 'Expression' instantiation
x = Expression()