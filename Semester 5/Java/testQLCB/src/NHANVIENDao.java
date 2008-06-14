import java.sql.*;
import java.util.*;

public class NHANVIENDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<NHANVIEN> getList(ResultSet rs)
	{
		List<NHANVIEN> result = new ArrayList<NHANVIEN>();
		try
		{
			while (rs.next())
			{
				NHANVIEN temp = new NHANVIEN();
				String _MANV = rs.getString("MANV");
				String _TEN = rs.getString("TEN");
				String _DCHI = rs.getString("DCHI");
				String _DTHOAI = rs.getString("DTHOAI");
				java.math.BigDecimal _LUONG = rs.getBigDecimal("LUONG");
				boolean _LOAINV = rs.getBoolean("LOAINV");
				temp.setMANV(_MANV);
				temp.setTEN(_TEN);
				temp.setDCHI(_DCHI);
				temp.setDTHOAI(_DTHOAI);
				temp.setLUONG(_LUONG);
				temp.setLOAINV(_LOAINV);
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
	public NHANVIENDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public NHANVIEN getByID(String _MANV)
	{
		NHANVIEN result = new NHANVIEN();
		try
		{
			String sql = "select * from NHANVIEN where MANV=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MANV);
			ResultSet rs = pst.executeQuery();
			List<NHANVIEN> lst = getList(rs);
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

	public List<NHANVIEN> getByTEN(String _TEN)
	{
		List<NHANVIEN> result = new ArrayList<NHANVIEN>();
		try
		{
			String sql = "select * from NHANVIEN where TEN=?";
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

	public List<NHANVIEN> getByDCHI(String _DCHI)
	{
		List<NHANVIEN> result = new ArrayList<NHANVIEN>();
		try
		{
			String sql = "select * from NHANVIEN where DCHI=?";
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

	public List<NHANVIEN> getByDTHOAI(String _DTHOAI)
	{
		List<NHANVIEN> result = new ArrayList<NHANVIEN>();
		try
		{
			String sql = "select * from NHANVIEN where DTHOAI=?";
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

	public List<NHANVIEN> getByLUONG(java.math.BigDecimal _LUONG)
	{
		List<NHANVIEN> result = new ArrayList<NHANVIEN>();
		try
		{
			String sql = "select * from NHANVIEN where LUONG=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBigDecimal(1, _LUONG);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<NHANVIEN> getByLOAINV(boolean _LOAINV)
	{
		List<NHANVIEN> result = new ArrayList<NHANVIEN>();
		try
		{
			String sql = "select * from NHANVIEN where LOAINV=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBoolean(1, _LOAINV);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<NHANVIEN> getAll()
	{
		List<NHANVIEN> result = new ArrayList<NHANVIEN>();
		try
		{
			String sql = "select * from NHANVIEN";
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

	public boolean Insert(NHANVIEN obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into NHANVIEN(MANV, TEN, DCHI, DTHOAI, LUONG, LOAINV) values (?, ?, ?, ?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMANV());
			pst.setString(2, obj.getTEN());
			pst.setString(3, obj.getDCHI());
			pst.setString(4, obj.getDTHOAI());
			pst.setBigDecimal(5, obj.getLUONG());
			pst.setBoolean(6, obj.getLOAINV());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(NHANVIEN obj)
	{
		boolean result = false;
		try
		{
			String sql = "update NHANVIEN set MANV = ?, TEN = ?, DCHI = ?, DTHOAI = ?, LUONG = ?, LOAINV = ? where MANV = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getMANV());
			pst.setString(2, obj.getTEN());
			pst.setString(3, obj.getDCHI());
			pst.setString(4, obj.getDTHOAI());
			pst.setBigDecimal(5, obj.getLUONG());
			pst.setBoolean(6, obj.getLOAINV());
			pst.setString(7, obj.getMANV());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}
}
