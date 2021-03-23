using ActivityLog.GlobalEngine;
using ActivityLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityLog.DataAccess
{
    public class CommonWorkDA
    {
        public static string ExecCommonWork(CommonWork oCommonWork, int nUserID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_CommonWork", oCommonWork.CommonWorkID, oCommonWork.CommonWorkName, oCommonWork.UpdateCols, nUserID);
        }
        public static string Gets(int nUserID)
        {
            return "SELECT * FROM CommonWork";
        }
        public static string Gets(string sSQL, int nUserID)
        {
            return sSQL;
        }
    }
}