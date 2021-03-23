using ActivityLog.DataAccess;
using ActivityLog.GlobalEngine;
using ActivityLog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivityLog.DataService
{
    public class CommonWorkService : CommonGateway, ICommonWork
    {
        #region Maping
        private CommonWork MapObject(SqlDataReader oReader)
        {
            CommonWork oCommonWork = new CommonWork();
            oCommonWork.CommonWorkID = (int)oReader["CommonWorkID"];
            oCommonWork.CommonWorkName = oReader["CommonWorkName"].ToString();
            oCommonWork.WhereCols = oReader["WhereCols"].ToString();
            oCommonWork.UpdateCols = oReader["UpdateCols"].ToString();
            oCommonWork.Remarks = oReader["Remarks"].ToString();
            oCommonWork.TypeID = (int)oReader["TypeID"];
            oCommonWork.TypeName = oReader["TypeName"].ToString();

            return oCommonWork;
        }
        private CommonWork MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            CommonWork oCommonWork = new CommonWork();
            oCommonWork = MapObject(oReader);
            return oCommonWork;
        }
        private List<CommonWork> MakeObjects(SqlDataReader oReader)
        {
            List<CommonWork> oCommonWorks = new List<CommonWork>();
            while (oReader.Read())
            {
                CommonWork oCommonWork = MapObject(oReader);
                oCommonWorks.Add(oCommonWork);
            }
            return oCommonWorks;
        }
        #endregion
        #region Function Implementation
        public List<CommonWork> Gets(int nUserID)
        {
            Connection.Open();
            Command.CommandText = CommonWorkDA.Gets(nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            CommonWork _oCommonWork = new CommonWork();
            List<CommonWork> _oCommonWorks = new List<CommonWork>();
            if (reader.HasRows)
            {
                _oCommonWorks = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oCommonWorks;
        }
        public List<CommonWork> Gets(string sSQL, int nUserID)
        {
            Connection.Open();
            Command.CommandText = CommonWorkDA.Gets(sSQL, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            CommonWork _oCommonWork = new CommonWork();
            List<CommonWork> _oCommonWorks = new List<CommonWork>();
            if (reader.HasRows)
            {
                _oCommonWorks = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oCommonWorks;
        }

        public string ExecCommonWork(CommonWork oCommonWork, int nUserID)
        {
            string sReturnMessage = "";
            Command.CommandText = CommonWorkDA.ExecCommonWork(oCommonWork, nUserID);
            SqlDataAdapter da = new SqlDataAdapter(Command.CommandText, Command.Connection);
            da.SelectCommand = Command;
            DataSet oDataSet = new DataSet();
            Connection.Open();
            try
            {
                da.Fill(oDataSet);
            }
            catch (Exception e)
            {
                sReturnMessage = e.Message.Split('~')[1];
            }
            Connection.Close();
            return sReturnMessage;
        }   
        #endregion
    }
}