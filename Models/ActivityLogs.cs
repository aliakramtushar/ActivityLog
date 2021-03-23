using ActivityLog.GlobalEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivityLog.Models
{
    public class ActivityLogs
    {
        public ActivityLogs()
        {
            ActivityLogID = 0;
            TableName = "";
            ColNames = "";
            ColPreviousValues = "";
            ColNewValues = "";
            WhereClause = "";
            BranchID = 0;
            Remarks = "";
            DBOperationID = EnumDBOperation.None;
            DBServerDateTime = DateTime.MinValue;
            ErrorMessage = "";
        }
        #region Property
        public int ActivityLogID { get; set; }
        public string TableName { get; set; }
        public string ColNames { get; set; }
        public string ColPreviousValues { get; set; }
        public string ColNewValues { get; set; }
        public string WhereClause { get; set; }
        public int BranchID { get; set; }
        public EnumDBOperation DBOperationID { get; set; }
        public DateTime DBServerDateTime { get; set; }
        public string Remarks { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property
        public string DBOperationSt
        {
            get
            {
                return this.DBOperationID.ToString();
            }
        }
        public string DBServerDateTimeSt
        {
            get
            {
                return this.DBServerDateTime.ToString();
            }
        }

        #endregion
    }
    public interface IActivityLogs
    {
        List<ActivityLogs> Gets(int nUserID);
        List<ActivityLogs> Gets(string sSQL, int nUserID);
        DataSet GetDynamicObjectList(string sSQL, int nUserID);
        DataSet UpdateDatabaseTable(string sSQL, int nUnserID);
    }
}