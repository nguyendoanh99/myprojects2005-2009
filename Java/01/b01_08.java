/*
 * Author: Nguyen Dang Khoa
 * Created: 03 tha´ng ta´m 2004 9:45:58 SA
 * Modified: 03 tha´ng ta´m 2004 9:45:58 SA
 */

/* Viet chuong trinh nhap ten, nam sinh cua nguoi su dung, 
 * sau do in ra man hinh ten, tuoi cua nguoi do
 */

import javax.swing.JOptionPane;
import java.util.Calendar;
public class b01_08
{
	public static void main(String[] args)
	{
		String ht=JOptionPane.showInputDialog("Ho ten?");
		String ns=JOptionPane.showInputDialog("Nam sinh?");
		System.out.println("Ban ten la "+ht.trim()+".");
		Calendar d=Calendar.getInstance();
		int t=d.get(Calendar.YEAR)-Integer.parseInt(ns);
		System.out.println("Nam nay ban "+t+" tuoi.");
		System.exit(0);
	}
}
