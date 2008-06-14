import java.sql.*;
import java.util.*;

public class CHUYENBAYDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<CHUYENBAY> getList(ResultSet rs)
	{
		List<CHUYENBAY> result = new ArrayList<CHUYENBAY>();
		try
		{
			while (rs.next())
			{
				CHUYENBAY temp = new CHUYENBAY();
				String _MACB = rs.getString("MACB");
				String _SBDI = rs.getString("SBDI");
				String _SBDEN = rs.getString("SBDEN");
				java.sql.Timestamp _GIODI = rs.getTimestamp("GIODI");
				java.sql.Timestamp _GIODEN = rs.getTimestamp("GIODEN");
				temp.setMACB(_MACB);
				temp.setSBDI(_SBDI);
				temp.setSBDEN(_SBDEN);
				temp.setGIODI(_GIODI);
				temp.setGIODEN(_GIODEN);
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
	public CHUYENBAYDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public CHUYENBAY getByID(String _MACB)
	{
		CHUYENBAY result = new CHUYENBAY();
		try
		{
			String sql = "select * from CHUYENBAY where MACB=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MACB);
			ResultSet rs = pst.executeQuery();
			List<CHUYENBAY> lst = getList(rs);
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

	public List<CHUYENBAY> getBySBDI(String _SBDI)
	{
		List<CHUYENBAY> result = new ArrayList<CHUYENBAY>();
		try
		{
			String sql = "select * from CHUYENBAY where SBDI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _SBDI);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<CHUYENBAY> getBySBDEN(String _SBDEN)
	{
		List<CHUYENBAY> result = new ArrayList<CHUYENBAY>();
		try
		{
			String sql = "select * from CHUYENBAY where SBDEN=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _SBDEN);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<CHUYENBAY> getByGIODI(java.sql.Timestamp _GIODI)
	{
		List<CHUYENBAY> result = new ArrayList<CHUYENBAY>();
		try
		{
			String sql = "select * from CHUYENBAY where GIODI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, _GIODI);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<CHUYENBAY> getByGIODEN(java.sql.Timestamp _GIODEN)
	{
		List<CHUYENBAY> result = new ArrayList<CHUYENBAY>();
		try
		{
			String sql = "select * from CHUYENBAY where GIODEN=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, _GIODEN);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<CHUYENBAY> getAll()
	{
		List<CHUYENBAY> result = new ArrayList<CHUYENBAY>();
		try
		{
			String sql = "select * from CHUYENBAY";
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

	public boolean Insert(CHUYENBAY obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into CHUYENBAY(MACB, SBDI, SBDEN, GIODI, GIODEN) values (?, ?, ?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMACB());
			pst.setString(2, obj.getSBDI());
			pst.setString(3, obj.getSBDEN());
			pst.setTimestamp(4, obj.getGIODI());
			pst.setTimestamp(5, obj.getGIODEN());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(CHUYENBAY obj)
	{
		boolean result = false;
		try
		{
			String sql = "update CHUYENBAY set MACB = ?, SBDI = ?, SBDEN = ?, GIODI = ?, GIODEN = ? where MACB = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMACB());
			pst.setString(2, obj.getSBDI());
			pst.setString(3, obj.getSBDEN());
			pst.setTimestamp(4, obj.getGIODI());
			pst.setTimestamp(5, obj.getGIODEN());
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
