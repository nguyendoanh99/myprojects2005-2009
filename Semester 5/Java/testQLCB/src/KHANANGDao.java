import java.sql.*;
import java.util.*;

public class KHANANGDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<KHANANG> getList(ResultSet rs)
	{
		List<KHANANG> result = new ArrayList<KHANANG>();
		try
		{
			while (rs.next())
			{
				KHANANG temp = new KHANANG();
				String _MANV = rs.getString("MANV");
				String _MALOAI = rs.getString("MALOAI");
				temp.setMANV(_MANV);
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
	public KHANANGDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public KHANANG getByID(String _MANV, String _MALOAI)
	{
		KHANANG result = new KHANANG();
		try
		{
			String sql = "select * from KHANANG where MANV=? and MALOAI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MANV);
			pst.setString(2, _MALOAI);
			ResultSet rs = pst.executeQuery();
			List<KHANANG> lst = getList(rs);
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

	public List<KHANANG> getByMANV(String _MANV)
	{
		List<KHANANG> result = new ArrayList<KHANANG>();
		try
		{
			String sql = "select * from KHANANG where MANV=?";
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

	public List<KHANANG> getByMALOAI(String _MALOAI)
	{
		List<KHANANG> result = new ArrayList<KHANANG>();
		try
		{
			String sql = "select * from KHANANG where MALOAI=?";
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

	public List<KHANANG> getAll()
	{
		List<KHANANG> result = new ArrayList<KHANANG>();
		try
		{
			String sql = "select * from KHANANG";
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

	public boolean Insert(KHANANG obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into KHANANG(MANV, MALOAI) values (?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMANV());
			pst.setString(2, obj.getMALOAI());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(KHANANG obj)
	{
		boolean result = false;
		try
		{
			String sql = "update KHANANG set MANV = ?, MALOAI = ? where MANV = ? and MALOAI = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMANV());
			pst.setString(2, obj.getMALOAI());
			pst.setString(3, obj.getMANV());
			pst.setString(4, obj.getMALOAI());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}
}
