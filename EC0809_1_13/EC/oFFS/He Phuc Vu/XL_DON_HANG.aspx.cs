using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class He_Phuc_Vu_XL_DON_HANG : System.Web.UI.Page
{
    private string soTheOFFS = "67F0C7649B9574DECEA8740BB80B15615649E0C0";
    private string loaiTheOFFS = "MasterCard";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Xac_nhan"] == "Tinh_tien_khuyen_mai")
            Tinh_tien_khuyen_mai();
        else if (Request["Xac_nhan"] == "Dat_hang_customer")
            Dat_hang_customer();
        else if (Request["Xac_nhan"] == "Dat_hang_guest")
            Dat_hang_guest();
        else if (Request["Xac_nhan"] == "Dat_don_hang_da_luu")
            Dat_don_hang_da_luu();
        else if (Request["Xac_nhan"] == "Tinh_Tien_Thue")
            Tinh_tien_thue();
        else if (Request["Xac_nhan"] == "Tinh_so_diem_toi_da")
            Tinh_so_diem_toi_da();
        else if (Request["Xac_nhan"] == "Tinh_so_diem_hoan_lai")
            Tinh_so_diem_hoan_lai();
        else if (Request["Xac_nhan"] == "Luu_trang_thai_form")
            Luu_trang_thai_form();
        else if (Request["Xac_nhan"] == "Luu_trang_thai_form_dinh_ky")
            Luu_trang_thai_form_dinh_ky();
        else if (Request["Xac_nhan"] == "Lay_trang_thai_form")
            Lay_trang_thai_form();
        else if (Request["Xac_nhan"] == "Lay_trang_thai_form_dinh_ky")
            Lay_trang_thai_form_dinh_ky();
      
    }
    protected void Lay_trang_thai_form_dinh_ky()
    {
        if (Session["FormDatHangDinhKy"] != null)
        {
            FormDatHangDinhKy form = (FormDatHangDinhKy)Session["FormDatHangDinhKy"];
            XL_THE the = new XL_THE("Goc");

            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbDiemSD", form.cmbDiemSD.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("lbSoTien", form.lbSoTien));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbHTKM", form.cmbHTKM.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbHTTT", form.cmbHTTT.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("rdThe", form.rdThe));
            if (form.rdThe == "rdKhac")
            {
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeLoaiThe", form.nodeLoaiThe.ToString()));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeSoThe", form.nodeSoThe));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeNgayHH", form.nodeNgayHH.ToString()));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeThangHH", form.nodeThangHH.ToString()));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeNamHH", form.nodeNamHH.ToString()));
            }
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("txtNguoiNhan", form.txtNguoiNhan));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("txtDiaChiNhan", form.txtDiaChiNhan));

            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbLoaiDK", form.cmbLoaiDK.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbNgayBD", form.cmbNgayBD.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbThangBD", form.cmbThangBD.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbNamBD", form.cmbNamBD.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbNgayKT", form.cmbNgayKT.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbThangKT", form.cmbThangKT.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbNamKT", form.cmbNamKT.ToString()));
       
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbGioGH", form.cmbGioGH.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbPhutGH", form.cmbPhutGH.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbBuoiGH", form.cmbBuoiGH.ToString()));

            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("chuoiDS", form.chuoiDS));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("chuoiDSChon", form.chuoiDSChon));

            string chuoi = the.Chuoi();
            XL_CHUOI.XuatChuoi(Response, chuoi);
        }
    }

    protected void Luu_trang_thai_form_dinh_ky()
    {
        FormDatHangDinhKy form = new FormDatHangDinhKy();
        form.cmbDiemSD = int.Parse(Request["cmbDiemSD"].ToString());
        form.lbSoTien = Request["lbSoTien"].ToString();
        form.cmbHTKM = int.Parse(Request["cmbHTKM"].ToString());
        form.cmbHTTT = int.Parse(Request["cmbHTTT"].ToString());
        form.rdThe = Request["rdThe"].ToString();

        if (form.rdThe == "rdKhac")
        {
            form.nodeLoaiThe = int.Parse(Request["nodeLoaiThe"].ToString());
            form.nodeSoThe = Request["nodeSoThe"].ToString();
            form.nodeNgayHH = int.Parse(Request["nodeNgayHH"].ToString());
            form.nodeThangHH = int.Parse(Request["nodeThangHH"].ToString());
            form.nodeNamHH = int.Parse(Request["nodeNamHH"].ToString());
        }

        form.txtNguoiNhan = Request["txtNguoiNhan"].ToString();
        form.txtDiaChiNhan = Request["txtDiaChiNhan"].ToString();
        form.cmbLoaiDK = int.Parse(Request["cmbLoaiDK"].ToString());
        form.cmbNgayBD = int.Parse(Request["cmbNgayBD"].ToString());
        form.cmbThangBD = int.Parse(Request["cmbThangBD"].ToString());
        form.cmbNamBD = int.Parse(Request["cmbNamBD"].ToString());
        form.cmbNgayKT = int.Parse(Request["cmbNgayKT"].ToString());
        form.cmbThangKT = int.Parse(Request["cmbThangKT"].ToString());
        form.cmbNamKT = int.Parse(Request["cmbNamKT"].ToString());
        form.cmbGioGH = int.Parse(Request["cmbGioGH"].ToString());
        form.cmbPhutGH = int.Parse(Request["cmbPhutGH"].ToString());
        form.cmbBuoiGH = int.Parse(Request["cmbBuoiGH"].ToString());

        form.chuoiDS = Request["chuoiDS"].ToString();
        form.chuoiDSChon = Request["chuoiDSChon"].ToString();

        Session["FormDatHangDinhKy"] = form; 
    }

    protected void Lay_trang_thai_form()
    {
        if (Session["FormDatHang"] != null)
        {
            FormDatHang form = (FormDatHang)Session["FormDatHang"];
            XL_THE the = new XL_THE("Goc");

            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbDiemSD", form.cmbDiemSD.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("lbSoTien", form.lbSoTien));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbHTKM", form.cmbHTKM.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbHTTT", form.cmbHTTT.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("rdThe", form.rdThe));
            if (form.rdThe == "rdKhac")
            {
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeLoaiThe", form.nodeLoaiThe.ToString()));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeSoThe", form.nodeSoThe));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeNgayHH", form.nodeNgayHH.ToString()));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeThangHH", form.nodeThangHH.ToString()));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("nodeNamHH", form.nodeNamHH.ToString()));
            }
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("txtNguoiNhan", form.txtNguoiNhan));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("txtDiaChiNhan", form.txtDiaChiNhan));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbNgayGH", form.cmbNgayGH.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbThangGH", form.cmbThangGH.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbNamGH", form.cmbNamGH.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbGioGH", form.cmbGioGH.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbPhutGH", form.cmbPhutGH.ToString()));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("cmbBuoiGH", form.cmbBuoiGH.ToString()));

            string chuoi = the.Chuoi();
            XL_CHUOI.XuatChuoi(Response, chuoi);
        }
    }

    protected void Luu_trang_thai_form()
    {
        FormDatHang form = new FormDatHang();
        form.cmbDiemSD = int.Parse(Request["cmbDiemSD"].ToString());
        form.lbSoTien = Request["lbSoTien"].ToString();
        form.cmbHTKM = int.Parse(Request["cmbHTKM"].ToString());
        form.cmbHTTT = int.Parse(Request["cmbHTTT"].ToString());
        form.rdThe = Request["rdThe"].ToString();

        if (form.rdThe == "rdKhac")
        {
            form.nodeLoaiThe = int.Parse(Request["nodeLoaiThe"].ToString());
            form.nodeSoThe = Request["nodeSoThe"].ToString();
            form.nodeNgayHH = int.Parse(Request["nodeNgayHH"].ToString());
            form.nodeThangHH = int.Parse(Request["nodeThangHH"].ToString());
            form.nodeNamHH = int.Parse(Request["nodeNamHH"].ToString());
        }

        form.txtNguoiNhan = Request["txtNguoiNhan"].ToString();
        form.txtDiaChiNhan = Request["txtDiaChiNhan"].ToString();
        form.cmbNgayGH = int.Parse(Request["cmbNgayGH"].ToString());
        form.cmbThangGH = int.Parse(Request["cmbThangGH"].ToString());
        form.cmbNamGH = int.Parse(Request["cmbNamGH"].ToString());
        form.cmbGioGH = int.Parse(Request["cmbGioGH"].ToString());
        form.cmbPhutGH = int.Parse(Request["cmbPhutGH"].ToString());
        form.cmbBuoiGH = int.Parse(Request["cmbBuoiGH"].ToString());

        Session["FormDatHang"] = form; 
    }

    protected void Tinh_so_diem_toi_da()
    {
        decimal giatri = int.Parse(Request["GiaTri"].ToString());
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];
        int diemht = vkhDto.Diem_khuyen_mai;
        
        int diem = (new DonHangBUS()).TinhSoDiemToiDa(giatri, diemht);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("Kq", diem.ToString());

        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    protected void Tinh_so_diem_hoan_lai()
    {
        decimal tiendu = int.Parse(Request["tiendu"].ToString());

        int diemhoanlai = (new DonHangBUS()).TinhDiemHoanLai(tiendu);
        if (diemhoanlai != 0)
        {
            XL_THE the = new XL_THE("goc");

            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("Kq", diemhoanlai.ToString()));
            string chuoi = the.Chuoi();
            XL_CHUOI.XuatChuoi(Response, chuoi);
        }
    }

    protected void Tinh_tien_thue()
    {
        Gio_hang_online gio_hang = (Gio_hang_online)Session["Gio_hang"];
        decimal giatri = gio_hang.gia_tri;
        decimal a = (new DonHangBUS()).TinhTienThue(giatri);
        double tienthue = double.Parse(a.ToString());
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("Kq", tienthue.ToString());

        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    protected void Tinh_tien_khuyen_mai()
    {
        int diem = int.Parse(Request["DiemKhuyenMai"].ToString());
        decimal tien = (new DonHangBUS()).TinhTienKhuyenMai(diem);
        
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("Kq", tien.ToString());

        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    protected void Dat_don_hang_da_luu()
    {
        int madonhang = int.Parse(Session["madonhangluu"].ToString());
        XL_THE the = new XL_THE("goc");

        try
        {
            (new DonHangBUS()).CapNhatTrangThaiDaDatHang(madonhang, true);
        }
        catch (Exception ex)
        {
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang loi"));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
            XL_CHUOI.XuatChuoi(Response, the.Chuoi());
            return;
        }

        the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang thanh cong"));
        the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "true"));
        XL_CHUOI.XuatChuoi(Response, the.Chuoi());

        Session["madonhangluu"] = null;
        return;
    }

    protected void Dat_hang_customer()
    {
        DonHangDTO donhang = new DonHangDTO();
        DonHangDinhKyDTO donhangdk = new DonHangDinhKyDTO();

        //Xac dinh tham so
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];
        donhang.Ma_khach_hang = vkhDto.Ma_nguoi_dung;
        donhang.Ngay_gio_lap = DateTime.Parse(Request["Ngay_lap"].ToString());
        donhang.Dia_chi_nhan = Request["Dia_chi_nhan"];
        donhang.Nguoi_nhan = Request["Nguoi_nhan"];
        donhang.Hinh_thuc_khuyen_mai = int.Parse(Request["HTKM"].ToString());
        donhang.Tien_khuyen_mai = decimal.Parse(Request["Tien_khuyen_mai"].ToString());
        donhang.Gia_tri = decimal.Parse(Request["Gia_tri"].ToString());
        donhang.Ma_hinh_thuc_thanh_toan = int.Parse(Request["HTTT"].ToString());

        int loaiyeucau = int.Parse(Request["Loai_yeu_cau"].ToString());
        if (loaiyeucau == 0 || loaiyeucau == 1) //lưu or đặt hàng bình thường
        {
            donhang.Loai_don_dat_hang = 0;  //don hang binh thuong
            donhang.Ngay_gio_giao_hang = DateTime.Parse(Request["Ngay_giao"].ToString());
            if (loaiyeucau == 0)
                donhang.Da_dat_hang = false;
            else
                donhang.Da_dat_hang = true;
        }
        else if (loaiyeucau == 2 || loaiyeucau == 3)   //lưu or đặt hàng định kỳ
        {
            donhang.Loai_don_dat_hang = 1; //đơn hàng định kỳ
            if (loaiyeucau == 2)
                donhang.Da_dat_hang = false;
            else
                donhang.Da_dat_hang = true;

            donhangdk.Loai_dinh_ky = Request["Loai_dk"].ToString();
            donhangdk.Ngay_bat_dau = DateTime.Parse(Request["Ngay_bd"].ToString());
            donhangdk.Ngay_ket_thuc = DateTime.Parse(Request["Ngay_kt"].ToString());
            if (donhangdk.Loai_dinh_ky == "Hang Tuan")
                donhangdk.Thu_giao = Request["Thoi_gian_giao"].ToString();
            else if (donhangdk.Loai_dinh_ky == "Hang Thang")
                donhangdk.Ngay_giao = Request["Thoi_gian_giao"].ToString();

            donhangdk.Gio_giao = DateTime.Parse(Request["Gio_giao"].ToString());
            donhangdk.Tinh_trang = true;
        }

        donhang.Da_thanh_toan = false;
        donhang.Da_giao_hang = false;
        donhang.Tien_thue = decimal.Parse(Request["Tien_thue"].ToString());

    
        int madonhang;
        Gio_hang_online gio_hang = (Gio_hang_online)Session["Gio_hang"];
        Gio_hang_online gio_qua_tang = new Gio_hang_online();
        if (Session["Gio_qua_tang"] != null)
            gio_qua_tang = (Gio_hang_online)Session["Gio_qua_tang"];
        
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;

        try
        {
            madonhang = (new DonHangBUS()).ThemDonHang(donhang);
        }
        catch (Exception ex)
        {
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang loi"));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
            string chuoi = the.Chuoi();
            XL_CHUOI.XuatChuoi(Response, chuoi);
            return;
        }
        //lưu or đặt hàng định kỳ
        if (donhang.Loai_don_dat_hang == 1)
        {
            donhangdk.Ma_don_hang = madonhang;
            try
            {
                (new DonHangDinhKyBUS()).ThemDonHangDinhKy(donhangdk);
            }
            catch (Exception ex)
            {
                (new DonHangDinhKyBUS()).XoaDonHang(madonhang);  //rollback
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang dinh ky loi"));
                the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
                string chuoi = the.Chuoi();
                XL_CHUOI.XuatChuoi(Response, chuoi);
                return;
            }
        }

        try
        {
            CTDonHangDTO ctdonhang = new CTDonHangDTO();
            CTDonHangBUS ctdhBUS = new CTDonHangBUS();
            TagBUS tagbus = new TagBUS();

            for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
            {
                Item_online item = (Item_online)gio_hang.DsMonAn[i];

                ctdonhang.Ma_don_hang = madonhang;
                ctdonhang.Ma_item = item.Ma_item;
                ctdonhang.So_luong = item.So_luong;
                ctdonhang.Thanh_tien = item.So_luong * item.Gia;
                ctdonhang.Loai_item = item.Loai_item;
                ctdonhang.La_qua_tang = false;

                ctdhBUS.ThemChiTietDonHang(ctdonhang);
                tagbus.CapNhatDoUuTien(ctdonhang.Ma_item, ctdonhang.Loai_item);
            }
            if (gio_qua_tang.DsMonAn != null)
            {
                for (int i = 0; i < gio_qua_tang.DsMonAn.Count; i++)
                {
                    Item_online item = (Item_online)gio_qua_tang.DsMonAn[i];
                    ctdonhang.Ma_don_hang = madonhang;
                    ctdonhang.Ma_item = item.Ma_item;
                    ctdonhang.So_luong = item.So_luong;
                    ctdonhang.Thanh_tien = item.So_luong * item.Gia;
                    ctdonhang.Loai_item = item.Loai_item;
                    ctdonhang.La_qua_tang = true;

                    ctdhBUS.ThemChiTietDonHang(ctdonhang);
                }
            }

            int diemmoi = (new DonHangBUS()).CapNhatDiemKMTheoQuiDinh(donhang.Ma_khach_hang, vkhDto.Diem_khuyen_mai, donhang.Gia_tri, donhang.Tien_khuyen_mai);
            vkhDto.Diem_khuyen_mai = diemmoi;
        }
        catch (Exception ex)
        {
            if (donhang.Loai_don_dat_hang == 1)
                (new DonHangDinhKyBUS()).XoaDonHangDinhKy(madonhang);   //rollback
            else
                (new DonHangBUS()).XoaDonHang(madonhang); //rollback

            (new KhachHangBUS()).CapNhatDiemKhuyenMai(donhang.Ma_khach_hang, vkhDto.Diem_khuyen_mai);   //rollback

            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang loi"));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
            string chuoi = the.Chuoi();
            XL_CHUOI.XuatChuoi(Response, chuoi);
            return;
        }
        //neu ko fai chon luu dh
        if (donhang.Da_dat_hang == true)
        {
            // Dat hang thanh cong + chon thanh toan = the tin dung -> tien hanh thanh toan
            int Thanh_toan = int.Parse(Request["Thanh_toan"].ToString());
            if (Thanh_toan == 1)
            {
                WS_CardSystem.CardDTO cardDto1 = new WS_CardSystem.CardDTO();

                //Neu su dung the khac 
                int The_khac = int.Parse(Request["The_khac"].ToString());
                ThanhToanTheTinDungDTO thett = new ThanhToanTheTinDungDTO();
                if (The_khac == 1)
                {
                    thett.Ma_don_hang = madonhang;  //don hang vua them
                    thett.Ma_loai_the = int.Parse(Request["Ma_loai_the"].ToString());
                    thett.So_the = Request["So_the"].ToString();
                    thett.Ngay_het_han = DateTime.Parse(Request["Ngay_hh"].ToString());

                    //them vao csdl the su dung
                    try
                    {
                        (new ThanhToanTheTinDungBUS()).ThemThanhToanTheTinDung(thett);
                    }
                    catch (Exception ex)
                    {
                        if (donhang.Loai_don_dat_hang == 1)
                            (new DonHangDinhKyBUS()).XoaDonHangDinhKy(madonhang);   //rollback
                        else
                            (new DonHangBUS()).XoaDonHang(madonhang); //rollback

                        (new KhachHangBUS()).CapNhatDiemKhuyenMai(donhang.Ma_khach_hang, vkhDto.Diem_khuyen_mai);   //rollback

                        the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang loi"));
                        the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
                        string chuoi = the.Chuoi();
                        XL_CHUOI.XuatChuoi(Response, chuoi);
                        return;
                    }

                    //The khac
                    cardDto1.Code = thett.So_the;
                    string tenloaithe = Request["Ten_loai_the"].ToString();
                    cardDto1.Type = tenloaithe;
                }
                else
                {
                    //the mac dinh
                    cardDto1.Code = vkhDto.So_the;
                    cardDto1.Type = vkhDto.Ten_loai_the;
                }

                //thanh toan
                bool kq = ThanhToan(donhang.Gia_tri, the, cardDto1);
                if (kq == true)
                    (new DonHangBUS()).CapNhatTrangThaiDaThanhToan(madonhang, true);
                else
                {
                    (new ThanhToanTheTinDungBUS()).XoaThanhToanTheTinDung(thett.Ma_don_hang);
                    if (donhang.Loai_don_dat_hang == 1)
                        (new DonHangDinhKyBUS()).XoaDonHangDinhKy(madonhang);   //rollback
                    else
                        (new DonHangBUS()).XoaDonHang(madonhang); //rollback

                    (new KhachHangBUS()).CapNhatDiemKhuyenMai(donhang.Ma_khach_hang, vkhDto.Diem_khuyen_mai);   //rollback

                    the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Thanh toan loi, dat hang khong thanh cong \n Vui long kiem tra lai the su dung"));
                    the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
                    string chuoi = the.Chuoi();
                    XL_CHUOI.XuatChuoi(Response, chuoi);
                    return;
                }

            }
            thuoc_tinh = new XL_THUOC_TINH("kq", "Dat hang thanh cong");
        }
        else
        {
            Session["madonhangluu"] = madonhang;    //luu lại mã đh để trh khách hàng chọn đặt mua sau đó
            thuoc_tinh = new XL_THUOC_TINH("kq", "Luu don hang thanh cong");
        }
        the.Danh_sach_thuoc_tinh.Add(thuoc_tinh);
        the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "true"));
        XL_CHUOI.XuatChuoi(Response, the.Chuoi());

        Session["Gio_qua_tang"] = null;
        Session["Gio_hang"] = null;
        Session["FormDatHangDinhKy"] = null;
        Session["FormDatHang"] = null;
       
        return;
    }

    private bool ThanhToan(decimal giatri, XL_THE the, WS_CardSystem.CardDTO cardDto1)
    {
        WS_CardSystem.Service cardsys = new WS_CardSystem.Service();
        bool kq = cardsys.KiemTraHopLe(cardDto1);

        if (kq == false)
        {
            return false;
        }
        else
        {
            WS_CardSystem.CardDTO cardDto2 = new WS_CardSystem.CardDTO();
            cardDto2.Code = soTheOFFS; //test
            cardDto2.Type = loaiTheOFFS;

            kq = cardsys.KiemTraHopLe(cardDto2);
            if (kq == false)
            {
                return false;
            }
            else
            {
                WS_Paypal.CardDTO cardsend = new WS_Paypal.CardDTO();
                WS_Paypal.CardDTO cardreci = new WS_Paypal.CardDTO();
                cardsend.Code = cardDto1.Code;
                cardsend.Type = cardDto1.Type;
                cardreci.Code = soTheOFFS; //test
                cardreci.Type = loaiTheOFFS;

                WS_Paypal.Service paypal = new WS_Paypal.Service();
                kq = paypal.ThanhToan(cardsend, cardreci, giatri);
                return kq;
            }
        }
    }

    protected void Dat_hang_guest()
    {
        DonHangDTO donhang = new DonHangDTO();

        //Xac dinh tham so
        donhang.Ngay_gio_lap = DateTime.Parse(Request["Ngay_lap"].ToString());
        donhang.Dia_chi_nhan = Request["Dia_chi_nhan"];
        donhang.Nguoi_nhan = Request["Nguoi_nhan"];
        donhang.Ngay_gio_giao_hang = DateTime.Parse(Request["Ngay_giao"].ToString());
        donhang.Gia_tri = decimal.Parse(Request["Gia_tri"].ToString());
        donhang.Da_dat_hang = true;
        donhang.Da_thanh_toan = false;
        donhang.Da_giao_hang = false;
        donhang.Tien_thue = decimal.Parse(Request["Tien_thue"].ToString());

        int madonhang;
        Gio_hang_online gio_hang = (Gio_hang_online)Session["Gio_hang"];

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;

        try
        {
            madonhang = (new DonHangBUS()).ThemDonHang(donhang);
        }
        catch (Exception ex)
        {
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang loi"));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
            string chuoi = the.Chuoi();
            XL_CHUOI.XuatChuoi(Response, chuoi);
            return;
        }

        try
        {
            CTDonHangDTO ctdonhang = new CTDonHangDTO();
            CTDonHangBUS ctdhBUS = new CTDonHangBUS();
            TagBUS tagbus = new TagBUS();

            for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
            {
                Item_online item = (Item_online)gio_hang.DsMonAn[i];

                ctdonhang.Ma_don_hang = madonhang;
                ctdonhang.Ma_item = item.Ma_item;
                ctdonhang.So_luong = item.So_luong;
                ctdonhang.Thanh_tien = item.So_luong * item.Gia;
                ctdonhang.Loai_item = item.Loai_item;
                ctdonhang.La_qua_tang = false;

                ctdhBUS.ThemChiTietDonHang(ctdonhang);
                tagbus.CapNhatDoUuTien(ctdonhang.Ma_item, ctdonhang.Loai_item);
            }
        }
        catch (Exception ex)
        {
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang loi"));
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "false"));
            string chuoi = the.Chuoi();
            XL_CHUOI.XuatChuoi(Response, chuoi);
            return;
        }

        the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "Dat hang thanh cong")); 
        the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("flag", "true"));
        XL_CHUOI.XuatChuoi(Response, the.Chuoi());

        Session["Gio_hang"] = null;

        return;
    }
}
