/*
 * Author: Nguyen Dang Khoa
 * Created: 17 tha´ng chi´n 2004 11:48:55 SA
 * Modified: 17 tha´ng chi´n 2004 11:48:55 SA
 */

import javax.swing.*;
import java.awt.*;
import java.awt.font.*;
import java.awt.geom.*;

public class FontTest
{
	public static void main(String[] args)
	{
		FontFrame frame=new FontFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.show();
	}
}

class FontFrame extends JFrame
{
	public FontFrame()
	{
		setTitle("FontTest");
		Toolkit kit=Toolkit.getDefaultToolkit();
		Dimension d=kit.getScreenSize();
		Image img=kit.getImage("Sedna.jpg");
		int x=(d.width-WIDTH)/2;
		int y=(d.height-HEIGHT)/2;
		setBounds(x,y,WIDTH,HEIGHT);
		setIconImage(img);
		setResizable(false);
		Container c=getContentPane();
		FontPanel p=new FontPanel();
		p.setBackground(Color.black);
		c.add(p);
	}
	public static final int WIDTH=300;
	public static final int HEIGHT=200;
}

class FontPanel extends JPanel
{
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		Graphics2D g2=(Graphics2D) g;
		Font f=new Font("vni-times",Font.BOLD,30);
		g2.setFont(f);
		FontRenderContext context=g2.getFontRenderContext();
		Rectangle2D rect=f.getStringBounds(MESSAGE,context);
		double x=(getWidth()-rect.getWidth())/2;
		double y=(getHeight()-rect.getHeight())/2;
		double baseY=y-rect.getY();
		g2.setPaint(Color.red);
		g2.drawString(MESSAGE,(int) x,(int) baseY);
		g2.setPaint(Color.blue);
		Rectangle2D r1=new Rectangle2D.Double(x,y,rect.getWidth(),rect.getHeight());
		g2.draw(r1);
		g2.setPaint(Color.green);
		g2.draw(new Line2D.Double(x,baseY,rect.getWidth()+x,baseY));
/*		
		System.out.println(++dem);
		System.out.println(rect.getY());
		System.out.println("y="+y);
		System.out.println("baseY="+baseY);
		System.out.println(getHeight()+" "+rect.getHeight());
*/
	}
	public static final String MESSAGE="Nguyeãn Ñaêng Khoa";
	public static int dem=0;
}