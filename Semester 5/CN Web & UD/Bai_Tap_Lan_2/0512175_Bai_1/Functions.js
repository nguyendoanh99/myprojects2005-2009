// Ham sap xep table, voi cot duoc sap xep la cot thu ColIndex
// Sap xep mot lan tang, roi den mot lan giam nho bien Col[ColInde]
function SortTable(id, ColIndex)
{
    var tbl = document.getElementById(id);
    var _row = tbl.getElementsByTagName("tr"); 
    Col[ColIndex] = !Col[ColIndex];
    var Type = Col[ColIndex];
    var A = new Array();
    var i;
    var j;
    // Nap du lieu vao bo nho    
    for (i = 1; i < _row.length; ++i)
    {
        A[i - 1] = new Array();
        var _cell = _row[i].getElementsByTagName("td");
        for (j = 0; j < _cell.length; ++j)
            A[i - 1][j] = _cell[j].innerHTML;
    }
    // Sap xep
    var temp;
    
    for (i = 0; i < A.length; ++i)    
        for (j = i + 1; j < A.length; ++j)
            if (Type == true)
            {
                if (CheckDate(A[0][ColIndex]) == "") // La kieu ngay
                {
                    if (InitDate(A[i][ColIndex]) < InitDate(A[j][ColIndex]))
                    {            
                        temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;   
                    }
                }
                else
                {   
                    if (A[i][ColIndex] < A[j][ColIndex])
                    {            
                        temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;   
                    }
                }
            }
            else
            {
                if (CheckDate(A[0][ColIndex]) == "") // La kieu ngay
                {
                    if (InitDate(A[i][ColIndex]) > InitDate(A[j][ColIndex]))
                    {            
                        temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;   
                    }
                }
                else
                {   
                    if (A[i][ColIndex] > A[j][ColIndex])
                    {            
                        temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;   
                    }
                }
            }
    // Dua du lieu vao lai table            
    for (i = 1; i < _row.length; ++i)
    {        
        var _cell = _row[i].getElementsByTagName("td");
        for (j = 0; j < _cell.length; ++j)
            _cell[j].innerHTML = A[i - 1][j];
    }
}
// Hàm kiểm tra số điện thoại hợp lệ
// return true : là số điện thoại
// return false : không là số điện thoại
function IsPhoneNumber(str)
{
    var _result = true;
    // str = XXXXXX
    if (str.length == 6)           
        _result = IsPositiveNumber(str);    
    else
        // str = XXX-XXXXXX
        if (str.length == 10)
        {
            var temp = str.split("-");
            if (temp.length == 2 && temp[0].length == 3 && temp[1].length == 6)            
                _result = IsPositiveNumber(temp[0]) && IsPositiveNumber(temp[1]);            
            else
                _result = false;
        }
        else
            _result = false;
            
    return _result;
}

// Hàm kiểm tra str có phải là địa chỉ mail của yahoo hoặc google hay không
// return true: là địa chỉ mail của yahoo hoặc google
// return false: không phải là địa chỉ mail của yahoo hoặc google
function IsGoogleOrYahooEmail(str)
{
    var _result = true;
    
    if (str.indexOf(" ") != -1) 
        _result = false;
    else
    {
        var temp = str.split("@");
        if (temp.length == 2)
        {            
            if (temp[0] == "" || !(temp[1] == "google.com" || temp[1] == "yahoo.com"))   
                _result = false;            
        }
        else
            _result = false;
    }
    
    return _result;
}
// Hàm kiểm tra lỗi nhập dữ liệu
// Trả về String
function CheckError(strID, strName, strAddress, strPhone, strBirthDay, strEmail)
{    
	var _result = new String();
	// Kiểm tra MSSV có hợp lệ hay không
	if (Trim(strID) == "")
	    _result = _result + "Mã số sinh viên không được bỏ trống.\n";
	// Kiểm tra Họ tên có hợp lệ hay không
	if (Trim(strName) == "")
	    _result = _result + "Họ tên sinh viên không được bỏ trống.\n";
	// Kiểm tra Địa chỉ có hợp lệ hay không
	if (Trim(strAddress) == "")
	    _result = _result + "Địa chỉ không được bỏ trống.\n";
	// Kiểm tra Số điện thoại có hợp lệ hay không
	if (IsPhoneNumber(Trim(strPhone)) == false)
	    _result = _result + "Số điện thoại phải có format XXX-XXXXXX (có mã vùng) hoặc XXXXXX(không cần mã vùng).\n";
	// Kiểm tra ngày sinh có hợp lệ hay không
	var temp = CheckDate(strBirthDay, InitDate("1/1/1900"), InitDate("31/12/2100"));
    if (temp != "")	
        _result = _result + temp.replace(strBirthDay, "Ngày sinh");
	// Kiểm tra Email có hợp lệ hay không
    if (!IsGoogleOrYahooEmail(Trim(strEmail)))
        _result = _result + "Chỉ chấp nhận địa chỉ email của Yahoo hoặc Google.\n"
	return _result;
}
// Hàm đọc nội dung của file XML
// return Array(String)
function ReadXMLFile(URL)
{    
    var XMLDoc = LoadXMLDoc(URL);
    var Root = XMLDoc.documentElement;    
    var y = Root.childNodes;
    var _result = new Array();
    
    for (var i = 0, index = 0; i < y.length; ++i)    
        if (y[i].nodeType == 1) // element node
            _result[index++] = y[i].childNodes[0].nodeValue;    
    
    return _result;
}
// Hàm chèn 1 dòng vào table với các cell[i] = Info[i], Info là một mảng chuỗi
function InsertRow(id, Info)
{   
    var z = document.getElementById(id).getElementsByTagName("tr"); 
    var x = document.getElementById(id).insertRow(z.length);    
    var y;
    
    x.id = "row" + z.length;
    
    x.onmouseover = function() {FocusEvent(x.id);}; //http://p2p.wrox.com/topic.asp?TOPIC_ID=20989        
    x.onmouseout = function() {LostFocusEvent(x.id);};
    
    for (var i = 0; i < Info.length; ++i)        
    {
        y = x.insertCell(i);
        y.innerHTML = Info[i];    
        y.align = "center";        
    }
}
