/*
 * Author: Nguyen Dang Khoa
 * Created: 05 tha´ng chi´n 2004 10:16:05 SA
 * Modified: 05 tha´ng chi´n 2004 10:16:05 SA
 */

import java.awt.event.*;
import java.text.*;
import javax.swing.*;

public class InnerClassTest
{
	public static void main(String[] args)
	{
		BankAccount account=new BankAccount(10000);
		account.start(10);
		JOptionPane.showMessageDialog(null,"Quit program?");
		System.exit(0);
	}
}

class BankAccount
{
	public BankAccount(double initialBalance)
	{
		balance=initialBalance;
	}
	public void start(final double rate)
	{
		class InterestAdder implements ActionListener
		{
//			public InterestAdder(double aRate)
//			{
//				rate=aRate;
//			}
			public void actionPerformed(ActionEvent event)
			{
				double interest=balance*rate/100;
				balance+=interest;
				NumberFormat formatter=NumberFormat.getCurrencyInstance();
				System.out.println("balance="+formatter.format(balance));
			}
//			private double rate;
		}
		ActionListener adder=new InterestAdder();
		Timer t=new Timer(1000,adder);
		t.start();
	}
	private double balance;
	
}