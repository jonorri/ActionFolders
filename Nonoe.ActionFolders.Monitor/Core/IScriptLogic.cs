// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScriptLogic.cs" company="Nonoe">
//   Jon Orri Kristjansson 22.01.2013
// </copyright>
// <summary>
//   The ScriptLogic interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nonoe.ActionFolders.BusinessLogic.Core
{
    using System.Collections.Generic;

    /// <summary>The ScriptLogic interface.</summary>
    public interface IScriptLogic
    {
        #region Public Methods and Operators

        /// <summary>Get's all properties needed to configure from the script.</summary>
        /// <param name="scriptLocation">The script location.</param>
        /// <returns>A dictionary of all the properties.</returns>
        Dictionary<string, string> GetPropertiesFromScript(string scriptLocation);

        /// <summary>Checks whether the script is properly formatted or not.</summary>
        /// <param name="scriptLocation">The script location.</param>
        /// <returns>True / False.</returns>
        bool IsScriptProperlyFormatted(string scriptLocation);

        /// <summary>
        /// Returns the header description of the script.
        /// </summary>
        /// <param name="scriptLocation">Where is the file stored in the file system</param>
        /// <returns>The description of the script</returns>
        string GetScriptDescription(string scriptLocation);

        #endregion
    }
}