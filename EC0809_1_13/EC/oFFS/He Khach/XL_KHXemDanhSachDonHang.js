// JScript File

function CreateTable()
{
    var arrRequest = new Array(
        "LayDanhSachDonHangDaLuu", "LayDanhSachDonHangDaDatChuaThanhToan",
        "LayDanhSachDonHangDaThanhToanChuaGiao", "LayDanhSachDonHangDaHoanTat",
        "LayDanhSachDonHangTrongNgay", "LayDanhSachDonHangDinhKy");
    var url = "He phuc vu/XL_KHXemDanhSachDonHang.aspx?request=" + arrRequest[loaiDonHang - 1] + "&time=" + (new Date().getTime()) + "&";
    
    var myDataSource = new YAHOO.util.DataSource(encodeURI(url));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "DonHang", // Name of the node for each result
        fields : [
            { key: "MaDonHang" }, // Attribute of the resultNode
            { key: "NgayGioLap" }, 
            { key: "DiaChiNhan"},
            { key: "NguoiNhan"},
            { key: "NgayGioGiaoHang"},
            { key: "GiaTri"}
        ]
    };        
    
    // Override the built-in formatter
    // Cho nút xóa tài khoản, gửi lại mật khẩu
    YAHOO.widget.DataTable.formatLink = function(elCell, oRecord, oColumn, oData) {
        var maDonHang = oRecord.getData("MaDonHang");
        if (oColumn.key.indexOf("XoaDonHang") != -1)
            elCell.innerHTML = '<a id="XoaDonHang' + maDonHang + '"><img src="Images/Close.png" title="Xóa đơn hàng" height="16"/></a>';
        else
            if (oColumn.key.indexOf("XemChiTiet") != -1)
                elCell.innerHTML = '<a href="KHXemChiTietDonHang.aspx?MaDonHang=' + maDonHang + '" id="XemChiTiet' + maDonHang + '"><img src="Images/Clipboard.png" title="Xem chi tiết đơn hàng" height="16"/></a>';
    };
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
        
     var myRequestBuilder = function(oState, oSelf) {
        // Get states or use defaults
        oState = oState || {pagination:null, sortedBy:null};
        var sort = (oState.sortedBy) ? oState.sortedBy.key : "myDefaultColumnKey";
        var dir = (oState.sortedBy && oState.sortedBy.dir === DT.CLASS_DESC) ? "false" : "true";
        var startIndex = (oState.pagination) ? oState.pagination.recordOffset : 0;
        var results = (oState.pagination) ? oState.pagination.rowsPerPage : 100;
        
        // Build custom request
        return  "column=" + sort +
                "&asc=" + true +
                "&startIndex=" + startIndex +
                "&results=" + results +
                "&t=" + (new Date().getTime());
    };
    
    var myConfigs = {
        generateRequest : myRequestBuilder,
        // Set up pagination
        initialRequest: "sort=id&dir=asc&startIndex=0&results=10", // Initial request for first page of data
        // Phân trang
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 10 // Số dòng tối đa của một trang
        }),
        // Sorting and pagination will be routed to the server via generateRequest
        dynamicData : true
    };
    
    // Định nghĩa cột
    var myColumnDefs = [
        { key: "STT", label:"STT", formatter: STTFormatter},
        { key: "NgayGioLap", label: "Ngày lập", formatter:"date"},                
        { key: "DiaChiNhan", label:"Địa chỉ nhận"},
        { key: "NguoiNhan", label: "Người nhận"},
        { key: "GiaTri", label: "Tổng trị giá", formatter:"number"},
        { key: "XemChiTiet", label:"", formatter: YAHOO.widget.DataTable.formatLink}
    ];
    
    // Thêm nút xóa vào danh sách đơn hàng đã lưu
    if (loaiDonHang == 1) // danh sách đơn hàng đã lưu
        myColumnDefs.push({ key: "XoaDonHang", label:"", formatter: YAHOO.widget.DataTable.formatLink});
    else 
        if (loaiDonHang == 6) // danh sách đơn hàng định kỳ
        {
            // Formatter cho STT
            var TinhTrangFormatter = function(elCell, oRecord, oColumn, oData) {
                var value = parseInt(oData);
                elCell.innerHTML = value == 1 ? "Đã hoàn tất" : "Chưa hoàn tất";
            };
            // Bỏ cột ngày giờ giao hàng
            myColumnDefs.splice(1, 1);
            var index = myColumnDefs.length - 2;
            myColumnDefs.splice(index, 0, { key: "LoaiDinhKy", label:"Loại định kỳ"},
                { key: "NgayBatDau", label:"Ngày bắt đầu", formatter:"date"},
                 { key: "NgayKetThuc", label:"Ngày kết thúc", formatter:"date"},
                { key: "TinhTrang", label:"Tình trạng", formatter: TinhTrangFormatter});
                
            // Thêm field cho datasource    
            var fields =myDataSource.responseSchema.fields;
            fields.push(
                { key: "LoaiDinhKy"},
                { key: "NgayBatDau"},
                { key: "NgayKetThuc"},
                { key: "TinhTrang"});
        }
        else if (loaiDonHang == 4)
        {
            var index = myColumnDefs.length - 3;
            myColumnDefs.splice(index, 0, { key: "NgayGioGiaoHang", label: "Ngày giao hàng", formatter:"date"});
        }
    var myDataTable = new YAHOO.widget.DataTable("divDanhSachDonHang", myColumnDefs, myDataSource, myConfigs);
        
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
    AddEvents(myDataTable);
}
function XoaDonHang(maDonHang)
{
    var ham = new XL_HAM("He phuc vu/XL_KHXemDanhSachDonHang");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "XoaDonHang"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaDonHang", maDonHang));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
        {   
             return "";
        }        
        else
        {
            return "Không xóa được do có lỗi phía server";
        }
    }
    else
        return "Lỗi đường truyền";
    
}