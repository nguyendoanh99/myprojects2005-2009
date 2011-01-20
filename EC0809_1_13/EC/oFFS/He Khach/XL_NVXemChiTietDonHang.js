// JScript File

function CreateTable()
{
    var url = "He phuc vu/XL_NVXemChiTietDonHang.aspx?request=LayCTDonHang&MaDonHang=" + maDonHang + "&time=" + (new Date().getTime()) + "&";
    
    var myDataSource = new YAHOO.util.DataSource(encodeURI(url));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "CTDonHang", // Name of the node for each result
        fields : [
            { key: "MaCTDonHang" }, // Attribute of the resultNode
            { key: "Ten" }, 
            { key: "LoaiItem"},
            { key: "SoLuong"},
            { key: "ThanhTien"}
        ]
    };        
    
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
      
    // Định nghĩa cột
    var myColumnDefs = [
        { key: "STT", label:"STT", formatter: STTFormatter},
        { key: "Ten", label: "Tên", formatter:"date"},                
        { key: "LoaiItem", label:"Loại"},
        { key: "SoLuong", label: "Số lượng"},
        { key: "ThanhTien", label: "Thành tiền", formatter:"number"}
    ];
    
    var myDataTable = new YAHOO.widget.DataTable("divDanhSachCTDonHang", myColumnDefs, myDataSource);
        
    return myDataTable;
}
// Thêm các event cho table
function AddEvents(myDataTable)
{
    var maDonHang;
    var oRecord;
    // Define various event handlers for Dialog
	var handleYes = function() {
	    this.hide();
	    var kq = XoaDonHang(maDonHang);
        if (kq.length == 0)
        {
            myDataTable.deleteRow(oRecord);
        }
        else    
            alert(kq);
	};
	var handleNo = function() {
		this.hide();
	};
 
	// Instantiate the Dialog
	Deletedialog = new YAHOO.widget.SimpleDialog("DeleteDLG", 
			 { width: "300px",
			   fixedcenter: true,
			   visible: false,
			   modal:true, 
			   draggable: true,
			   close: true,
			   text: "Bạn có muốn xóa đơn hàng này không?",
			   icon: YAHOO.widget.SimpleDialog.ICON_HELP,
			   constraintoviewport: true,
			   buttons: [ { text:"Có", handler:handleYes },
						  { text:"Không",  handler:handleNo, isDefault:true } ]
			 } );
	Deletedialog.setHeader("Xóa đơn hàng?");
	
	// Render the Dialog
	Deletedialog.render(document.body);
	
    // Enables row highlighting
//     myDataTable.subscribe("rowMouseoverEvent", myDataTable.onEventHighlightRow);
//     myDataTable.subscribe("rowMouseoutEvent", myDataTable.onEventUnhighlightRow);

    // Sự kiện click trên link (Xóa tài khoản, Gửi lại mật khẩu)
    myDataTable.subscribe("linkClickEvent", function(oArgs){
        var target = oArgs.target;
        oRecord = this.getRecord(target);
        maDonHang = oRecord.getData("MaDonHang");
        if (target.id.indexOf("XoaDonHang") != -1) // xóa tài khoản người dùng
        {
            Deletedialog.show();
        }
        
    });
}
function LoadTable(t)
{            
    document.body.className += " yui-skin-sam";
    var myDataTable = CreateTable();
    //AddEvents(myDataTable);
}

