/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng chi´n 2004 10:02:27 SA
 * Modified: 05 tha´ng chi´n 2004 10:02:27 SA
 */

import java.util.*;
public class CloneTest
{
	public static void main(String[] args)
	{
		Employee original=new Employee("Join Q.Public", 50000);
		original.setPayDay(2000, 1, 1);
		Employee copy=(Employee) original.clone();
		copy.raiseSalary(10);
		copy.addPayDay(14);
		System.out.println("original="+original);
		System.out.println("copy="+copy);
	}
}
class Employee implements Cloneable
{
	public Employee(String n, double s)
	{
		name=n;
		salary=s;
	}
	public Object clone()
	{
		try
		{
			Employee cloned=(Employee) super.clone();
			cloned.payDay=(GregorianCalendar) payDay.clone();
			return cloned;
		}
		catch (CloneNotSupportedException e)
		{
			return null;
		}
	}
	public void setPayDay(int year, int month, int day)
	{
		payDay=new GregorianCalendar(year, month-1, day);
	}
	public void addPayDay(int days)
	{
		payDay.add(Calendar.DAY_OF_MONTH, days);
	}
	public Date getPayDay()
	{
		return payDay.getTime();
	}
	public void raiseSalary(double byPercent)
	{
		double raise=salary*byPercent/100;
		salary+=raise;
	}
	public String toString()
	{
		return "Employee [name="+name+", salary="+salary+", payDay="+getPayDay()+"]";
	}
	private String name;
	private double salary;
	private GregorianCalendar payDay;
}