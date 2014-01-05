namespace Nonoe.ActionFolders.BusinessLogic.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;

    using Ionic.Zip;

    public class ScriptLogic
    {
        public void ExportScriptsToZipFile(string archiveName, Collection<string> fileNames)
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (var file in fileNames)
                {
                    zip.AddFile(Path.Combine(Environment.CurrentDirectory, "Scripts", file));                    
                }

                zip.Save(archiveName);
            }
        }

        /// <summary>The build script models.</summary>
        /// <returns>An enumerable collection of script models.</returns>
        public IEnumerable<ScriptModel> BuildScriptModels()
        {
            string[] files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "SCRIPTS"));
            foreach (string file in files.Where(x => x.EndsWith(".py") || x.EndsWith(".rb")))
            {
                IScriptLogic scriptLogic = ScriptLogicFactory.GetHandler(Path.GetExtension(file));
                string description = scriptLogic.GetScriptDescription(file);
                yield return new ScriptModel { ScriptName = Path.GetFileName(file), ScriptLocation = file, ScriptDescription = description };
            }
        }
    }
}