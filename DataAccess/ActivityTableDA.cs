using ActivityLog.GlobalEngine;
using ActivityLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityLog.DataAccess
{
    public class ActivityTableDA
    {
        public static string Gets(int nUserID)
        {
            return "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
        }
    }
}