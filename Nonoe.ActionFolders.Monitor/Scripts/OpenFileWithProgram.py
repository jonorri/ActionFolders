from System.Diagnostics import Process
import re

class Expression(object):
    @property
    def programPath(self):
        p = re.compile('"programPath":"[a-zA-Z0-9:/.()\s]*"')
        self._jsonConfigs = self._jsonConfigs.replace("\\", "/")
        self._jsonConfigs = self._jsonConfigs.replace("//", "/")
        outcome = p.search(self._jsonConfigs)
        return outcome.group(0)[15:-1]

    @property
    def jsonConfigs(self):
        return self._jsonConfigs
    @jsonConfigs.setter
    def jsonConfigs(self, value):
        self._jsonConfigs = value

    def Runner(self, filename):
        p = Process()
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.FileName = self.programPath
        p.StartInfo.Arguments = "\"" + filename.replace("\\", "/") + "\""
        p.Start()

# Class 'Expression' instantiation
x = Expression()
#x.jsonConfigs = '{\"programPath\":\"C:\\\\Program Files (x86)\\\\uTorrent\\\\uTorrent.exe\"}'
#x.Runner('C:\\Users\\jonorri\\Dropbox\\torrent\\1 - Copy.torrent')
#raw_input("Press Enter to continue.....")