using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nonoe.ActionFolders.DAL;
using Nonoe.ActionFolders.Objects;

// ReSharper disable CheckNamespace
namespace Nonoe.ActionFolders.Tests
// ReSharper restore CheckNamespace
{
    [TestClass]
    public class ActionFolderDalTest
    {
        private static ActionFolderDAL actionFolderDAL;

        [ClassInitialize]
        public static void ClassInitialize(TestContext textContext)
        {
            actionFolderDAL = new ActionFolderDAL();
        }

       [TestMethod]
       public void TestAddActionFolder()
       {
           int countBefore = actionFolderDAL.GetAllActionFolders().Count;

           actionFolderDAL.Insert(new ActionFolder { Folder = CreateRandomPath(), FileType = "*.txt", ScriptLocation = "", FileSystemWatcher = null, JsonConfigs = "", Type = RunnerType.Python });

           int countAfter = actionFolderDAL.GetAllActionFolders().Count;

           Assert.IsTrue(countBefore + 1 == countAfter, "The counts doesn't match");
       }

       [TestMethod]
       public void TestRemoveActionFolder()
       {
           IList<ActionFolder> folders = actionFolderDAL.GetAllActionFolders();
           int countBefore = folders.Count;
           actionFolderDAL.Delete(folders.First().Id);

           int countAfter = actionFolderDAL.GetAllActionFolders().Count;
 
           Assert.IsTrue(countBefore - 1 == countAfter, "The counts do not match");
       }

       [TestMethod]
       public void TestUpdateActionFolder()
       {
           TestAddActionFolder();
           IList<ActionFolder> folders = actionFolderDAL.GetAllActionFolders();
           ActionFolder itemToUpdate = folders.First();
           itemToUpdate.FileType = "*.torrent";
           actionFolderDAL.UpdateActionFolder(itemToUpdate);
           itemToUpdate = actionFolderDAL.GetActionFolder(itemToUpdate.Id);
           Assert.IsTrue(itemToUpdate.FileType == "*.torrent", "The update statement didn't stick");
       }

       public static string CreateRandomPath()
       {
           return "c:\\temp\\" + DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture) + "\\";
       }
    }
}
