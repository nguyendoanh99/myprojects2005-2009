
import java.awt.event.KeyEvent;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.Event;
import java.awt.BorderLayout;
import javax.swing.SwingConstants;
import javax.swing.SwingUtilities;
import javax.swing.KeyStroke;
import java.awt.Point;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JMenuItem;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JFrame;
import javax.swing.JDialog;
import javax.swing.JScrollPane;
import java.awt.Dimension;
import javax.swing.JList;
import java.awt.Rectangle;
import javax.swing.JProgressBar;
import javax.swing.JButton;
import javax.swing.JEditorPane;
import javax.swing.JPasswordField;
import java.awt.GridBagLayout;
import javax.swing.BorderFactory;
import javax.swing.border.TitledBorder;
import java.awt.Font;
import java.awt.Color;
import javax.swing.JTextField;
import java.awt.GridBagConstraints;
import javax.swing.ListModel;
import javax.swing.event.ListDataListener;
import java.lang.Object;
import javax.swing.DefaultListModel;
import javax.swing.ListSelectionModel;
import javax.swing.JCheckBox;
import javax.swing.JScrollBar;
import java.awt.ComponentOrientation;

/**
 * 
 */

/**
 * @author DangKhoa
 *
 */
public class MainForm {

	private JFrame jFrame;  //  @jve:decl-index=0:visual-constraint="10,10"

	private JPanel jContentPane;


	private JLabel jLabel = null;

	private JButton jButtonOK = null;
	
	public static _DAOGenerator mDao = new _DAOGenerator();

	private JPanel jPanelDao = null;

	private JLabel jLabel1 = null;

	private JList jLstDatabase = null;

	private JList jLstTable = null;

	private JButton jButChonTatCa = null;

	private JButton jButBoChonTatCa = null;

	private JCheckBox jChkUser = null;

	private JProgressBar jProgressBar = null;

	private JScrollPane jScrollPane = null;

	private void LoadTable(JList list, String database, boolean system)
	{
										
		DefaultListModel listmodel = (DefaultListModel) list.getModel();
		
		mDao.ConnectDatabase(database);
		String[] arrTable = mDao.GetTable(system);
		listmodel.clear();
		
		for (int i = 0; i < arrTable.length; ++i)
		{
			listmodel.addElement(arrTable[i]);
		}
	}
	
	private void SelectAll(JList list)
	{
		DefaultListModel listmodel = (DefaultListModel) list.getModel();
		jLstTable.setSelectionInterval(0, listmodel.getSize() - 1);	
	}
	/**
	 * 
	 */
	public MainForm() {
		// TODO Auto-generated constructor stub
		
		getJFrame();
		String[] arrDatabase = mDao.GetDatabases();
		DefaultListModel listmodel = (DefaultListModel) jLstDatabase.getModel();
		
		for (int i = 0; i < arrDatabase.length; ++i)
		{
			listmodel.addElement(arrDatabase[i]);
		}
		System.out.println(listmodel.getSize());
	}

