namespace Nonoe.ActionFolders.BusinessLogic.Core
{
    using System;
    using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

    [Export(".rb", typeof(IScriptLogic))]
    public class RubyScriptLogic : IScriptLogic
    {
        public Dictionary<string, string> GetPropertiesFromScript(string scriptLocation)
        {
            var properties = new Dictionary<string, string>();
            if (File.Exists(scriptLocation) && IsScriptProperlyFormatted(scriptLocation))
            {
                // The regular expression to find all properties needed to config the script
                const string Regexp = @"attr_accessor(\s*):(\s*)(\w*)";

                var regex = new Regex(Regexp);

                var fileInfo = File.ReadAllText(scriptLocation);

                var mc = regex.Matches(fileInfo);

                // Fill in the grid with the config values.
                foreach (Match match in mc)
                {
                    if (
                        match.Groups[0].Value.ToString(CultureInfo.InvariantCulture)
                                       .Substring(
                                           match.Groups[0].Value.ToString(CultureInfo.InvariantCulture)
                                                          .LastIndexOf(" ", System.StringComparison.Ordinal) + 2) ==
                        "jsonConfigs") continue;
                    string configName = match.Groups[0].Value.Substring(match.Groups[0].Value.ToString(CultureInfo.InvariantCulture).LastIndexOf(" ", System.StringComparison.Ordinal) + 2);
                    properties.Add(configName, "");
                }
            }
            return properties;
        }

        /// <summary>
        /// This method checks whether the appropriate script is properly formatted.
        /// It checks the 2 vital things the script should have.
        /// - class name Script
        /// - method named Run
        /// </summary>
        /// <param name="scriptLocation">The location of the script</param>
        /// <returns>True / False</returns>
        public bool IsScriptProperlyFormatted(string scriptLocation)
        {
            const string FindClassScript = @"(\w*)class Script(\s)(\w*)";
            const string FindMethodRun = @"(\w*)def(\s*)Run\((\w*)";
            var findClassScriptRegExp = new Regex(FindClassScript);
            var findMethodRunRegExp = new Regex(FindMethodRun);
            
            var fileInfo = File.ReadAllText(scriptLocation);

            var findClassScriptMatches = findClassScriptRegExp.Matches(fileInfo);
            var findMethodRunMatches = findMethodRunRegExp.Matches(fileInfo);

            return findClassScriptMatches.Count > 0 && findMethodRunMatches.Count > 0;
        }

        /// <summary>
        /// Returns the header description of the script.
        /// </summary>
        /// <param name="scriptLocation">Where is the file stored in the file system</param>
        /// <returns>The description of the script</returns>
        public string GetScriptDescription(string scriptLocation)
        {
            StringBuilder sb = new StringBuilder();
            var fileInfo = File.ReadAllText(scriptLocation);
            var lines = fileInfo.Split('\n');
            foreach (var line in lines)
            {
                if (line.Contains("class Script"))
                {
                    break;
                }

                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}