function LoadData()
{
    var ham = new XL_HAM("He phuc vu/XL_NVXemChiTietDonHang");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "LayThongTinDonHang"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaDonHang", maDonHang));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var tenKhachHang = goc.getAttribute("TenKhachHang");
        var ngayGioLap = goc.getAttribute("NgayGioLap");
        var diaChiNhan = goc.getAttribute("DiaChiNhan");
        var nguoiNhan = goc.getAttribute("NguoiNhan");
        var ngayGioGiaoHang = goc.getAttribute("NgayGioGiaoHang");
        var hinhThucKhuyenMai = goc.getAttribute("HinhThucKhuyenMai");
        var tienKhuyenMai = goc.getAttribute("TienKhuyenMai");
        var giaTri = goc.getAttribute("GiaTri");
        var tienThue = goc.getAttribute("TienThue");
        var tinhTrang = parseInt(goc.getAttribute("TinhTrang"));
        
        var setTenKhachHang = document.getElementById("setTenKhachHang");
        var setNgayGioLap = document.getElementById("setNgayGioLap");
        var setDiaChiNhan = document.getElementById("setDiaChiNhan");
        var setNguoiNhan = document.getElementById("setNguoiNhan");
        var setNgayGioGiaoHang = document.getElementById("setNgayGioGiaoHang");
        var setHinhThucKhuyenMai = document.getElementById("setHinhThucKhuyenMai");
        var setTienKhuyenMai = document.getElementById("setTienKhuyenMai");
        var setGiaTri = document.getElementById("setGiaTri");
        var setTienThue = document.getElementById("setTienThue");
        var setTinhTrang = document.getElementById("setTinhTrang");
        
        setTenKhachHang.innerHTML = tenKhachHang;
        setNgayGioLap.innerHTML = ngayGioLap;
        setDiaChiNhan.innerHTML = diaChiNhan;
        setNguoiNhan.innerHTML = nguoiNhan;
        setNgayGioGiaoHang.innerHTML = ngayGioGiaoHang;
        setHinhThucKhuyenMai.innerHTML = hinhThucKhuyenMai;
        setTienKhuyenMai.innerHTML = tienKhuyenMai;
        setGiaTri.innerHTML = giaTri;
        setTienThue.innerHTML = tienThue;
         
        var str = "";
        switch (tinhTrang)
        {
        case 0: // Đã đặt hàng nhưng chưa thanh toán
            str = "Đã đặt hàng nhưng chưa thanh toán";
            break;
        case 1: // Đã thanh toán nhưng chưa giao hàng
            str = "Đã thanh toán nhưng chưa giao hàng";
            var obj = document.getElementById("aDaThanhToan");
            var parent = obj.parentNode; // Label
            parent.removeChild(obj);          

            break;
        case 2: // Đã hoàn tất
            str = "Đã hoàn tất";
            var obj = document.getElementById("aDaThanhToan");
            var parent = obj.parentNode; // Label
            
            var p2 = parent.parentNode;
            p2.removeChild(parent); // Xóa label
            break;
        }
        setTinhTrang.innerHTML = str;
        
    }
    else
        alert("Lỗi đường truyền");
}

function DaThanhToan()
{
    var str = CapNhatTrangThai(maDonHang, 0);
    if (str.length != 0)
        alert(str);
}
function DaGiaoHang()
{
    var str = CapNhatTrangThai(maDonHang, 1);
    if (str.length != 0)
        alert(str);
}
function CapNhatTrangThai(maDonHang, trangThai)
{
    var ham = new XL_HAM("He phuc vu/XL_NVXemDanhSachDonHang");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "CapNhatTrangThai"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaDonHang", maDonHang));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("TrangThai", trangThai));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
        {   
            var setTinhTrang = document.getElementById("setTinhTrang");
            if (trangThai == 0) // Đã thanh toán
            {
                var obj = document.getElementById("aDaThanhToan");
                var parent = obj.parentNode; // Label
                parent.removeChild(obj);          
                setTinhTrang.innerHTML = "Đã thanh toán nhưng chưa giao hàng";
            }
            else
            {
                var obj = document.getElementById("aDaGiaoHang");
                var parent = obj.parentNode; // Label
                var p2 = parent.parentNode;
                p2.removeChild(parent); // Xóa label
                setTinhTrang.innerHTML = "Đã hoàn tất";
                
                var setNgayGioGiaoHang = document.getElementById("setNgayGioGiaoHang");
                var ngayGioGiaoHang = goc.getAttribute("NgayGioGiaoHang");
                setNgayGioGiaoHang.innerHTML = ngayGioGiaoHang;                
            }            
            return "";
        }        
        else
            return "Không thực hiện được do có lỗi phía server";
    }
    else
        return "Lỗi đường truyền";
}