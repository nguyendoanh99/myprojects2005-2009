import java.sql.*;
import java.util.*;

public class LICHBAYDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<LICHBAY> getList(ResultSet rs)
	{
		List<LICHBAY> result = new ArrayList<LICHBAY>();
		try
		{
			while (rs.next())
			{
				LICHBAY temp = new LICHBAY();
				java.sql.Timestamp _NGAYDI = rs.getTimestamp("NGAYDI");
				String _MACB = rs.getString("MACB");
				int _SOHIEU = rs.getInt("SOHIEU");
				String _MALOAI = rs.getString("MALOAI");
				temp.setNGAYDI(_NGAYDI);
				temp.setMACB(_MACB);
				temp.setSOHIEU(_SOHIEU);
				temp.setMALOAI(_MALOAI);
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
	public LICHBAYDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public LICHBAY getByID(java.sql.Timestamp _NGAYDI, String _MACB)
	{
		LICHBAY result = new LICHBAY();
		try
		{
			String sql = "select * from LICHBAY where NGAYDI=? and MACB=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, _NGAYDI);
			pst.setString(2, _MACB);
			ResultSet rs = pst.executeQuery();
			List<LICHBAY> lst = getList(rs);
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

	public List<LICHBAY> getByNGAYDI(java.sql.Timestamp _NGAYDI)
	{
		List<LICHBAY> result = new ArrayList<LICHBAY>();
		try
		{
			String sql = "select * from LICHBAY where NGAYDI=?";
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

	public List<LICHBAY> getByMACB(String _MACB)
	{
		List<LICHBAY> result = new ArrayList<LICHBAY>();
		try
		{
			String sql = "select * from LICHBAY where MACB=?";
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

	public List<LICHBAY> getBySOHIEU(int _SOHIEU)
	{
		List<LICHBAY> result = new ArrayList<LICHBAY>();
		try
		{
			String sql = "select * from LICHBAY where SOHIEU=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, _SOHIEU);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<LICHBAY> getByMALOAI(String _MALOAI)
	{
		List<LICHBAY> result = new ArrayList<LICHBAY>();
		try
		{
			String sql = "select * from LICHBAY where MALOAI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MALOAI);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<LICHBAY> getAll()
	{
		List<LICHBAY> result = new ArrayList<LICHBAY>();
		try
		{
			String sql = "select * from LICHBAY";
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

	public boolean Insert(LICHBAY obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into LICHBAY(NGAYDI, MACB, SOHIEU, MALOAI) values (?, ?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, obj.getNGAYDI());
			pst.setString(2, obj.getMACB());
			pst.setInt(3, obj.getSOHIEU());
			pst.setString(4, obj.getMALOAI());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(LICHBAY obj)
	{
		boolean result = false;
		try
		{
			String sql = "update LICHBAY set NGAYDI = ?, MACB = ?, SOHIEU = ?, MALOAI = ? where NGAYDI = ? and MACB = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, obj.getNGAYDI());
			pst.setString(2, obj.getMACB());
			pst.setInt(3, obj.getSOHIEU());
			pst.setString(4, obj.getMALOAI());
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
