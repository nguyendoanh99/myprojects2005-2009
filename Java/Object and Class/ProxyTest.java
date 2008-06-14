/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng chi´n 2004 11:03:18 SA
 * Modified: 05 tha´ng chi´n 2004 11:03:18 SA
 */

import java.lang.reflect.*;
import java.util.*;

public class ProxyTest
{
	public static void main(String[] args)
	{
		Object[] elements=new Object[1000];
		for (int i=0; i<elements.length; i++)
		{
			Integer value=new Integer(i+1);
			Class[] interfaces=value.getClass().getInterfaces();
			InvocationHandler handler=new TraceHandler(value);
			Object proxy=Proxy.newProxyInstance(null, interfaces, handler);
			elements[i]=proxy;
		}
		Random generator=new Random();
		int r=generator.nextInt(elements.length);
		Integer key=new Integer(r+1);
		int result=Arrays.binarySearch(elements, key);
		if (result>=0) System.out.println(elements[result]);
	}
}

class TraceHandler implements InvocationHandler
{
	public TraceHandler(Object t)
	{
		target=t;
	}
	public Object invoke(Object proxy, Method m, Object[] args) throws Throwable
	{
		System.out.print(target);
		System.out.print("."+m.getName()+"(");
		if (args!=null)
		{
			for (int i=0; i<args.length; i++)
			{
				System.out.print(args[i]);
				if (i<args.length-1) System.out.print(", ");				
			}
		}
		System.out.println(")");
		return m.invoke(target, args);
	}
	private Object target;
}