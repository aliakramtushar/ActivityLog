using ActivityLog.GlobalEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivityLog.Models
{
    public class ActivityTable
    {
        public ActivityTable()
        {
            ActivityTableID = 0;
            TableName = "";
            TableType = "";
            TableSchema = "";
            TableCatalog = "";
            ErrorMessage = "";
        }
        #region Property
        public int ActivityTableID { get; set; }
        public string TableName { get; set; }
        public string TableType { get; set; }
        public string TableSchema { get; set; }
        public string TableCatalog { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property

        #endregion
    }
    public interface IActivityTable
    {
        List<ActivityTable> Gets(int nUserID);
    }
}