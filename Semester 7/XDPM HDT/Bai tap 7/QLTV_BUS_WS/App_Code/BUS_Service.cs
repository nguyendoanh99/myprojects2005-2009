using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using DAO_WS;
using System.Collections.Generic;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class BUS_Service : System.Web.Services.WebService
{
    DAO_Service sv = new DAO_Service();
    public BUS_Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public LoaiDocGiaDTO[] LoaiDocGia_GetAll()
    {
        return sv.LoaiDocGia_GetAll();
    }
    [WebMethod]
    public LoaiDocGiaDTO[] LoaiDocGia_GetByProperties(string[] lstKey, object[] Values, bool[] Exact)
    {
        return sv.LoaiDocGia_GetByProperties(lstKey, Values, Exact);
    }
    [WebMethod]
    public TheDocGiaDTO[] TheDocGia_GetAll()
    {
        return sv.TheDocGia_GetAll();
    }
    [WebMethod]
    public TheDocGiaDTO[] TheDocGia_GetByProperties(string[] lstKey, object[] Values, bool[] Exact)
    {
        return sv.TheDocGia_GetByProperties(lstKey, Values, Exact);
    }
    [WebMethod]
    public void TheDocGia_Insert(ref TheDocGiaDTO dto)
    {
        dto.NgayLapThe = DateTime.Now.Date;
        dto.NgayHetHan = dto.NgayLapThe.AddMonths(6).Date;
        sv.TheDocGia_Insert(ref dto);
    }
    [WebMethod]
    public void TheDocGia_Update(TheDocGiaDTO dto)
    {
        sv.TheDocGia_Update(dto);
    }
    [WebMethod]
    public void TheDocGia_Delete(TheDocGiaDTO dto)
    {
        sv.TheDocGia_Delete(dto);
    }
}
