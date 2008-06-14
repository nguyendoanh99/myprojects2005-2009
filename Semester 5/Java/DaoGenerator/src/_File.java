import java.io.*;

public class _File {
	public String WriteFile(String FileName, String str)
	{
		String result = new String();
		FileWriter fw;
		
		try
		{
			fw = new FileWriter(FileName);
			str = str.replace("\n", "\r\n");
			fw.write(str);
			fw.close();
		}
		catch(IOException exc) 
		{
			result += exc.toString();
		}
		
		return result;
	}
	
	public String WriteFile(String FileName, String[] arrStr)
	{
		String result = new String();
		FileWriter fw;
		
		try
		{
			fw = new FileWriter(FileName);
			for (int i = 0; i < arrStr.length; ++i)
			{
				String str = arrStr[i];
				str = str.replace("\n", "\r\n");
				fw.write(arrStr[i]);
				fw.write("\r\n");
			}
			fw.close();
		}
		catch(IOException exc) 
		{
			result += exc.toString();
		}
		
		return result;
	}
}
