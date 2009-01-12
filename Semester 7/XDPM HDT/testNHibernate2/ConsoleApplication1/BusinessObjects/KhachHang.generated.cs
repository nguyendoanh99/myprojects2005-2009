using System;
using System.Collections;
using System.Collections.Generic;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.BusinessObjects
{
    public partial class KhachHang : BusinessBase<int>
    {
        #region Declarations

		private string _hoTen = String.Empty;
		private string _soNha = String.Empty;
		private string _duong = String.Empty;
		private string _phuong = String.Empty;
		private string _quan = String.Empty;
		private string _thanhPho = String.Empty;
		private string _dienThoaiBan = String.Empty;
		private string _diDong = String.Empty;
		private bool _nam = default(Boolean);
		private short _namSinh = default(Int16);
		private string _ghiChu = String.Empty;
		
		
		private IList<XeDaSua> _xeDaSuas = new List<XeDaSua>();
		
		#endregion

        #region Constructors

        public KhachHang() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_hoTen);
			sb.Append(_soNha);
			sb.Append(_duong);
			sb.Append(_phuong);
			sb.Append(_quan);
			sb.Append(_thanhPho);
			sb.Append(_dienThoaiBan);
			sb.Append(_diDong);
			sb.Append(_nam);
			sb.Append(_namSinh);
			sb.Append(_ghiChu);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string HoTen
        {
            get { return _hoTen; }
			set
			{
				
				_hoTen = value;
				
			}
        }
		
		public virtual string SoNha
        {
            get { return _soNha; }
			set
			{
				
				_soNha = value;
				
			}
        }
		
		public virtual string Duong
        {
            get { return _duong; }
			set
			{
				
				_duong = value;
				
			}
        }
		
		public virtual string Phuong
        {
            get { return _phuong; }
			set
			{
				
				_phuong = value;
				
			}
        }
		
		public virtual string Quan
        {
            get { return _quan; }
			set
			{
				
				_quan = value;
				
			}
        }
		
		public virtual string ThanhPho
        {
            get { return _thanhPho; }
			set
			{
				
				_thanhPho = value;
				
			}
        }
		
		public virtual string DienThoaiBan
        {
            get { return _dienThoaiBan; }
			set
			{
				
				_dienThoaiBan = value;
				
			}
        }
		
		public virtual string DiDong
        {
            get { return _diDong; }
			set
			{
				
				_diDong = value;
				
			}
        }
		
		public virtual bool Nam
        {
            get { return _nam; }
			set
			{
				
				_nam = value;
				
			}
        }
		
		public virtual short NamSinh
        {
            get { return _namSinh; }
			set
			{
				
				_namSinh = value;
				
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
		
		public virtual IList<XeDaSua> XeDaSuas
        {
            get { return _xeDaSuas; }
            set
			{
				
				_xeDaSuas = value;
				
			}
        }
		
        #endregion
    }
}
