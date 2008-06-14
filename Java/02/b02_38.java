/*
 * Author: Nguyen Dang Khoa
 * Created: 09 tha´ng ta´m 2004 10:05:35 SA
 * Modified: 09 tha´ng ta´m 2004 10:05:35 SA
 */

/*
 * Viet chuong trinh nhap 2 ma tran gom cac so nguyen,
 * co toi da 100 dong, 100 cot, sau do tinh tich 2 ma 
 * tran nay roi in ket qua ra man hinh.
 */

import javax.swing.JOptionPane;
import java.util.Arrays;
public class b02_38
{
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("n (n<=100) =");
		int n=Integer.parseInt(s);
		int[][] a=new int[n][n];
		int[][] b=new int[n][n];
		int[][] c=new int[n][n];
		// Tao so ngau nhien cho cac phan tu cua mang a,b
		for (int i=0;i<n;i++)
			for (int j=0;j<n;j++) 
			{
				a[i][j]=(int) (Math.random()*10);
				b[i][j]=(int) (Math.random()*10);
			}
		// Xuat mang A ra man hinh
		System.out.println("Mang A");
		for (int i=0;i<n;i++)
		{
			for (int j=0;j<n;j++) System.out.print(a[i][j]+"   ");
			System.out.println();
		}
		// Xuat mang B ra man hinh
		System.out.println("Mang B");
		for (int i=0;i<n;i++)
		{
			for (int j=0;j<n;j++) System.out.print(b[i][j]+"   ");
			System.out.println();
		}
		// Nhan 2 ma tran
		for (int i=0;i<n;i++)
		{
			Arrays.fill(c[i],0); // Khoi tao gia tri ban dau cho mang c[i]
			for (int j=0;j<n;j++) 
				for (int k=0;k<n;k++) c[i][j]+=a[i][k]*b[k][j];
		}
		// Xuat mang C ra man hinh
		System.out.println("Mang C=A*B");
		for (int i=0;i<n;i++)
		{
			for (int j=0;j<n;j++) System.out.print(c[i][j]+"   ");
			System.out.println();
		}
		System.exit(0);
	}
}