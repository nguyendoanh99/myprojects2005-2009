// JScript File

function XL_MonAnYeuThich()
{
}

function XL_MonAnYeuThich.PhanTrang()
{
    var ham = new XL_HAM("He phuc vu/XL_MON_AN_YEU_THICH");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "TongSoTrang"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var tongSoTrang = parseInt(goc.getAttribute("TongSoTrang"));
        var tableTag = document.getElementById("tbodyPhanTrang");
        var tr = document.createElement("tr");
        for (var i = 1; i <= tongSoTrang; ++i)
        {
            var td = document.createElement("td");
            td.setAttribute("class", "alt1");
            var aTag = document.createElement("a");
            aTag.innerText = i;
            aTag.href="javascript:XL_MonAnYeuThich.LayDSMonAn(" + i + ")";
            td.appendChild(aTag);            
            tr.appendChild(td);
        }
        while (tableTag.firstChild != null)
        {
            tableTag.removeChild(tableTag.firstChild);
        }  
        tableTag.appendChild(tr);
    }
    else
        alert("Lỗi đường truyền, không thực hiện phân trang được");
}

function XL_MonAnYeuThich.HienThiTrangChu()
{
    var ham = new XL_HAM("He phuc vu/XL_MON_AN_YEU_THICH");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSMonAn"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var arr = XL_MON_AN.Khoi_tao_ds_mon_an(goc);
        var th = document.getElementById("Th_mon_an_yeu_thich");
        //XL_MonAnYeuThich.Khoi_tao_hien_thi(arr, th);
        XL_MonAnYeuThich.Th_Danh_sach_mon_an(arr, th);
    }
}

function XL_MonAnYeuThich.ThemMonAnMoi()
{        
    var ham = new XL_HAM("He Phuc Vu/XL_MON_AN_YEU_THICH");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThemMonAn"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    //Yêu cầu server cập nhật thông tin cho khách hàng
    var goc = ham.Thuc_hien();
//    if(goc != null)
//    {
        
        //XL_CHUOI.Xuat("Thêm thành công!");   
        //redirect toi trang danh sach cac thuc don
        XL_MonAnYeuThich.LayDSMonAn(1)
        XL_MonAnYeuThich.PhanTrang();
//    }
//    else
//        XL_CHUOI.Xuat("Thêm bị lỗi!");    
}

