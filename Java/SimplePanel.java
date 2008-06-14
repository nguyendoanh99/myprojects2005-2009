/*
 * Author: Nguyen Dang Khoa
 * Created: 12 tha´ng chi´n 2004 8:14:19 SA
 * Modified: 12 tha´ng chi´n 2004 8:14:19 SA
 */

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.*;
import javax.swing.Timer;

public class SimplePanel
{
	public static void main(String[] args)
	{
		JFrame f=new JFrame();
		f.setTitle("Nguyen Dang Khoa");
		Toolkit t=Toolkit.getDefaultToolkit();
		Dimension d=t.getScreenSize();
		int w=d.width;
		int h=d.height;
		System.out.println(h+" "+w);
		f.setBounds(w/4,h/4,w/2,h/2);
		Image img=t.getImage("sedna.jpg");
		f.setIconImage(img);
		f.setResizable(false);
		f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		d=f.getSize();
		h=d.height;
		w=d.width;
		System.out.println(h+" "+w);
		TPanel p=new TPanel("I love you",w/4,h/2-20);
		Container c=f.getContentPane();
		c.add(p);
		f.show();
		ActionListener l=new In(f,p);
		Timer time=new Timer(1000,l);
		time.start();
	}
}

class In implements ActionListener
{
	public In(JFrame frame,TPanel panel)
	{
		f=frame;
		p=panel;
	}
	public void actionPerformed(ActionEvent event)
	{
		Date now=new Date();
		f.setTitle(now.toString());
		p.setTitle(now.toString());
		p.repaint();
	}
	JFrame f;
	TPanel p;
}

class TPanel extends JPanel
{
	public TPanel(String ten,int x1,int y1)
	{
		s=ten;
		x=x1;
		y=y1;
	}
	public void setTitle(String ten)
	{
		s=ten;
	}
	public void setx(int x1)
	{
		x=x1;
	}
	public void sety(int y1)
	{
		y=y1;
	}
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		g.drawString(s,x,y);
	}
	public String s;
	public int x;
	public int y;
}