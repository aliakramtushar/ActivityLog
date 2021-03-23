using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityLog.GlobalEngine
{
    public class SessionObj
    {
        public static string ConnectionString;

        public SessionObj(HttpSessionStateBase session)
        {
            ConnectionString = session["ConnectionString"].ToString();
        }
    }
}