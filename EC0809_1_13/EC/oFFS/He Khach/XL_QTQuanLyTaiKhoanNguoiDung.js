// JScript File
var myDataSource;
function CreateTable()
{
    myDataSource = new YAHOO.util.DataSource(encodeURI("He phuc vu/XL_QTQuanLyTaiKhoanNguoiDung.aspx?request=LayDanhSachNguoiDung&time=" + (new Date().getTime()) + "&"));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "TaiKhoan", // Name of the node for each result
        fields : [
            { key: "MaNguoiDung" }, // Attribute of the resultNode
            { key: "Username" }, 
            { key: "HoTen" },
            { key: "PhanLoai"},
            { key: "KichHoat"}
        ],
        metaNode : "DANH_SACH", // Name of the node holding meta data
        metaFields : {
            totalRecords : "totalRecords" // Tổng số dòng 
        }
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
    
    // Định nghĩa các formatter dành cho các cột
    // Define a custom format function
    var TinhTrangKichHoatFormatter = function(elCell, oRecord, oColumn, oData) {
        var oTinhTrang = parseInt(oData);
        elCell.innerHTML = oTinhTrang==1 ? "Kích hoạt" : "Vô hiệu hóa";
    };
    
    // Override the built-in formatter
    // Cho nút xóa tài khoản, gửi lại mật khẩu
    YAHOO.widget.DataTable.formatLink = function(elCell, oRecord, oColumn, oData) {
        var maNguoiDung = oRecord.getData("MaNguoiDung");
        if (oColumn.key.indexOf("XoaTaiKhoan") != -1)
            elCell.innerHTML = '<a id="XoaTaiKhoan' + maNguoiDung + '"><img src="Images/Close.png" title="Xóa tài khoản" height="16"/></a>';
        else
            elCell.innerHTML = '<a id="GuiLaiMatKhau' + maNguoiDung + '"><img src="Images/jamembo-new-email.png" title="Gửi lại mật khẩu" height="16"/></a>';
    };
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
    
    var radioEditor = new YAHOO.widget.RadioCellEditor({radioOptions:[{label: "Kích hoạt", value: 1}, {label: "Vô hiệu hóa", value: 0}]});
    radioEditor._elSaveBtn.innerHTML = "Lưu";
    radioEditor._elCancelBtn.innerHTML = "Bỏ qua";
    // Định nghĩa cột
    var myColumnDefs = [
        { label:"STT", formatter: STTFormatter},
        { key: "Username", sortable:true },                
        { key: "HoTen", label:"Họ tên" },
        { key: "PhanLoai", label: "Phân loại"},
        { key: "KichHoat", label: "Tình trạng", editor: radioEditor, formatter: TinhTrangKichHoatFormatter},
        { key: "XoaTaiKhoan", label:"", formatter: YAHOO.widget.DataTable.formatLink},
        { key: "GuiLaiMatKhau", label: "", formatter: YAHOO.widget.DataTable.formatLink}
    ];
    
    var myDataTable = new YAHOO.widget.DataTable("divDsNguoiDung", myColumnDefs, myDataSource, myConfigs);
    // Update totalRecords on the fly with value from server
    // Dành cho phân trang, cập nhật lại tổng số dòng
    myDataTable.handleDataReturnPayload = function(oRequest, oResponse, oPayload) {
        oPayload.totalRecords = parseInt(oResponse.meta.totalRecords);
        return oPayload;
    }
    
    return myDataTable;
}
// Thêm các event cho table
function AddEvents(myDataTable)
{
    var maNguoiDung;
    var oRecord;
    // Define various event handlers for Dialog
	var handleYes = function() {
	    this.hide();
	    var kq = XoaTaiKhoan(maNguoiDung);
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
			   icon: YAHOO.widget.SimpleDialog.ICON_HELP,
			   constraintoviewport: true,
			   buttons: [ { text:"Có", handler:handleYes },
						  { text:"Không",  handler:handleNo, isDefault:true } ]
			 } );
	Deletedialog.setHeader("Xóa đơn hàng?");
	
	// Render the Dialog
	Deletedialog.render(document.body);
	
    var highlightEditableCell = function(oArgs) {
        var elCell = oArgs.target;
        if(YAHOO.util.Dom.hasClass(elCell, "yui-dt-editable") 
            || YAHOO.util.Dom.hasClass(elCell, "yui-dt0-col-XoaTaiKhoan")
            || YAHOO.util.Dom.hasClass(elCell, "yui-dt0-col-GuiLaiMatKhau")) {
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
        var tinhTrang = oArgs.newData;
        var oldData = oArgs.oldData;
        if (parseInt(tinhTrang) == parseInt(oldData))
            return;
            
        var maNguoiDung = oEditor.getRecord().getData("MaNguoiDung");
        CapNhatTinhTrangKichHoat(maNguoiDung, tinhTrang);
    };
	myDataTable.subscribe("editorSaveEvent", myEditorSaveEvent);     
	
    // Sự kiện click trên link (Xóa tài khoản, Gửi lại mật khẩu)
    myDataTable.subscribe("linkClickEvent", function(oArgs){
        var target = oArgs.target;
        oRecord = this.getRecord(target);
        maNguoiDung = oRecord.getData("MaNguoiDung");        
        var hoTen = oRecord.getData("HoTen");
        if (target.id.indexOf("XoaTaiKhoan") != -1) // xóa tài khoản người dùng
        {
            Deletedialog.setBody("Bạn có muốn xóa người dùng '" + hoTen + "' không?"); 
            Deletedialog.show();
        }
        else
        {
            var username = oRecord.getData("Username");
            var str = GuiLaiMatKhau(username);
            alert(str);
        }
    });
}
function LoadTable()
{     
    document.body.className += " yui-skin-sam";
    var myDataTable = CreateTable();
    AddEvents(myDataTable);
}

function CapNhatTinhTrangKichHoat(maNguoiDung, tinhTrang)
{
    var ham = new XL_HAM("He phuc vu/XL_QTQuanLyTaiKhoanNguoiDung");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "CapNhatTinhTrangKichHoat"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaNguoiDung", maNguoiDung));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("TinhTrang", tinhTrang));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
        {            
            var chk = document.getElementById("chkKichHoat" + maNguoiDung);
            chk.setAttribute("checked", "checked");
            obj.disabled = "true";
            var voHieu = document.getElementById("butVoHieu" + maNguoiDung);
            voHieu.disabled = "";
        }        
        else
            return "Không thực hiện được do có lỗi phía server";
    }
    else
        return "Lỗi đường truyền";
}
function GuiLaiMatKhau(username)
{
    var ham = new XL_HAM("He phuc vu/XL_QTQuanLyTaiKhoanNguoiDung");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "GuiLaiMatKhau"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("Username", username));
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
            return "Không reset được mật khẩu do có lỗi phía server (lỗi csdl hoặc lỗi gửi mail)";
        }
    }
    else
        return "Lỗi đường truyền";
}
function XoaTaiKhoan(maNguoiDung)
{
    var ham = new XL_HAM("He phuc vu/XL_QTQuanLyTaiKhoanNguoiDung");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "XoaTaiKhoan"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaNguoiDung", maNguoiDung));
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