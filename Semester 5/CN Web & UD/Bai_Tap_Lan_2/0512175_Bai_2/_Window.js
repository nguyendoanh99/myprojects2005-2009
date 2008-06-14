var ListImage = new Array(); // Chua ten cac file anh
// Load hinh
ListImage_Init("Images.xml");

var MaxHeight = "600px"; // Cho biet height toi da khi maximize
var MaxWidth = "800px"; // Cho biet width toi da khi maximize
var Contain = new Array(); // Cho biet co window nao dang minimize o vi tri thu i khong
// Lop _Window
function _Window(id, title, height, width, left, top)
{
    this.mId = id;
    this.mHeight = height;
    this.mWidth = width;
    this.mLeft = left;
    this.mTop = top;
    this.mTitle = title;
    this.mCurrentState = 0; // trang thai hien tai cua cua so
                    // -1 : minimize
                    // 0  : normal
                    // 1  : maximize
    this.mPreState = 0;  // trang thai truoc do cua cua so   
    this.mIndex = 0; // cho biet hien tai anh nao dang duoc load len
    this.mTime; // Biet dung cho setTimeout
    this.mIndexContain = -1; // Cho biet neu cua so o trang thai minimize thi no nam o dau
    
    // Tao div Window
    var _window = document.createElement("div");    

    _window.name = "window";
    _window.id = "window" + this.mId;
    _window.style.left = this.mLeft;
    _window.style.top = this.mTop;    
    _window.style.position = "absolute";
    _window.style.background = "#EEEEEE";
    _window.style.display = "block";

    // Tao div Title
    var _title = document.createElement("div");
    _title.name = "title";
    _title.id = "title" + this.mId;
    _title.style.position = "relative";
    _title.style.display = "block";
    _title.style.background = "#0066CC";
    
    // Tao img Close, minimize, maximize
    var _close = document.createElement("img");
    var _minimize = document.createElement("img");
    var _maximize = document.createElement("img");
    
    _minimize.name = "minimize";    
    _maximize.name = "maximize";    
    _close.name = "close";
    
    _minimize.id = "minimize" + this.mId;
    _maximize.id = "maximize" + this.mId;
    _close.id = "close" + this.mId;
    
    _minimize.src = "images/" + "minimize.gif";
    _maximize.src = "images/" + "maximize.gif";
    _close.src = "images/" + "close.gif";
    
    _minimize.style.width = _maximize.style.width = _close.style.width = "18px";    
    _minimize.style.height = _maximize.style.height = _close.style.height = "18px";    
    _minimize.style.position = _maximize.style.position = _close.style.position = "absolute";
    
    _close.style.right = "0px";
    _maximize.style.right = "19px";
    _minimize.style.right = "38px";
    var temp = this;
    _close.onclick = function(){temp.Close();};
    _minimize.onclick = function(){temp.Minimize();};
    _maximize.onclick = function () {temp.Maximize();};
    
    // Them img vao title
    _title.innerHTML = this.mTitle;
    _title.appendChild(_close);
    _title.appendChild(_minimize);
    _title.appendChild(_maximize);
    
    // Tao div Client
    var _client = document.createElement("div");
    _client.name = "client";
    _client.id = "client" + this.mId;
    _client.style.position = "relative";
    _client.style.background = "#EEEEEE";    
    
    // Tao img image
    var _image = document.createElement("img");    
    _image.name = "image";
    _image.id = "image" + this.mId;
    _image.style.width = "50%";
    _image.style.height = "50%";
    _image.src = "images/angry.gif";
    // Them image vao client
    _client.appendChild(_image);
    
    // Tao div status
    var _status = document.createElement("div");
    _status.name = "status";
    _status.id = "status" + this.mId;
    _status.style.position = "relative";
    _status.style.background = "#654321";
    
    // Tao div handle
    var _handle = document.createElement("div");
    _handle.name = "handle";
    _handle.id = "handle" + this.mId;
    _handle.style.width = "18px";
    _handle.style.height = "18px";
    _handle.style.right = "0px";
    _handle.style.position = "absolute";    
    _handle.style.backgroundImage = "url('images/handle.gif')";
   
    // Them handle vao status
    _status.appendChild(_handle);
    
    // Them title, client, status vao window
    _window.appendChild(_title);
    _window.appendChild(_client);
    _window.appendChild(_status);
    
    document.getElementsByTagName("body")[0].appendChild(_window);        
    this.ChangeSize(this.mHeight, this.mWidth);
}
// Ham xu ly khi nhap vao nut Close
_Window.prototype.Close = function ()
{
    var x = document.getElementById("window" + this.mId);
    var parentWindow = x.parentNode;
    
    if (this.mIndexContain != -1)
        Contain[this.mIndexContain] = false;
        
    parentWindow.removeChild(x); 
    clearTimeout(this.mTime);   
}
// Ham xu ly khi nhap vao nut Minimize
_Window.prototype.Minimize = function ()
{
    var _window = document.getElementById("window" + this.mId);
    var client;
    var status;

    client = _window.childNodes[1];  
    status = _window.childNodes[2]; 
     
    // Luu lai toa do, kich thuoc cua window
    var tempLeft = this.mLeft;
    var tempTop = this.mTop;
    var tempHeight = this.mHeight;
    var tempWidth = this.mWidth;

    if (this.mCurrentState != -1) // Trang thai hien tai khong phai la minimize, thi cho minimize
    {
        client.style.display = "none";        
        status.style.display = "none";        
        
        // Di chuyen va thay doi kich thuoc window        
        var i;
        for (i = 0; i < Contain.length; ++i)
            if (Contain[i] == false)
                break;
        
        this.mIndexContain = i;                        
        this.MoveWindow((i * 100) + (i * 5) + "px", "500px");
        this.ChangeSize("20px", "100px");       
        Contain[i] = true; // Thong bao da co window
        
        // Cap nhat cac trang thai
        this.mPreState = this.mCurrentState;
        this.mCurrentState = -1;
    }
    else
    {
        // tra cho trong lai cho contain
        if (this.mIndexContain != -1)
            Contain[this.mIndexContain] = false;
            
        client.style.display = "block";
        status.style.display = "block";
        if (this.mPreState == 0) // Trang thai truoc do la normal
        {            
            this.MoveWindow(this.mLeft, this.mTop);
            this.ChangeSize(this.mHeight, this.mWidth);   
        }
        else
            if (this.mPreState == 1) // Trang thai truoc do la maximize
            {
                // Di chuyen va thay doi kich thuoc window                
                this.MoveWindow("1px", "1px");
                this.ChangeSize(MaxHeight, MaxWidth);                       
            }            
            
        this.mCurrentState = this.mPreState;
        this.mPreState = -1;
    }    
    
    // Gan lai toa do, kich thuoc cua window
    this.mLeft = tempLeft;
    this.mTop = tempTop;
    this.mHeight = tempHeight
    this.mWidth = tempWidth;
}
// Ham xu ly khi nhap vao nut Minimize
_Window.prototype.Maximize = function()
{

    var _window = document.getElementById("window" + this.mId);
    var client;
    var status;

    client = _window.childNodes[1];  
    status = _window.childNodes[2]; 

    // tra cho trong lai cho contain
    if (this.mIndexContain != -1)
        Contain[this.mIndexContain] = false;
        
    client.style.display = "block";
    status.style.display = "block";
    if (this.mCurrentState != 1) // Trang thai hien tai khong phai la maximize thi cho maximize
    {
        // Luu lai toa do, kich thuoc cua window
        var tempLeft = this.mLeft;
        var tempTop = this.mTop;
        var tempHeight = this.mHeight;
        var tempWidth = this.mWidth;
        // Di chuyen va thay doi kich thuoc window
        
        this.MoveWindow("1px", "1px");
        this.ChangeSize(MaxHeight, MaxWidth);        

        // Gan lai toa do, kich thuoc cua window
        this.mLeft = tempLeft;
        this.mTop = tempTop;
        this.mHeight = tempHeight
        this.mWidth = tempWidth;
           
        // Cap nhat cac trang thai
        this.mPreState = this.mCurrentState;
        this.mCurrentState = 1;
    }
    else
    {
        this.MoveWindow(this.mLeft, this.mTop);
        this.ChangeSize(this.mHeight, this.mWidth);        
        
        this.mCurrentState = 0;
        this.mPreState = 1;
    }    
    
}
// Ham thay doi cua so
_Window.prototype.ChangeSize = function(h, w)
{
    var _window = document.getElementById("window" + this.mId);
    var title;
    var client;
    var status;
        
    title = _window.childNodes[0];
    client = _window.childNodes[1];  
    status = _window.childNodes[2]; 

    // Thay doi kich thuoc trong lop
    this.mHeight = h;
    this.mWidth = w;
    // Thay doi kich thuoc thuc te
    _window.style.height = h;
    _window.style.width = w;
        
    var temp = parseInt(_window.style.height.replace("px", "")) - 40; // 40px = 20px (title) + 20px (status)
    if (temp < 0)
        temp = 0;

    client.style.height = temp + "px";    
    title.style.width = _window.style.width;
    client.style.width = _window.style.width;
    status.style.width = _window.style.width;    
}

// Ham di chuyen Window
_Window.prototype.MoveWindow = function(left, top)
{
    var _window = document.getElementById("window" + this.mId);
    // Toa do moi cua doi tuong	    
    this.mLeft = left;
    this.mTop = top;
    _window.style.left = left;
	_window.style.top = top;
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
// Ham doc tu file XML len de lay danh sach ten cac file anh
function ListImage_Init(URL)
{
    var Objects = ReadXMLFile(URL);
    for (var i = 0; i < Objects.length; ++i)
    {
        ListImage[i] = Objects[i];        
    }
}

