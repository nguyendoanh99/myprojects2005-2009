using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class PhuTung : BusinessBase<int>
    {
        #region Declarations

		private string _maSoPhuTung = String.Empty;
		private string _tenPhuTung = String.Empty;
		private int _soLuong = default(Int32);
		private string _donVi = String.Empty;
		private decimal _tongTienVon = default(Decimal);
		private decimal _giaVonTren1DV = default(Decimal);
		private decimal _giaBanTren1DV = default(Decimal);
		private string _ghiChu = String.Empty;
		
		private Model _model = null;
		
		private IList<CTHDNhapPhuTung> _cTHDNhapPhuTungs = new List<CTHDNhapPhuTung>();
		private IList<CTHDSuaXe> _cTHDSuaXes = new List<CTHDSuaXe>();
		
		#endregion

        #region Constructors

        public PhuTung() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_maSoPhuTung);
			sb.Append(_tenPhuTung);
			sb.Append(_soLuong);
			sb.Append(_donVi);
			sb.Append(_tongTienVon);
			sb.Append(_giaVonTren1DV);
			sb.Append(_giaBanTren1DV);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string MaSoPhuTung
        {
            get { return _maSoPhuTung; }
			set
			{
				
				_maSoPhuTung = value;
				
			}
        }
		
		public virtual string TenPhuTung
        {
            get { return _tenPhuTung; }
			set
			{
				
				_tenPhuTung = value;
				
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
		
		public virtual string DonVi
        {
            get { return _donVi; }
			set
			{
				
				_donVi = value;
				
			}
        }
		
		public virtual decimal TongTienVon
        {
            get { return _tongTienVon; }
			set
			{
				
				_tongTienVon = value;
				
			}
        }
		
		public virtual decimal GiaVonTren1DV
        {
            get { return _giaVonTren1DV; }
			set
			{
				
				_giaVonTren1DV = value;
				
			}
        }
		
		public virtual decimal GiaBanTren1DV
        {
            get { return _giaBanTren1DV; }
			set
			{
				
				_giaBanTren1DV = value;
				
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
		
		public virtual Model ModelMember
        {
            get { return _model; }
			set
			{
				
				_model = value;
				
			}
        }
		
		public virtual IList<CTHDNhapPhuTung> CTHDNhapPhuTungs
        {
            get { return _cTHDNhapPhuTungs; }
            set
			{
				
				_cTHDNhapPhuTungs = value;
				
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
