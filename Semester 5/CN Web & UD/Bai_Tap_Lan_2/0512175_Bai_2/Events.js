// Ham xu ly khi click vao menuitem New
function New_Click()
{
    CurrentID++;
    listWindow.AddWindow("" + CurrentID, "title" + CurrentID, "300px", "100px", "100px", "100px");
    ChangeImage("" + CurrentID);
}
// Hàm xử lý khi click vào menuitem
function MenuItem_Click(id)
{
    var x = document.getElementById(id);
  
    alert("Bạn vừa chọn menuItem \"" + x.getElementsByTagName("a")[0].childNodes[0].nodeValue + "\""); 
}
// Hàm xử lý khi click vào PopupMenuItem
function pMenuItem_Click(id)
{
    var x = document.getElementById(id);
    var p = document.getElementById("popupmenu");
  
    alert("Bạn vừa chọn menuItem \"" + x.getElementsByTagName("a")[0].childNodes[0].nodeValue + "\""); 
    p.style.display = "none";
}
// Ham xu ly khi co su kien nhap chuot
function MouseDown(e)
{     
    HideMenu(e);
    
    var name;
    var temp;
    //http://javascript.internet.com/page-details/drag-n-drop.html
    if (IE) // code cho IE
    {
        obj = event.srcElement; 
	    cursorX = event.clientX;
    	cursorY = event.clientY;        
    	temp = event;
    }
    else
    {        
        obj = e.target;       
        cursorX = e.pageX;
        cursorY = e.pageY;
        temp = e;
    }
    // Chi cho phep di chuyen nhung object co name = "title"
    // Hoac thay doi kich thuoc nhung object co name = "handle"
    name = obj.name;        
    if (name != "title" && name != "handle")
    {
        obj = null;
        return;
    }
    
    obj = obj.parentNode;
    if (name == "title")
        document.onmousemove = DrapDrop;
    else
        document.onmousemove = ChangeSizeWindow;

}
// Ham xu ly khi co su kien di nha phim chuot
function MouseUp()
{
    //http://javascript.internet.com/page-details/drag-n-drop.html
	obj = null;
	document.onmousemove = null;
}
