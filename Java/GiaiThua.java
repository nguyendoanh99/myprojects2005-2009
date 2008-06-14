/*
 * Author: Nguyen Dang Khoa
 * Created: 25 tha´ng ta´m 2004 10:53:02 SA
 * Modified: 25 tha´ng ta´m 2004 10:53:02 SA
 */

import javax.swing.JOptionPane;
public class GiaiThua
{
	public static long gt(int t)
	{
		if (t==0) return 1;		
		if (t==1) return 1;
		else return (t*gt(t-1));
	}
	public static void main(String[] args)
	{
		String s=JOptionPane.showInputDialog("n =");
		int n=Integer.parseInt(s);
		System.out.println(gt(n));
		System.exit(0);
	}
}
