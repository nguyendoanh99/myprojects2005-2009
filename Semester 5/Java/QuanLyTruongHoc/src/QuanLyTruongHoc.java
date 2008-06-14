import javax.swing.SwingConstants;
import javax.swing.SwingUtilities;

import javax.swing.DefaultListModel;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JFrame;
import javax.swing.JRadioButton;
import java.awt.Rectangle;
import javax.swing.JScrollPane;
import javax.swing.JList;
import javax.swing.BorderFactory;
import javax.swing.border.TitledBorder;
import java.awt.Font;
import java.awt.Color;
import javax.swing.JOptionPane;
import javax.swing.JButton;
import java.text.DateFormat;
import java.text.ParseException;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import javax.swing.JTextField;

import DAO.DuLieuDAO;
import DAO.HOCSINHDAO;
import DAO.KHOIDAO;
import DAO.LOPHOCDAO;
import DAO.TRUONGDAO;
import DTO.GIAOVIENDTO;
import DTO.HOCSINHDTO;
import DTO.KETQUAHOCTAPDTO;
import DTO.KHOIDTO;
import DTO.LOPHOCDTO;
import DTO.TRUONGDTO;
import javax.swing.ListSelectionModel;

/**
 * 
 */

/**
 * @author DangKhoa
 *
 */
public class QuanLyTruongHoc {

	private JFrame jFrame;  //  @jve:decl-index=0:visual-constraint="10,10"

	private JPanel jContentPane;

	private JRadioButton jRadioKhoi10 = null;

	private JRadioButton jRadioKhoi11 = null;

	private JRadioButton jRadioKhoi12 = null;

	private JPanel jPanelKhoi = null;

	private JScrollPane jSPDanhSachLop = null;

	private JList jListDanhSachLop = null;

	private JPanel jPanel = null;

	private JPanel jPanelLop = null;

	private JLabel jLabel = null;

	private JLabel jLabel1 = null;

	private JPanel jPanelGiaoVien = null;

	private JLabel jLabel2 = null;

	private JLabel jLabel21 = null;

	private JLabel jLabel22 = null;

	private JLabel jLabel23 = null;

	private JLabel jLabel24 = null;

	private JPanel jPanelDanhSachHocSinh = null;

	private JScrollPane jScrollPane = null;

	private JList jListDanhSachHocSinh = null;

	private JPanel jPanelThongTinHocSinh = null;

	private JLabel jLabel3 = null;

	private JLabel jLabel4 = null;

	private JLabel jLabel5 = null;

	private JLabel jLabel6 = null;

	private JLabel jLabel7 = null;

	private JPanel jPanelKQHT = null;

	private JLabel jLabel8 = null;

	private JLabel jLabel9 = null;

	private JLabel jLabel10 = null;

	private JLabel jLabel11 = null;

	private JButton jButThemLop = null;

	private JButton jButXoaLop = null;

	private JButton jButCapNhat = null;

	private JPanel jPanel1 = null;

	private JPanel jPanel11 = null;

	private JButton jButThemHocSinh = null;

	private JButton jButXoaHocSinh = null;

	private JButton jButCapNhatHocSinh = null;

	private JButton jButChuyenLop = null;

	private JTextField jTextMaHS = null;

	private JTextField jTextHoTenHS = null;

	private JTextField jTextNgaySinh = null;

	private JTextField jTextDiaChiHS = null;

	private JTextField jTextDienThoaiHS = null;

	private JTextField jTextToan = null;

	private JTextField jTextLy = null;

	private JTextField jTextHoa = null;

	private JTextField jTextDTB = null;

	private JTextField jTextMaLop = null;

	private JTextField jTextTenLop = null;

	private JTextField jTextMaGV = null;

	private JTextField jTextHoTenGV = null;

	private JTextField jTextTenTat = null;

	private JTextField jTextDiaChiGV = null;

	private JTextField jTextDienThoaiGV = null;

	private TRUONGDTO m_Truong = null;
	private KHOIDTO m_Khoi = null;
	private LOPHOCDTO m_Lop = null;  //  @jve:decl-index=0:
	private HOCSINHDTO m_HocSinh = null;  //  @jve:decl-index=0:
	private int flagRadio = -1;
	private JLabel jLabel12 = null;

	private JLabel jLabel13 = null;

	private JTextField jTextPhongHoc = null;

	private JTextField jTextGioHoc = null;

	private JLabel jLabel14 = null;
	private void XoaHocSinh(LOPHOCDTO lop, HOCSINHDTO hocsinh, JList list)
	{		
		DefaultListModel listmodel = (DefaultListModel) list.getModel();
		listmodel.removeElement(hocsinh);
		
		LOPHOCDAO lopdao = new LOPHOCDAO();
		lopdao.XoaHocSinh(lop, hocsinh);
	}
	
	private String KiemTraDiem(String str)
	{
		String kq = "";
		float value = 0;
		try 
		{
			value = Float.parseFloat(str);
			if (value < 0 || value > 10)
				kq += "\nĐiểm chỉ nằm trong khoảng [0, 10]";
		}
		catch (NumberFormatException nfe)
		{
			kq += "\nNhập sai điểm .";
		}
		return kq;
	}
	
