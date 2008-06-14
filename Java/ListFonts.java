/*
 * Author: Nguyen Dang Khoa
 * Created: 16 tha´ng chi´n 2004 12:14:58 CH
 * Modified: 16 tha´ng chi´n 2004 12:14:58 CH
 */

import java.awt.*;

public class ListFonts
{
	public static void main(String[] args)
	{
		String[] fontNames=GraphicsEnvironment
			.getLocalGraphicsEnvironment()
			.getAvailableFontFamilyNames();
		System.out.println(fontNames.length);
		for (int i=0;i<fontNames.length;i++)
			System.out.println(fontNames[i]);
	}
	
}
