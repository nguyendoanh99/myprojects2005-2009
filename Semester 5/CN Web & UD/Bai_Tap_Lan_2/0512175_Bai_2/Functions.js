var obj; // cho biet doi tuong nao dang duoc chon, dung cho xu ly drag & drop, thay doi kich thuoc mang hinh
var cursorX; // vi tri chuot truoc do (X)
var cursorY; // vi tri chuot truoc do (Y)
// Thay doi hinh cua window
function ChangeImage (id)
{
    var obj = listWindow.Get("" + id);
    obj.mIndex++;
    if (obj.mIndex >= ListImage.length)
        obj.mIndex = 0;
        
    var x = document.getElementById("image" + obj.mId);    
    x.src = "images/" + ListImage[obj.mIndex];
    obj.mTime = setTimeout("ChangeImage(" + id + ")", 5000);    
}
// Ham xu ly Drap & Drop
function DrapDrop(e)
{
	if (obj)
	{
	    var temp = listWindow.Get(obj.id);
	    if (temp.mCurrentState != 0) // trang thai phai la normal moi cho phep di chuyen
	        return;
	        
	    //http://javascript.internet.com/page-details/drag-n-drop.html
	    var x, y;
	    if (IE)
	    {
            x = event.clientX;
            y = event.clientY;
        }
        else
        {
            x = e.pageX;
            y = e.pageY;
		}
		var Dx = x - cursorX;
		var Dy = y - cursorY;
		var _left = obj.style.left.replace("px", "");
		var _top = obj.style.top.replace("px", "");

        // Toa do moi cua doi tuong	    
        temp.MoveWindow(parseInt(_left) + Dx + 'px', parseInt(_top) + Dy + 'px');  

		// Gan lai cursorX, cursorY la vi tri hien tai cua chuot
		cursorX = x;
	    cursorY = y;
	}
}
// Ham xu ly khi thay doi kich thuoc window
function ChangeSizeWindow(e)
{
	if (obj) // trang thai phai la normal moi cho phep thay doi kich thuoc window
	{	
	    var _window = obj.parentNode; // status --> window
	    var temp = listWindow.Get(_window.id);
	    if (temp.mCurrentState != 0) // trang thai phai la normal moi cho phep di chuyen
	        return;
	
	    //http://javascript.internet.com/page-details/drag-n-drop.html
	    var x, y;
	    
	    if (IE)
	    {
            x = event.clientX;
            y = event.clientY;
        }
        else
        {            
            x = e.pageX;
            y = e.pageY;            
		}
		
		var Dx = parseInt(x - cursorX);
		var Dy = parseInt(y - cursorY);
		
		var _height = parseInt(_window.style.height.replace("px", ""));
		var _width = parseInt(_window.style.width.replace("px", ""));
	    
        // Toa do moi cua doi tuong	    
        _height += Dy;
        if (_height < 40)
            _height = 40;
        
        _width += Dx;
        if (_width < 100)
            _width = 100;            
            
        temp.ChangeSize(_height + 'px', _width + 'px');        
 
		// Gan lai cursorX, cursorY la vi tri hien tai cua chuot
		cursorX = x;
	    cursorY = y;    	 
	}
}

function HideMenu(e)
{
    var button;
    var p = document.getElementById("popupmenu");
    var obj;
    if (IE)
    {        
        button = event.button;        
        obj = event.srcElement;
    }
    else
    {
        button = e.button;
        obj = e.target;
    }
    
    if (button != 2) // khong phai la chuot phai
    {
        // Neu click vao PopupMenuItem thi dung de su kien onclick cua cac item co hieu luc
        if (obj.tagName == "A" && obj.name == "pmenu")
            return;
            
        p.style.display = "none";
    }
}
// Hien thi popup menu
function ShowMenu(e)
{	    
	var p = document.getElementById("popupmenu");
	
	var x, y;
    if (IE)
    {
        x = event.clientX;
        y = event.clientY;
    }
    else
    {
        x = e.pageX;
        y = e.pageY;
	}

	p.style.left = x + "px";
	p.style.top = y + "px";    
	p.style.display = "block";

	return false;
}