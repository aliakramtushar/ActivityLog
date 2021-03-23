using ActivityLog.GlobalEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivityLog.Models
{
    public class UpdateObject
    {
        public UpdateObject()
        {
            UpdateObjectID = 0;
            TableName = "";
            ActivityColumns = new List<ActivityColumn>();
            WhereClause = "";
            SPName = "";
            UserID = 0;
            DBOperationID = 2;
            ErrorMessage = "";
        }
        #region Property
        public int UpdateObjectID { get; set; }
        public string TableName { get; set; }
        public List<ActivityColumn> ActivityColumns { get; set; }
        public string WhereClause { get; set; }
        public string SPName { get; set; }
        public int UserID { get; set; }
        public string Remarks { get; set; }
        public int DBOperationID { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property

        #endregion
    }
}