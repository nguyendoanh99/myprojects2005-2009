import java.sql.*;
import java.util.*;

public class PHANCONGDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<PHANCONG> getList(ResultSet rs)
	{
		List<PHANCONG> result = new ArrayList<PHANCONG>();
		try
		{
			while (rs.next())
			{
				PHANCONG temp = new PHANCONG();
				String _MANV = rs.getString("MANV");
				java.sql.Timestamp _NGAYDI = rs.getTimestamp("NGAYDI");
				String _MACB = rs.getString("MACB");
				temp.setMANV(_MANV);
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
	public PHANCONGDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public PHANCONG getByID(String _MANV, java.sql.Timestamp _NGAYDI, String _MACB)
	{
		PHANCONG result = new PHANCONG();
		try
		{
			String sql = "select * from PHANCONG where MANV=? and NGAYDI=? and MACB=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MANV);
			pst.setTimestamp(2, _NGAYDI);
			pst.setString(3, _MACB);
			ResultSet rs = pst.executeQuery();
			List<PHANCONG> lst = getList(rs);
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

	public List<PHANCONG> getByMANV(String _MANV)
	{
		List<PHANCONG> result = new ArrayList<PHANCONG>();
		try
		{
			String sql = "select * from PHANCONG where MANV=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MANV);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<PHANCONG> getByNGAYDI(java.sql.Timestamp _NGAYDI)
	{
		List<PHANCONG> result = new ArrayList<PHANCONG>();
		try
		{
			String sql = "select * from PHANCONG where NGAYDI=?";
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

	public List<PHANCONG> getByMACB(String _MACB)
	{
		List<PHANCONG> result = new ArrayList<PHANCONG>();
		try
		{
			String sql = "select * from PHANCONG where MACB=?";
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

	public List<PHANCONG> getAll()
	{
		List<PHANCONG> result = new ArrayList<PHANCONG>();
		try
		{
			String sql = "select * from PHANCONG";
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

	public boolean Insert(PHANCONG obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into PHANCONG(MANV, NGAYDI, MACB) values (?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMANV());
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

	public boolean Update(PHANCONG obj)
	{
		boolean result = false;
		try
		{
			String sql = "update PHANCONG set MANV = ?, NGAYDI = ?, MACB = ? where MANV = ? and NGAYDI = ? and MACB = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMANV());
			pst.setTimestamp(2, obj.getNGAYDI());
			pst.setString(3, obj.getMACB());
			pst.setString(4, obj.getMANV());
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
