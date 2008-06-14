import java.util.*;

public class test {
	
	
	/**
	 * @param args
	 */
	public static void main(String args[])
	{	
		_DAOGenerator dao = new _DAOGenerator();
		dao.Connect("sa", "sa");
		dao.ConnectDatabase("QLCHUYENBAY");
//		dao.WriteFile();
//		System.out.println(dao.CreategetByID("CHUYENBAY"));
//		System.out.println(dao.CreateEntityClass("CHUYENBAY"));
//		String[] arr = dao.GetTable();
//		for (int i = 0; i < arr.length; ++i)
//			System.out.println(arr[i] + "\n");
//		System.out.println(dao.CreateDaoClass("LICHBAY"));
		
		dao.WriteEntityClassToFile();
		dao.WriteDaoClassToFile();
//		String[] arr = dao.GetTable();
//		for (int i = 0; i < arr.length; ++i)
//			System.out.println(arr[i]);
//		dao.CreateDaoClass("temp");
//		dao.CreateEntityClass("temp");
//		List<String> primarykeys = new ArrayList<String> ();
//		List types = new ArrayList();
//		System.out.println(dao.CreategetByID("KHACHHANG"));
//		dao.GetPrimaryKeysInfo("KHACHHANG", primarykeys, types);
//		System.out.println(dao.CreateUpdate("DATCHO"));
		System.out.println("finish");
	}
}
