// JScript File

function CreateTable()
{
    var arrRequest = new Array(
        "LayDanhSachDonHangChuaThanhToanChuaGiao", "LayDanhSachDonHangDaThanhToanChuaGiao",
        "LayDanhSachDonHangDaHoanTatTrongNgay");
    var url = "He phuc vu/XL_NVXemDanhSachDonHang.aspx?request=" + arrRequest[loaiDonHang - 1] + "&time=" + (new Date().getTime()) + "&";
    
    var myDataSource = new YAHOO.util.DataSource(encodeURI(url));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "DonHang", // Name of the node for each result
        fields : [
            { key: "MaDonHang" }, // Attribute of the resultNode
            { key: "TenKhachHang" }, 
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
                elCell.innerHTML = '<a href="NVXemChiTietDonHang.aspx?MaDonHang=' + maDonHang + '" id="XemChiTiet' + maDonHang + '"><img src="Images/Clipboard.png" title="Xem chi tiết đơn hàng" height="16"/></a>';
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
        { key: "TenKhachHang", label:"Tên khách hàng"},
        { key: "NgayGioLap", label: "Ngày lập", formatter:"date"},                
        { key: "DiaChiNhan", label:"Địa chỉ nhận"},
        { key: "NguoiNhan", label: "Người nhận"},        
        { key: "GiaTri", label: "Tổng trị giá", formatter:"number"},        
        { key: "XemChiTiet", label:"", formatter: YAHOO.widget.DataTable.formatLink}
    ];
    
    if (loaiDonHang != 3) // không phải danh sách đơn hàng đã hoàn tất trong ngày
    {
        var sTrangThai = "";
        var arrTrangThai = new Array({label: "Đã thanh toán", value: 0}, {label: "Đã giao hàng", value: 1});
        switch (loaiDonHang)
        {
            case 1: // Đã đặt hàng nhưng chưa thanh toán
                sTrangThai = "Đã đặt hàng";
                break;
            case 2: // Đã thanh toán nhưng chưa giao hàng
                sTrangThai = "Đã thanh toán";
                arrTrangThai.splice(0, 1);
                break;
        }
        
        // Định nghĩa các formatter dành cho các cột
        // Define a custom format function
        var TrangThaiFormatter = function(elCell, oRecord, oColumn, oData) {     
            elCell.innerHTML = sTrangThai;
        };
        
        var radioEditor = new YAHOO.widget.RadioCellEditor({radioOptions:arrTrangThai});
        radioEditor._elSaveBtn.innerHTML = "Lưu";
        radioEditor._elCancelBtn.innerHTML = "Bỏ qua";
        
        var index = myColumnDefs.length - 2;
        myColumnDefs.splice(index, 0, { key: "TrangThai", label:"Trạng thái", editor: radioEditor, formatter: TrangThaiFormatter});
    }
    else
    {
        var index = myColumnDefs.length - 3;
        myColumnDefs.splice(index, 0, { key: "NgayGioGiaoHang", label: "Ngày giao hàng", formatter:"date"});
    }
        
    var myDataTable = new YAHOO.widget.DataTable("divDanhSachDonHang", myColumnDefs, myDataSource, myConfigs);
        
    return {dataTable: myDataTable, dataSource: myDataSource};
}
// Thêm các event cho table
function AddEvents(obj)
{
    var myDataTable = obj.dataTable;
    var myDataSource = obj.dataSource;
	var highlightEditableCell = function(oArgs) {
        var elCell = oArgs.target;
        if(YAHOO.util.Dom.hasClass(elCell, "yui-dt-editable")) {
            this.highlightCell(elCell);
        }
    };
    
    // Enable inline cell editing 
    myDataTable.subscribe("cellMouseoverEvent", highlightEditableCell);
    myDataTable.subscribe("cellMouseoutEvent", myDataTable.onEventUnhighlightCell);
    myDataTable.subscribe("cellClickEvent", myDataTable.onEventShowCellEditor);

    // Sự kiện click vào nút Save
    // Cập nhật lại tình trạng kích hoạt của tài khoản    
	// Create a Custom Event handler
    var myEditorSaveEvent = function(oArgs) {
        var oEditor = oArgs.editor;
        var trangThai = oArgs.newData;
        var oldData = oArgs.oldData;
        var oRecord = oEditor.getRecord();
        
        if (trangThai == null)            
            return;
            
        var maDonHang = oRecord.getData("MaDonHang");
        CapNhatTrangThai(myDataTable, oRecord, maDonHang, trangThai);
    };    
    myDataTable.subscribe("editorSaveEvent", myEditorSaveEvent);   
}
function LoadTable(t)
{            
    var title = document.getElementById("_title");
    switch (loaiDonHang)
    {
    case 1:
        title.innerHTML = "Danh sách đơn hàng chưa thanh toán";
        break;
    case 2:
        title.innerHTML = "Danh sách đơn hàng chưa giao hàng";
        break;
    case 3:
        title.innerHTML = "Danh sách đơn hàng đã hoàn tất trong ngày";
        break;
    }
    document.body.className += " yui-skin-sam";
    var obj = CreateTable();
    AddEvents(obj);
}
function CapNhatTrangThai(myDataTable, oRecord, maDonHang, trangThai)
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
            myDataTable.deleteRow(oRecord);
        }        
        else
            return "Không thực hiện được do có lỗi phía server";
    }
    else
        return "Lỗi đường truyền";
}