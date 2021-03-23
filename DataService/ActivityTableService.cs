using ActivityLog.DataAccess;
using ActivityLog.GlobalEngine;
using ActivityLog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivityLog.DataService
{
    public class ActivityTableService : CommonGateway, IActivityTable
    {
        #region Maping
        private ActivityTable MapObject(SqlDataReader oReader)
        {
            ActivityTable oActivityTable = new ActivityTable();
            //oActivityTable.ActivityTableID = (int)oReader["ActivityTableID"];
            oActivityTable.TableName = oReader["TABLE_NAME"].ToString();
            oActivityTable.TableType = oReader["TABLE_TYPE"].ToString();
            oActivityTable.TableSchema = oReader["TABLE_SCHEMA"].ToString();
            oActivityTable.TableCatalog = oReader["TABLE_CATALOG"].ToString();
            return oActivityTable;
        }
        private ActivityTable MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            ActivityTable oActivityTable = new ActivityTable();
            oActivityTable = MapObject(oReader);
            return oActivityTable;
        }
        private List<ActivityTable> MakeObjects(SqlDataReader oReader)
        {
            List<ActivityTable> oActivityTables = new List<ActivityTable>();
            while (oReader.Read())
            {
                ActivityTable oActivityTable = MapObject(oReader);
                oActivityTables.Add(oActivityTable);
            }
            return oActivityTables;
        }
        #endregion
        #region Function Implementation
       
        public List<ActivityTable> Gets(int nUserID)
        {
            Connection.Open();
            Command.CommandText = ActivityTableDA.Gets(nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ActivityTable _oActivityTable = new ActivityTable();
            List<ActivityTable> _oActivityTables = new List<ActivityTable>();
            if (reader.HasRows)
            {
                _oActivityTables = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oActivityTables;
        }

        
        #endregion
    }
}