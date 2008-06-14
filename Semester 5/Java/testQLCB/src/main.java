import java.sql.*;
import java.util.*;
public class main {
	
	public static void main(String args[])
	{
		/*
		LICHBAY t;
		LICHBAYDao dao = new LICHBAYDao();
		Timestamp ts = new Timestamp(2000 - 1900, 10 - 1, 31, 1, 1, 1, 1); 
		t = dao.getByID("100", ts);
		System.out.println(t.getNGAYDI());
		System.out.println(t.getMACB());
		System.out.println(t.getMALOAI());
		System.out.println(t.getSOHIEU());
		*/
		CHUYENBAY t1 = new CHUYENBAY();
		CHUYENBAYDao dao1 = new CHUYENBAYDao();
		t1 = dao1.getByID("100");
		System.out.println(t1.getMACB());
		System.out.println(t1.getSBDI());
		System.out.println(t1.getSBDEN());
		System.out.println(t1.getGIODI().toString());
		System.out.println(t1.getGIODEN().toString());
		
		NHANVIEN t2;
		NHANVIENDao dao2 = new NHANVIENDao();
		t2 = dao2.getByID("1001");
		List<NHANVIEN> temp = dao2.getByDCHI("12/6 Nguyen Kiem");
		for (int i = 0 ; i < temp.size(); ++i)
		{
			t2 = temp.get(i);
			t2.setTEN("xxj1");
			t2.setDTHOAI("xxx");
			
			dao2.Update(t2);
			t2.setLOAINV(true);
			t2.setMANV("111");
			dao2.Insert(t2);
			System.out.print(t2.getMANV());
			System.out.print("\t" +t2.getTEN());
			System.out.print("\t" + t2.getLOAINV());
			System.out.print("\t" + t2.getDTHOAI());
			System.out.print("\t" + t2.getDCHI());
			System.out.println("\t" + t2.getLUONG());
		}
		
		/*
		List<CHUYENBAY> t3 = new ArrayList<CHUYENBAY>();
		CHUYENBAYDao dao3 = new CHUYENBAYDao();		
		//t3.add(dao3.getByID("100"));
		t3 = dao3.getBySBDEN("YYV");
		for (int i = 0; i < t3.size(); ++i)
		{
			CHUYENBAY cb = t3.get(i);
			String str = new String();
			str += cb.getMACB() + " ";
			str += cb.getSBDI() + " ";
			str += cb.getSBDEN() + " ";
			str += cb.getGIODI() + " ";
			str += cb.getGIODEN() + " ";
			System.out.println(str);
		}
		*/
//		List<temp> t3 = new ArrayList<temp>();
//		tempDao dao3 = new tempDao();
//		t3.add(dao3.getByID());
//		t3 = dao3.getByten("Kim");
//		t3 = dao3.getByDCHI("ASD");
//		System.out.println(dao3.Show(t3));
//		t3.get(0).setMAKH("000312");
//		t3.get(0).setMANV("1002");
//		temp ttt = new temp();
//		ttt.setid("10");
//		ttt.setten("Lê");
//		dao3.Insert(ttt);
//		t3.get(0).setten("Hoàng");
//		t3.get(0).setten("Nguyễn Đăng Khoa");
//		t3.get(0).set_nchar("Nguyễn Đăng Khoa");
//		t3.get(0).setid("123");
//		System.out.println(dao3.Insert(t3.get(0)));
//		System.out.println(dao3.Update(t3.get(0)));
		System.out.println("finish");
	}
}
