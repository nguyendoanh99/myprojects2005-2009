public class dtproperties
{
	private int mid;
	private int mobjectid;
	private String mproperty;
	private String mvalue;
	private String muvalue;
	private byte[] mlvalue;
	private int mversion;
	
	public void setid(int id)
	{
		this.mid = id;
	}
	
	public int getid()
	{
		return mid;
	}
	
	public void setobjectid(int objectid)
	{
		this.mobjectid = objectid;
	}
	
	public int getobjectid()
	{
		return mobjectid;
	}
	
	public void setproperty(String property)
	{
		this.mproperty = property;
	}
	
	public String getproperty()
	{
		return mproperty;
	}
	
	public void setvalue(String value)
	{
		this.mvalue = value;
	}
	
	public String getvalue()
	{
		return mvalue;
	}
	
	public void setuvalue(String uvalue)
	{
		this.muvalue = uvalue;
	}
	
	public String getuvalue()
	{
		return muvalue;
	}
	
	public void setlvalue(byte[] lvalue)
	{
		this.mlvalue = lvalue;
	}
	
	public byte[] getlvalue()
	{
		return mlvalue;
	}
	
	public void setversion(int version)
	{
		this.mversion = version;
	}
	
	public int getversion()
	{
		return mversion;
	}
	
	
}