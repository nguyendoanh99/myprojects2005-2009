/*
 * Author: Nguyen Dang Khoa
 * Created: 29 tha´ng ba?y 2004 8:13:56 SA
 * Modified: 29 tha´ng ba?y 2004 8:13:56 SA
 */

//Chuong trinh Java cong hai so, cac so duoc nhap tu doi so dong lenh

public class AddNumber
{
  //Chuong trinh chinh
	public static void main(String[] args)
	{
	  //Chuyen doi so tu chuoi thanh so nguyen
		Integer x=new Integer(args[0]); //So thu nhat
		Integer y=new Integer(args[1]); //So thu hai
	  //Lay ve gia tri va cong 
		int result=x.intValue()+y.intValue();
	  //In ket qua ra man hinh
		System.out.println("Result="+result);
	}
}