function XL_MonAnYeuThich.LayDSMonAn(pageNum)
{
    var ham = new XL_HAM("He phuc vu/XL_MON_AN_YEU_THICH");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSMonAn"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("pageNum", pageNum));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        var tbody = document.getElementById("tbodyDSMonAn");
        while (tbody.firstChild != null)
        {
            tbody.removeChild(tbody.firstChild);
        }              
        
        
        for(var i = 0; i<M.length; i++)
        {   
            var mamon = M[i].getAttribute("Ma_mon");
            var tenmon = M[i].getAttribute("Ten_mon");
            var hinhanh = M[i].getAttribute("Hinh_anh_minh_hoa");            
            var gia = M[i].getAttribute("Gia");
            var tinhtrang = M[i].getAttribute("Tinh_trang");
            var diem = parseInt(M[i].getAttribute("Diem_binh_chon"));           
            
            var tr = document.createElement("tr");
            var td = document.createElement("td");     
            tr.appendChild(td);
            var hidden = document.createElement("input");
            hidden.type = "hidden";
            hidden.id = "productid";
            hidden.value = mamon;
            td.appendChild(hidden);
            
            tr.id = "tr" + mamon;
            // STT
            td = document.createElement("td");            
            var textNode = document.createTextNode(i + 1);
            td.appendChild(textNode);            
            tr.appendChild(td);
            
            // TenMon
            td = document.createElement("td");          
            textNode = document.createTextNode(tenmon);
            td.id = "mon" + mamon;
            td.appendChild(textNode);
            tr.appendChild(td);
            
            // HinhAnhMinhHoa
            td = document.createElement("td");     
            var img = document.createElement("img");
            img.src = hinhanh;
            img.width = "80";
            img.height = "80";
            td.appendChild(img);
            tr.appendChild(td);
            
            // Gia
            var arr1 = new Array();
            arr1 = gia.split('.');
            td = document.createElement("td");          
            textNode = document.createTextNode(arr1[0]);
            td.appendChild(textNode);
            tr.appendChild(td);
            
            // TinhTrang
            td = document.createElement("td");    
            var checked = (tinhtrang == 'True' ? 'checked' : '');      
            td.innerHTML = '<input type="checkbox" id="chkTinhTrang' + mamon + '" DISABLED ' + checked + '>';
            tr.appendChild(td);
            
            // DiemBinhChon
            td = document.createElement("td");          
            textNode = document.createTextNode(diem);
            td.appendChild(textNode);
            tr.appendChild(td);
            
            //dat hang
            td = document.createElement("td");    
            var form = document.createElement("form");
            form.method = "post";
            form.action = "AddToCard.aspx";
            td.appendChild(form);
            var input = document.createElement("input");
            input.className = "submitbtn";
            input.type = "submit";
            input.name = "order";        
            input.value = "Đặt mua";
            input.onclick = XL_MonAnYeuThich.Ghi_nhan_dat_hang_mon_an;        
            form.appendChild(input);                   
            tr.appendChild(td);   
            
            // Nút bo
            td = document.createElement("td"); 
            var but = document.createElement("input");
            but.type = "button";
            but.onclick= function() {XL_MonAnYeuThich.BoMonAn(this);};
            but.value = "Bỏ";
            but.MaMon = mamon;
            but.TenMon = tenmon;
            but.HinhAnh = hinhanh;
            but.Gia = gia;
            but.id = "butBo" + mamon;            
            //but.disable = (tinhtrang == 1 ? false : true);
            td.appendChild(but);
            
            tr.appendChild(td);            
            tbody.appendChild(tr);
        }        
    }
    else
        alert("Lỗi đường truyền");
}

function XL_MonAnYeuThich.BoMonAn(obj)
{
    //var mathucdon = obj.MaThucDon;
//    var gia = obj.Gia;
//    var tbody = document.getElementById("tbodyDSThucDon");
//    var tr = document.getElementById('tr' + mathucdon);
//    
//    tbody.removeChild(tr);
//    
//    var i;
//    for(i = 0; i < DsMaMonAn.length; ++i)
//    {
//        if(DsMaMonAn[i] == mamon)
//            break;
//    }
//    DsMaMonAn.splice(i, 1);
////    var nodeGia = document.getElementById('txtGia');
////    nodeGia.value = parseInt(nodeGia.value) - parseInt(gia)
//    
//    var childs = tbody.childNodes;
//    for(i = 0; i < childs.length; ++i)
//    {
//        var tr = childs[i];
//        var tdSTT = tr.firstChild;
//        tdSTT.innerText = i + 1;
//    }

    var ham = new XL_HAM("He phuc vu/XL_MON_AN_YEU_THICH");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "XoaMonAn"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mamon", obj.MaMon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));

    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        XL_MonAnYeuThich.LayDSMonAn(1)
        XL_MonAnYeuThich.PhanTrang();
    }
}

function XL_MonAnYeuThich.Ghi_nhan_dat_hang_mon_an()
{
    var ma_mon_an = window.event.srcElement.parentNode.parentNode.parentNode.firstChild.firstChild.value;

    var Ham = new XL_HAM("He Phuc Vu/XL_GIO_HANG");
    var Tham_so = new XL_THAM_SO("Xac_nhan","Ghi_nhan_dat_hang");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Loai", "0");    
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma", ma_mon_an);
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("So_luong", 1);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    
    window.location = "DanhSachMonAnYeuThich.aspx";
}

