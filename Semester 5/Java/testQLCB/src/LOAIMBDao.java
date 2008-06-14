import java.sql.*;
import java.util.*;

public class LOAIMBDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<LOAIMB> getList(ResultSet rs)
	{
		List<LOAIMB> result = new ArrayList<LOAIMB>();
		try
		{
			while (rs.next())
			{
				LOAIMB temp = new LOAIMB();
				String _HANGSX = rs.getString("HANGSX");
				String _MALOAI = rs.getString("MALOAI");
				temp.setHANGSX(_HANGSX);
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
	public LOAIMBDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public LOAIMB getByID(String _MALOAI)
	{
		LOAIMB result = new LOAIMB();
		try
		{
			String sql = "select * from LOAIMB where MALOAI=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _MALOAI);
			ResultSet rs = pst.executeQuery();
			List<LOAIMB> lst = getList(rs);
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

	public List<LOAIMB> getByHANGSX(String _HANGSX)
	{
		List<LOAIMB> result = new ArrayList<LOAIMB>();
		try
		{
			String sql = "select * from LOAIMB where HANGSX=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _HANGSX);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<LOAIMB> getAll()
	{
		List<LOAIMB> result = new ArrayList<LOAIMB>();
		try
		{
			String sql = "select * from LOAIMB";
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

	public boolean Insert(LOAIMB obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into LOAIMB(HANGSX, MALOAI) values (?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getHANGSX());
			pst.setString(2, obj.getMALOAI());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(LOAIMB obj)
	{
		boolean result = false;
		try
		{
			String sql = "update LOAIMB set HANGSX = ?, MALOAI = ? where MALOAI = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getHANGSX());
			pst.setString(2, obj.getMALOAI());
			pst.setString(3, obj.getMALOAI());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}
}
