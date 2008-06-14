/*
 * Author: Nguyen Dang Khoa
 * Created: 01 tha´ng chi´n 2004 8:46:07 SA
 * Modified: 01 tha´ng chi´n 2004 8:46:07 SA
 */

import java.lang.reflect.*;
import javax.swing.JOptionPane;
public class ReflectionTest
{
	public static void main(String[] args)
	{
		String name;
		if (args.length>0) name=args[0];
		else name=JOptionPane.showInputDialog("Class name : ");
		try
		{
			Class supercl;
			do 
			{
				Class cl=Class.forName(name);
				supercl=cl.getSuperclass();
				System.out.print("class "+name);
				if (supercl!=null && supercl!=Object.class)
					System.out.print(" extends "+supercl.getName());
				System.out.print("\n{\n");
				showConstructors(cl);
				System.out.println();
				showMethods(cl);
				System.out.println();
				showFields(cl);
				System.out.println("}\n");
				if (supercl!=null) name=supercl.getName();
			}
			while (supercl!=null && supercl!=Object.class);
		}
		catch (ClassNotFoundException e)
		{
			e.printStackTrace();
		}
		System.exit(0);
	}
	public static void showConstructors(Class cl)
	{
		Constructor[] con=cl.getDeclaredConstructors();
		for (int i=0;i<con.length;i++)
		{
			Constructor c=con[i];
			System.out.print("\t"+Modifier.toString(c.getModifiers())+" "+c.getName()+"(");
			Class[] Pa=c.getParameterTypes();
			for (int j=0;j<Pa.length;j++)
			{
				if (j>0) System.out.print(", ");
				System.out.print(Pa[j].getName());
			}
			System.out.println(");");
		}
	}
	public static void showMethods(Class cl)
	{
		Method[] me=cl.getDeclaredMethods();
		for (int i=0;i<me.length;i++)
		{
			Method t=me[i];
			System.out.print("\t"+Modifier.toString(t.getModifiers())+" "+
				t.getReturnType().getName()+" "+t.getName()+"(");
			Class[] Pa=t.getParameterTypes();
			for (int j=0;j<Pa.length;j++)
			{
				if (j>0) System.out.print(", ");
				System.out.print(Pa[j].getName());
			}
			System.out.println(");");
		}
	}
	public static void showFields(Class cl)
	{
		Field[] Fi=cl.getDeclaredFields();
		for (int i=0;i<Fi.length;i++)
		{
			System.out.println("\t"+Modifier.toString(Fi[i].getModifiers())+" "+
				Fi[i].getType().getName()+" "+Fi[i].getName()+";");
		}
	}
}