function XL_MonAnYeuThich.Ghi_nhan_mon_an()
{
//    var obj = window.event.srcElement.parentNode.firstChild;
//    var parent = obj.parentNode.parentNode;
//    parent = parent.nextSibling;
//    var node = parent.firstChild.innerText;    

    var obj = window.event.srcElement.parentNode.parentNode;      
    var parent = obj.previousSibling.previousSibling.previousSibling.previousSibling;    
    var ma_mon_an = parent.firstChild.nodeValue;
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN_YEU_THICH");
    Tham_so = new XL_THAM_SO("xac_nhan","Ghi_nhan_mon_an");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma_mon", ma_mon_an);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    
    window.location = "DanhSachMonAnYeuThich.aspx";
}

function XL_MonAnYeuThich.Ghi_nhan_mon_an_tu_chi_tiet()
{
    var obj = window.event.srcElement.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;      
    //var parent = obj.previousSibling.previousSibling.previousSibling;    
    var ma_mon_an = obj.firstChild.nextSibling.innerHTML;
    var arr = ma_mon_an.split(": ");
    ma_mon_an = arr[1];
    
    var Kq = null;
    var Ham = new XL_HAM("He Phuc Vu/XL_MON_AN_YEU_THICH");
    Tham_so = new XL_THAM_SO("xac_nhan","Ghi_nhan_mon_an");
    Ham.Danh_sach_tham_so.push(Tham_so);
    Tham_so = new XL_THAM_SO("Ma_mon", ma_mon_an);
    Ham.Danh_sach_tham_so.push(Tham_so);

    var Goc = Ham.Thuc_hien();
    
    window.location = "DanhSachMonAnYeuThich.aspx";
}

