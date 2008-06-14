/*
 * Author: Nguyen Dang Khoa
 * Created: 08 tha´ng chi´n 2004 12:08:37 CH
 * Modified: 08 tha´ng chi´n 2004 12:08:37 CH
 */

import javax.swing.*;
public class SimpleFrame extends JFrame
{
	public static void main(String[] args)
	{
		SimpleFrame frame=new SimpleFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
	}
	public SimpleFrame()
	{
		setSize(WIDTH,HEIGHT);
	}
	public static final int WIDTH=300;
	public static final int HEIGHT=200;
}