	/**
	 * This method initializes jButtonOK	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButtonOK() {
		if (jButtonOK == null) {
			try {
				jButtonOK = new JButton();
				jButtonOK.setText("Thực thi");  // Generated
				jButtonOK.setBounds(new Rectangle(456, 126, 118, 25));  // Generated
				jButtonOK.setEnabled(true);  // Generated
				jButtonOK.setName("");  // Generated
				jButtonOK.addActionListener(new java.awt.event.ActionListener() {   
					public void actionPerformed(java.awt.event.ActionEvent e) {
						
						Object[] arrTable = jLstTable.getSelectedValues();
						jProgressBar.setMaximum(arrTable.length);						
						
						for (int i = 0; i < arrTable.length; ++i)
						{
							// Entity class
							String entityclass = mDao.CreateEntityClass(arrTable[i].toString());
							_File f = new _File();
							System.out.println(arrTable[i].toString() + ".java");
							String FileName = arrTable[i].toString() + ".java";
							f.WriteFile(FileName, entityclass);
							
							// Dao class
							String[] daoclass = mDao.CreateDaoClass(arrTable[i].toString());
							f = new _File();
							FileName = arrTable[i].toString() + "Dao.java";
							f.WriteFile(FileName, daoclass);
							
							System.out.println(arrTable[i].toString() + "Dao.java");
						}
						
						JOptionPane.showMessageDialog(jFrame, "Đã tạo xong");
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButtonOK;
	}

	/**
	 * This method initializes jPanelDao	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanelDao() {
		if (jPanelDao == null) {
			try {
				jLabel1 = new JLabel();
				jLabel1.setBounds(new Rectangle(200, 24, 234, 14));  // Generated
				jLabel1.setText("Chọn table để tạo lớp Entity và lớp Dao");  // Generated
				jPanelDao = new JPanel();
				jPanelDao.setLayout(null);  // Generated
				jPanelDao.setBounds(new Rectangle(1, 4, 615, 369));  // Generated
				jPanelDao.setBorder(BorderFactory.createTitledBorder(null, "Dao Generator", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanelDao.setEnabled(false);  // Generated
				jPanelDao.add(jLabel, null);  // Generated
				jPanelDao.add(getJButtonOK(), null);  // Generated
				jPanelDao.add(jLabel1, null);  // Generated
				jPanelDao.add(getJLstDatabase(), null);  // Generated
				jPanelDao.add(getJButChonTatCa(), null);  // Generated
				jPanelDao.add(getJButBoChonTatCa(), null);  // Generated
				jPanelDao.add(getJChkUser(), null);  // Generated
				jPanelDao.add(getJProgressBar(), null);  // Generated
				jPanelDao.add(getJScrollPane(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanelDao;
	}

	/**
	 * This method initializes jLstDatabase	
	 * 	
	 * @return javax.swing.JList	
	 */
	private JList getJLstDatabase() {
		if (jLstDatabase == null) {
			try {
				jLstDatabase = new JList();
				jLstDatabase.setBounds(new Rectangle(15, 49, 172, 235));  // Generated
				jLstDatabase.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);  // Generated
				jLstDatabase.setModel(new DefaultListModel());  // Generated
				jLstDatabase
						.addListSelectionListener(new javax.swing.event.ListSelectionListener() {
							public void valueChanged(javax.swing.event.ListSelectionEvent e) {
								if (jLstDatabase.getSelectedIndex() != -1)
								{
									String database = jLstDatabase.getSelectedValue().toString();
									boolean system = jChkUser.isSelected();
									LoadTable(jLstTable, database, system);
									SelectAll(jLstTable);
								}
								System.out.println("valueChanged()"); // TODO Auto-generated Event stub valueChanged()
							}
						});
								
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jLstDatabase;
	}

	/**
	 * This method initializes jLstTable	
	 * 	
	 * @return javax.swing.JList	
	 */
	private JList getJLstTable() {
		if (jLstTable == null) {
			try {
				jLstTable = new JList();
				jLstTable.setModel(new DefaultListModel());  // Generated
				jLstTable.setComponentOrientation(ComponentOrientation.LEFT_TO_RIGHT);  // Generated
				jLstTable.setLayoutOrientation(JList.VERTICAL);
				jLstTable.setVisibleRowCount(-1);
				
//				JScrollPane listScroller = new JScrollPane(jLstTable);
				
//				listScroller.setPreferredSize(new Dimension(233, 80));

			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jLstTable;
	}

	/**
	 * This method initializes jButChonTatCa	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButChonTatCa() {
		if (jButChonTatCa == null) {
			try {
				jButChonTatCa = new JButton();
				jButChonTatCa.setBounds(new Rectangle(456, 53, 118, 25));  // Generated
				jButChonTatCa.setText("Chọn tất cả");  // Generated
				jButChonTatCa.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						SelectAll(jLstTable);
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButChonTatCa;
	}

	/**
	 * This method initializes jButBoChonTatCa	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButBoChonTatCa() {
		if (jButBoChonTatCa == null) {
			try {
				jButBoChonTatCa = new JButton();
				jButBoChonTatCa.setText("Bỏ chọn tất cả");  // Generated
				jButBoChonTatCa.setBounds(new Rectangle(456, 90, 118, 25));  // Generated
				jButBoChonTatCa.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						jLstTable.setSelectedIndices(new int[] {});
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButBoChonTatCa;
	}

	/**
	 * This method initializes jChkUser	
	 * 	
	 * @return javax.swing.JCheckBox	
	 */
	private JCheckBox getJChkUser() {
		if (jChkUser == null) {
			try {
				jChkUser = new JCheckBox();
				jChkUser.setBounds(new Rectangle(208, 290, 237, 25));  // Generated
				jChkUser.setText("Chỉ chọn những table thuộc loại User");  // Generated
				jChkUser.setSelected(true);  // Generated
				jChkUser.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						
						if (jLstDatabase.getSelectedIndex() != -1)
						{
							String database = jLstDatabase.getSelectedValue().toString();
							boolean system = jChkUser.isSelected();
							LoadTable(jLstTable, database, system);
							SelectAll(jLstTable);
						}						
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jChkUser;
	}

	/**
	 * This method initializes jProgressBar	
	 * 	
	 * @return javax.swing.JProgressBar	
	 */
	private JProgressBar getJProgressBar() {
		if (jProgressBar == null) {
			try {
				jProgressBar = new JProgressBar();
				jProgressBar.setBounds(new Rectangle(25, 340, 575, 18));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jProgressBar;
	}

	/**
	 * This method initializes jScrollPane	
	 * 	
	 * @return javax.swing.JScrollPane	
	 */
	private JScrollPane getJScrollPane() {
		if (jScrollPane == null) {
			try {
				jScrollPane = new JScrollPane();
				jScrollPane.setBounds(new Rectangle(201, 52, 231, 234));  // Generated
				jScrollPane.setViewportView(getJLstTable());  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jScrollPane;
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {

		// TODO Auto-generated method stub
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {				
//				LoginForm loginform = new LoginForm();
//				loginform.jFrame.setVisible(true);
				MainForm application = new MainForm();
				application.getJFrame().setVisible(true);
				
			}
		});
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
			jFrame.setSize(645, 414);
			jFrame.setResizable(false);  // Generated
			jFrame.setContentPane(getJContentPane());
			jFrame.setTitle("DaoGenerator");
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
			jLabel = new JLabel();
			jLabel.setText("Chọn database");  // Generated
			jLabel.setBounds(new Rectangle(14, 19, 115, 23));  // Generated
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
			jContentPane.add(getJPanelDao(), null);  // Generated

		}
		return jContentPane;
	}

}
