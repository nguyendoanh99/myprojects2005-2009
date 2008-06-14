/*
 * Author: Nguyen Dang Khoa
 * Created: 10 tha´ng ta´m 2004 7:32:03 SA
 * Modified: 10 tha´ng ta´m 2004 7:32:03 SA
 */

/*
 * Tuoi cua cha nam nay la 35, tuoi cua con nam nay la 4.
 * Hoi sau bao nhieu nam nua, tuoi cha gap doi tuoi con.
 */

public class b03_17
{
	public static void main(String[] args)
	{
		float cha=35;
		int con=4;
		int i=0;
		do
		{
			i++;
			cha++;
			con++;
		}
		while (cha/con!=2.0);
		System.out.println("Sau "+i+" nam thi tuoi cha gap doi tuoi con.");
	}
}
