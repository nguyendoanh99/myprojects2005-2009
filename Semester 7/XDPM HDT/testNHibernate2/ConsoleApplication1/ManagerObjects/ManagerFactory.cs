using System;
using System.Collections.Generic;
using System.Text;

using NHibernate.Generated.Base;

namespace NHibernate.Generated.ManagerObjects
{
    public interface IManagerFactory
    {
		// Get Methods
		ICTHDNhapPhuTungManager GetCTHDNhapPhuTungManager();
		ICTHDNhapPhuTungManager GetCTHDNhapPhuTungManager(INHibernateSession session);
		ICTHDSuaXeManager GetCTHDSuaXeManager();
		ICTHDSuaXeManager GetCTHDSuaXeManager(INHibernateSession session);
		IHangXeManager GetHangXeManager();
		IHangXeManager GetHangXeManager(INHibernateSession session);
		IHDNhapPhuTungManager GetHDNhapPhuTungManager();
		IHDNhapPhuTungManager GetHDNhapPhuTungManager(INHibernateSession session);
		IHDSuaXeManager GetHDSuaXeManager();
		IHDSuaXeManager GetHDSuaXeManager(INHibernateSession session);
		IKhachHangManager GetKhachHangManager();
		IKhachHangManager GetKhachHangManager(INHibernateSession session);
		ILoaiXeManager GetLoaiXeManager();
		ILoaiXeManager GetLoaiXeManager(INHibernateSession session);
		IModelManager GetModelManager();
		IModelManager GetModelManager(INHibernateSession session);
		IPhuTungManager GetPhuTungManager();
		IPhuTungManager GetPhuTungManager(INHibernateSession session);
		IXeDaSuaManager GetXeDaSuaManager();
		IXeDaSuaManager GetXeDaSuaManager(INHibernateSession session);
    }

    public class ManagerFactory : IManagerFactory
    {
        #region Constructors

        public ManagerFactory()
        {
        }

        #endregion

        #region Get Methods

		public ICTHDNhapPhuTungManager GetCTHDNhapPhuTungManager()
        {
            return new CTHDNhapPhuTungManager();
        }
		public ICTHDNhapPhuTungManager GetCTHDNhapPhuTungManager(INHibernateSession session)
        {
            return new CTHDNhapPhuTungManager(session);
        }
		public ICTHDSuaXeManager GetCTHDSuaXeManager()
        {
            return new CTHDSuaXeManager();
        }
		public ICTHDSuaXeManager GetCTHDSuaXeManager(INHibernateSession session)
        {
            return new CTHDSuaXeManager(session);
        }
		public IHangXeManager GetHangXeManager()
        {
            return new HangXeManager();
        }
		public IHangXeManager GetHangXeManager(INHibernateSession session)
        {
            return new HangXeManager(session);
        }
		public IHDNhapPhuTungManager GetHDNhapPhuTungManager()
        {
            return new HDNhapPhuTungManager();
        }
		public IHDNhapPhuTungManager GetHDNhapPhuTungManager(INHibernateSession session)
        {
            return new HDNhapPhuTungManager(session);
        }
		public IHDSuaXeManager GetHDSuaXeManager()
        {
            return new HDSuaXeManager();
        }
		public IHDSuaXeManager GetHDSuaXeManager(INHibernateSession session)
        {
            return new HDSuaXeManager(session);
        }
		public IKhachHangManager GetKhachHangManager()
        {
            return new KhachHangManager();
        }
		public IKhachHangManager GetKhachHangManager(INHibernateSession session)
        {
            return new KhachHangManager(session);
        }
		public ILoaiXeManager GetLoaiXeManager()
        {
            return new LoaiXeManager();
        }
		public ILoaiXeManager GetLoaiXeManager(INHibernateSession session)
        {
            return new LoaiXeManager(session);
        }
		public IModelManager GetModelManager()
        {
            return new ModelManager();
        }
		public IModelManager GetModelManager(INHibernateSession session)
        {
            return new ModelManager(session);
        }
		public IPhuTungManager GetPhuTungManager()
        {
            return new PhuTungManager();
        }
		public IPhuTungManager GetPhuTungManager(INHibernateSession session)
        {
            return new PhuTungManager(session);
        }
		public IXeDaSuaManager GetXeDaSuaManager()
        {
            return new XeDaSuaManager();
        }
		public IXeDaSuaManager GetXeDaSuaManager(INHibernateSession session)
        {
            return new XeDaSuaManager(session);
        }
        
        #endregion
    }
}
