// JScript File

// JScript File
var myDataSource;
function CreateTable()
{
    myDataSource = new YAHOO.util.DataSource(encodeURI("He phuc vu/XL_QTDanhSachEmailDaGui.aspx?request=LayDanhSach&time=" + (new Date().getTime()) + "&"));
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "TaiKhoan", // Name of the node for each result
        fields : [
            { key: "MaMail" }, // Attribute of the resultNode
            { key: "Username" }, 
            { key: "Email" },
            { key: "NgayGui"},
            { key: "TieuDe"}
        ]
        
    };        
        
    var myConfigs = {
        // Phân trang
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 10 // Số dòng tối đa của một trang
        })
    };
    
    // Formatter cho STT
    var STTFormatter = function(elCell, oRecord, oColumn, oData) {
        elCell.innerHTML = myDataTable.getRecordIndex(oRecord) + 1;
    };
    
    // Định nghĩa cột
    var myColumnDefs = [
        { key: "MaMail", hidden: true },
        { label:"STT", formatter: STTFormatter},
        { key: "Username"},                
        { key: "Email"},
        { key: "NgayGui", label: "Ngày gửi"},
        { key: "TieuDe", label: "Tiêu đề"}
    ];
    
    var myDataTable = new YAHOO.widget.DataTable("divDsEmail", myColumnDefs, myDataSource, myConfigs);   
    
    return myDataTable;
}
// Thêm các event cho table
function AddEvents(myDataTable)
{
    var maNguoiDung;
    var oRecord;
    // Enable inline cell editing 

    // Enables row highlighting
    myDataTable.subscribe("rowMouseoverEvent", myDataTable.onEventHighlightRow);
    myDataTable.subscribe("rowMouseoutEvent", myDataTable.onEventUnhighlightRow);

    // Selects any cell that receives a checkbox click
    myDataTable.subscribe("rowClickEvent", function(oArgs){
        var target = oArgs.target;
        var id = oArgs.target.cells[0].innerText;
        var str = LayNoiDungEmail(id);
        if (str != "")
            alert(str);
    });
    
}
function LoadTable()
{     
    document.body.className += " yui-skin-sam";
    var myDataTable = CreateTable();
    AddEvents(myDataTable);
}

function LayNoiDungEmail(maMail)
{
    var ham = new XL_HAM("He phuc vu/XL_QTDanhSachEmailDaGui");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "LayNoiDungEmail"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaMail", maMail));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var obj = document.getElementById("body");
    var body = "";
    obj.innerHTML = body;
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var kq = goc.getAttribute("kq");
        if (kq != "")
        {   
            body = decodeURI(kq);
            obj.innerHTML =  body ;
             return "";
        }        
        else
        {
            return "Không lấy được nội dung email do có lỗi phía server";
        }
    }
    else
        return "Lỗi đường truyền";
    
}