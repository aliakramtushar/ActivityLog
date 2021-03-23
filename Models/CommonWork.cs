using ActivityLog.GlobalEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivityLog.Models
{
    public class CommonWork
    {
        public CommonWork()
        {
            CommonWorkID = 0;
            CommonWorkName = "";
            WhereCols = "";
            UpdateCols = "";
            Remarks = "";
            ErrorMessage = "";
            TypeID = 0;
            TypeName = "";
        }
        #region Property
        public int CommonWorkID { get; set; }
        public string CommonWorkName { get; set; }
        public string WhereCols { get; set; }
        public string UpdateCols { get; set; }
        public string Remarks { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property
        public string CommonWorkNameFullName {
            get
            {
                return this.CommonWorkName + '(' + this.TypeName + ')';
            }
        }


        #endregion
    }
    public interface ICommonWork
    {
        List<CommonWork> Gets(int nUserID);
        List<CommonWork> Gets(string sSQL, int nUserID);
        string ExecCommonWork(CommonWork oCommonWork, int nUserID);
    }
}