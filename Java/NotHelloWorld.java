/*
 * Author: Nguyen Dang Khoa
 * Created: 09 tha´ng chi´n 2004 12:46:51 CH
 * Modified: 09 tha´ng chi´n 2004 12:46:51 CH
 */

import javax.swing.*;
import java.awt.*;

public class NotHelloWorld
{
	public static void main(String[] args)
	{
		NotHelloWorldFrame frame=new NotHelloWorldFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
	}
}

class NotHelloWorldFrame extends JFrame
{
	public NotHelloWorldFrame()
	{
		setTitle("NotHelloWorld");
		setSize(WIDTH,HEIGHT);
		NotHelloWorldPanel panel=new NotHelloWorldPanel();
		Container contentPane=getContentPane();
		contentPane.add(panel);
	}
	public static final int WIDTH=300;
	public static final int HEIGHT=200;
}

class NotHelloWorldPanel extends JPanel
{
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		g.drawString("Not a Hello, World program",X,Y);
	}
	public static final int X=75;
	public static final int Y=100;
}

