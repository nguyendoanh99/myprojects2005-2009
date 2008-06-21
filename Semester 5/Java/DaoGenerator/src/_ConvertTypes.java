import java.sql.*;
import java.util.*;

public class _ConvertTypes {
	//**********************************************************
	// Attributes
	//**********************************************************
	private List mJDBCTypes;
	private List<String> mJavaTypes;
	private List<String> mResultSetFunc;
	private List<String> mPreparedStatementFunc;
	//**********************************************************
	// Private Functions
	//**********************************************************
	//	 Lay ham tuong ung voi kieu du lieu
	private String TypeToFunc(List type, List<String> Func, Object data_type)
	{
		String result;
		int index = type.indexOf(data_type);
		result = Func.get(index);
		return result;
	}
	//**********************************************************
	// Contructors
	//**********************************************************
	public _ConvertTypes()
	{	
		PreparedStatement pst;
		mJDBCTypes = new ArrayList();
		mJavaTypes = new ArrayList<String>();
		mResultSetFunc = new ArrayList<String>();
		mPreparedStatementFunc = new ArrayList<String>();
		
		mJDBCTypes.add(Types.BIGINT);
		mJavaTypes.add("long");
		mResultSetFunc.add("getLong(arg0)");
		mPreparedStatementFunc.add("setLong(arg0, arg1)");
		
		mJDBCTypes.add(Types.BINARY);
		mJavaTypes.add("byte[]");
		mResultSetFunc.add("getBytes(arg0)");
		mPreparedStatementFunc.add("setBytes(arg0, arg1)");

		mJDBCTypes.add(Types.BIT);
		mJavaTypes.add("boolean");
		mResultSetFunc.add("getBoolean(arg0)");
		mPreparedStatementFunc.add("setBoolean(arg0, arg1)");
		
		mJDBCTypes.add(Types.CHAR);
		mJavaTypes.add("String");
		mResultSetFunc.add("getString(arg0)");
		mPreparedStatementFunc.add("setString(arg0, arg1)");
		
		mJDBCTypes.add(Types.DECIMAL);
		mJavaTypes.add("java.math.BigDecimal");
		mResultSetFunc.add("getBigDecimal(arg0)");
		mPreparedStatementFunc.add("setBigDecimal(arg0, arg1)");
		
		mJDBCTypes.add(Types.DOUBLE);
		mJavaTypes.add("double");
		mResultSetFunc.add("getDouble(arg0)");
		mPreparedStatementFunc.add("setDouble(arg0, arg1)");
		
		mJDBCTypes.add(Types.FLOAT);
		mJavaTypes.add("double");
		mResultSetFunc.add("getDouble(arg0)");
		mPreparedStatementFunc.add("setDouble(arg0, arg1)");
		
		mJDBCTypes.add(Types.INTEGER);
		mJavaTypes.add("int");
		mResultSetFunc.add("getInt(arg0)");
		mPreparedStatementFunc.add("setInt(arg0, arg1)");
		
		mJDBCTypes.add(Types.LONGVARBINARY);
		mJavaTypes.add("byte[]");
		mResultSetFunc.add("getBytes(arg0)");
		mPreparedStatementFunc.add("setBytes(arg0, arg1)");
		
		mJDBCTypes.add(Types.LONGVARCHAR);
		mJavaTypes.add("String");
		mResultSetFunc.add("getString(arg0)");
		mPreparedStatementFunc.add("setString(arg0, arg1)");
		
		mJDBCTypes.add(Types.NUMERIC);
		mJavaTypes.add("java.math.BigDecimal");
		mResultSetFunc.add("getBigDecimal(arg0)");
		mPreparedStatementFunc.add("setBigDecimal(arg0, arg1)");
		
		mJDBCTypes.add(Types.REAL);
		mJavaTypes.add("float");
		mResultSetFunc.add("getFloat(arg0)");
		mPreparedStatementFunc.add("setFloat(arg0, arg1)");
		
		mJDBCTypes.add(Types.SMALLINT);
		mJavaTypes.add("short");
		mResultSetFunc.add("getShort(arg0)");
		mPreparedStatementFunc.add("setShort(arg0, arg1)");

		mJDBCTypes.add(Types.TIMESTAMP);
		mJavaTypes.add("java.sql.Timestamp");
		mResultSetFunc.add("getTimestamp(arg0)");
		mPreparedStatementFunc.add("setTimestamp(arg0, arg1)");
		
		mJDBCTypes.add(Types.VARBINARY);
		mJavaTypes.add("byte[]");
		mResultSetFunc.add("getBytes(arg0)");
		mPreparedStatementFunc.add("setBytes(arg0, arg1)");
		
		mJDBCTypes.add(Types.VARCHAR);
		mJavaTypes.add("String");
		mResultSetFunc.add("getString(arg0)");
		mPreparedStatementFunc.add("setString(arg0, arg1)");
		
		mJDBCTypes.add(Types.TINYINT);
		mJavaTypes.add("short");
		mResultSetFunc.add("getShort(arg0)");
		mPreparedStatementFunc.add("setShort(arg0, arg1)");
	}
	//	**********************************************************
	// Public Functions
	//**********************************************************
	public String JDBCToJavaType(int data_type)
	{
		String result = new String();
		int index = mJDBCTypes.indexOf(data_type);
		result = mJavaTypes.get(index);
		return result;
	}
	public int JavaToJDBCType(String data_type)
	{
		int result;
		int index = mJavaTypes.indexOf(data_type);
		result = Integer.parseInt(mJDBCTypes.get(index).toString());
		return result;
	}
	
	//	 Lay ham cua Entity class tuong ung voi kieu du lieu
	public String JavaTypeToResultFunc(String data_type)
	{
		return TypeToFunc(mJavaTypes, mResultSetFunc, data_type);
	}
	public String JDBCTypeToResultFunc(int data_type)
	{
		return TypeToFunc(mJDBCTypes, mResultSetFunc, data_type);
	}
	// Lay ham cua PreparedStatement tuong ung voi kieu du lieu 
	public String JavaTypeToPreparedFunc(String data_type)
	{
		return TypeToFunc(mJavaTypes, mPreparedStatementFunc, data_type);
	}
	public String JDBCTypeToPreparedFunc(int data_type)
	{
		return TypeToFunc(mJDBCTypes, mPreparedStatementFunc, data_type);
	}
}