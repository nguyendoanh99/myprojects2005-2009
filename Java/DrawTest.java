/*
 * Author: Nguyen Dang Khoa
 * Created: 14 tha´ng chi´n 2004 12:13:40 CH
 * Modified: 14 tha´ng chi´n 2004 12:13:40 CH
 */

import javax.swing.*;
import java.awt.*;
import java.awt.geom.*;

public class DrawTest
{
	public static void main(String[] args)
	{
		DrawFrame frame=new DrawFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
	}
}

class DrawFrame extends JFrame
{
	public DrawFrame()
	{
		setTitle("Draw Test");
		setResizable(false);
		Toolkit kit=Toolkit.getDefaultToolkit();
		Dimension d=kit.getScreenSize();
		Image img=kit.getImage("sedna.jpg");
		setIconImage(img);
		int w=d.width;
		int h=d.height;
		int x=(w-width)/2;
		int y=(h-height)/2;
		System.out.println(w+" "+h+" "+x+" "+y);
		setBounds(x,y,width,height);
//		setSize(width,height);
//		setLocation(x,y);
		DrawPanel p=new DrawPanel();
		Container con=getContentPane();
		con.add(p);
	}
	public static final int width=400;
	public static final int height=400;
}

class DrawPanel extends JPanel
{
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
//		g.drawString("I love you",100,100);
		Graphics2D g2=(Graphics2D) g;
		float x=100;
		float y=100;
		float w=200;
		float h=150;
		Rectangle2D rect=new Rectangle2D.Float();
		rect.setRect(x,y,w,h+50); // Khong co tac dung
		rect.setFrameFromDiagonal(x+w,y+h,x,y);
//		Rectangle2D rect=new Rectangle2D.Float(x,y,w,h);
		g2.draw(rect);
		g2.draw(new Line2D.Float(x+w,y+h,x,y));
		g2.draw(new Line2D.Float(x+w,y,x,y+h));
		Ellipse2D e=new Ellipse2D.Float();
		e.setFrame(rect);
		g2.draw(e);
		float cX=(float) rect.getCenterX();
		float cY=(float) rect.getCenterY();
		float radius=150;
		Ellipse2D circle=new Ellipse2D.Float();
		for (radius=10;radius<=230;radius+=3)
		{
			circle.setFrameFromCenter(cX,cY,cX+radius,cY+radius);
			g2.draw(circle);
		}
	}
}