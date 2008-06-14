/*
 * Author: Nguyen Dang Khoa
 * Created: 29 tha´ng ba?y 2004 8:34:08 SA
 * Modified: 29 tha´ng ba?y 2004 8:34:08 SA
 */

// Vi du ve toan tu tren so nguyen

public class Vidu
{
  //Chuong trinh chinh
	public static void main(String[] args)
	{
	  //Chuyen doi so tu chuoi sang so nguyen
		Integer x=new Integer(args[0]); //So thu nhat
		Integer y=new Integer(args[1]); //So thu nhat
		int kq;
		kq=x.intValue()+y.intValue(); //Phep cong
		System.out.println(x+" + "+y+" = "+kq);
		kq=x.intValue()-y.intValue(); //Phep tru
		System.out.println(x+" - "+y+" = "+kq);
		kq=x.intValue()*y.intValue(); //Phep nhan
		System.out.println(x+" * "+y+" = "+kq);
		kq=x.intValue()/y.intValue(); //Phep chia lay nguyen
		System.out.println(x+" / "+y+" = "+kq);
		kq=x.intValue()%y.intValue(); //Phep chia lay du
		System.out.println(x+" % "+y+" = "+kq);
		kq=x.intValue()&y.intValue(); //Phep AND tren bit
		System.out.println(x+" & "+y+" = "+kq); 
		kq=x.intValue()|y.intValue(); //Phep OR tren bit
		System.out.println(x+" | "+y+" = "+kq);
		kq=x.intValue()^y.intValue(); //Phep XOR tren bit
		System.out.println(x+" ^ "+y+" = "+kq);
		kq=x.intValue(); //Phep phan tren bit
		System.out.println("~"+x+" = "+kq);
		kq=-x.intValue(); //Phep doi dau
		System.out.println("x = "+x+" ==> -x = "+kq);
		kq=x.intValue()<<y.intValue(); //Dich chuyen bit sang trai
		System.out.println(x+" << "+y+" = "+kq);
		kq=x.intValue()>>y.intValue(); //Dich chuyen bit sang phai
		System.out.println(x+" >> "+y+" = "+kq);
		kq=x.intValue()>>>y.intValue(); //Dich chuyen bit sang phai va dien vao cac bit trong gia tri 0
		System.out.println(x+" >>> "+y+" = "+kq);
	}
}
