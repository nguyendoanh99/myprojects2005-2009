/*
 * Author: Nguyen Dang Khoa
 * Created: 18 tha´ng ta´m 2004 10:38:57 SA
 * Modified: 18 tha´ng ta´m 2004 10:38:57 SA
 */

/*
 * Tao lich don gian
 */

import java.util.*;
public class CalendarTest
{
	public static void main(String[] args)
	{
		GregorianCalendar d=new GregorianCalendar();
		System.out.println("Sun Mon Tue Wed Thu Fri Sat");
		int today=d.get(Calendar.DAY_OF_MONTH);
		int month=d.get(Calendar.MONTH);
		d.set(Calendar.DAY_OF_MONTH,1);
		int week=d.get(Calendar.DAY_OF_WEEK);
		for (int i=Calendar.SUNDAY;i<week;i++) System.out.print("    ");
		do
		{
			int day=d.get(Calendar.DAY_OF_MONTH);
			if (day<10) System.out.print("0");
			System.out.print(day);
			if (day==today) System.out.print("* ");
			else System.out.print("  ");
			if (week==Calendar.SATURDAY) System.out.println();
			d.add(Calendar.DAY_OF_MONTH,1);
			week=d.get(Calendar.DAY_OF_WEEK);
		}
		while (d.get(Calendar.MONTH)==month);
	}
}
