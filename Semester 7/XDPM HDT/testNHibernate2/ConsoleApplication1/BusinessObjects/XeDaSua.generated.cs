using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class XeDaSua : BusinessBase<int>
    {
        #region Declarations

		private string _loaiXe = String.Empty;
		private string _bienSo = String.Empty;
		private string _mauSac = String.Empty;
		private string _soKhung = String.Empty;
		private string _soMay = String.Empty;
		private System.DateTime _ngayMua = new DateTime();
		private string _ghiChu = String.Empty;
		
		private KhachHang _khachHang = null;
		
		private IList<HDSuaXe> _hDSuaXes = new List<HDSuaXe>();
		
		#endregion

        #region Constructors

        public XeDaSua() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_loaiXe);
			sb.Append(_bienSo);
			sb.Append(_mauSac);
			sb.Append(_soKhung);
			sb.Append(_soMay);
			sb.Append(_ngayMua);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string LoaiXe
        {
            get { return _loaiXe; }
			set
			{
				
				_loaiXe = value;
				
			}
        }
		
		public virtual string BienSo
        {
            get { return _bienSo; }
			set
			{
				
				_bienSo = value;
				
			}
        }
		
		public virtual string MauSac
        {
            get { return _mauSac; }
			set
			{
				
				_mauSac = value;
				
			}
        }
		
		public virtual string SoKhung
        {
            get { return _soKhung; }
			set
			{
				
				_soKhung = value;
				
			}
        }
		
		public virtual string SoMay
        {
            get { return _soMay; }
			set
			{
				
				_soMay = value;
				
			}
        }
		
		public virtual System.DateTime NgayMua
        {
            get { return _ngayMua; }
			set
			{
				
				_ngayMua = value;
				
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
		
		public virtual KhachHang KhachHangMember
        {
            get { return _khachHang; }
			set
			{
				
				_khachHang = value;
				
			}
        }
		
		public virtual IList<HDSuaXe> HDSuaXes
        {
            get { return _hDSuaXes; }
            set
			{
				
				_hDSuaXes = value;
				
			}
        }
		
        #endregion
    }
}
