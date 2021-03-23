using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityLog.GlobalEngine
{
    public class GlobalHelpers
    {
        public static string SessionConnectionString;
        public static string ExcecuteQurey(string StoreProcedure, params object[] param)
        {
            string args = "";
            foreach (var oitem in param)
            {
                args += oitem + "','";
            }
            args = args.Remove(args.LastIndexOf(","), 2);
            return StoreProcedure + " '" + args;
        }
    }
}