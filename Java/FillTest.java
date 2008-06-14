/*
 * Author: Nguyen Dang Khoa
 * Created: 15 tha´ng chi´n 2004 12:58:02 CH
 * Modified: 15 tha´ng chi´n 2004 12:58:02 CH
 */

import javax.swing.*;
import java.awt.*;
import java.awt.geom.*;

public class FillTest
{
	public static void main(String[] args)
	{
		FillFrame frame=new FillFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
	}
}

class FillFrame extends JFrame
{
	public FillFrame()
	{
		Toolkit kit=Toolkit.getDefaultToolkit();
		Dimension d=kit.getScreenSize();
		Image img=kit.getImage("sedna.jpg");
		int w=d.width;
		int h=d.height;
		int x=(w-width)/2;
		int y=(h-height)/2;
		setTitle("Fill Test");
		setResizable(false);
		setBounds(x,y,width,height);
//		setSize(width,height);
//		setLocation(x,y);
		setIconImage(img);
		FillPanel p=new FillPanel();
		p.setBackground(SystemColor.desktop);
		Container c=getContentPane();
		c.add(p);
	}
	public static final int width=400;
	public static final int height=400;
}

class FillPanel extends JPanel
{
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		Graphics2D g2=(Graphics2D) g;
		Rectangle2D rect=new Rectangle2D.Double(100,100,200,150);
		g2.setPaint(Color.red);
		g2.fill(rect);
		g2.setPaint(new Color(0,128,128));
		Ellipse2D e=new Ellipse2D.Double();
		e.setFrame(rect);
		g2.fill(e);
		for (int i=0;i<255;i++)
		{
			Line2D l=new Line2D.Double(0,i,80,i);
			g2.setPaint(new Color(i,i,i));
			g2.draw(l);
		}
		Arc2D a=new Arc2D.Double(rect,0,90,Arc2D.CHORD);
		g2.draw(a);
	}
}