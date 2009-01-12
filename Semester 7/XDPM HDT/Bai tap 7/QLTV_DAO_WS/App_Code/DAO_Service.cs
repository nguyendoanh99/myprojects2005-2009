using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections;
using DTO;
using DAO;
using System.Collections.Generic;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class DAO_Service : System.Web.Services.WebService
{
    public DAO_Service () {
        string DBFullPathName = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\ThuVien.mdb";
        DAO.DataProvider.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFullPathName;
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<LoaiDocGiaDTO> LoaiDocGia_GetAll()
    {
        LoaiDocGiaDAO dao = new LoaiDocGiaDAO();
        return (List<LoaiDocGiaDTO>)dao.GetAll();
    }
    [WebMethod]
    public List<LoaiDocGiaDTO> LoaiDocGia_GetByProperties(List<string> lstKey, List<object> Values, List<bool> Exact)
    {
        LoaiDocGiaDAO dao = new LoaiDocGiaDAO();
        return (List<LoaiDocGiaDTO>)dao.GetByProperties(lstKey, Values, Exact);
    }
    [WebMethod]
    public List<TheDocGiaDTO> TheDocGia_GetAll()
    {
        TheDocGiaDAO dao = new TheDocGiaDAO();
        return (List<TheDocGiaDTO>)dao.GetAll();
    }
    [WebMethod]
    public List<TheDocGiaDTO> TheDocGia_GetByProperties(List<string> lstKey, List<object> Values, List<bool> Exact)
    {
        TheDocGiaDAO dao = new TheDocGiaDAO();
        return (List<TheDocGiaDTO>)dao.GetByProperties(lstKey, Values, Exact);
    }
    [WebMethod]
    public void TheDocGia_Insert(ref TheDocGiaDTO dto)
    {
        TheDocGiaDAO dao = new TheDocGiaDAO();
        dao.Insert(dto);
    }
    [WebMethod]
    public void TheDocGia_Update(TheDocGiaDTO dto)
    {
        TheDocGiaDAO dao = new TheDocGiaDAO();
        dao.Update(dto);
    }
    [WebMethod]
    public void TheDocGia_Delete(TheDocGiaDTO dto)
    {
        TheDocGiaDAO dao = new TheDocGiaDAO();
        dao.Delete(dto);
    }
}
