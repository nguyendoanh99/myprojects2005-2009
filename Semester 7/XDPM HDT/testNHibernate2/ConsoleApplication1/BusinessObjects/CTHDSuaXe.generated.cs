using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class CTHDSuaXe : BusinessBase<int>
    {
        #region Declarations

		private int _sTT = default(Int32);
		private string _chiTietSua = String.Empty;
		private int _soLuong = default(Int32);
		private decimal _donGium = default(Decimal);
		private double _phanTramGiam = default(Double);
		private decimal _thanhTien = default(Decimal);
		private string _ghiChu = String.Empty;
		private bool _loai = default(Boolean);
		
		private HDSuaXe _hDSuaXe = null;
		private PhuTung _phuTung = null;
		
		
		#endregion

        #region Constructors

        public CTHDSuaXe() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_sTT);
			sb.Append(_chiTietSua);
			sb.Append(_soLuong);
			sb.Append(_donGium);
			sb.Append(_phanTramGiam);
			sb.Append(_thanhTien);
			sb.Append(_ghiChu);
			sb.Append(_loai);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual int STT
        {
            get { return _sTT; }
			set
			{
				
				_sTT = value;
				
			}
        }
		
		public virtual string ChiTietSua
        {
            get { return _chiTietSua; }
			set
			{
				
				_chiTietSua = value;
				
			}
        }
		
		public virtual int SoLuong
        {
            get { return _soLuong; }
			set
			{
				
				_soLuong = value;
				
			}
        }
		
		public virtual decimal DonGium
        {
            get { return _donGium; }
			set
			{
				
				_donGium = value;
				
			}
        }
		
		public virtual double PhanTramGiam
        {
            get { return _phanTramGiam; }
			set
			{
				
				_phanTramGiam = value;
				
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
		
		public virtual string GhiChu
        {
            get { return _ghiChu; }
			set
			{
				
				_ghiChu = value;
				
			}
        }
		
		public virtual bool Loai
        {
            get { return _loai; }
			set
			{
				
				_loai = value;
				
			}
        }
		
		public virtual HDSuaXe HDSuaXeMember
        {
            get { return _hDSuaXe; }
			set
			{
				
				_hDSuaXe = value;
				
			}
        }
		
		public virtual PhuTung PhuTungMember
        {
            get { return _phuTung; }
			set
			{
				
				_phuTung = value;
				
			}
        }
		
        #endregion
    }
}