function XL_MonAnYeuThich.Th_Danh_sach_mon_an(arr, Th)
{    
    var temp;
    var m;
        
    var obj = null;
    if(window.event == null)
        curPg = 1;
    else
    {
        obj = window.event.srcElement;        
    }
    if(obj != null)
    {
        if(obj.innerText == "Prev ")
        {
            //obj = curPg.nextSibling;
            //m = obj.innerText.split(" ");
            curPg -= 1;
        }
        else if(obj.innerText == "Next")
        {
            //obj = curPg.nextSibling;
            //m = obj.innerText.split(" ");
            curPg += 1;
        }    
        else
        {
            m = obj.innerText.split(" ");
            curPg = parseInt(m[0]);
        }   
    }    
    
    //xu ly phan trang
    var maxPages = 2;
    var totalPages = new Number();        
    var totalRows;
    
    if(arr.length % 3 == 0)
        totalRows = arr.length/3;
    else
        totalRows = parseInt(arr.length/3 + 1);

    if(totalRows % maxRows ==0)  
	        totalPages = totalRows / maxRows;
    else 
	        totalPages = parseInt(totalRows / maxRows + 1);
    
    var curPage =curPg;
    var curRow = (curPage-1)*maxRows+1;
    //////////////////////////////////////////////////////////////////////////////////////////////////////
                   
    var table = document.createElement("table");
    table.align = "center";
    table.id = "container";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    td.id = "main";
    td.className = "vt";
    
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //tạo tiêu đề cho danh sách
    var h1 = document.createElement("h1");
    h1.align = "center";
    h1.appendChild(document.createTextNode("Danh Sách Món Ăn Yêu Thích"));    
    td.appendChild(h1);
    
    if(arr.length == 0)
    {
        td.appendChild(document.createTextNode("Không có sản phẩm nào"));
        td.align = "left";
        Th.innerHTML = "";
        Th.appendChild(table);
        return;
    }
    
    var table3 = document.createElement("table");
    table3.width = "100%";
    table3.border = "0";
    td.appendChild(table3);
    
    var tbody3 = document.createElement("tbody");
    table3.appendChild(tbody3);
    
    var tr3 = document.createElement("tr");
    tbody3.appendChild(tr3);
    
    var td3 = document.createElement("td");
    td3.className = "ac"    ;
    tr3.appendChild(td3);
    
    //tiep tuc phan trang        
    
    var i=new Number();
    if(totalRows >= maxRows)
    {
        if(curPage>maxPages)
        {
            var pre=start-1;	        
            var a = document.createElement("a");
            a.href = "#";            
		    a.onclick = XL_MON_AN.Th_Danh_sach_mon_an;
		    a.appendChild(document.createTextNode("Prev "));
		    td3.appendChild(a);
        }
    
        var start=1;
        var end=1;			 	 
        for( i=1;i<=totalPages;i++)
        {	
        
             if( (i >= (parseInt((curPage-1)/maxPages))* maxPages) && (i <= (parseInt((curPage-1)/maxPages+1))* maxPages ))
	        {
	            var a = document.createElement("a");
		        if(start==1) 
		            start=i;
		        if(i==curPage)      
		        {		            		        
			        a.appendChild(document.createTextNode(i + " "));
		        }			    
		        else    
			    {			    
			        a.href = "#";            
		            a.onclick = XL_MON_AN.Th_Danh_sach_mon_an;
			        a.appendChild(document.createTextNode(i + " "));
			    }
			    	
			    td3.appendChild(a);
		        end=i;
	        }
        }
    	
        //phan trang        
        
        if((((curPage-1)/maxPages+1)*maxPages) <= totalPages)
        {
            var next= end+1;	        
	        var a = document.createElement("a");
	        a.href = "#";            
		    a.onclick = XL_MON_AN.Th_Danh_sach_mon_an;
			a.appendChild(document.createTextNode("Next"));
			td3.appendChild(a);
	    }
    }
    
    //tạo danh sách các món ăn ở trong
    var table1 = document.createElement("table");
    table1.className = "vt";
    table1.width = "100%";
    table1.cellspacing = "1";
    table1.cellpadding = "4";
    table1.border = "0";
    table1.align = "center";
    td.appendChild(table1);
    
    var tbody1 = document.createElement("tbody");
    table1.appendChild(tbody1);
       
    var low=curRow;								
    i=low-1;
    //curRow=1;
    var j = -1;
    var tr1;
    while (i<totalRows && (curRow<=totalRows) && (curRow <= curPage*maxRows))
	{	
	    j++;    	    
	    if(((curRow-1) * 3 + j) >= arr.length )/////////
	        break;
	    if(j % 4 == 0)///////////
        {
            tr1 = document.createElement("tr");
            tbody1.appendChild(tr1);
        }
	    
        var mon_an = arr[(curRow-1) * 3 + j];////////////
        
        if((j+1) % 3 == 0)//////////
        {
            curRow++;
            j = -1;
        }                
        
       // if(curRow<low)
		//    continue;
        if(mon_an.TrangThaiHienThi == false)
            continue;          
                
        
        var td1 = document.createElement("td");
        td1.className = "al vt";
        tr1.appendChild(td1);
        
        var form = document.createElement("form");
        form.method = "post";
        form.action = "AddToCard.aspx";
        td1.appendChild(form);
        
        //tạo hidden chua id món ăn
        var hidden = document.createElement("input");
        hidden.type = "hidden";
        hidden.id = "productid";
        hidden.value = mon_an.MaMon;
        form.appendChild(hidden);
        
        var table2 = document.createElement("table");
        table2.id = "table"+i;
        table2.width = "100%";
        table2.cellspacing = "2";
        table2.cellpadding = "2";
        table2.border = "0";        
        form.appendChild(table2);
        table2.style.border = "1px dotted rgb(119, 119, 119)";
        //table2.style.margin = "6px 6px 6px";
        
        var tbody2 = document.createElement("tbody");
        table2.appendChild(tbody2);
        
        //Ten mon an
        var tr2 = document.createElement("tr");
        var td2 = document.createElement("td");
        td2.align = "center";  
        td2.colSpan = 2;
        td2.appendChild(document.createTextNode(mon_an.TenMon));
        tr2.appendChild(td2);
        td2.style.background = "transparent url(./ImageInstock/h3r.gif) repeat-x scroll 0%"          
        td2.style.fontWeight = "bold";
        td2.style.mozBackgroundClip = "-moz-initial"; 
        td2.style.mozBackgroundOrigin = "-moz-initial";
        td2.style.mozBackgroundInlinePolicy = "-moz-initial";
        td2.style.color = "black";
        td2.style.textAlign = "center";
        tbody2.appendChild(tr2);
        
        //don vi tinh
        tr2 = document.createElement("tr");
        td2 = document.createElement("td");
        td2.colSpan = 2;        
        td2.align = "center";  
        var div = document.createElement("div");
        div.appendChild(document.createTextNode(mon_an.DonViTinh));
        td2.appendChild(div);
        tr2.appendChild(td2);
        div.style.borderBottom = "1px dotted rgb(19, 91, 46)";
        div.style.textAlign = "center";
        tbody2.appendChild(tr2);
        
        //hinh anh
        tr2 = document.createElement("tr");
        tbody2.appendChild(tr2);
        
        td2 = document.createElement("td");
        td2.width = "50%";
        td2.valign = "top";
        td2.align = "left";
        var p = document.createElement("p");
        p.className = "ac";        
        var img = document.createElement("IMG");
        img.border = "0";
        img.alt = "CT";        
        img.src = mon_an.HinhAnhMinhHoa;
        img.width = 160;
        img.height= 150;
        //img.onclick = XL_MON_AN.Ghi_nhan_mon_an;
        p.appendChild(img);
        
        p.appendChild(document.createElement("br"));
        var a = document.createElement("a");
        a.href = "javascript:XL_MON_AN.Ghi_nhan_mon_an("+mon_an.MaMon+")";
        a.appendChild(document.createTextNode("Chi Tiết"));
        p.appendChild(a);
        td2.appendChild(p);
        tr2.appendChild(td2);
          
        //Don Gia   
        var arr1 = new Array();
        arr1 = mon_an.Gia.split('.');
        td2 = document.createElement("td");
        td2.width = "50%";
        td2.valign = "middle";
        td2.align = "right";
        div = document.createElement("div");     
        div.id = "proID";
        div.style.display = "none";
        div.appendChild(document.createTextNode(mon_an.MaMon));
        td2.appendChild(div);
        div.style.margin = "10px 0pt";        
        div.style.textAlign = "center";
        div.style.fontSize = "100%";
        div.style.color = "rgb(155, 155, 155)";   
        
        div = document.createElement("div");     
        div.appendChild(document.createTextNode(arr1[0] + " VND"));
        td2.appendChild(div);
        div.style.margin = "10px 0pt";
        div.style.fontWeight = "bold";
        div.style.textAlign = "center";
        div.style.fontSize = "120%";
        div.style.color = "rgb(19, 91, 46)";   
             
        div = document.createElement("div");  
        td2.appendChild(div);        
        div.style.margin = "5px";
        div.style.textAlign = "center";                      
        var input = document.createElement("input");
        input.className = "txtfield";
        input.type = "text";
        input.name = "quantity";
        input.value = "1";
        input.size = "3";
        input.maxlength = "4";
        div.appendChild(input);
        
        div = document.createElement("div");  
        td2.appendChild(div);                
        div.style.textAlign = "center";
        input = document.createElement("input");
        input.className = "submitbtn";
        input.type = "submit";
        input.name = "Order";        
        input.value = "Order";
        input.onclick =  XL_GIO_HANG.Ghi_nhan_dat_hang_mon_an ;
        div.appendChild(input);                
             
        tr2.appendChild(td2);               
    }
    Th.innerHTML = "";
    Th.appendChild(table);
}