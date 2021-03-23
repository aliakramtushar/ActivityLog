using ActivityLog.GlobalEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ActivityLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewLogin()
        {
            Session.Add("ConnectionString", "");
            SessionObj oSessionobj = new SessionObj(Session);
            return View();
        }


        [HttpPost]
        public JsonResult UserLogin(CommonGateway oCommonGateway)
        {
            if(oCommonGateway.UserID == "admin1")
            {
                Session.Add("ConnectionString", "Server=209.151.194.144,8494;Database=sms_activitylog_db;User ID=aliakramtushar;password=2sR01676555291;Integrated Security=false");
            }
            else if (oCommonGateway.UserID == "admin2")
            {
                Session.Add("ConnectionString", "Server=209.151.194.144,8494;Database=sms_chandpurelectric_db_test;User ID=aliakramtushar;password=2sR01676555291;Integrated Security=false");
            }
            else
            {
                string sTemp = "Server=" + oCommonGateway.Server + ";Database=" + oCommonGateway.Database + ";User ID=" + oCommonGateway.UserID + ";password=" + oCommonGateway.Password + ";Integrated Security=false";
                Session.Add("ConnectionString", sTemp);
            }
            SessionObj oSessionobj = new SessionObj(Session);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize("Successful");
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}