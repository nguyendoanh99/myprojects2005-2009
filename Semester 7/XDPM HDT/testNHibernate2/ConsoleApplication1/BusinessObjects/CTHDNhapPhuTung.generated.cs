using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class CTHDNhapPhuTung : BusinessBase<int>
    {
        #region Declarations

		private int _soLuong = default(Int32);
		private decimal _donGiaNhap = default(Decimal);
		private decimal _thanhTien = default(Decimal);
		private string _ghiChu = String.Empty;
		
		private HDNhapPhuTung _hDNhapPhuTung = null;
		private PhuTung _phuTung = null;
		
		
		#endregion

        #region Constructors

        public CTHDNhapPhuTung() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_soLuong);
			sb.Append(_donGiaNhap);
			sb.Append(_thanhTien);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual int SoLuong
        {
            get { return _soLuong; }
			set
			{
				
				_soLuong = value;
				
			}
        }
		
		public virtual decimal DonGiaNhap
        {
            get { return _donGiaNhap; }
			set
			{
				
				_donGiaNhap = value;
				
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
		
		public virtual HDNhapPhuTung HDNhapPhuTungMember
        {
            get { return _hDNhapPhuTung; }
			set
			{
				
				_hDNhapPhuTung = value;
				
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