	private void LoadThongTinHocSinh(HOCSINHDTO hocsinh)
	{
		String strMaHS = "";
		String strHoTenHS = "";
		String strDiaChiHS = "";
		String strDienThoaiHS = "";
		String strNgaySinh = "";
		String strToan = "";
		String strLy = "";
		String strHoa = "";
		String strDTB = "";
		
		if (hocsinh != null)
		{			
			strMaHS = hocsinh.getMaHocSinh();
			strHoTenHS = hocsinh.getHoTen();
			strDiaChiHS = hocsinh.getDiaChi();
			strDienThoaiHS = hocsinh.getDienThoai();
			DateFormat df = DateFormat.getDateInstance(DateFormat.SHORT, new Locale("vi", "VN"));
			strNgaySinh = df.format(hocsinh.getNamSinh());
			KETQUAHOCTAPDTO kqht = hocsinh.getKQHT();
			strToan = String.valueOf(kqht.getToan());
			strLy = String.valueOf(kqht.getLy());
			strHoa = String.valueOf(kqht.getHoa());
			strDTB = String.valueOf(kqht.getDTB());
		}
		
		jTextMaHS.setText(strMaHS);
		jTextHoTenHS.setText(strHoTenHS);
		jTextNgaySinh.setText(strNgaySinh);
		jTextDiaChiHS.setText(strDiaChiHS);
		jTextDienThoaiHS.setText(strDienThoaiHS);
		jTextToan.setText(strToan);
		jTextLy.setText(strLy);
		jTextHoa.setText(strHoa);
		jTextDTB.setText(strDTB);
	}
	private void LoadThongTinLopHoc(LOPHOCDTO lophoc)
	{
		String strMaLop = "";
		String strTenLop = "";
		String strMaGV = "";
		String strHoTenGV = "";
		String strDiaChiGV = "";
		String strDienThoaiGV = "";
		String strTenTat = "";
		String strPhongHoc = "";
		String strGioHoc = "";
		List<HOCSINHDTO> lsthocsinh = null;
		
		if (lophoc != null)
		{			
			strMaLop = lophoc.getMaLop();
			strTenLop = lophoc.getTenLop();
			strPhongHoc = lophoc.getPhongHoc();
			DateFormat df = DateFormat.getTimeInstance(DateFormat.SHORT, new Locale("vi", "VN"));
			strGioHoc = df.format(lophoc.getGioHoc());
			GIAOVIENDTO giaovien = lophoc.getGiaoVien();
			strMaGV = giaovien.getMaGiaoVien();
			strHoTenGV = giaovien.getHoTen();
			strDiaChiGV = giaovien.getDiaChi();
			strDienThoaiGV = giaovien.getDienThoai();
			strTenTat = giaovien.getTenTat();
			lsthocsinh = lophoc.getDanhSachHocSinh();
		}
		
		jTextMaLop.setText(strMaLop);
		jTextTenLop.setText(strTenLop);
		jTextMaGV.setText(strMaGV);
		jTextHoTenGV.setText(strHoTenGV);
		jTextDiaChiGV.setText(strDiaChiGV);
		jTextDienThoaiGV.setText(strDienThoaiGV);
		jTextTenTat.setText(strTenTat);
		jTextPhongHoc.setText(strPhongHoc);
		jTextGioHoc.setText(strGioHoc);
		LoadList(jListDanhSachHocSinh, lsthocsinh);
	}
	private void LoadList(JList list, List lst)
	{										
		DefaultListModel listmodel = (DefaultListModel) list.getModel();
		
		listmodel.clear();
		
		if (lst == null)
			return;
		
		for (int i = 0; i < lst.size(); ++i)
		{
			listmodel.addElement(lst.get(i));
		}
	}
	private String CapNhatLopHoc(LOPHOCDTO lophoc)
	{
		String kq = "";
		String strMaLop = jTextMaLop.getText();
		String strTenLop = jTextTenLop.getText();
		String strPhongHoc = jTextPhongHoc.getText();
		String strGioHoc = jTextGioHoc.getText();
		String strMaGV = jTextMaGV.getText();
		String strHoTenGV = jTextHoTenGV.getText();
		String strTenTat = jTextTenTat.getText();
		String strDiaChiGV = jTextDiaChiGV.getText();
		String strDienThoaiGV = jTextDienThoaiGV.getText();
		DateFormat df = DateFormat.getTimeInstance(DateFormat.SHORT, new Locale("vi", "VN"));
		Date d = null;
		try
		{
			d = df.parse(strGioHoc);	
		}
		catch (ParseException pe)
		{
			return "Nhập sai giờ học";
		}
		
		lophoc.setMaLop(strMaLop);
		lophoc.setTenLop(strTenLop);
		lophoc.setPhongHoc(strPhongHoc);
		lophoc.setGioHoc(d);
		GIAOVIENDTO giaovien = lophoc.getGiaoVien();
		giaovien.setMaGiaoVien(strMaGV);
		giaovien.setHoTen(strHoTenGV);
		giaovien.setTenTat(strTenTat);
		giaovien.setDiaChi(strDiaChiGV);
		giaovien.setDienThoai(strDienThoaiGV);
		
		LOPHOCDAO lophocdao = new LOPHOCDAO();
		if (lophocdao.CapNhatLopHoc(lophoc) == false)
			kq = "Không thể cập nhật được. \nKhông xác định được lỗi.";
		return kq;
	}
	private String CapNhatHocSinh(HOCSINHDTO hocsinh)
	{
		String kq = "";
		String strMaHS = jTextMaHS.getText();
		String strHoTen = jTextHoTenHS.getText();
		String strNgaySinh = jTextNgaySinh.getText();
		String strDiaChi = jTextDiaChiHS.getText();
		String strDienThoai = jTextDienThoaiHS.getText();
		String strToan = jTextToan.getText();
		String strLy = jTextLy.getText();
		String strHoa = jTextHoa.getText();		
		float Toan = 0;
		float Ly = 0;
		float Hoa = 0;
		
		DateFormat df = DateFormat.getDateInstance(DateFormat.SHORT, new Locale("vi", "VN"));
		Date d = null;
		try
		{
			d = df.parse(strNgaySinh);		
		}
		catch (ParseException pe)
		{
			kq += "\nNhập sai ngày sinh.";
		}
		// Toan
		try 
		{
			Toan = Float.parseFloat(strToan);
			if (Toan < 0 || Toan > 10)
				kq += "\nĐiểm toán chỉ nằm trong khoảng [0, 10]";
		}
		catch (NumberFormatException nfe)
		{
			kq += "\nNhập sai điểm toán.";
		}
		// Ly
		try 
		{
			Ly = Float.parseFloat(strLy);
			if (Ly < 0 || Ly > 10)
				kq += "\nĐiểm lý chỉ nằm trong khoảng [0, 10]";
		}
		catch (NumberFormatException nfe)
		{
			kq += "\nNhập sai điểm lý.";
		}
		// Hoa
		try 
		{
			Hoa = Float.parseFloat(strHoa);
			if (Hoa < 0 || Hoa > 10)
				kq += "\nĐiểm hóa chỉ nằm trong khoảng [0, 10]";
		}
		catch (NumberFormatException nfe)
		{
			kq += "\nNhập sai điểm hóa.";
		}
		
		if (kq.equals("") == false)
			return kq;
		
		hocsinh.setMaHocSinh(strMaHS);
		hocsinh.setHoTen(strHoTen);
		hocsinh.setNamSinh(d);
		hocsinh.setDiaChi(strDiaChi);
		hocsinh.setDienThoai(strDienThoai);
		KETQUAHOCTAPDTO kqht = hocsinh.getKQHT();
		kqht.setToan(Toan);
		kqht.setLy(Ly);
		kqht.setHoa(Hoa);
		kqht.TinhDTB();
		HOCSINHDAO hocsinhdao = new HOCSINHDAO();
		if (hocsinhdao.CapNhatThongTin(hocsinh) == false)
			kq = "Không thể cập nhật.\nLỗi không xác định.";
		
		return kq;
	}
	/**
	 * 
	 */
	public QuanLyTruongHoc() {
		// TODO Auto-generated constructor stub
		TRUONGDAO truongdao = new TRUONGDAO();
		m_Truong = truongdao.getTruong();		
	}

