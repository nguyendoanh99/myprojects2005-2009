
import java.awt.event.KeyEvent;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.Event;
import java.awt.BorderLayout;
import javax.swing.SwingConstants;
import javax.swing.SwingUtilities;
import javax.swing.KeyStroke;
import javax.swing.JOptionPane;
import java.awt.Point;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JMenuItem;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JFrame;
import javax.swing.JDialog;
import javax.swing.JTextField;
import java.awt.Rectangle;
import javax.swing.JPasswordField;
import java.awt.Dimension;
import javax.swing.JButton;

public class LoginForm {

	public JFrame jFrame;  //  @jve:decl-index=0:visual-constraint="16,11"

	private JPanel jContentPane;

	private JTextField jTxtUserName = null;

	private JPasswordField jPassword = null;

	private JButton jButLogin = null;

	private JLabel jLabel = null;

	private JLabel jLabel1 = null;

	public LoginForm()
	{
		getJFrame();
	}
	/**
	 * This method initializes jFrame
	 * 
	 * @return javax.swing.JFrame
	 */
	private JFrame getJFrame() {
		if (jFrame == null) {
			jFrame = new JFrame();
			jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			jFrame.setSize(382, 130);
			jFrame.setResizable(false);  // Generated
			jFrame.setContentPane(getJContentPane());
			jFrame.setTitle("Đăng nhập");
		}
		return jFrame;
	}

	/**
	 * This method initializes jContentPane
	 * 
	 * @return javax.swing.JPanel
	 */
	private JPanel getJContentPane() {
		if (jContentPane == null) {
			jLabel1 = new JLabel();
			jLabel1.setBounds(new Rectangle(15, 57, 83, 20));  // Generated
			jLabel1.setText("Password");  // Generated
			jLabel = new JLabel();
			jLabel.setBounds(new Rectangle(16, 18, 127, 21));  // Generated
			jLabel.setText("Username");  // Generated
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
			jContentPane.add(getJTxtUserName(), null);  // Generated
			jContentPane.add(getJPassword(), null);  // Generated
			jContentPane.add(getJButLogin(), null);  // Generated
			jContentPane.add(jLabel, null);  // Generated
			jContentPane.add(jLabel1, null);  // Generated
		}
		return jContentPane;
	}

	/**
	 * This method initializes jTxtUserName	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTxtUserName() {
		if (jTxtUserName == null) {
			try {
				jTxtUserName = new JTextField();
				jTxtUserName.setBounds(new Rectangle(79, 15, 175, 24));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTxtUserName;
	}

	/**
	 * This method initializes jPassword	
	 * 	
	 * @return javax.swing.JPasswordField	
	 */
	private JPasswordField getJPassword() {
		if (jPassword == null) {
			try {
				jPassword = new JPasswordField();
				jPassword.setBounds(new Rectangle(79, 54, 174, 23));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPassword;
	}

	/**
	 * This method initializes jButLogin	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButLogin() {
		if (jButLogin == null) {
			try {
				jButLogin = new JButton();
				jButLogin.setBounds(new Rectangle(272, 17, 99, 25));  // Generated
				jButLogin.setText("Đăng nhập");  // Generated
				jButLogin.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {						
						String username = jTxtUserName.getText();				
						String password = new String(jPassword.getPassword());
						String str = MainForm.mDao.Connect(username, password);
						if (str.length() == 0)
						{
							JOptionPane.showMessageDialog(jFrame, "Đã kết nối thành công");
							jFrame.setVisible(false);
							MainForm.main(null);							
						}
						else
							JOptionPane.showMessageDialog(jFrame,

					                "Username và Password không đúng. Mời bạn nhập lại.",

					                "Thông báo lỗi",

					                JOptionPane.ERROR_MESSAGE);

						System.out.println(str); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButLogin;
	}

	/**
	 * Launches this application
	 */
	public static void main(String[] args) {
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				LoginForm application = new LoginForm();
				application.getJFrame().setVisible(true);
			}
		});
	}

}
