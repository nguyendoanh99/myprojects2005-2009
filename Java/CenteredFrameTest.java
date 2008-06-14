/*
 * Author: Nguyen Dang Khoa
 * Created: 08 tha´ng chi´n 2004 12:50:49 CH
 * Modified: 08 tha´ng chi´n 2004 12:50:49 CH
 */

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
public class CenteredFrameTest
{
	public static void main(String[] args)
	{
		CenteredFrame frame=new CenteredFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
		frame.toBack();
		frame.setResizable(false);
	}
}

class CenteredFrame extends JFrame
{
	public CenteredFrame()
	{
		Toolkit kit=Toolkit.getDefaultToolkit();
		Dimension screenSize=kit.getScreenSize();
		int screenHeight=screenSize.height;
		int screenWidth=screenSize.width;
//		setSize(screenWidth/2,screenHeight/2);
//		setLocation(screenWidth/4,screenHeight/4);
		setBounds(screenWidth/4,screenHeight/4,screenWidth/2,screenHeight/2);
		//Image img=kit.getImage("F:/downloads/images/sedna.jpg");
		setIconImage(kit.getImage("F:/downloads/images/sedna.jpg"));
		setTitle("CenteredFrame");
	}
}
