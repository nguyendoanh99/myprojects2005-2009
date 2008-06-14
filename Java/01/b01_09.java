/*
 * Author: Nguyen Dang Khoa
 * Created: 03 tha´ng ta´m 2004 10:42:15 SA
 * Modified: 03 tha´ng ta´m 2004 10:42:15 SA
 */

/* Nhap chieu cao (cm), vong nguc toi da (cm),
 * vong nguc toi thieu (cm), can nang (kg), 
 * sau do tinh roi in ra man hinh chi so Pignet 
 * tinh bang cong thuc:
 * CSTH=chieu cao-(trung binh vong nguc+trong luong)
 */
import javax.swing.JOptionPane;
public class b01_09
{
	public static void main(String[] args)
	{
		String cc=JOptionPane.showInputDialog("Chieu cao (cm)?");
		String td=JOptionPane.showInputDialog("Vong nguc toi da (cm)?");
		String tt=JOptionPane.showInputDialog("Vong nguc toi thieu (cm)?");
		String cn=JOptionPane.showInputDialog("Can nang (kg)?");
		float tbvn=0.5f*(Float.parseFloat(td)+Float.parseFloat(tt));
		float csth=Float.parseFloat(cc)-(tbvn+Float.parseFloat(cn));
		System.out.println("CSTH = "+csth);
	}
}
