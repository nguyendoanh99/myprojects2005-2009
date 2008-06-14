/*
 * Author: Nguyen Dang Khoa
 * Created: 12 tha´ng chi´n 2004 7:36:13 SA
 * Modified: 12 tha´ng chi´n 2004 7:36:13 SA
 */

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.Timer;
import java.util.*;
public class Simple
{
	public static void main(String[] args)
	{
		JFrame f=new JFrame();
		f.setSize(300,200);
		f.setTitle("Nguyen Dang Khoa");
		Toolkit kit=Toolkit.getDefaultToolkit();
		Dimension d=kit.getScreenSize();
		int w=d.width;
		int h=d.height;
		f.setBounds(w/4,h/4,w/2,h/2);
		f.setResizable(false);
		Image img=kit.getImage("SEDNA.jpg");
		f.setIconImage(img);
		f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		f.show();
		ActionListener l=new In(f);
		Timer t=new Timer(1000,l);
		t.start();
	}
}

class In implements ActionListener
{
	public In(JFrame frame)
	{
		f=frame;
	}
	public void actionPerformed(ActionEvent event)
	{
		Date now=new Date();
		f.setTitle(now.toString());
	}
	JFrame f;
}