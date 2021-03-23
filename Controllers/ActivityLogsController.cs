using ActivityLog.DataService;
using ActivityLog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using ActivityLog.GlobalEngine;

namespace ActivityLog.Controllers
{
    public class ActivityLogsController : Controller
    {
        ActivityLogs _oActivityLogs = new ActivityLogs();
        List<ActivityLogs> _oActivityLogss = new List<ActivityLogs>() { };
        ActivityLogsService _oActivityLogsService = new ActivityLogsService();

        public ActionResult ActivityLogsList(int nUserID, int nPageNumber = 1)
        {
            SessionObj oSessionobj = new SessionObj(Session);
            if (nPageNumber < 1) nPageNumber = 1;
            nPageNumber--;
            int nPerPageData = 100;
            _oActivityLogss = _oActivityLogsService.Gets("SELECT * from ActivityLog ORDER BY DBServerDateTime DESC OFFSET " + ((nPageNumber * nPerPageData)) + " ROWS FETCH NEXT " +  nPerPageData + " ROWS ONLY", 1);
            ViewBag.List = _oActivityLogss;
            ViewBag.PageNumber = ++nPageNumber;
            return View(_oActivityLogss);
        }
        public ActionResult ViewActivityLogs(int nID, int nUserID)
        {
            SessionObj oSessionobj = new SessionObj(Session);
            if (nID>0)
            {
                //_oActivityLogs = _oActivityLogsService.ge
            }
            else
            {
                _oActivityLogs = new ActivityLogs();
            }
            ActivityTable oActivityTable = new ActivityTable();
            List<ActivityTable> _oActivityTables = new List<ActivityTable>() { };
            ActivityTableService _oActivityTableService = new ActivityTableService();
            _oActivityTables = _oActivityTableService.Gets(nUserID);

            ViewBag.ActivityTables = _oActivityTables;
            return View();
        }
        public ActionResult ViewCommonWork(int nUserID)
        {
            SessionObj oSessionobj = new SessionObj(Session);
            CommonWork oCommonWork = new CommonWork();
            List<CommonWork> oCommonWorks = new List<CommonWork>();
            CommonWorkService oCommonWorkService = new CommonWorkService();
            oCommonWorks = oCommonWorkService.Gets(nUserID);
            ViewBag.CommonWorks = oCommonWorks;
            return View();
        }
        [HttpPost]
        public JsonResult GetsByTable(ActivityColumn objActivityColumn)
        {
            SessionObj oSessionobj = new SessionObj(Session);
            ActivityColumn oActivityColumn = new ActivityColumn();
            List<ActivityColumn> oActivityColumns = new List<ActivityColumn>();
            ActivityColumnService oActivityColumnService = new ActivityColumnService();

            oActivityColumns = oActivityColumnService.GetsByTable(objActivityColumn.TableName, 1);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(oActivityColumns);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Search(ActivityLogs objActivityLogs)
        {
            SessionObj oSessionobj = new SessionObj(Session);
            ActivityLogs oActivityLogs = new ActivityLogs();
            List<ActivityLogs> oActivityLogsList = new List<ActivityLogs>();
            ActivityLogsService oActivityLogsService = new ActivityLogsService();
            DataSet oDataSet = new DataSet();
            oDataSet = oActivityLogsService.GetDynamicObjectList(objActivityLogs.ErrorMessage,1);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(oDataSet.Tables[0]);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(JSONString);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateDatabaseTable(UpdateObject oUpdateObject)
        {
            SessionObj oSessionobj = new SessionObj(Session);
            string sFinalSP = "";
            string sTableName = oUpdateObject.TableName;
            string sSPName = "SP_ActivityLog";
            string sColNames = "";
            string sColValues = "";
            string sWhereClause = oUpdateObject.WhereClause;
            int nDBOperationID = oUpdateObject.DBOperationID;
            string sRemarks = oUpdateObject.Remarks;
            int nBranchID = 0;

            for (int i=0; i< oUpdateObject.ActivityColumns.Count();i++)
            {
                sColNames = sColNames + oUpdateObject.ActivityColumns[i].ColumnName + '#';
                sColValues = sColValues + oUpdateObject.ActivityColumns[i].ColumnData + '#';
            }
            if(nDBOperationID!=3)
            {
                sColNames = sColNames.Remove(sColNames.Length - 1, 1);
                sColValues = sColValues.Remove(sColValues.Length - 1, 1);
            }
            sFinalSP = "EXEC " + sSPName + " '" + sTableName + "', '" + sColNames + "', '" + sColValues + "', '" + sWhereClause + "', " + nBranchID + ", " + nDBOperationID + ", '" + sRemarks + "'";
            _oActivityLogs = new ActivityLogs();

            DataSet oDataSet = new DataSet();
            oDataSet = _oActivityLogsService.UpdateDatabaseTable(sFinalSP, 1);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(oDataSet.Tables[1]);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(JSONString);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult ExecCommonWork(CommonWork oCommonWork)
        {
            CommonWork objCommonWork = new CommonWork();
            CommonWorkService objCommonWorkService = new CommonWorkService();
            string sFeedBackMessage = objCommonWorkService.ExecCommonWork(oCommonWork, 1);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string sjson = serializer.Serialize(sFeedBackMessage);
            return Json(sjson, JsonRequestBehavior.AllowGet);
        }
    }
}