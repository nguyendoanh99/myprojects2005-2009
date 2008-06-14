import java.sql.*;
import java.util.*;

public class MAYBAYDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<MAYBAY> getList(ResultSet rs)
	{
		List<MAYBAY> result = new ArrayList<MAYBAY>();
		try
		{
			while (rs.next())
			{
				MAYBAY temp = new MAYBAY();
				int _SOHIEU = rs.getInt("SOHIEU");
				String _MALOAI = rs.getString("MALOAI");
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
	public MAYBAYDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public MAYBAY getByID(int _SOHIEU, String _MALOAI)
	{
		MAYBAY result = new MAYBAY();
		try
		{
			String sql = "select * from MAYBAY where SOHIEU=? and MALOAI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, _SOHIEU);
			pst.setString(2, _MALOAI);
			ResultSet rs = pst.executeQuery();
			List<MAYBAY> lst = getList(rs);
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

	public List<MAYBAY> getBySOHIEU(int _SOHIEU)
	{
		List<MAYBAY> result = new ArrayList<MAYBAY>();
		try
		{
			String sql = "select * from MAYBAY where SOHIEU=?";
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

	public List<MAYBAY> getByMALOAI(String _MALOAI)
	{
		List<MAYBAY> result = new ArrayList<MAYBAY>();
		try
		{
			String sql = "select * from MAYBAY where MALOAI=?";
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

	public List<MAYBAY> getAll()
	{
		List<MAYBAY> result = new ArrayList<MAYBAY>();
		try
		{
			String sql = "select * from MAYBAY";
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

	public boolean Insert(MAYBAY obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into MAYBAY(SOHIEU, MALOAI) values (?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, obj.getSOHIEU());
			pst.setString(2, obj.getMALOAI());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(MAYBAY obj)
	{
		boolean result = false;
		try
		{
			String sql = "update MAYBAY set SOHIEU = ?, MALOAI = ? where SOHIEU = ? and MALOAI = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, obj.getSOHIEU());
			pst.setString(2, obj.getMALOAI());
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
}
