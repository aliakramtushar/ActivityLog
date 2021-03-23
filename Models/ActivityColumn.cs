using ActivityLog.GlobalEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivityLog.Models
{
    public class ActivityColumn
    {
        public ActivityColumn()
        {
            ActivityColumnID = 0;
            ColumnName = "";
            DataType = "";
            TableName = "";
            TableSchema = "";
            TableCatalog = "";
            OrdinalPosition = 0;
            IsPrimaryKey = false;
            ErrorMessage = "";
        }
        #region Property
        public int ActivityColumnID { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string TableName { get; set; }
        public string TableSchema { get; set; }
        public string TableCatalog { get; set; }
        public int OrdinalPosition { get; set; }
        public bool IsPrimaryKey { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property
        public string ColumnData { get; set; }
        #endregion
    }
    public interface IActivityColumn
    {
        List<ActivityColumn> Gets(int nUserID);
        List<ActivityColumn> GetsByTable(string sTableName, int nUserID);
    }
}