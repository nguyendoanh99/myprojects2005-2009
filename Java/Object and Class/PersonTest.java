/*
 * Author: Nguyen Dang Khoa
 * Created: 27 tha´ng ta´m 2004 1:40:38 CH
 * Modified: 27 tha´ng ta´m 2004 1:40:38 CH
 */


public class PersonTest
{
	public static void main(String[] args)
	{
		Person[] people=new Person[2];
		people[0]=new Employee("1");
		Person p=people[0];
		System.out.println(p.get());
		System.out.println(p.getName()+ ", "+p.get());
	}
}
abstract class Person
{
	public Person(String n)
	{
		name=n;
	}
	public abstract String get();
	public String getName()
	{
		return name;
	}
	private String name;
}
class Employee extends Person
{
	public Employee(String n)
	{
		super(n);
	}
	public String get()
	{
		return "Mo ta";
	}
}