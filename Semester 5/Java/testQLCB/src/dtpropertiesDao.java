import java.sql.*;
import java.util.*;

public class dtpropertiesDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<dtproperties> getList(ResultSet rs)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			while (rs.next())
			{
				dtproperties temp = new dtproperties();
				int _id = rs.getInt("id");
				int _objectid = rs.getInt("objectid");
				String _property = rs.getString("property");
				String _value = rs.getString("value");
				String _uvalue = rs.getString("uvalue");
				byte[] _lvalue = rs.getBytes("lvalue");
				int _version = rs.getInt("version");
				temp.setid(_id);
				temp.setobjectid(_objectid);
				temp.setproperty(_property);
				temp.setvalue(_value);
				temp.setuvalue(_uvalue);
				temp.setlvalue(_lvalue);
				temp.setversion(_version);
				result.add(temp);
			}
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}
	public String ConnectDatabase(String database, String username, String password)
	{
		String result = new String();
		mDatabase = database;

		try
		{
			Class.forName("com.microsoft.jdbc.sqlserver.SQLServerDriver");
			mConnection = DriverManager.getConnection
			("jdbc:microsoft:sqlserver://localhost:1433", username, password);
			mConnection.setCatalog(mDatabase);
		}
		catch (SQLException e)
		{
			result += e.toString();
		}
		catch (ClassNotFoundException e)
		{
			result += e.toString();
		}

		return result;
	}
	public dtpropertiesDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public dtproperties getByID(int _id, String _property)
	{
		dtproperties result = new dtproperties();
		try
		{
			String sql = "select * from dtproperties where id=? and property=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, _id);
			pst.setString(2, _property);
			ResultSet rs = pst.executeQuery();
			List<dtproperties> lst = getList(rs);
			if (lst.size() == 0)
				result = null;
			else
				result = lst.get(0);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getByid(int _id)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties where id=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, _id);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getByobjectid(int _objectid)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties where objectid=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, _objectid);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getByproperty(String _property)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties where property=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _property);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getByvalue(String _value)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties where value=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _value);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getByuvalue(String _uvalue)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties where uvalue=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _uvalue);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getBylvalue(byte[] _lvalue)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties where lvalue=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBytes(1, _lvalue);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getByversion(int _version)
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties where version=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, _version);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<dtproperties> getAll()
	{
		List<dtproperties> result = new ArrayList<dtproperties>();
		try
		{
			String sql = "select * from dtproperties";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public boolean Insert(dtproperties obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into dtproperties(id, objectid, property, value, uvalue, lvalue, version) values (?, ?, ?, ?, ?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, obj.getid());
			pst.setInt(2, obj.getobjectid());
			pst.setString(3, obj.getproperty());
			pst.setString(4, obj.getvalue());
			pst.setString(5, obj.getuvalue());
			pst.setBytes(6, obj.getlvalue());
			pst.setInt(7, obj.getversion());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(dtproperties obj)
	{
		boolean result = false;
		try
		{
			String sql = "update dtproperties set id = ?, objectid = ?, property = ?, value = ?, uvalue = ?, lvalue = ?, version = ? where id = ? and property = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, obj.getid());
			pst.setInt(2, obj.getobjectid());
			pst.setString(3, obj.getproperty());
			pst.setString(4, obj.getvalue());
			pst.setString(5, obj.getuvalue());
			pst.setBytes(6, obj.getlvalue());
			pst.setInt(7, obj.getversion());
			pst.setInt(8, obj.getid());
			pst.setString(9, obj.getproperty());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}
}
