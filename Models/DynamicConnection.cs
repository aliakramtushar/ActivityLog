using ActivityLog.GlobalEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivityLog.Models
{
    public class DynamicConnection
    {
        public DynamicConnection(string sServer, string sDatabase, string sUserID, string sPassword, bool bIntegratedSecurity)
        {
            Server = sServer;
            Database = sDatabase;
            UserID = sUserID;
            Password = sPassword;
            IntegratedSecurity = bIntegratedSecurity;
        }
        #region Property
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public bool IntegratedSecurity { get; set; }
        #endregion

        #region Derived Property
        public string ConnectionString
        {
            get
            {
                return "Server=" + this.Server + ";Database=" + this.Database + ";User ID=" + this.UserID + ";password=" + this.Password + ";Integrated Security=" + this.IntegratedSecurity + "";
            }
        }

        #endregion
    }
}