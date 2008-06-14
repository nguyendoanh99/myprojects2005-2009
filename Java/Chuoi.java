/*
 * Author: Nguyen Dang Khoa
 * Created: 30 tha´ng ba?y 2004 11:47:30 SA
 * Modified: 30 tha´ng ba?y 2004 11:47:30 SA
 */

// Vi du ve chuoi
import java.text.*;
public class Chuoi
{
	public static void main(String[] args)
	{
		String s=args[0];
	  //substring(a,b) copy chuoi tu vi tri thu a den vi tri thu b	
		String s1=s.substring(0,s.length()-1);
		System.out.println("s1 = "+s1);
		// So sanh 2 chuoi co phan biet chu hoa chu thuong
		System.out.println("equals "+s.equals(args[1])); 
		// So sanh 2 chuoi khong phan biet chu hoa chu thuong
		System.out.println("equalsIgnoreCase "+s.equalsIgnoreCase(args[1]));
		// <0 if s dung truoc args[1] trong thu tu tu dien
		// >0 if s dung sau args[1] trong thu tu tu dien
		// =0 if s = args[1] trong thu tu tu dien
		System.out.println("compareTo "+s.compareTo(args[1]));
		// True if chuoi ket thuc cua s = args[1]
		System.out.println("endsWith "+s.endsWith(args[1]));
		System.out.println("indexOf "+s.indexOf(args[1]));
		System.out.println("lastIndexOf "+s.lastIndexOf(args[1]));
		System.out.println("replace "+s.replace(args[1].charAt(0),args[1].charAt(args[1].length()-1)));
		System.out.println("startsWith "+s.startsWith(args[1]));
		System.out.println("toLowerCase "+s.toLowerCase());
		System.out.println("toUpperCase "+s.toUpperCase());
		s="   "+s+"  "+"jhh   ";
		System.out.println("trim "+s.trim());
		System.out.println("s = "+s);
		s=s.trim();
		System.out.println(Double.NEGATIVE_INFINITY);
		int[][] a=new int[5][];
		for (int i=0;i<a.length;i++) a[i]=new int[i+1];
		int j=0;
		for (int i=0;i<a.length;i++)
		{
			for (int k=0;k<a[i].length;k++,j++)
			{
				a[i][k]=j;
				System.out.print(a[i][k]+"  ");
			}
			System.out.println();
		}
		System.out.println("concat "+s.concat("! I love you"));
		char[] t={'3','1','5','H','e','l','l','o'};
		s=String.copyValueOf(t,3,5);
		System.out.println(s);
		char[] o=new char[10];
		s.getChars(0,4,o,2);
		for (int i=0;i<o.length;i++) System.out.print(o[i]+" ");
		System.out.println(s.replace('l','h'));
		s="boo:and: fo"+'o';
		String[] s2=s.split("o",0);
		for (int i=0;i<s2.length;i++) System.out.println(i+"\t"+s2[i]);
		char[] c=s.toCharArray();
		for (int i=0;i<c.length;i++) System.out.print("\""+c[i]+"\"\t");
		System.out.println();
		CharSequence g=s.subSequence(1,5);
		System.out.println(g);
		double z=10000.0/3.0;
		System.out.println(z);
		System.out.println(Math.round(z));
		NumberFormat formatter=NumberFormat.getPercentInstance();
		formatter.setMaximumFractionDigits(4);
		formatter.setMinimumIntegerDigits(6);
		s=formatter.format(z);
		System.out.println(s);
		System.out.println(Math.exp(0.33));
	}
}
