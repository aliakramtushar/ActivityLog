using ActivityLog.GlobalEngine;
using ActivityLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityLog.DataAccess
{
    public class ActivityColumnDA
    {
        public static string Gets(int nUserID)
        {
            return "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
        }
        public static string GetsByTable(string sTableName, int nUser)
        {
            return "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + sTableName + "' ORDER BY ORDINAL_POSITION";     // For All Coulmn Including PK
            //return "SELECT * FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = '" + sTableName + "' AND COLUMN_NAME IN (SELECT column_name as COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME AND KU.table_name = '" + sTableName + "')";
        }
    }
}