	/**
	 * This method initializes jRadioKhoi10	
	 * 	
	 * @return javax.swing.JRadioButton	
	 */
	private JRadioButton getJRadioKhoi10() {
		if (jRadioKhoi10 == null) {
			try {
				jRadioKhoi10 = new JRadioButton();
				jRadioKhoi10.setText("10");  // Generated
				jRadioKhoi10.setSelected(false);  // Generated
				jRadioKhoi10.setBounds(new Rectangle(7, 16, 47, 23));  // Generated
				jRadioKhoi10.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						if (jRadioKhoi10.isSelected() == false)
						{
							if (flagRadio == 1)
								jRadioKhoi10.setSelected(true);
							return;
						}
						flagRadio = 1; 
						
						jRadioKhoi11.setSelected(false);
						jRadioKhoi12.setSelected(false);
						
						jButThemLop.setEnabled(true);
						m_Khoi = m_Truong.getDanhSachKhoiHoc().get(0);
						List<LOPHOCDTO> lstLophoc = m_Khoi.getDanhSachLopHoc();
						LoadList(jListDanhSachLop, lstLophoc);
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jRadioKhoi10;
	}

	/**
	 * This method initializes jRadioKhoi11	
	 * 	
	 * @return javax.swing.JRadioButton	
	 */
	private JRadioButton getJRadioKhoi11() {
		if (jRadioKhoi11 == null) {
			try {
				jRadioKhoi11 = new JRadioButton();
				jRadioKhoi11.setText("11");  // Generated
				jRadioKhoi11.setBounds(new Rectangle(66, 17, 45, 23));  // Generated
				jRadioKhoi11.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						if (jRadioKhoi11.isSelected() == false)
						{
							if (flagRadio == 2)
								jRadioKhoi11.setSelected(true);
							return;
						}
						flagRadio = 2; 
						
						jButThemLop.setEnabled(true);
						jRadioKhoi10.setSelected(false);						
						jRadioKhoi12.setSelected(false);
						
						m_Khoi = m_Truong.getDanhSachKhoiHoc().get(1);
						List<LOPHOCDTO> lstLophoc = m_Khoi.getDanhSachLopHoc();
						LoadList(jListDanhSachLop, lstLophoc);
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jRadioKhoi11;
	}

	/**
	 * This method initializes jRadioKhoi12	
	 * 	
	 * @return javax.swing.JRadioButton	
	 */
	private JRadioButton getJRadioKhoi12() {
		if (jRadioKhoi12 == null) {
			try {
				jRadioKhoi12 = new JRadioButton();
				jRadioKhoi12.setText("12");  // Generated
				jRadioKhoi12.setBounds(new Rectangle(129, 17, 42, 23));  // Generated
				jRadioKhoi12.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						if (jRadioKhoi12.isSelected() == false)
						{
							if (flagRadio == 3)
								jRadioKhoi12.setSelected(true);
							return;
						}
						flagRadio = 3; 
						
						jButThemLop.setEnabled(true);
						jRadioKhoi10.setSelected(false);
						jRadioKhoi11.setSelected(false);						
						
						m_Khoi = m_Truong.getDanhSachKhoiHoc().get(2);
						List<LOPHOCDTO> lstLophoc = m_Khoi.getDanhSachLopHoc();
						LoadList(jListDanhSachLop, lstLophoc);
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jRadioKhoi12;
	}

	/**
	 * This method initializes jPanelKhoi	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanelKhoi() {
		if (jPanelKhoi == null) {
			try {
				jPanelKhoi = new JPanel();
				jPanelKhoi.setLayout(null);  // Generated
				jPanelKhoi.setBounds(new Rectangle(593, 54, 185, 45));  // Generated
				jPanelKhoi.setBorder(BorderFactory.createTitledBorder(null, "Kh\u1ed1i", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanelKhoi.add(getJRadioKhoi10(), null);  // Generated
				jPanelKhoi.add(getJRadioKhoi11(), null);  // Generated
				jPanelKhoi.add(getJRadioKhoi12(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanelKhoi;
	}

	/**
	 * This method initializes jSPDanhSachLop	
	 * 	
	 * @return javax.swing.JScrollPane	
	 */
	private JScrollPane getJSPDanhSachLop() {
		if (jSPDanhSachLop == null) {
			try {
				jSPDanhSachLop = new JScrollPane();
				jSPDanhSachLop.setBounds(new Rectangle(6, 20, 213, 498));  // Generated
				jSPDanhSachLop.setViewportView(getJListDanhSachLop());  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jSPDanhSachLop;
	}

	/**
	 * This method initializes jListDanhSachLop	
	 * 	
	 * @return javax.swing.JList	
	 */
	private JList getJListDanhSachLop() {
		if (jListDanhSachLop == null) {
			try {
				jListDanhSachLop = new JList();
				jListDanhSachLop.setModel(new DefaultListModel());  // Generated
				jListDanhSachLop.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);  // Generated
				jListDanhSachLop
						.addListSelectionListener(new javax.swing.event.ListSelectionListener() {
							public void valueChanged(javax.swing.event.ListSelectionEvent e) {
								
								int index = jListDanhSachLop.getSelectedIndex();
								if (index != -1)	
								{
									m_Lop = m_Khoi.getDanhSachLopHoc().get(index);
									jButXoaLop.setEnabled(true);
									jButCapNhat.setEnabled(true);
									jButThemHocSinh.setEnabled(true);
								}
								else
								{
									m_Lop = null;
									jButXoaLop.setEnabled(false);
									jButCapNhat.setEnabled(false);
									jButThemHocSinh.setEnabled(false);
								}
								
								LoadThongTinLopHoc(m_Lop);
								System.out.println("valueChanged()"); // TODO Auto-generated Event stub valueChanged()
							}
						});				
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jListDanhSachLop;
	}

	/**
	 * This method initializes jPanel	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanel() {
		if (jPanel == null) {
			try {
				jPanel = new JPanel();
				jPanel.setLayout(null);  // Generated
				jPanel.setBounds(new Rectangle(0, 94, 780, 524));  // Generated
				jPanel.setBorder(BorderFactory.createTitledBorder(null, "Danh sách l\u1edbp", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanel.add(getJSPDanhSachLop(), null);  // Generated
				jPanel.add(getJPanelLop(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanel;
	}

	/**
	 * This method initializes jPanelLop	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanelLop() {
		if (jPanelLop == null) {
			try {
				jLabel13 = new JLabel();
				jLabel13.setBounds(new Rectangle(189, 38, 56, 14));  // Generated
				jLabel13.setText("Giờ học");  // Generated
				jLabel12 = new JLabel();
				jLabel12.setBounds(new Rectangle(8, 38, 62, 14));  // Generated
				jLabel12.setText("Phòng học");  // Generated
				jLabel1 = new JLabel();
				jLabel1.setBounds(new Rectangle(186, 15, 59, 14));  // Generated
				jLabel1.setText("Tên lớp");  // Generated
				jLabel = new JLabel();
				jLabel.setBounds(new Rectangle(8, 13, 48, 14));  // Generated
				jLabel.setText("Mã lớp");  // Generated
				jPanelLop = new JPanel();
				jPanelLop.setLayout(null);  // Generated
				jPanelLop.setBorder(BorderFactory.createTitledBorder(null, "Thông tin l\u1edbp h\u1ecdc", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanelLop.setBounds(new Rectangle(226, 15, 547, 505));  // Generated
				jPanelLop.add(jLabel, null);  // Generated
				jPanelLop.add(jLabel1, null);  // Generated
				jPanelLop.add(getJPanelGiaoVien(), null);  // Generated
				jPanelLop.add(getJPanelDanhSachHocSinh(), null);  // Generated				
				jPanelLop.add(getJTextMaLop(), null);  // Generated
				jPanelLop.add(getJTextTenLop(), null);  // Generated
				jPanelLop.add(getJPanel1(), null);  // Generated
				jPanelLop.add(jLabel12, null);  // Generated
				jPanelLop.add(jLabel13, null);  // Generated
				jPanelLop.add(getJTextPhongHoc(), null);  // Generated
				jPanelLop.add(getJTextGioHoc(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanelLop;
	}

	/**
	 * This method initializes jPanelGiaoVien	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanelGiaoVien() {
		if (jPanelGiaoVien == null) {
			try {
				jLabel24 = new JLabel();
				jLabel24.setBounds(new Rectangle(9, 102, 60, 14));  // Generated
				jLabel24.setText("Điện thoại");  // Generated
				jLabel23 = new JLabel();
				jLabel23.setBounds(new Rectangle(9, 80, 60, 14));  // Generated
				jLabel23.setText("Địa chỉ");  // Generated
				jLabel22 = new JLabel();
				jLabel22.setBounds(new Rectangle(9, 58, 60, 14));  // Generated
				jLabel22.setText("Tên tắt");  // Generated
				jLabel21 = new JLabel();
				jLabel21.setBounds(new Rectangle(9, 36, 60, 14));  // Generated
				jLabel21.setText("Họ tên");  // Generated
				jLabel2 = new JLabel();
				jLabel2.setText("Mã GV");  // Generated
				jLabel2.setBounds(new Rectangle(9, 14, 43, 14));  // Generated
				jPanelGiaoVien = new JPanel();
				jPanelGiaoVien.setLayout(null);  // Generated
				jPanelGiaoVien.setBounds(new Rectangle(8, 65, 398, 132));  // Generated
				jPanelGiaoVien.setBorder(BorderFactory.createTitledBorder(null, "Thông tin giáo viên ch\u1ee7 nhi\u1ec7m", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanelGiaoVien.add(jLabel2, null);  // Generated
				jPanelGiaoVien.add(jLabel21, null);  // Generated
				jPanelGiaoVien.add(jLabel22, null);  // Generated
				jPanelGiaoVien.add(jLabel23, null);  // Generated
				jPanelGiaoVien.add(jLabel24, null);  // Generated
				jPanelGiaoVien.add(getJTextMaGV(), null);  // Generated
				jPanelGiaoVien.add(getJTextHoTenGV(), null);  // Generated
				jPanelGiaoVien.add(getJTextTenTat(), null);  // Generated
				jPanelGiaoVien.add(getJTextDiaChiGV(), null);  // Generated
				jPanelGiaoVien.add(getJTextDienThoaiGV(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanelGiaoVien;
	}

	/**
	 * This method initializes jPanelDanhSachHocSinh	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanelDanhSachHocSinh() {
		if (jPanelDanhSachHocSinh == null) {
			try {
				jPanelDanhSachHocSinh = new JPanel();
				jPanelDanhSachHocSinh.setLayout(null);  // Generated
				jPanelDanhSachHocSinh.setBounds(new Rectangle(8, 203, 532, 290));  // Generated
				jPanelDanhSachHocSinh.setBorder(BorderFactory.createTitledBorder(null, "Danh sách h\u1ecdc sinh", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanelDanhSachHocSinh.add(getJScrollPane(), null);  // Generated
				jPanelDanhSachHocSinh.add(getJPanelThongTinHocSinh(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanelDanhSachHocSinh;
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
				jScrollPane.setBounds(new Rectangle(7, 19, 166, 262));  // Generated
				jScrollPane.setViewportView(getJListDanhSachHocSinh());  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jScrollPane;
	}

	/**
	 * This method initializes jListDanhSachHocSinh	
	 * 	
	 * @return javax.swing.JList	
	 */
	private JList getJListDanhSachHocSinh() {
		if (jListDanhSachHocSinh == null) {
			try {
				jListDanhSachHocSinh = new JList();
				jListDanhSachHocSinh.setModel(new DefaultListModel());  // Generated
				jListDanhSachHocSinh.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);  // Generated
				jListDanhSachHocSinh
						.addListSelectionListener(new javax.swing.event.ListSelectionListener() {
							public void valueChanged(javax.swing.event.ListSelectionEvent e) {
								
								int index = jListDanhSachHocSinh.getSelectedIndex();
								if (index != -1)
								{
									m_HocSinh = m_Lop.getDanhSachHocSinh().get(index);
									jButXoaHocSinh.setEnabled(true);
									jButCapNhatHocSinh.setEnabled(true);
									jButChuyenLop.setEnabled(true);
								}
								else
								{
									m_HocSinh = null;
									jButXoaHocSinh.setEnabled(false);
									jButCapNhatHocSinh.setEnabled(false);
									jButChuyenLop.setEnabled(false);
								}
								LoadThongTinHocSinh(m_HocSinh);
								System.out.println("valueChanged()"); // TODO Auto-generated Event stub valueChanged()
							}
						});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jListDanhSachHocSinh;
	}

	/**
	 * This method initializes jPanelThongTinHocSinh	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanelThongTinHocSinh() {
		if (jPanelThongTinHocSinh == null) {
			try {
				jLabel7 = new JLabel();
				jLabel7.setBounds(new Rectangle(9, 113, 61, 14));  // Generated
				jLabel7.setText("Điện thoại");  // Generated
				jLabel6 = new JLabel();
				jLabel6.setBounds(new Rectangle(9, 89, 64, 14));  // Generated
				jLabel6.setText("Địa chỉ");  // Generated
				jLabel5 = new JLabel();
				jLabel5.setBounds(new Rectangle(9, 64, 65, 14));  // Generated
				jLabel5.setText("Ngày sinh");  // Generated
				jLabel4 = new JLabel();
				jLabel4.setBounds(new Rectangle(9, 41, 66, 14));  // Generated
				jLabel4.setText("Họ tên");  // Generated
				jLabel3 = new JLabel();
				jLabel3.setText("Mã HS");  // Generated
				jLabel3.setBounds(new Rectangle(9, 16, 64, 14));  // Generated
				jPanelThongTinHocSinh = new JPanel();
				jPanelThongTinHocSinh.setLayout(null);  // Generated
				jPanelThongTinHocSinh.setBounds(new Rectangle(179, 15, 345, 268));  // Generated
				jPanelThongTinHocSinh.setBorder(BorderFactory.createTitledBorder(null, "Thông tin h\u1ecdc sinh", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanelThongTinHocSinh.add(jLabel3, null);  // Generated
				jPanelThongTinHocSinh.add(jLabel4, null);  // Generated
				jPanelThongTinHocSinh.add(jLabel5, null);  // Generated
				jPanelThongTinHocSinh.add(jLabel6, null);  // Generated
				jPanelThongTinHocSinh.add(jLabel7, null);  // Generated
				jPanelThongTinHocSinh.add(getJPanelKQHT(), null);  // Generated
				jPanelThongTinHocSinh.add(getJPanel11(), null);  // Generated
				jPanelThongTinHocSinh.add(getJTextMaHS(), null);  // Generated
				jPanelThongTinHocSinh.add(getJTextHoTenHS(), null);  // Generated
				jPanelThongTinHocSinh.add(getJTextNgaySinh(), null);  // Generated
				jPanelThongTinHocSinh.add(getJTextDiaChiHS(), null);  // Generated
				jPanelThongTinHocSinh.add(getJTextDienThoaiHS(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanelThongTinHocSinh;
	}

	/**
	 * This method initializes jPanelKQHT	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanelKQHT() {
		if (jPanelKQHT == null) {
			try {
				jLabel11 = new JLabel();
				jLabel11.setBounds(new Rectangle(11, 88, 50, 14));  // Generated
				jLabel11.setText("ĐTB");  // Generated
				jLabel10 = new JLabel();
				jLabel10.setBounds(new Rectangle(11, 64, 37, 14));  // Generated
				jLabel10.setText("Hóa");  // Generated
				jLabel9 = new JLabel();
				jLabel9.setBounds(new Rectangle(11, 40, 36, 14));  // Generated
				jLabel9.setText("Lý");  // Generated
				jLabel8 = new JLabel();
				jLabel8.setText("Toán");  // Generated
				jLabel8.setBounds(new Rectangle(10, 15, 31, 14));  // Generated
				jPanelKQHT = new JPanel();
				jPanelKQHT.setLayout(null);  // Generated
				jPanelKQHT.setBounds(new Rectangle(9, 138, 325, 119));  // Generated
				jPanelKQHT.setBorder(BorderFactory.createTitledBorder(null, "K\u1ebft qu\u1ea3 h\u1ecdc t\u1eadp", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanelKQHT.add(jLabel8, null);  // Generated
				jPanelKQHT.add(jLabel9, null);  // Generated
				jPanelKQHT.add(jLabel10, null);  // Generated
				jPanelKQHT.add(jLabel11, null);  // Generated
				jPanelKQHT.add(getJTextToan(), null);  // Generated
				jPanelKQHT.add(getJTextLy(), null);  // Generated
				jPanelKQHT.add(getJTextHoa(), null);  // Generated
				jPanelKQHT.add(getJTextDTB(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanelKQHT;
	}

	/**
	 * This method initializes jButThemLop	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButThemLop() {
		if (jButThemLop == null) {
			try {
				jButThemLop = new JButton();
				jButThemLop.setText("Thêm lớp");  // Generated
				jButThemLop.setBounds(new Rectangle(10, 5, 90, 23));  // Generated
				jButThemLop.setEnabled(false);  // Generated
				jButThemLop.setName("jButThemLop");  // Generated
				jButThemLop.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						DuLieuDAO dulieudao = new DuLieuDAO();
						String strMaGiaoVien = dulieudao.TaoMaGiaoVien();
						String strMaLop = dulieudao.TaoMaLop();
						LOPHOCDTO lophocdto = new LOPHOCDTO();
						lophocdto.setMaLop(strMaLop);
						lophocdto.getGiaoVien().setMaGiaoVien(strMaGiaoVien);
						KHOIDAO khoidao = new KHOIDAO();
						khoidao.ThemLop(m_Khoi, lophocdto);
						m_Lop = lophocdto;						
						
						// Them vao list
						DefaultListModel listmodel = (DefaultListModel) jListDanhSachLop.getModel();
						listmodel.addElement(m_Lop);
						
						jListDanhSachLop.setSelectedIndex(m_Khoi.getDanhSachLopHoc().size() - 1);
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButThemLop;
	}

	/**
	 * This method initializes jButXoaLop	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButXoaLop() {
		if (jButXoaLop == null) {
			try {
				jButXoaLop = new JButton();
				jButXoaLop.setText("Xóa lớp");  // Generated
				jButXoaLop.setBounds(new Rectangle(10, 33, 90, 23));  // Generated
				jButXoaLop.setEnabled(false);  // Generated
				jButXoaLop.setName("jButXoaLop");  // Generated
				jButXoaLop.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						int kq = JOptionPane.showConfirmDialog(null, 
								"Bạn có chắc là muốn xóa lớp này không?", "Hỏi", JOptionPane.YES_NO_OPTION);
						
						if (kq != JOptionPane.YES_OPTION)
							return;
						
						LOPHOCDTO lop = m_Lop;
						
						DefaultListModel listmodel = (DefaultListModel) jListDanhSachLop.getModel();
						listmodel.removeElement(lop);
						
						KHOIDAO khoidao = new KHOIDAO();
						khoidao.XoaLop(m_Khoi, lop);
						
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButXoaLop;
	}

	/**
	 * This method initializes jButCapNhat	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButCapNhat() {
		if (jButCapNhat == null) {
			try {
				jButCapNhat = new JButton();
				jButCapNhat.setText("Cập nhật");  // Generated
				jButCapNhat.setBounds(new Rectangle(10, 61, 90, 23));  // Generated
				jButCapNhat.setEnabled(false);  // Generated
				jButCapNhat.setName("jButCapNhat");  // Generated
				jButCapNhat.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {						
						String str = CapNhatLopHoc(m_Lop);
						
						if (str.equals("") == true)
						{
							int index = jListDanhSachLop.getSelectedIndex();
							DefaultListModel listmodel = (DefaultListModel) jListDanhSachLop.getModel();
							listmodel.setElementAt(m_Lop, index);
							JOptionPane.showMessageDialog(jFrame,
					                "Cập nhật thông tin lớp học thành công",
					                "Thông báo",
					                JOptionPane.INFORMATION_MESSAGE);
						}
						else
						{
							JOptionPane.showMessageDialog(jFrame,
					                str,
					                "Thông báo lỗi",
					                JOptionPane.ERROR_MESSAGE);
						}
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButCapNhat;
	}

	/**
	 * This method initializes jPanel1	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanel1() {
		if (jPanel1 == null) {
			try {
				jPanel1 = new JPanel();
				jPanel1.setBorder(BorderFactory.createTitledBorder(null, "", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanel1.setLayout(null);  // Generated
				jPanel1.setBounds(new Rectangle(417, 15, 110, 90));  // Generated
				jPanel1.add(getJButThemLop(), null);  // Generated
				jPanel1.add(getJButXoaLop(), null);  // Generated
				jPanel1.add(getJButCapNhat(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanel1;
	}

	/**
	 * This method initializes jPanel11	
	 * 	
	 * @return javax.swing.JPanel	
	 */
	private JPanel getJPanel11() {
		if (jPanel11 == null) {
			try {
				jPanel11 = new JPanel();
				jPanel11.setLayout(null);  // Generated
				jPanel11.setBounds(new Rectangle(215, 14, 121, 118));  // Generated
				jPanel11.setBorder(BorderFactory.createTitledBorder(null, "", TitledBorder.DEFAULT_JUSTIFICATION, TitledBorder.DEFAULT_POSITION, new Font("Tahoma", Font.PLAIN, 11), Color.black));  // Generated
				jPanel11.add(getJButThemHocSinh(), null);  // Generated
				jPanel11.add(getJButXoaHocSinh(), null);  // Generated
				jPanel11.add(getJButCapNhatHocSinh(), null);  // Generated
				jPanel11.add(getJButChuyenLop(), null);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jPanel11;
	}

	/**
	 * This method initializes jButThemHocSinh	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButThemHocSinh() {
		if (jButThemHocSinh == null) {
			try {
				jButThemHocSinh = new JButton();
				jButThemHocSinh.setBounds(new Rectangle(8, 5, 105, 23));  // Generated
				jButThemHocSinh.setText("Thêm HS");  // Generated
				jButThemHocSinh.setEnabled(false);  // Generated
				jButThemHocSinh.setName("jButThemHS");  // Generated
				jButThemHocSinh.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						String strMaHocSinh = new DuLieuDAO().TaoMaHocSinh();
						HOCSINHDTO hocsinhdto = new HOCSINHDTO();
						hocsinhdto.setMaHocSinh(strMaHocSinh);
						LOPHOCDAO lophocdao = new LOPHOCDAO();
						lophocdao.ThemHocSinh(m_Lop, hocsinhdto);
						m_HocSinh = hocsinhdto;						
						
						// Them vao list
						DefaultListModel listmodel = (DefaultListModel) jListDanhSachHocSinh.getModel();
						listmodel.addElement(m_HocSinh);
						
						jListDanhSachHocSinh.setSelectedIndex(m_Lop.getDanhSachHocSinh().size() - 1);
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButThemHocSinh;
	}

	/**
	 * This method initializes jButXoaHocSinh	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButXoaHocSinh() {
		if (jButXoaHocSinh == null) {
			try {
				jButXoaHocSinh = new JButton();
				jButXoaHocSinh.setBounds(new Rectangle(8, 33, 105, 23));  // Generated
				jButXoaHocSinh.setText("Xóa HS");  // Generated
				jButXoaHocSinh.setEnabled(false);  // Generated
				jButXoaHocSinh.setName("jButXoaHS");  // Generated
				jButXoaHocSinh.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						int kq = JOptionPane.showConfirmDialog(null, 
								"Bạn có chắc là muốn xóa học sinh này không?", "Hỏi", JOptionPane.YES_NO_OPTION);
						
						if (kq != JOptionPane.YES_OPTION)
							return;

						XoaHocSinh(m_Lop, m_HocSinh, jListDanhSachHocSinh);
						m_HocSinh = null;
						
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButXoaHocSinh;
	}

	/**
	 * This method initializes jButCapNhatHocSinh	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButCapNhatHocSinh() {
		if (jButCapNhatHocSinh == null) {
			try {
				jButCapNhatHocSinh = new JButton();
				jButCapNhatHocSinh.setBounds(new Rectangle(8, 61, 105, 23));  // Generated
				jButCapNhatHocSinh.setText("Cập nhật");  // Generated
				jButCapNhatHocSinh.setEnabled(false);  // Generated
				jButCapNhatHocSinh.setName("jButCapNhatHS");  // Generated
				jButCapNhatHocSinh.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						String str = CapNhatHocSinh(m_HocSinh);
						
						if (str.equals("") == true)
						{
							int index = jListDanhSachHocSinh.getSelectedIndex();
							DefaultListModel listmodel = (DefaultListModel) jListDanhSachHocSinh.getModel();
							listmodel.setElementAt(m_HocSinh, index);
							JOptionPane.showMessageDialog(jFrame,
					                "Cập nhật thông tin học sinh thành công",
					                "Thông báo",
					                JOptionPane.INFORMATION_MESSAGE);
						}
						else
						{
							JOptionPane.showMessageDialog(jFrame,
					                str,
					                "Thông báo lỗi",
					                JOptionPane.ERROR_MESSAGE);
						}
							
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButCapNhatHocSinh;
	}

	/**
	 * This method initializes jButChuyenLop	
	 * 	
	 * @return javax.swing.JButton	
	 */
	private JButton getJButChuyenLop() {
		if (jButChuyenLop == null) {
			try {
				jButChuyenLop = new JButton();
				jButChuyenLop.setBounds(new Rectangle(8, 88, 105, 23));  // Generated
				jButChuyenLop.setText("Chuyển lớp");  // Generated
				jButChuyenLop.setEnabled(false);  // Generated
				jButChuyenLop.setName("jButChuyenLop");  // Generated
				jButChuyenLop.addActionListener(new java.awt.event.ActionListener() {
					public void actionPerformed(java.awt.event.ActionEvent e) {
						Object[] possibleValues = m_Khoi.getDanhSachLopHoc().toArray();
						Object selectedValue = JOptionPane.showInputDialog(null, 
						"Chọn lớp học muốn chuyển.", "Chọn lớp học muốn chuyển",
						JOptionPane.INFORMATION_MESSAGE, null,
						possibleValues, possibleValues[0]);
						
						if (selectedValue == null)
							return;
						
						if (selectedValue.equals(m_Lop) == true)
						{
							JOptionPane.showMessageDialog(jFrame,
					                "Không thể chuyển cùng một lớp.",
					                "Thông báo lỗi",
					                JOptionPane.ERROR_MESSAGE);
							return;
						}
						
						LOPHOCDAO lopdao = new LOPHOCDAO();
						HOCSINHDTO hocsinh = m_HocSinh;
						lopdao.ChuyenLop(m_Lop, (LOPHOCDTO) selectedValue, hocsinh);
						
						DefaultListModel listmodel = (DefaultListModel) jListDanhSachHocSinh.getModel();
						listmodel.removeElement(hocsinh);
						m_HocSinh = null;
						
						JOptionPane.showMessageDialog(jFrame,
				                "Chuyển lớp thành công.",
				                "Thông báo",
				                JOptionPane.INFORMATION_MESSAGE);
						System.out.println("actionPerformed()"); // TODO Auto-generated Event stub actionPerformed()						
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jButChuyenLop;
	}

	/**
	 * This method initializes jTextMaHS	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextMaHS() {
		if (jTextMaHS == null) {
			try {
				jTextMaHS = new JTextField();
				jTextMaHS.setBounds(new Rectangle(82, 16, 125, 20));  // Generated
				jTextMaHS.setEditable(false);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextMaHS;
	}

	/**
	 * This method initializes jTextHoTenHS	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextHoTenHS() {
		if (jTextHoTenHS == null) {
			try {
				jTextHoTenHS = new JTextField();
				jTextHoTenHS.setBounds(new Rectangle(82, 41, 125, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextHoTenHS;
	}

	/**
	 * This method initializes jTextNgaySinh	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextNgaySinh() {
		if (jTextNgaySinh == null) {
			try {
				jTextNgaySinh = new JTextField();
				jTextNgaySinh.setBounds(new Rectangle(82, 64, 125, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextNgaySinh;
	}

	/**
	 * This method initializes jTextDiaChiHS	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextDiaChiHS() {
		if (jTextDiaChiHS == null) {
			try {
				jTextDiaChiHS = new JTextField();
				jTextDiaChiHS.setBounds(new Rectangle(82, 89, 125, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextDiaChiHS;
	}

	/**
	 * This method initializes jTextDienThoaiHS	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextDienThoaiHS() {
		if (jTextDienThoaiHS == null) {
			try {
				jTextDienThoaiHS = new JTextField();
				jTextDienThoaiHS.setBounds(new Rectangle(82, 113, 125, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextDienThoaiHS;
	}

	/**
	 * This method initializes jTextToan	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextToan() {
		if (jTextToan == null) {
			try {
				jTextToan = new JTextField();
				jTextToan.setBounds(new Rectangle(73, 15, 240, 20));  // Generated				
				jTextToan.addCaretListener(new javax.swing.event.CaretListener() {
					public void caretUpdate(javax.swing.event.CaretEvent e) {
						if (m_HocSinh == null)
							return ;
						
						String str = jTextToan.getText();
						if (KiemTraDiem(str).equals("") == true)
						{
							KETQUAHOCTAPDTO kqht = m_HocSinh.getKQHT();
							kqht.setToan(Float.parseFloat(str));
							kqht.TinhDTB();
							jTextDTB.setText(String.valueOf(kqht.getDTB()));
						}
						else
						{
							jTextDTB.setText("NaN");
						}
						System.out.println("caretUpdate()"); // TODO Auto-generated Event stub caretUpdate()
					}
				});
				
				
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextToan;
	}

	/**
	 * This method initializes jTextLy	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextLy() {
		if (jTextLy == null) {
			try {
				jTextLy = new JTextField();
				jTextLy.setBounds(new Rectangle(73, 40, 240, 20));  // Generated
				
				jTextLy.addCaretListener(new javax.swing.event.CaretListener() {
					public void caretUpdate(javax.swing.event.CaretEvent e) {
						if (m_HocSinh == null)
							return ;
						
						String str = jTextLy.getText();
						if (KiemTraDiem(str).equals("") == true)
						{
							KETQUAHOCTAPDTO kqht = m_HocSinh.getKQHT();
							kqht.setLy(Float.parseFloat(str));
							kqht.TinhDTB();
							jTextDTB.setText(String.valueOf(kqht.getDTB()));
						}
						else
						{
							jTextDTB.setText("NaN");
						}
						System.out.println("caretUpdate()"); // TODO Auto-generated Event stub caretUpdate()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextLy;
	}

	/**
	 * This method initializes jTextHoa	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextHoa() {
		if (jTextHoa == null) {
			try {
				jTextHoa = new JTextField();
				jTextHoa.setBounds(new Rectangle(73, 64, 240, 20));  // Generated
		
				jTextHoa.addCaretListener(new javax.swing.event.CaretListener() {
					public void caretUpdate(javax.swing.event.CaretEvent e) {
						if (m_HocSinh == null)
							return ;
						
						String str = jTextHoa.getText();
						if (KiemTraDiem(str).equals("") == true)
						{
							KETQUAHOCTAPDTO kqht = m_HocSinh.getKQHT();
							kqht.setHoa(Float.parseFloat(str));
							kqht.TinhDTB();
							jTextDTB.setText(String.valueOf(kqht.getDTB()));
						}
						else
						{
							jTextDTB.setText("NaN");
						}
						System.out.println("caretUpdate()"); // TODO Auto-generated Event stub caretUpdate()
					}
				});
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextHoa;
	}

	/**
	 * This method initializes jTextDTB	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextDTB() {
		if (jTextDTB == null) {
			try {
				jTextDTB = new JTextField();
				jTextDTB.setBounds(new Rectangle(73, 88, 240, 20));  // Generated
				jTextDTB.setEditable(false);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextDTB;
	}

	/**
	 * This method initializes jTextMaLop	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextMaLop() {
		if (jTextMaLop == null) {
			try {
				jTextMaLop = new JTextField();
				jTextMaLop.setBounds(new Rectangle(72, 13, 107, 20));  // Generated
				jTextMaLop.setEditable(false);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextMaLop;
	}

	/**
	 * This method initializes jTextTenLop	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextTenLop() {
		if (jTextTenLop == null) {
			try {
				jTextTenLop = new JTextField();
				jTextTenLop.setBounds(new Rectangle(250, 15, 156, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextTenLop;
	}

	/**
	 * This method initializes jTextMaGV	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextMaGV() {
		if (jTextMaGV == null) {
			try {
				jTextMaGV = new JTextField();
				jTextMaGV.setBounds(new Rectangle(74, 14, 261, 20));  // Generated
				jTextMaGV.setEditable(false);  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextMaGV;
	}

	/**
	 * This method initializes jTextHoTenGV	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextHoTenGV() {
		if (jTextHoTenGV == null) {
			try {
				jTextHoTenGV = new JTextField();
				jTextHoTenGV.setBounds(new Rectangle(74, 36, 261, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextHoTenGV;
	}

	/**
	 * This method initializes jTextTenTat	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextTenTat() {
		if (jTextTenTat == null) {
			try {
				jTextTenTat = new JTextField();
				jTextTenTat.setBounds(new Rectangle(74, 58, 261, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextTenTat;
	}

	/**
	 * This method initializes jTextDiaChiGV	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextDiaChiGV() {
		if (jTextDiaChiGV == null) {
			try {
				jTextDiaChiGV = new JTextField();
				jTextDiaChiGV.setBounds(new Rectangle(74, 80, 261, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextDiaChiGV;
	}

	/**
	 * This method initializes jTextDienThoaiGV	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextDienThoaiGV() {
		if (jTextDienThoaiGV == null) {
			try {
				jTextDienThoaiGV = new JTextField();
				jTextDienThoaiGV.setBounds(new Rectangle(74, 102, 261, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextDienThoaiGV;
	}

	/**
	 * This method initializes jTextPhongHoc	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextPhongHoc() {
		if (jTextPhongHoc == null) {
			try {
				jTextPhongHoc = new JTextField();
				jTextPhongHoc.setBounds(new Rectangle(73, 38, 107, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextPhongHoc;
	}

	/**
	 * This method initializes jTextGioHoc	
	 * 	
	 * @return javax.swing.JTextField	
	 */
	private JTextField getJTextGioHoc() {
		if (jTextGioHoc == null) {
			try {
				jTextGioHoc = new JTextField();
				jTextGioHoc.setBounds(new Rectangle(250, 38, 156, 20));  // Generated
			} catch (java.lang.Throwable e) {
				// TODO: Something
			}
		}
		return jTextGioHoc;
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				QuanLyTruongHoc application = new QuanLyTruongHoc();
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
			jFrame.setBounds(new Rectangle(0, 0, 800, 650));  // Generated
			jFrame.setContentPane(getJContentPane());
			jFrame.setTitle("Quản lý trường học");
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
			jLabel14 = new JLabel();
			jLabel14.setBounds(new Rectangle(1, 1, 779, 55));  // Generated
			jLabel14.setHorizontalTextPosition(SwingConstants.CENTER);  // Generated
			jLabel14.setHorizontalAlignment(SwingConstants.CENTER);  // Generated
			jLabel14.setFont(new Font("Tahoma", Font.BOLD, 30));  // Generated
			jLabel14.setForeground(Color.blue);  // Generated
			jLabel14.setText("QUẢN LÝ TRƯỜNG HỌC");  // Generated
			jContentPane = new JPanel();
			jContentPane.setLayout(null);
			jContentPane.add(getJPanelKhoi(), null);  // Generated
			jContentPane.add(getJPanel(), null);  // Generated
			jContentPane.add(jLabel14, null);  // Generated
		}
		return jContentPane;
	}

}
