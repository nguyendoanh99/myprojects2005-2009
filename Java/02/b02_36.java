/*
 * Author: Nguyen Dang Khoa
 * Created: 08 tha´ng ta´m 2004 10:15:26 SA
 * Modified: 08 tha´ng ta´m 2004 10:15:26 SA
 */

/* 
 * Viet chuong trinh nhap 1 so nguyen duong, sau do
 * in ra man hinh cac he so cua khai trien: (a+b)^n
 */

import javax.swing.*;
public class b02_36
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("n =");	
		int n=Integer.parseInt(s);
		System.out.print("a^"+n+"+");
		for (int i=1,m=1,t=n;i<n;t*=n-i,m*=++i)
			System.out.print("("+(t/m)+"*a^"+(n-i)+"*b^"+i+")+");
		System.out.print("b^"+n);
		System.exit(0);
	}
}
