/*
 * Author: Nguyen Dang Khoa
 * Created: 02 tha´ng chi´n 2004 10:04:27 CH
 * Modified: 02 tha´ng chi´n 2004 10:04:27 CH
 */

import java.awt.*;
import java.awt.event.*;
import java.util.*;
import javax.swing.JOptionPane;
import javax.swing.Timer;
public class TimerTest
{
	public static void main(String[] args)
	{
		ActionListener listener=new TimePrinter();
		Timer t=new Timer(2000,listener);
		t.start();
//		JOptionPane.showMessageDialog(null,"Quit progran ?");
//		System.exit(0);
	}
}

class TimePrinter implements ActionListener
{
	public void actionPerformed(ActionEvent event)
	{
		Date now=new Date();
		System.out.println("At the tone, the time is "+now);
		Toolkit.getDefaultToolkit().beep();
	}
}