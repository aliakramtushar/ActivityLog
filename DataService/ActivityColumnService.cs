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
    public class ActivityColumnService : CommonGateway, IActivityColumn
    {
        #region Maping
        private ActivityColumn MapObject(SqlDataReader oReader)
        {
            ActivityColumn oActivityColumn = new ActivityColumn();
            oActivityColumn.ColumnName = oReader["COLUMN_NAME"].ToString();
            oActivityColumn.DataType = oReader["DATA_TYPE"].ToString();
            oActivityColumn.TableName = oReader["TABLE_NAME"].ToString();
            oActivityColumn.TableSchema = oReader["TABLE_SCHEMA"].ToString();
            oActivityColumn.TableCatalog = oReader["TABLE_CATALOG"].ToString();
            oActivityColumn.OrdinalPosition = (int)oReader["ORDINAL_POSITION"];
            return oActivityColumn;
        }
        private ActivityColumn MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            ActivityColumn oActivityColumn = new ActivityColumn();
            oActivityColumn = MapObject(oReader);
            return oActivityColumn;
        }
        private List<ActivityColumn> MakeObjects(SqlDataReader oReader)
        {
            List<ActivityColumn> oActivityColumns = new List<ActivityColumn>();
            while (oReader.Read())
            {
                ActivityColumn oActivityColumn = MapObject(oReader);
                oActivityColumns.Add(oActivityColumn);
            }
            return oActivityColumns;
        }
        #endregion
        #region Function Implementation

        public List<ActivityColumn> Gets(int nUserID)
        {
            Connection.Open();
            Command.CommandText = ActivityColumnDA.Gets(nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ActivityColumn _oActivityColumn = new ActivityColumn();
            List<ActivityColumn> _oActivityColumns = new List<ActivityColumn>();
            if (reader.HasRows)
            {
                _oActivityColumns = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oActivityColumns;
        }
        public List<ActivityColumn> GetsByTable(string sTableNameint, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ActivityColumnDA.GetsByTable(sTableNameint, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            ActivityColumn _oActivityColumn = new ActivityColumn();
            List<ActivityColumn> _oActivityColumns = new List<ActivityColumn>();
            if (reader.HasRows)
            {
                _oActivityColumns = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oActivityColumns;
        }


        #endregion
    }
}