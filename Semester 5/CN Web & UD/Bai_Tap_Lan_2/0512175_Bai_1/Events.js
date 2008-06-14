// Hàm xử lý khi x được focus
function FocusEvent(x)
{
	document.getElementById(x).style.background = "#FFFF99";
}
// Hàm xử lý khi x mất focus
function LostFocusEvent(x)
{
    document.getElementById(x).style.background = "#FFFFFF";
}
// Hàm xử lý khi click vào butRegister
function butRegister_Click()
{		
	var strID = document.getElementById("txtID").value;
    var strName = document.getElementById("txtName").value;
    var strAddress = document.getElementById("txtAddress").value;
    var strPhone = document.getElementById("txtPhone").value;
    
    var x = document.getElementById("mnuMonth");    
    var strBirthday = document.getElementById("txtDate").value;
    strBirthday = strBirthday + "/" + x.options[x.selectedIndex].text;    
    strBirthday = strBirthday + "/" + document.getElementById("txtYear").value;    
    var strEmail = document.getElementById("txtEmail").value;
    
    var temp = CheckError(strID, strName, strAddress, strPhone, strBirthday, strEmail);

    if (temp == "")
    {
        var str = new Array();
        str[0] = strID;
        str[1] = strName;
        if (document.getElementById("chkMale").checked == true)
            str[2] = "Nam";
        else
            str[2] = "Nữ";
        str[3] = strBirthday;        
        InsertRow("tableStudents", str);
        document.getElementById("butDelete").click();
    }
    else    
        alert(temp);
}
// Hàm xử lý khi click vào chkSex
function chkSex_Click(id)
{
    var x = document.getElementById("chkMale");
    var y = document.getElementById("chkFemale");
    
    if (id == "chkMale")
    {
        x.checked = true;
        y.checked = false;
    }
    else
    {
        x.checked = false;
        y.checked = true;
    }    
}
// Hàm khởi tạo của mnuMonth
function mnuMonth_Init()
{
    var x = document.getElementById("mnuMonth");    
    var e;
    
    for (var i = 1; i < 13; ++i)
    {
        e = document.createElement("option");
        if (i < 10)
            e.text = "0" + i;
        else
            e.text = i;
           
        try
        {
            x.add(e, null);
        }
        catch (err)
        {
            x.add(e); // IE Only
        }
    }
}
// Hàm khởi tạo của lstSubjects
function lstSubjects_Init(URL)
{
    var x = document.getElementById("lstSubjects");
    var e;
    var Objects = ReadXMLFile(URL);
    for (var i = 0; i < Objects.length; ++i)
    {
        e = document.createElement("option");
        e.text = Objects[i];
        
        try
        {
            x.add(e, null);
        }
        catch (err)
        {
            x.add(e);
        }
    }
}
// Onload()
function Load()
{
    mnuMonth_Init();
    lstSubjects_Init("Subjects.xml");
}
// Hàm di chuyển các item được chọn của lstSrc sang lstDes
function MoveItem(lstSrc, lstDes)
{    
    var x = document.getElementById(lstSrc.id);
    var y = document.getElementById(lstDes.id);
    var e;

    var i = 0;
    while (i < x.length)
    {
        if (x.options[i].selected == true)
        {
            e = document.createElement("option");    
            e.text = x.options[i].text;
            // Thêm item vào Des
            try
            {
                y.add(e, null);
            }
            catch (err)
            {
                y.add(e); // IE Only
            }
            // Xóa item ở Src
            x.remove(i);
        }
        else
            ++i;
    }       
}
// Hàm di chuyển tất cả item của lstSrc sang lstDes
function MoveItemsAll(lstSrc, lstDes)
{
    var x = document.getElementById(lstSrc.id);
    var y = document.getElementById(lstDes.id);
    
    for (var i = 0; i < x.length; ++i)
        x.options[i].selected = true;
        
    MoveItem(lstSrc, lstDes);
}
// Hàm xử lý khi click vào nút OK
function butOK_Click()
{
    var str = "";
    var x = document.getElementById("lstSelectedSubjects");
    
    for (var i = 0; i < x.length; ++i)    
        str = str + "        " + x.options[i].text + "\n";
        
    if (str != "")
        alert("Danh sách các môn học được chọn là:\n" + str);
    else
        alert("Chưa có môn học nào được chọn.");
}