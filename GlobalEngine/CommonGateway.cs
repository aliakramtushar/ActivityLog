using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ActivityLog.GlobalEngine
{
    public class CommonGateway
    {
        //private string ConnectionString = "Server=204.93.178.181;Database=smsbd_smartmanagementsystem;User ID=smsbd_akram;password=welt12#;Integrated Security=false";
        //private string ConnectionString = "Server=EG-CSMDB-01;Database=CSMDB;User ID=ali.akram;password=Akram@mobicsm;Integrated Security=false";

        public string Server { get; set; }
        public string Database { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public bool IntegratedSecurity { get; set; }

        public string ConnectionString
        {
            get
            {
                return "Server=" + this.Server + ";Database=" + this.Database + ";User ID=" + this.UserID + ";password=" + this.Password + ";Integrated Security=false";
            }
        }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public CommonGateway()
        {
            Connection = new SqlConnection(SessionObj.ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }

    }
}