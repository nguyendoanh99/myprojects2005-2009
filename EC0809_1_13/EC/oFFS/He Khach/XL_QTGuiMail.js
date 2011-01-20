// JScript File
var xmlhttp ;
var myEditor = null;
function GuiEmail()
{
    var select = document.getElementById("idUsername");
    var username;
    for (var i = 0; i < select.childNodes.length; ++i)
    {
        var child = select.childNodes[i];
        if (child.selected == true)
        {
            username = child.innerText;
            break;
            }
    }
    myEditor.saveHTML(); 
    var html = myEditor.get('element').value; 
    var subject = document.getElementById("idTieuDe");
    subject = subject.value;
//     
//       
//     
//     var ham = new XL_HAM("He phuc vu/XL_QTGuiMail");
//     ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "GuiMail"));
//     
//     ham.Danh_sach_tham_so.push(new XL_THAM_SO("Username", username));
//     ham.Danh_sach_tham_so.push(new XL_THAM_SO("subject", subject));
//     ham.Danh_sach_tham_so.push(new XL_THAM_SO("body", html));
//     ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
//     var goc = ham.Thuc_hien();
//     if (goc != null)
//     {
//         var flag = parseInt(goc.getAttribute("kq"));
//         if (flag == 0)
//             alert("Không thực hiện được do lỗi server");
//         else
//             alert("Đã gửi mail thành công");
//     }
//     else
//         alert("Lỗi đường truyền");
}

function Load()
{
    var ham = new XL_HAM("He phuc vu/XL_QTGuiMail");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("request", "LayDanhSachNguoiDung"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var select = document.getElementById("idUsername"); 
        for (var i = 0; i < goc.childNodes.length; ++i)
        {
            var child = goc.childNodes[i];
            var username = child.getAttribute("Username");
     
            var opt = document.createElement("option");
            opt.innerHTML = username;
            if (i == 0)
                opt.selected = "selected";
            select.appendChild(opt);
        }        
    }
    else
        alert("Không load danh sách người dùng được vì Lỗi đường truyền");

    myEditor = new YAHOO.widget.Editor('msgpost', {
            height: '300px',
            width: '522px',
            dompath: true, //Turns on the bar at the bottom
            animate: true //Animates the opening, closing and moving of Editor windows
        });
        myEditor.render();
        var html = myEditor.get('element').value; 
}
