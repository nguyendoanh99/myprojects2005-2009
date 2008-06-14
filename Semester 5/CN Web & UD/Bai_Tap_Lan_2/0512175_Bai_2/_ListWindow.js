// Lop _ListWindow
function _ListWindow()
{
    this.mArrWin = new Array();
}
// Them mot cua so vao _ListWindow
_ListWindow.prototype.AddWindow = function(id, title, height, width, left, top)
{    
    this.mArrWin[this.mArrWin.length] = new _Window(id, title, height, width, left, top);
}

// Lay doi tuong _Window trong _ListWindow co mId = id
_ListWindow.prototype.Get = function(id)
{
    var x = null;
    
    id = id.replace("window", "");

    for (var i = 0; i < this.mArrWin.length; ++i)
        if (id == this.mArrWin[i].mId)
        {
            x = this.mArrWin[i];    
            break;
        }
    
    return x;
}
