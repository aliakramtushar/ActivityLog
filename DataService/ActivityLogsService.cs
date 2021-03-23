using ActivityLog.DataAccess;
using ActivityLog.GlobalEngine;
using ActivityLog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivityLog.DataService
{
    public class ActivityLogsService: CommonGateway, IActivityLogs
    {
        #region Maping
        private ActivityLogs MapObject(SqlDataReader oReader)
        {
            ActivityLogs oActivityLogs = new ActivityLogs();
            oActivityLogs.ActivityLogID = (int)oReader["ActivityLogID"];
            oActivityLogs.TableName = oReader["TableName"].ToString();
            oActivityLogs.ColNames = oReader["ColNames"].ToString();
            oActivityLogs.ColPreviousValues = oReader["ColPreviousValues"].ToString();
            oActivityLogs.ColNewValues = oReader["ColNewValues"].ToString();
            oActivityLogs.WhereClause = oReader["WhereClause"].ToString();
            oActivityLogs.Remarks = oReader["Remarks"].ToString();
            oActivityLogs.BranchID = (int)oReader["BranchID"];
            oActivityLogs.DBOperationID = (EnumDBOperation)oReader["DBOperationID"];
            oActivityLogs.DBServerDateTime = (DateTime)oReader["DBServerDateTime"];

            return oActivityLogs;
        }
        private ActivityLogs MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            ActivityLogs oActivityLogs = new ActivityLogs();
            oActivityLogs = MapObject(oReader);
            return oActivityLogs;
        }
        private List<ActivityLogs> MakeObjects(SqlDataReader oReader)
        {
            List<ActivityLogs> oActivityLogss = new List<ActivityLogs>();
            while (oReader.Read())
            {
                ActivityLogs oActivityLogs = MapObject(oReader);
                oActivityLogss.Add(oActivityLogs);
            }
            return oActivityLogss;
        }
        #endregion
        #region Function Implementation
        public DataSet UpdateDatabaseTable(string sSQL, int nUserID)
        {
            Command.CommandText = ActivityLogsDA.GetDynamicObjectList(sSQL, nUserID);
            SqlDataAdapter da = new SqlDataAdapter(Command.CommandText, Command.Connection);
            da.SelectCommand = Command;
            DataSet oDataSet = new DataSet();

            Connection.Open();
            da.Fill(oDataSet);
            Connection.Close();

            return oDataSet;
        }
        public List<ActivityLogs> Gets(int nUserID)
        {
            Connection.Open();
            Command.CommandText = ActivityLogsDA.Gets(nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ActivityLogs _oActivityLogs = new ActivityLogs();
            List<ActivityLogs> _oActivityLogss = new List<ActivityLogs>();
            if (reader.HasRows)
            {
                _oActivityLogss = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oActivityLogss;
        }
        public List<ActivityLogs> Gets(string sSQL, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ActivityLogsDA.Gets(sSQL, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ActivityLogs _oActivityLogs = new ActivityLogs();
            List<ActivityLogs> _oActivityLogss = new List<ActivityLogs>();
            if (reader.HasRows)
            {
                _oActivityLogss = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oActivityLogss;
        }
        public DataSet GetDynamicObjectList(string sSQL, int nUserID)
        {
            Command.CommandText = ActivityLogsDA.GetDynamicObjectList(sSQL, nUserID);
            SqlDataAdapter da = new SqlDataAdapter(Command.CommandText, Command.Connection);
            da.SelectCommand = Command;
            DataSet oDataSet = new DataSet();

            Connection.Open();
            da.Fill(oDataSet);
            Connection.Close();

            return oDataSet;
        }
        #endregion
    }
}