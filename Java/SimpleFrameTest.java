/*
 * Author: Nguyen Dang Khoa
 * Created: 07 tha´ng chi´n 2004 1:51:50 CH
 * Modified: 07 tha´ng chi´n 2004 1:51:50 CH
 */

import javax.swing.*;

public class SimpleFrameTest
{
	public static void main(String[] args)
	{
		SimpleFrame frame=new SimpleFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
	}
}

class SimpleFrame extends JFrame
{
	public SimpleFrame()
	{
		setSize(WIDTH,HEIGHT);
	}
	public static final int WIDTH=300;
	public static final int HEIGHT=200;
}
