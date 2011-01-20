// JScript File

function CreateTable()
{
    var url = "He phuc vu/XL_KHXemChiTietDonHang.aspx?request=LayCTDonHang&MaDonHang=" + maDonHang + "&time=" + (new Date().getTime()) + "&";
    
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
    var ham = new XL_HAM("He phuc vu/XL_KHXemChiTietDonHang");
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
        var loai = parseInt(goc.getAttribute("loai"));
        
        var setTenKhachHang = document.getElementById("setTenKhachHang");
        var setNgayGioLap = document.getElementById("setNgayGioLap");
        var setDiaChiNhan = document.getElementById("setDiaChiNhan");
        var setNguoiNhan = document.getElementById("setNguoiNhan");
        var setNgayGioGiaoHang = document.getElementById("setNgayGioGiaoHang");
        var setHinhThucKhuyenMai = document.getElementById("setHinhThucKhuyenMai");
        var setTienKhuyenMai = document.getElementById("setTienKhuyenMai");
        var setGiaTri = document.getElementById("setGiaTri");
        var setTienThue = document.getElementById("setTienThue");
        
        setTenKhachHang.innerHTML = tenKhachHang;
        setNgayGioLap.innerHTML = ngayGioLap;
        setDiaChiNhan.innerHTML = diaChiNhan;
        setNguoiNhan.innerHTML = nguoiNhan;
        setNgayGioGiaoHang.innerHTML = ngayGioGiaoHang;
        setHinhThucKhuyenMai.innerHTML = hinhThucKhuyenMai;
        setTienKhuyenMai.innerHTML = tienKhuyenMai;
        setGiaTri.innerHTML = giaTri;
        setTienThue.innerHTML = tienThue;
        
        
        if (loai == 5) // Định kỳ
        {
            var obj = document.getElementById("ngaygiolap_giao");
            var parent = obj.parentNode;
            parent.removeChild(obj);
            
            var loaiDinhKy = goc.getAttribute("LoaiDinhKy");
            var ngayBatDau = goc.getAttribute("NgayBatDau");
            var ngayKetThuc = goc.getAttribute("NgayKetThuc");
            var thoiDiemGiao = goc.getAttribute("ThoiDiemGiao");
            var gioGiao = goc.getAttribute("GioGiao");
            var tinhTrang = parseInt(goc.getAttribute("TinhTrang"));
            
            var setLoaiDinhKy = document.getElementById("setLoaiDinhKy");
            var setNgayBatDau = document.getElementById("setNgayBatDau");
            var setNgayKetThuc = document.getElementById("setNgayKetThuc");
            var setThoiDiemGiao = document.getElementById("setThoiDiemGiao");
            var setGioGiao = document.getElementById("setGioGiao");
            var setTinhTrang = document.getElementById("setTinhTrang");
            
            setLoaiDinhKy.innerHTML = loaiDinhKy;
            setNgayBatDau.innerHTML = ngayBatDau;
            setNgayKetThuc.innerHTML = ngayKetThuc;
            setThoiDiemGiao.innerHTML = thoiDiemGiao;
            setGioGiao.innerHTML = gioGiao;
            setTinhTrang.innerHTML = tinhTrang == 1 ? "Đã hoàn tất" : "Chưa hoàn tất";
        }
        else
        {
            var dinhky1 = document.getElementById("dinhky1");
            var dinhky2 = document.getElementById("dinhky2");
            var dinhky3 = document.getElementById("dinhky3");
            var dinhky4 = document.getElementById("dinhky4");
            var parent = dinhky1.parentNode;
            parent.removeChild(dinhky1);
            parent.removeChild(dinhky2);
            parent.removeChild(dinhky3);
            parent.removeChild(dinhky4);
        }
        
        var title = document.getElementById("_title");
        switch (loai)
        {
        case 0:
            title.innerHTML = "Chi tiết đơn hàng (Đã lưu)";
            break;
        case 1:
            title.innerHTML = "Chi tiết đơn hàng (Đã đặt hàng nhưng chưa thanh toán)";
            break;
        case 2:
            title.innerHTML = "Chi tiết đơn hàng (Đã thanh toán nhưng chưa giao hàng)";
            break;
        case 3:
            title.innerHTML = "Chi tiết đơn hàng (Đã hoàn tất)";
            break;
        case 4:
            title.innerHTML = "Chi tiết đơn hàng (Trong ngày, đã đặt hàng)";
            break;
        case 5:
            title.innerHTML = "Chi tiết đơn hàng (Định kỳ)";
            break;
        }
    }
    else
        alert("Lỗi đường truyền");
}