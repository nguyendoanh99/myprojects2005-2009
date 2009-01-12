using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class HDSuaXe : BusinessBase<int>
    {
        #region Declarations

		private string _maSoHoaDon = String.Empty;
		private string _khachHang = String.Empty;
		private string _diaChi = String.Empty;
		private string _dienThoai = String.Empty;
		private int _soKm = default(Int32);
		private System.DateTime _ngaySua = new DateTime();
		private string _loaiHinhSuaChua = String.Empty;
		private string _tinhTrangHuHong = String.Empty;
		private string _timPanSuaChua = String.Empty;
		private decimal _tienPhuTung = default(Decimal);
		private decimal _tienCong = default(Decimal);
		private decimal _thanhTien = default(Decimal);
		private string _nhanVienPhucVu = String.Empty;
		private string _ghiChu = String.Empty;
		
		private XeDaSua _xeDaSua = null;
		
		private IList<CTHDSuaXe> _cTHDSuaXes = new List<CTHDSuaXe>();
		
		#endregion

        #region Constructors

        public HDSuaXe() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_maSoHoaDon);
			sb.Append(_khachHang);
			sb.Append(_diaChi);
			sb.Append(_dienThoai);
			sb.Append(_soKm);
			sb.Append(_ngaySua);
			sb.Append(_loaiHinhSuaChua);
			sb.Append(_tinhTrangHuHong);
			sb.Append(_timPanSuaChua);
			sb.Append(_tienPhuTung);
			sb.Append(_tienCong);
			sb.Append(_thanhTien);
			sb.Append(_nhanVienPhucVu);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string MaSoHoaDon
        {
            get { return _maSoHoaDon; }
			set
			{
				
				_maSoHoaDon = value;
				
			}
        }
		
		public virtual string KhachHang
        {
            get { return _khachHang; }
			set
			{
				
				_khachHang = value;
				
			}
        }
		
		public virtual string DiaChi
        {
            get { return _diaChi; }
			set
			{
				
				_diaChi = value;
				
			}
        }
		
		public virtual string DienThoai
        {
            get { return _dienThoai; }
			set
			{
				
				_dienThoai = value;
				
			}
        }
		
		public virtual int SoKm
        {
            get { return _soKm; }
			set
			{
				
				_soKm = value;
				
			}
        }
		
		public virtual System.DateTime NgaySua
        {
            get { return _ngaySua; }
			set
			{
				
				_ngaySua = value;
				
			}
        }
		
		public virtual string LoaiHinhSuaChua
        {
            get { return _loaiHinhSuaChua; }
			set
			{
				
				_loaiHinhSuaChua = value;
				
			}
        }
		
		public virtual string TinhTrangHuHong
        {
            get { return _tinhTrangHuHong; }
			set
			{
				
				_tinhTrangHuHong = value;
				
			}
        }
		
		public virtual string TimPanSuaChua
        {
            get { return _timPanSuaChua; }
			set
			{
				
				_timPanSuaChua = value;
				
			}
        }
		
		public virtual decimal TienPhuTung
        {
            get { return _tienPhuTung; }
			set
			{
				
				_tienPhuTung = value;
				
			}
        }
		
		public virtual decimal TienCong
        {
            get { return _tienCong; }
			set
			{
				
				_tienCong = value;
				
			}
        }
		
		public virtual decimal ThanhTien
        {
            get { return _thanhTien; }
			set
			{
				
				_thanhTien = value;
				
			}
        }
		
		public virtual string NhanVienPhucVu
        {
            get { return _nhanVienPhucVu; }
			set
			{
				
				_nhanVienPhucVu = value;
				
			}
        }
		
		public virtual string GhiChu
        {
            get { return _ghiChu; }
			set
			{
				
				_ghiChu = value;
				
			}
        }
		
		public virtual XeDaSua XeDaSuaMember
        {
            get { return _xeDaSua; }
			set
			{
				
				_xeDaSua = value;
				
			}
        }
		
		public virtual IList<CTHDSuaXe> CTHDSuaXes
        {
            get { return _cTHDSuaXes; }
            set
			{
				
				_cTHDSuaXes = value;
				
			}
        }
		
        #endregion
    }
}
