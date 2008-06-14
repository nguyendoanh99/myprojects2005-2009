import java.sql.*;
import java.util.*;

public class DATCHODao
{
	private String mDatabase;
	private Connection mConnection;

	private List<DATCHO> getList(ResultSet rs)
	{
		List<DATCHO> result = new ArrayList<DATCHO>();
		try
		{
			while (rs.next())
			{
				DATCHO temp = new DATCHO();
				String _MAKH = rs.getString("MAKH");
				java.sql.Timestamp _NGAYDI = rs.getTimestamp("NGAYDI");
				String _MACB = rs.getString("MACB");
				temp.setMAKH(_MAKH);
				temp.setNGAYDI(_NGAYDI);
				temp.setMACB(_MACB);
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
	public DATCHODao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public DATCHO getByID(String _MAKH, java.sql.Timestamp _NGAYDI, String _MACB)
	{
		DATCHO result = new DATCHO();
		try
		{
			String sql = "select * from DATCHO where MAKH=? and NGAYDI=? and MACB=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MAKH);
			pst.setTimestamp(2, _NGAYDI);
			pst.setString(3, _MACB);
			ResultSet rs = pst.executeQuery();
			List<DATCHO> lst = getList(rs);
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

	public List<DATCHO> getByMAKH(String _MAKH)
	{
		List<DATCHO> result = new ArrayList<DATCHO>();
		try
		{
			String sql = "select * from DATCHO where MAKH=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MAKH);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<DATCHO> getByNGAYDI(java.sql.Timestamp _NGAYDI)
	{
		List<DATCHO> result = new ArrayList<DATCHO>();
		try
		{
			String sql = "select * from DATCHO where NGAYDI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, _NGAYDI);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<DATCHO> getByMACB(String _MACB)
	{
		List<DATCHO> result = new ArrayList<DATCHO>();
		try
		{
			String sql = "select * from DATCHO where MACB=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MACB);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<DATCHO> getAll()
	{
		List<DATCHO> result = new ArrayList<DATCHO>();
		try
		{
			String sql = "select * from DATCHO";
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

	public boolean Insert(DATCHO obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into DATCHO(MAKH, NGAYDI, MACB) values (?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMAKH());
			pst.setTimestamp(2, obj.getNGAYDI());
			pst.setString(3, obj.getMACB());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(DATCHO obj)
	{
		boolean result = false;
		try
		{
			String sql = "update DATCHO set MAKH = ?, NGAYDI = ?, MACB = ? where MAKH = ? and NGAYDI = ? and MACB = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMAKH());
			pst.setTimestamp(2, obj.getNGAYDI());
			pst.setString(3, obj.getMACB());
			pst.setString(4, obj.getMAKH());
			pst.setTimestamp(5, obj.getNGAYDI());
			pst.setString(6, obj.getMACB());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}
}
