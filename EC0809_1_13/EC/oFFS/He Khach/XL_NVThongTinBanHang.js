// JScript File
function CreateTable()
{
    var myDataSource = new YAHOO.util.DataSource(encodeURI("He phuc vu/XL_NVThongTinBanHang.aspx?time=" + (new Date().getTime())));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "BanHang", // Name of the node for each result
        fields : [
            { key: "MaLoai" }, // Attribute of the resultNode
            { key: "DienGiai" }, 
            { key: "SoLuongDonHang"}
        ]
    };        
    
    // Override the built-in formatter
    YAHOO.widget.DataTable.formatLink = function(elCell, oRecord, oColumn, oData) {
        var maLoai = oRecord.getData("MaLoai");
        var dienGiai = oRecord.getData("DienGiai").replace("Đơn hàng ", "");
        if (oColumn.key.indexOf("XemChiTiet") != -1)
            elCell.innerHTML = '<a href="NVXemDanhSachDonHang.aspx?loai=' + maLoai + '" id="XemChiTiet' + maLoai + '"><img src="Images/Clipboard.png"'
            + 'title="Xem danh sách các đơn hàng ' + dienGiai + '" height="16"/></a>';
    };
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
        
    // Định nghĩa cột
    var myColumnDefs = [
        { label:"STT", formatter: STTFormatter},
        { key: "DienGiai", label: "Diễn giải", sortable:true},                
        { key: "SoLuongDonHang", label:"Số lượng đơn hàng", sortable:true, formatter:"number"},
        { key: "XemChiTiet", label:"", formatter: YAHOO.widget.DataTable.formatLink}
    ];
    
    var myDataTable = new YAHOO.widget.DataTable("divThongTinBanHang", myColumnDefs, myDataSource);
    
    return myDataTable;
}
// Thêm các event cho table
function AddEvents(myDataTable)
{
    // Enables row highlighting
//     myDataTable.subscribe("rowMouseoverEvent", myDataTable.onEventHighlightRow);
//     myDataTable.subscribe("rowMouseoutEvent", myDataTable.onEventUnhighlightRow);
}
function LoadTable()
{            
    var myDataTable = CreateTable();
    AddEvents(myDataTable);
}
