/*
 * Author: Nguyen Dang Khoa
 * Created: 19 tha´ng chi´n 2004 8:49:23 SA
 * Modified: 19 tha´ng chi´n 2004 8:49:23 SA
 */

import javax.swing.*;
import java.awt.*;

public class ImageTest
{
	public static void main(String[] args)
	{
		ImageFrame frame=new ImageFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
	}
}

class ImageFrame extends JFrame
{
	public ImageFrame()
	{
		setTitle("ImageTest");
		Toolkit kit=Toolkit.getDefaultToolkit();
		Dimension d=kit.getScreenSize();
		Image img=kit.getImage("sedna.jpg");
		setIconImage(img);
		int w=d.width;
		int h=d.height;
		int x=(w-WIDTH)/2;
		int y=(h-HEIGHT)/2;
		setBounds(x,y,WIDTH,HEIGHT);
//		setResizable(false);
//		setLocation(x,y);
//		setSize(WIDTH,HEIGHT);
		ImagePanel p=new ImagePanel();
		Container c=getContentPane();
		c.add(p);
	}
	public static final int WIDTH=300;
	public static final int HEIGHT=200;
}

class ImagePanel extends JPanel
{
	public ImagePanel()
	{
		img=Toolkit.getDefaultToolkit().getImage("sedna.jpg");
		MediaTracker tracker=new MediaTracker(this);
		tracker.addImage(img,0);
		try
		{
			tracker.waitForID(0);
		}
		catch (InterruptedException e){}
	}
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		int imgWidth=img.getWidth(this);
		int imgHeight=img.getHeight(this);
		g.drawImage(img,0,0,null);
		for (int i=0;i*imgWidth<=getWidth();i++)
			for (int j=0;j*imgHeight<=getHeight();j++)
				if (i+j>0) g.copyArea(0,0,imgWidth,imgHeight,i*imgWidth,j*imgHeight);
	}
	private Image img;
}