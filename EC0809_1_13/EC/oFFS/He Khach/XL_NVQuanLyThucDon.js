// JScript File
var myDataSource;
function CreateTable()
{
    myDataSource = new YAHOO.util.DataSource(encodeURI("He phuc vu/XL_NVQuanLyThucDon.aspx?request=LayDanhSachThucDon&time=" + (new Date().getTime()) + "&"));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "ThucDon", // Name of the node for each result
        fields : [
            { key: "MaThucDon" }, // Attribute of the resultNode
            { key: "TenThucDon" }, 
            { key: "LoaiThucDon" },
            { key: "MoTa"},
            { key: "HinhAnhMinhHoa"}, 
            { key: "Gia"}, 
            { key: "TrangThaiHienThi"}, 
            { key: "TinhTrang"}
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
    var TinhTrangFormatter = function(elCell, oRecord, oColumn, oData) {
        var oTinhTrang = parseInt(oData);
        elCell.innerHTML = oTinhTrang==1 ? "Còn" : "Hết";
    };
    var HienThiFormatter = function(elCell, oRecord, oColumn, oData) {
        var oTinhTrang = parseInt(oData);
        elCell.innerHTML = oTinhTrang==1 ? "Hiện" : "Ẩn";
    };
    
    // Override the built-in formatter
    // Cho nút xóa tài khoản, gửi lại mật khẩu
    YAHOO.widget.DataTable.formatLink = function(elCell, oRecord, oColumn, oData) {
        var maThucDon = oRecord.getData("MaThucDon");
        if (oColumn.key.indexOf("XoaThucDon") != -1)
            elCell.innerHTML = '<a id="XoaThucDon' + maThucDon + '"><img src="Images/Close.png" title="Xóa thực đơn" height="16"/></a>';
    };
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
    
    var HinhAnhFormatter = function(elCell, oRecord, oColumn, oData) {
        var hinhAnh = oRecord.getData("HinhAnhMinhHoa");
        elCell.innerHTML = '<img src="' + hinhAnh + '" height="48" width="48"/>';
    };
    
    var radioEditorHienThi = new YAHOO.widget.RadioCellEditor({radioOptions:[{label: "Hiện", value: 1}, {label: "Ẩn", value: 0}]});
    radioEditorHienThi._elSaveBtn.innerHTML = "Lưu";
    radioEditorHienThi._elCancelBtn.innerHTML = "Bỏ qua";
    
    var radioEditorTinhTrang = new YAHOO.widget.RadioCellEditor({radioOptions:[{label: "Còn", value: 1}, {label: "Hết", value: 0}]});
    radioEditorTinhTrang._elSaveBtn.innerHTML = "Lưu";
    radioEditorTinhTrang._elCancelBtn.innerHTML = "Bỏ qua";
    // Định nghĩa cột
    var myColumnDefs = [
        { label:"STT", formatter: STTFormatter},
        { key: "HinhAnhMinhHoa", label: "", formatter: HinhAnhFormatter},                
        { key: "TenThucDon", label: "Tên thực đơn"},                
        { key: "LoaiThucDon", label:"Loại thực đơn" },
        { key: "MoTa", label: "Mô tả"},
        { key: "Gia", label: "Giá", formatter: "number"},
        { key: "TrangThaiHienThi", label: "Trạng thái", editor: radioEditorHienThi, formatter: HienThiFormatter},
        { key: "TinhTrang", label: "Tình trạng", editor: radioEditorTinhTrang, formatter: TinhTrangFormatter},
        { key: "XoaThucDon", label:"", formatter: YAHOO.widget.DataTable.formatLink}
    ];
    
    var myDataTable = new YAHOO.widget.DataTable("divDsThucDon", myColumnDefs, myDataSource, myConfigs);
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
    var maThucDon;
    var oRecord;
    // Define various event handlers for Dialog
	var handleYes = function() {
	    this.hide();
	    var kq = XoaThucDon(maThucDon);
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
	Deletedialog.setHeader("Xóa thực đơn?");
	
	// Render the Dialog
	Deletedialog.render(document.body);
	
    var highlightEditableCell = function(oArgs) {
        var elCell = oArgs.target;
        if(YAHOO.util.Dom.hasClass(elCell, "yui-dt-editable") 
            || YAHOO.util.Dom.hasClass(elCell, "yui-dt0-col-XoaThucDon")) {
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
        
        var key = oEditor.getColumn().key;
        var maThucDon = oEditor.getRecord().getData("MaThucDon");
        
        if (key.indexOf("TinhTrang") != -1)
            CapNhat("CapNhatTinhTrang", maThucDon, tinhTrang);
        else
            CapNhat("CapNhatTrangThaiHienThi", maThucDon, tinhTrang);
    };
	myDataTable.subscribe("editorSaveEvent", myEditorSaveEvent);     
	
    // Sự kiện click trên link (Xóa tài khoản, Gửi lại mật khẩu)
    myDataTable.subscribe("linkClickEvent", function(oArgs){
        var target = oArgs.target;
        oRecord = this.getRecord(target);
        maThucDon = oRecord.getData("MaThucDon");
        var tenThucDon = oRecord.getData("TenThucDon");
        if (target.id.indexOf("XoaThucDon") != -1) // xóa thực đơn
        {
            Deletedialog.setBody("Bạn có muốn xóa thực đơn '" + tenThucDon + "' không?"); 
            Deletedialog.show();
        }
    });
}
function LoadTable()
{     
    document.body.className += " yui-skin-sam";
    var myDataTable = CreateTable();
    AddEvents(myDataTable);
}

function CapNhat(request, maThucDon, giaTri)
{
    var ham = new XL_HAM("He phuc vu/XL_NVQuanLyThucDon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", request));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaThucDon", maThucDon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("GiaTri", giaTri));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
        {            
        }        
        else
            return "Không thực hiện được do có lỗi phía server";
    }
    else
        return "Lỗi đường truyền";
}
function XoaThucDon(maThucDon)
{
    var ham = new XL_HAM("He phuc vu/XL_NVQuanLyThucDon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "XoaThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaThucDon", maThucDon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = parseInt(goc.getAttribute("kq"));
        if (kq == 1)
             return "";
        else
            return "Không xóa được do có lỗi phía server";
    }
    else
        return "Lỗi đường truyền";
    
}