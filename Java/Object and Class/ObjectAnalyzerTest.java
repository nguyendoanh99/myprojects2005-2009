/*
 * Author: Nguyen Dang Khoa
 * Created: 01 tha´ng chi´n 2004 1:41:31 CH
 * Modified: 01 tha´ng chi´n 2004 1:41:31 CH
 */

import java.lang.reflect.*;
public class ObjectAnalyzerTest
{
	public static void main(String[] args)
	{
		System.out.println(toString(System.out));
	}
	public static String toString(Object obj)
	{
		Class cl=obj.getClass();
		String r=cl.getName();
		do
		{
			r+="[";
			Field[] fi=cl.getDeclaredFields();
			AccessibleObject.setAccessible(fi,true);
			for (int i=0;i<fi.length;i++)
			{
				Field t=fi[i];
				r+=t.getName()+"=";
				try
				{
					Object val=t.get(obj);
					r+=val.toString();
				}
				catch (Exception e)
				{
					e.printStackTrace();
				}
				if (i<fi.length-1) 
				{
					r+=", ";
					if ((i+1)%2==0) r+="\n";
				}
			}
			r+="] ";
			cl=cl.getSuperclass();
		}
		while (cl!=Object.class);
		return r;
	}
}
