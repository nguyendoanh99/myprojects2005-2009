using System;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
	/// <summary>
	/// Summary description for DataProvider.
	/// </summary>
	public abstract class DataProvider
	{
		protected static string _connectionString;

		protected OleDbConnection connection;
		protected OleDbDataAdapter adapter;
		protected OleDbCommand command;

        public IList GetAll()
        {            
            DataTable dt = executeQuery("select * from " + GetTableName());
            return DataTableToList(dt);
            
        }
        public IList GetByProperties(List<string> lstKey, List<object> Values, List<bool> Exact)
        {
            DataTable dt = GetByPropertiesToDataTable(lstKey, Values, Exact);
            return DataTableToList(dt);
        }
        private IList DataTableToList(DataTable dt)
        {
            IList result = GetRelatedList();
            foreach (DataRow dr in dt.Rows)
            {
                result.Add(GetDataFromDataRow(dr));
            }
            return result;
        }
        protected abstract string GetTableName();
        protected abstract object GetDataFromDataRow(DataRow dr);
        // Lay List<> tuong ung voi lop DAO
        protected abstract IList GetRelatedList();

		public static string ConnectionString
		{
			get
			{
				return _connectionString;
			}
			set
			{
				_connectionString = value;
			}
		}
        public DataProvider()
        {
            connect();
        }
		public void connect()
		{
			connection = new OleDbConnection(ConnectionString);
			connection.Open();
		}

		public void disconnect()
		{
			connection.Close();
		}
        
/*
		public IDataReader executeQuery(string sqlString)
		{			
			command = new OleDbCommand(sqlString, connection);
			return command.ExecuteReader();			
		}
*/
        public DataTable executeQuery(string sqlString)
        {
            DataSet ds = new DataSet();
            adapter = new OleDbDataAdapter(sqlString, connection);
            adapter.Fill(ds);
            return ds.Tables[0];
        }

		public void executeNonQuery(string sqlString)
		{
			command = new OleDbCommand(sqlString, connection);
			command.ExecuteNonQuery();
		}

		public object executeScalar(string sqlString)
		{
			command = new OleDbCommand(sqlString, connection);
			return command.ExecuteScalar();
		}

        protected DataTable GetByPropertiesToDataTable(List<string> Keys, List<Object> Values, List<bool> Exact)
        {
            DataSet result = new DataSet();
            string strTableName = GetTableName(); // Tên của bảng liên quan
            StringBuilder strSQL = new StringBuilder("select * from ");
            strSQL.Append(strTableName);

            // Thêm các điều kiện tìm kiếm
            if (Keys.Count > 0)
            {
                strSQL.Append(" where ");
                for (int i = 0; i < Keys.Count; ++i)
                {
                    // So sánh chính xác
                    if (Exact[i] == true)
                    {
                        if (Values[i] is DateTime)
                            strSQL.Append("datediff('d'," + Keys[i] + " , ?)=0");
                        else
                            strSQL.Append(Keys[i] + "=?");
                    }
                    else
                    {
                        if (Values[i] is String) // Tìm kiếm chuỗi này có thuộc chuỗi kia hay kô
                        {
                            strSQL.Append(Keys[i] + " like ?");
                        }
                        else
                            if (Values[i] is DateTime)
                            {
                                strSQL.Append("datediff('d', ?," + Keys[i] + ")>=0");
                                strSQL.Append("datediff('d'," + Keys[i] + " , ?)>=0");
                            }
                            else // Tìm kiếm trong khoảng, dành cho dữ liệu có thể so sánh được
                            {
                                strSQL.Append("?<=" + Keys[i]);
                                strSQL.Append(" AND " + Keys[i] + "<=?");
                            }

                    }

                    if (i < Keys.Count - 1)
                        strSQL.Append(" AND ");
                }
            }

            // Assumes that connection is a valid OleDbConnection object.
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(strSQL.ToString(), connection);
            adapter.SelectCommand = cmd;

            // Đưa các giá trị tìm kiếm vào trong điều kiện tìm kiếm
            for (int i = 0; i < Keys.Count; ++i)
            {
                string str = "@" + Keys[i];
                OleDbType type = GetOleDbType(connection, strTableName, Keys[i]);

                // So sánh chính xác
                if (Exact[i] == true)
                    cmd.Parameters.Add(str, type).Value = Values[i];
                else
                {
                    if (Values[i] is String) // Tìm kiếm chuỗi này có thuộc chuỗi kia hay kô
                        cmd.Parameters.Add(str, type).Value = "%" + Values[i].ToString() + "%";
                    else // Tìm kiếm trong khoảng, dành cho dữ liệu có thể so sánh được
                    {
                        Array temp = Values[i] as Array;
                        cmd.Parameters.Add(str + "Min", type).Value = temp.GetValue(0);
                        cmd.Parameters.Add(str + "Max", type).Value = temp.GetValue(1);
                    }
                }
            }

            adapter.Fill(result, strTableName);
            return result.Tables[0];
        }
        // Cho biết kiểu dữ liệu 
        private OleDbType GetOleDbType(OleDbConnection cn, string Table, string Column)
        {
            DataTable dt = cn.GetOleDbSchemaTable(
                  OleDbSchemaGuid.Columns,
                  new object[] { null, null, Table, Column });
            return (OleDbType)dt.Rows[0][dt.Columns["DATA_TYPE"]];
        }
	}
}
