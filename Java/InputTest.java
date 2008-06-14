/*
 * Author: Nguyen Dang Khoa
 * Created: 30 tha´ng ba?y 2004 9:50:04 CH
 * Modified: 30 tha´ng ba?y 2004 9:50:04 CH
 */

// InputTest

import javax.swing.*;

public class InputTest
{
	public static void main(String[] args)
	{
		String name=JOptionPane.showInputDialog("Ban ten la gi?");
		String input=JOptionPane.showInputDialog("Ban bao nhieu tuoi?");
		int age=Integer.parseInt(input);
		System.out.println("Hello, "+name+". Next year, you'll be "+(age+1));
		System.exit(0);
		System.out.println("asd");
	}
}
