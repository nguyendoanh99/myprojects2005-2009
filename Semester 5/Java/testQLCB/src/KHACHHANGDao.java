import java.sql.*;
import java.util.*;

public class KHACHHANGDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<KHACHHANG> getList(ResultSet rs)
	{
		List<KHACHHANG> result = new ArrayList<KHACHHANG>();
		try
		{
			while (rs.next())
			{
				KHACHHANG temp = new KHACHHANG();
				String _MAKH = rs.getString("MAKH");
				String _TEN = rs.getString("TEN");
				String _DCHI = rs.getString("DCHI");
				String _DTHOAI = rs.getString("DTHOAI");
				temp.setMAKH(_MAKH);
				temp.setTEN(_TEN);
				temp.setDCHI(_DCHI);
				temp.setDTHOAI(_DTHOAI);
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
	public KHACHHANGDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public KHACHHANG getByID(String _MAKH)
	{
		KHACHHANG result = new KHACHHANG();
		try
		{
			String sql = "select * from KHACHHANG where MAKH=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MAKH);
			ResultSet rs = pst.executeQuery();
			List<KHACHHANG> lst = getList(rs);
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

	public List<KHACHHANG> getByTEN(String _TEN)
	{
		List<KHACHHANG> result = new ArrayList<KHACHHANG>();
		try
		{
			String sql = "select * from KHACHHANG where TEN=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _TEN);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<KHACHHANG> getByDCHI(String _DCHI)
	{
		List<KHACHHANG> result = new ArrayList<KHACHHANG>();
		try
		{
			String sql = "select * from KHACHHANG where DCHI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _DCHI);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<KHACHHANG> getByDTHOAI(String _DTHOAI)
	{
		List<KHACHHANG> result = new ArrayList<KHACHHANG>();
		try
		{
			String sql = "select * from KHACHHANG where DTHOAI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _DTHOAI);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<KHACHHANG> getAll()
	{
		List<KHACHHANG> result = new ArrayList<KHACHHANG>();
		try
		{
			String sql = "select * from KHACHHANG";
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

	public boolean Insert(KHACHHANG obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into KHACHHANG(MAKH, TEN, DCHI, DTHOAI) values (?, ?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMAKH());
			pst.setString(2, obj.getTEN());
			pst.setString(3, obj.getDCHI());
			pst.setString(4, obj.getDTHOAI());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(KHACHHANG obj)
	{
		boolean result = false;
		try
		{
			String sql = "update KHACHHANG set MAKH = ?, TEN = ?, DCHI = ?, DTHOAI = ? where MAKH = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMAKH());
			pst.setString(2, obj.getTEN());
			pst.setString(3, obj.getDCHI());
			pst.setString(4, obj.getDTHOAI());
			pst.setString(5, obj.getMAKH());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}
}
