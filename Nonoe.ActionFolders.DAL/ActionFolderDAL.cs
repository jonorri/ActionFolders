// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionFolderDAL.cs" company="Nonoe">
//   Copyright JOK 2013
// </copyright>
// <summary>
//   Action Folder Data Access Layer
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Nonoe.ActionFolders.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SQLite;
    using System.Linq;

    using Nonoe.ActionFolders.Objects;

    /// <summary>
    ///     Action Folder Data Access Layer
    /// </summary>
    public class ActionFolderDAL
    {
        #region Fields

        /// <summary>The dataset.</summary>
        private readonly DataSet ds = new DataSet();

        /// <summary>The SQLite data adapter.</summary>
        private SQLiteDataAdapter db;

        /// <summary>The SQL command</summary>
        private SQLiteCommand sqlCmd;

        /// <summary>The SQL connection.</summary>
        private SQLiteConnection sqlCon;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ActionFolderDAL"/> class.</summary>
        public ActionFolderDAL()
        {
            const string TxtSQLQuery =
                "CREATE TABLE IF NOT EXISTS actionFolders(" + "Id INTEGER PRIMARY KEY AUTOINCREMENT," + "Folder ,"
                + "FileType ," + "ScriptLocation ," + "JsonConfigs ," + "Type ," + "Active" + ");";
            this.ExecuteQuery(TxtSQLQuery);
            this.SetupDefaultHandlers();
        }

        #endregion

        #region Properties

        /// <summary>Gets the connection string.</summary>
        private static string ConnectionString
        {
            get
            {
                return "Data Source=" + ConfigurationManager.AppSettings["Nonoe.ActionFolders.ActionFoldersPath"] + ";Version=3;New=False;Compress=True;";
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Deletes an action folder by id</summary>
        /// <param name="actionFolderId"></param>
        public void Delete(int actionFolderId)
        {
            string txtSQLQuery = "delete from actionFolders where ID = " + actionFolderId;
            this.ExecuteQuery(txtSQLQuery);
        }

        /// <summary>Gets an action folder item by id</summary>
        /// <param name="actionFolderId">ActionFolderId</param>
        /// <returns>The <see cref="ActionFolder"/>.</returns>
        public ActionFolder GetActionFolder(int actionFolderId)
        {
            using (this.sqlCon = new SQLiteConnection(ConnectionString))
            {
                this.sqlCon.Open();
                using (this.sqlCmd = this.sqlCon.CreateCommand())
                {
                    string commandText = "select Id, Folder, FileType, ScriptLocation, JsonConfigs, Type, Active from actionFolders where actionFolders = " + actionFolderId;
                    this.db = new SQLiteDataAdapter(commandText, this.sqlCon);
                    this.ds.Reset();
                    this.db.Fill(this.ds);
                }
            }

            return this.ds.Tables[0].AsEnumerable().Select(ConvertToActionFolder).ToList().FirstOrDefault();
        }

        /// <summary>
        ///     Gets all ActionFolders
        /// </summary>
        /// <returns>A collection of ActionFolder</returns>
        public IList<ActionFolder> GetAllActionFolders()
        {
            using (this.sqlCon = new SQLiteConnection(ConnectionString))
            {
                this.sqlCon.Open();
                using (this.sqlCmd = this.sqlCon.CreateCommand())
                {
                    const string CommandText = "select Id, Folder, FileType, ScriptLocation, JsonConfigs, Type, Active from actionFolders";
                    this.db = new SQLiteDataAdapter(CommandText, this.sqlCon);
                    this.ds.Reset();
                    this.db.Fill(this.ds);
                }
            }

            return this.ds.Tables[0].AsEnumerable().Select(ConvertToActionFolder).ToList();
        }

        /// <summary>Creates an action folder</summary>
        /// <param name="item">Action folder item to create</param>
        public void Insert(ActionFolder item)
        {
            string txtSQLQuery =
                "insert into actionFolders (Folder, FileType, ScriptLocation, JsonConfigs, Type, Active) values ('"
                + item.Folder + "', '" + item.FileType + "', '" + item.ScriptLocation + "', '" + item.JsonConfigs
                + "', '" + item.Type + "', '" + item.Active + "')";
            this.ExecuteQuery(txtSQLQuery);
        }

        /// <summary>
        ///     This method sets up the default handlers of the system.
        ///     The only handler that is default by now is the IsServiceUp handler.
        /// </summary>
        public void SetupDefaultHandlers()
        {
            using (this.sqlCon = new SQLiteConnection(ConnectionString))
            {
                this.sqlCon.Open();
                using (this.sqlCmd = this.sqlCon.CreateCommand())
                {
                    const string CommandText = "select Id, Folder, FileType, ScriptLocation, JsonConfigs, Type, Active from actionFolders where ScriptLocation LIKE '%IsServiceUp.rb%'";
                    this.db = new SQLiteDataAdapter(CommandText, this.sqlCon);
                    this.ds.Reset();
                    this.db.Fill(this.ds);
                }
            }

            ActionFolder item = this.ds.Tables[0].AsEnumerable().Select(ConvertToActionFolder).ToList().FirstOrDefault();

            if (item != null)
            {
                return;
            }

            const string TxtSQLQuery = "INSERT INTO actionFolders (Folder, FileType, ScriptLocation, JsonConfigs, Type, Active) VALUES ('c:/temp/', '*.txt', 'Scripts/IsServiceUp.rb', '', 'Ruby', 'true')";
            this.ExecuteQuery(TxtSQLQuery);
        }

        /// <summary>Update an action folder</summary>
        /// <param name="item">Item to update</param>
        /// <returns>The <see cref="IList"/>.</returns>
        public void UpdateActionFolder(ActionFolder item)
        {
            string txtSQLQuery = "update actionFolders set " + 
                                 "Folder = '" + item.Folder + "'," + "FileType = '" + item.FileType + "',"
                                 + "ScriptLocation = '" + item.ScriptLocation + "'," + "JsonConfigs = '" + item.JsonConfigs
                                 + "'," + "Type = '" + item.Type + "'," + "Active = '" + item.Active + "' where Id = "
                                 + item.Id;
            this.ExecuteQuery(txtSQLQuery);
        }

        #endregion

        #region Methods

        /// <summary>The convert data row to action folder.</summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns>The <see cref="ActionFolder"/>.</returns>
        private static ActionFolder ConvertToActionFolder(DataRow dataRow)
        {
            return new ActionFolder
            {
                Id = int.Parse(dataRow["Id"].ToString()),
                Active = bool.Parse(dataRow["Active"].ToString()),
                FileType = dataRow["FileType"].ToString(),
                Folder = dataRow["Folder"].ToString(),
                JsonConfigs = dataRow["JsonConfigs"].ToString(),
                ScriptLocation = dataRow["ScriptLocation"].ToString(),
                Type = (RunnerType)Enum.Parse(typeof(RunnerType), dataRow["Type"].ToString())
            };
        }

        /// <summary>The execute query method.</summary>
        /// <param name="txtQuery">The query.</param>
        private void ExecuteQuery(string txtQuery)
        {
            using (this.sqlCon = new SQLiteConnection(ConnectionString))
            {
                this.sqlCon.Open();
                using (this.sqlCmd = this.sqlCon.CreateCommand())
                {
                    this.sqlCmd.CommandText = txtQuery;
                    this.sqlCmd.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}