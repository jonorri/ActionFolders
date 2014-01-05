namespace Nonoe.ActionFolders.Runners
{
    using System;

    public interface IScriptRunner
    {
        event EventHandler Error;

        string ScriptLocation { get; set; }
        string FilePath { get; set; }
        string JsonConfigurations { get; set; }

        void CreateEventHandler();
    }
}
