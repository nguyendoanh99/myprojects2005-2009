import java.sql.*;
import java.util.*;

public class tempDao
{
	private String mDatabase;
	private Connection mConnection;

	private List<temp> getList(ResultSet rs)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			while (rs.next())
			{
				temp temp = new temp();
				String _id = rs.getString("id");
				String _ten = rs.getString("ten");
				double __float = rs.getDouble("_float");
				java.math.BigDecimal __decimal = rs.getBigDecimal("_decimal");
				byte[] __image = rs.getBytes("_image");
				long _bigint = rs.getLong("bigint");
				byte[] _binary = rs.getBytes("binary");
				boolean __BIT = rs.getBoolean("_BIT");
				java.sql.Timestamp __datetime = rs.getTimestamp("_datetime");
				int __int = rs.getInt("_int");
				java.math.BigDecimal __money = rs.getBigDecimal("_money");
				String __nchar = rs.getString("_nchar");
				String __ntext = rs.getString("_ntext");
				java.math.BigDecimal __numeric = rs.getBigDecimal("_numeric");
				String __nvarchar = rs.getString("_nvarchar");
				float __real = rs.getFloat("_real");
				java.sql.Timestamp __smalldatetime = rs.getTimestamp("_smalldatetime");
				short __smallint = rs.getShort("_smallint");
				java.math.BigDecimal __smallmoney = rs.getBigDecimal("_smallmoney");
				String __text = rs.getString("_text");
				short __tinyint = rs.getShort("_tinyint");
				String __uniquidentifier = rs.getString("_uniquidentifier");
				byte[] __varbinary = rs.getBytes("_varbinary");
				String __varchar = rs.getString("_varchar");
				temp.setid(_id);
				temp.setten(_ten);
				temp.set_float(__float);
				temp.set_decimal(__decimal);
				temp.set_image(__image);
				temp.setbigint(_bigint);
				temp.setbinary(_binary);
				temp.set_BIT(__BIT);
				temp.set_datetime(__datetime);
				temp.set_int(__int);
				temp.set_money(__money);
				temp.set_nchar(__nchar);
				temp.set_ntext(__ntext);
				temp.set_numeric(__numeric);
				temp.set_nvarchar(__nvarchar);
				temp.set_real(__real);
				temp.set_smalldatetime(__smalldatetime);
				temp.set_smallint(__smallint);
				temp.set_smallmoney(__smallmoney);
				temp.set_text(__text);
				temp.set_tinyint(__tinyint);
				temp.set_uniquidentifier(__uniquidentifier);
				temp.set_varbinary(__varbinary);
				temp.set_varchar(__varchar);
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
	public tempDao()
	{
		ConnectDatabase("QLCHUYENBAY", "sa", "sa");
	}

	public temp getByID(String _id)
	{
		temp result = new temp();
		try
		{
			String sql = "select * from temp where id=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _id);
			ResultSet rs = pst.executeQuery();
			List<temp> lst = getList(rs);
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

	public List<temp> getByten(String _ten)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where ten=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, _ten);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_float(double __float)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _float=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setDouble(1, __float);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_decimal(java.math.BigDecimal __decimal)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _decimal=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBigDecimal(1, __decimal);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_image(byte[] __image)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _image=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBytes(1, __image);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBybigint(long _bigint)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where bigint=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setLong(1, _bigint);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBybinary(byte[] _binary)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where binary=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBytes(1, _binary);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_BIT(boolean __BIT)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _BIT=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBoolean(1, __BIT);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_datetime(java.sql.Timestamp __datetime)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _datetime=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, __datetime);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_int(int __int)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _int=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setInt(1, __int);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_money(java.math.BigDecimal __money)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _money=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBigDecimal(1, __money);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_nchar(String __nchar)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _nchar=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, __nchar);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_ntext(String __ntext)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _ntext=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, __ntext);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_numeric(java.math.BigDecimal __numeric)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _numeric=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBigDecimal(1, __numeric);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_nvarchar(String __nvarchar)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _nvarchar=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, __nvarchar);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_real(float __real)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _real=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setFloat(1, __real);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_smalldatetime(java.sql.Timestamp __smalldatetime)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _smalldatetime=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setTimestamp(1, __smalldatetime);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_smallint(short __smallint)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _smallint=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setShort(1, __smallint);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_smallmoney(java.math.BigDecimal __smallmoney)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _smallmoney=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBigDecimal(1, __smallmoney);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_text(String __text)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _text=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, __text);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_tinyint(short __tinyint)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _tinyint=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setShort(1, __tinyint);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_uniquidentifier(String __uniquidentifier)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _uniquidentifier=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, __uniquidentifier);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_varbinary(byte[] __varbinary)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _varbinary=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setBytes(1, __varbinary);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getBy_varchar(String __varchar)
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp where _varchar=?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, __varchar);
			ResultSet rs = pst.executeQuery();
			result = getList(rs);
		}
		catch (SQLException e)
		{
			System.out.println(e.toString());
		}
		return result;
	}

	public List<temp> getAll()
	{
		List<temp> result = new ArrayList<temp>();
		try
		{
			String sql = "select * from temp";
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

	public boolean Insert(temp obj)
	{
		boolean result = false;
		try
		{
			String sql = "insert into temp(id, ten, _float, _decimal, _image, bigint, binary, _BIT, _datetime, _int, _money, _nchar, _ntext, _numeric, _nvarchar, _real, _smalldatetime, _smallint, _smallmoney, _text, _tinyint, _uniquidentifier, _varbinary, _varchar) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getid());
			pst.setString(2, obj.getten());
			pst.setDouble(3, obj.get_float());
			pst.setBigDecimal(4, obj.get_decimal());
			pst.setBytes(5, obj.get_image());
			pst.setLong(6, obj.getbigint());
			pst.setBytes(7, obj.getbinary());
			pst.setBoolean(8, obj.get_BIT());
			pst.setTimestamp(9, obj.get_datetime());
			pst.setInt(10, obj.get_int());
			pst.setBigDecimal(11, obj.get_money());
			pst.setString(12, obj.get_nchar());
			pst.setString(13, obj.get_ntext());
			pst.setBigDecimal(14, obj.get_numeric());
			pst.setString(15, obj.get_nvarchar());
			pst.setFloat(16, obj.get_real());
			pst.setTimestamp(17, obj.get_smalldatetime());
			pst.setShort(18, obj.get_smallint());
			pst.setBigDecimal(19, obj.get_smallmoney());
			pst.setString(20, obj.get_text());
			pst.setShort(21, obj.get_tinyint());
			pst.setString(22, obj.get_uniquidentifier());
			pst.setBytes(23, obj.get_varbinary());
			pst.setString(24, obj.get_varchar());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}

	public boolean Update(temp obj)
	{
		boolean result = false;
		try
		{
			String sql = "update temp set id = ?, ten = ?, _float = ?, _decimal = ?, _image = ?, bigint = ?, binary = ?, _BIT = ?, _datetime = ?, _int = ?, _money = ?, _nchar = ?, _ntext = ?, _numeric = ?, _nvarchar = ?, _real = ?, _smalldatetime = ?, _smallint = ?, _smallmoney = ?, _text = ?, _tinyint = ?, _uniquidentifier = ?, _varbinary = ?, _varchar = ? where id = ?";
			PreparedStatement pst = mConnection.prepareStatement(sql);
			pst.setString(1, obj.getid());
			pst.setString(2, obj.getten());
			pst.setDouble(3, obj.get_float());
			pst.setBigDecimal(4, obj.get_decimal());
			pst.setBytes(5, obj.get_image());
			pst.setLong(6, obj.getbigint());
			pst.setBytes(7, obj.getbinary());
			pst.setBoolean(8, obj.get_BIT());
			pst.setTimestamp(9, obj.get_datetime());
			pst.setInt(10, obj.get_int());
			pst.setBigDecimal(11, obj.get_money());
			pst.setString(12, obj.get_nchar());
			pst.setString(13, obj.get_ntext());
			pst.setBigDecimal(14, obj.get_numeric());
			pst.setString(15, obj.get_nvarchar());
			pst.setFloat(16, obj.get_real());
			pst.setTimestamp(17, obj.get_smalldatetime());
			pst.setShort(18, obj.get_smallint());
			pst.setBigDecimal(19, obj.get_smallmoney());
			pst.setString(20, obj.get_text());
			pst.setShort(21, obj.get_tinyint());
			pst.setString(22, obj.get_uniquidentifier());
			pst.setBytes(23, obj.get_varbinary());
			pst.setString(24, obj.get_varchar());
			pst.setString(25, obj.getid());
	
			if (pst.executeUpdate() > 0)
				result = true;
		}
		catch (SQLException e)
		{
		}
		return result;
	}
}
