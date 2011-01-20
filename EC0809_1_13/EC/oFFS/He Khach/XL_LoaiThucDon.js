// JScript File

function XL_LoaiThucDon()
{
}

function Loai_ThucDon()
{
    this.MaLoaiThucDon = -1;
    this.TenLoaiThucDon = "";
    this.MaLoaiThucDonCha = -1;
    this.LaLoaiThucDonLa = "False";
}

var arr;
var Th;
var path;
//  Nghi
// lấy danh sách loại thực đơn cấp root show lên menu bên tay phải của masterpage
function XL_LoaiThucDon.LoadDSLoaiThucDonGoc(nodename)
{
    var nodeDiv = document.getElementById(nodename);
    
    var ham = new XL_HAM("He phuc vu/XL_LoaiThucDon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiThucDonGoc"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        
        //<a title="Thức ăn nhanh" style="display:block;" class="mainlevel" href="danhsachmonan.aspx" >Thức ăn nhanh</a>
        for(var i =0; i<M.length; i++)
        {
            var ma = M[i].getAttribute("MaLoaiThucDon");
            var ten = M[i].getAttribute("TenLoaiThucDon");
            
            
            var nodeA = document.createElement("a");
            nodeA.innerHTML = ten;
            nodeA.style.display = 'block';
            nodeA.setAttribute("className", "mainlevel");
            
            ////////////////////////////////LONG THÊM HÀM THÍCH HỢP CHO CHỖ NÀY
            nodeA.href = "javascript:XL_LoaiThucDon.click(" + ma + ")";
            
            nodeDiv.appendChild(nodeA);
        }
    }
    else
        alert("Lỗi khi load loại món");
}

function XL_LoaiThucDon.click(maloaithucdon)
{
    var ham = new XL_HAM("He Phuc Vu/XL_LoaiThucDon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "GhiNhanLoaiThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("Ma_loai_thuc_don", maloaithucdon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    window.location = "DsThucDonThuocLoaiThucDon.aspx";
}

//bien chua duong dan khi duyet loai thuc don hay loai ThucDon an
var arrMaLoaiThucDon = new Array();

function XL_LoaiThucDon.ChiTietLoaiThucDon(ma_loai_ThucDon)
{
    var ham = new XL_HAM("He Phuc Vu/XL_LoaiThucDon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ChiTietLoaiThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaLoaiThucDon", ma_loai_ThucDon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    var ltd = null;
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        ltd = new Loai_ThucDon();
        
        ltd.MaLoaiThucDon = goc.getAttribute("MaLoaiThucDon");
        ltd.TenLoaiThucDon = goc.getAttribute("TenLoaiThucDon");
        ltd.MaLoaiThucDonCha = goc.getAttribute("MaLoaiThucDonCha");
        ltd.LaLoaiThucDonLa = goc.getAttribute("LaLoaiThucDonLa");
    }
    
    return ltd;
}

function XL_LoaiThucDon.push(ma)
{
    if(ma != null)
        arrMaLoaiThucDon.push(ma);
    
    var DOM = XL_LoaiThucDon.HienThiDuongDan(arrMaLoaiThucDon);
    return DOM;
}

function XL_LoaiThucDon.pop(ma)
{
    if(ma == null)
    {
        for(var i = arrMaLoaiThucDon.length - 1; i >= 0; i--)
            arrMaLoaiThucDon.pop();
        return null;
    }
    var n = arrMaLoaiThucDon.length;
    
    for(var i = n - 1; i >= 0; i--)
        if(arrMaLoaiThucDon[i] != ma)
            arrMaLoaiThucDon.pop();
            
    var DOM = XL_LoaiThucDon.HienThiDuongDan(arrMaLoaiThucDon);
    return DOM;
}

function XL_LoaiThucDon.HienThiDuongDan(arrMaLoaiTD)
{
    var div = document.createElement("div");
    div.textAlign = "left";
    var a = document.createElement("a");
    a.appendChild(document.createTextNode("DS Loai ThucDon"));
    a.href = "javascript:XL_LoaiThucDon.DanhSachLoaiThucDon()"
//    a.Color = "#FF0000";
    div.appendChild(a);

    for(var i = 0; i < arrMaLoaiTD.length; i++)
    {
        var loai_ThucDon = XL_LoaiThucDon.ChiTietLoaiThucDon(arrMaLoaiTD[i]);
        div.appendChild(document.createTextNode(" --> "));                
        
        if(i < arrMaLoaiTD.length - 1)
        {
            a = document.createElement("a");
            a.appendChild(document.createTextNode(loai_ThucDon.TenLoaiThucDon));
            a.href = "javascript:XL_LoaiThucDon.pop("+loai_ThucDon.MaLoaiThucDon+");javascript:XL_LoaiThucDon.DanhSachLoaiThucDonCon("+loai_ThucDon.MaLoaiThucDon+",'"+loai_ThucDon.LaLoaiThucDonLa+"')"
            a.color = "#FF0000";
            div.appendChild(a);
        }        
        else
        {
            //a = document.createElement("a");
            div.appendChild(document.createTextNode(loai_ThucDon.TenLoaiThucDon));            
            //a.color = "rgb(255, 0, 0)";
            //div.appendChild(a);
        }
    }
    
    return div;
}

function XL_LoaiThucDon.LoadDSLoaiThucDon(nodename) //lá
{
    var nodeCmb = document.getElementById(nodename);
    
    var ham = new XL_HAM("He Phuc Vu/XL_LoaiThucDon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        var nodeOpt = document.createElement("option");        
        nodeCmb.appendChild(nodeOpt);
        
        for(var i =0; i<M.length; i++)
        {
            var maloaithucdon = M[i].getAttribute("MaLoaiThucDon");
            var tenloaithucdon = M[i].getAttribute("TenLoaiThucDon");
            
            var nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = tenloaithucdon;
            nodeOpt.value = maloaithucdon;
            nodeCmb.appendChild(nodeOpt);
        }
    }
    else
        alert("Lỗi khi load loại thuc don");
}

function XL_LoaiThucDon.DanhSachLoaiThucDon()
{
    var kq = null;

    var ham = new XL_HAM("He Phuc Vu/XL_LoaiThucDon");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSLoaiThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        arr = XL_LoaiThucDon.Khoi_tao_ds_loai_ThucDon(goc)
        Th = document.getElementById("Th_ds_loai_ThucDon");
        XL_LoaiThucDon.pop(null);
        var _kq = XL_LoaiThucDon.HienThiDuongDan(arrMaLoaiThucDon);
        XL_LoaiThucDon.HienThiDanhSachLoaiThucDon(1, _kq)
    }
    
    //return kq;
}

function XL_LoaiThucDon.DanhSachLoaiThucDonCon(ma_loai_ThucDon, la_loai_ThucDon_la)
{
    var kq = null;
    if(la_loai_ThucDon_la == "False")
    {
        var ham = new XL_HAM("He Phuc Vu/XL_LoaiThucDon");
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDanhSachLoaiThucDonCon"));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaLoaiThucDon", ma_loai_ThucDon));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));

        var goc = ham.Thuc_hien();
        var _path = null;
        if(goc != null)
        {
                    
            arr = XL_LoaiThucDon.Khoi_tao_ds_loai_ThucDon(goc)
            Th = document.getElementById("Th_ds_loai_ThucDon");
            var i;
            if(arrMaLoaiThucDon.length != 0)
            {
                for(i = 0; i < arrMaLoaiThucDon.length; i++)
                    if(arrMaLoaiThucDon[i] == ma_loai_ThucDon)
                    {
                        _path = XL_LoaiThucDon.pop(ma_loai_ThucDon);
                        break;
                    }
            }        
            else if(arrMaLoaiThucDon.length == 0)
                _path = XL_LoaiThucDon.push(ma_loai_ThucDon);
            else if(arrMaLoaiThucDon.length != 0 && i == arrMaLoaiThucDon.length)
                _path = XL_LoaiThucDon.push(ma_loai_ThucDon);
            XL_LoaiThucDon.HienThiDanhSachLoaiThucDon(0, _path)
        }
    }
    else
    {        
        var ham = new XL_HAM("He Phuc Vu/XL_LoaiThucDon");
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSThucDon"));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("MaLoaiThucDon", ma_loai_ThucDon));
        ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));

        var goc = ham.Thuc_hien();
        if(goc != null)
        {            
            arr = XL_THUC_DON.Khoi_tao_ds_thuc_don(goc);
            Th = document.getElementById("Th_ds_loai_ThucDon");
            path = XL_LoaiThucDon.push(ma_loai_ThucDon);
            XL_LoaiThucDon.HienThiDanhSachThucDon()
        }
        else
        {
            arr = null;
            Th = document.getElementById("Th_ds_loai_ThucDon");
            path = XL_LoaiThucDon.push(ma_loai_ThucDon);
            XL_LoaiThucDon.HienThiDanhSachThucDon()
        }        
    }
    
    //return kq;
}

function XL_LoaiThucDon.Khoi_tao_ds_loai_ThucDon(Nut)
{
    var Kq = new Array();
    var M = Nut.childNodes;
    for(var i =0;i<M.length;i++)
    {
        var lma = new Loai_ThucDon();
        
        lma.MaLoaiThucDon = M[i].getAttribute("MaLoaiThucDon");
        lma.TenLoaiThucDon = M[i].getAttribute("TenLoaiThucDon");
        lma.MaLoaiThucDonCha = M[i].getAttribute("MaLoaiThucDonCha");
        lma.LaLoaiThucDonLa = M[i].getAttribute("LaLoaiThucDonLa");
                
        Kq.push(lma);
    }
    return Kq;
}

function XL_LoaiThucDon.HienThiDanhSachLoaiThucDon(flag, path)
{                
    var table = document.createElement("table");
    table.align = "center";
    table.width = "100%";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //tao duong dan
    td.appendChild(path);    
    tr = document.createElement("tr");
    td = document.createElement("td");
    tbody.appendChild(tr);
    
    //tạo tiêu đề cho danh sách    
    var h1 = document.createElement("h1");
    h1.align = "center";
    h1.appendChild(document.createTextNode("Danh Sách Loai Thuc Don"));    
    td.appendChild(h1);
    tr.appendChild(td);
    
    var table3 = document.createElement("table");
    table3.align = "center";
    table3.width = "70%";
    table3.border = "0";
    td.appendChild(table3);
    
    var tbody3 = document.createElement("tbody");
    table3.appendChild(tbody3);
    var tr3 = document.createElement("tr");
    tbody3.appendChild(tr3);
    var td3 = document.createElement("td");
    td3.width = "20%";
    td3.appendChild(document.createTextNode("Ma Loai Thuc Don"));
    tr3.appendChild(td3);
    td3 = document.createElement("td");
    td3.width = "40%";
    td3.appendChild(document.createTextNode("Ten Loai Thuc Don"));
    tr3.appendChild(td3);
//    td3 = document.createElement("td");
//    td3.width = "20%";
//    td3.appendChild(document.createTextNode("Ma Loai ThucDon Cha"));
//    tr3.appendChild(td3);
    
    for(var i = 0; i < arr.length; i++)
    {
        var loai_ThucDon = arr[i];
        if(loai_ThucDon.MaLoaiThucDonCha != 0 && flag == 1)
            continue;
        tr3 = document.createElement("tr");
        tbody3.appendChild(tr3);
        td3 = document.createElement("td");
        td3.width = "20%";
        var a = document.createElement("a");
        a.href = "javascript:XL_LoaiThucDon.DanhSachLoaiThucDonCon("+loai_ThucDon.MaLoaiThucDon +",'" + loai_ThucDon.LaLoaiThucDonLa+"')";
        a.appendChild(document.createTextNode(loai_ThucDon.MaLoaiThucDon));
        td3.appendChild(a);
        tr3.appendChild(td3);
        td3 = document.createElement("td");
        td3.width = "40%";
        a = document.createElement("a");
        a.href = "javascript:XL_LoaiThucDon.DanhSachLoaiThucDonCon("+loai_ThucDon.MaLoaiThucDon + ",'" + loai_ThucDon.LaLoaiThucDonLa+"')";
        a.appendChild(document.createTextNode(loai_ThucDon.TenLoaiThucDon));
        td3.appendChild(a);
        tr3.appendChild(td3);
        //td3 = document.createElement("td");
        //td3.width = "20%";
        //td3.appendChild(document.createTextNode(loai_ThucDon.MaLoaiThucDonCha));
        //tr3.appendChild(td3);
    }
    
    Th.innerHTML = "";
    Th.appendChild(table);
}

function XL_LoaiThucDon.HienThiDanhSachThucDon()
{    
    var temp;
    var m;
    //var mathucdon = XL_THUC_DON.Lay_ma_thuc_don();
        
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

    //var arr = new Array();
    //arr = XL_THUC_DON.Chi_tiet_thuc_don(mathucdon);
    
    var table = document.createElement("table");
    table.align = "center";
    table.width = "100%";
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td = document.createElement("td");

    
    tr.appendChild(td);
    tbody.appendChild(tr);
    table.appendChild(tbody);
    
    //tao duong dan
    td.appendChild(path);    
    tr = document.createElement("tr");
    td = document.createElement("td");
    tbody.appendChild(tr);
    tr.appendChild(td);
    
    //tạo tiêu đề cho danh sách
    var h1 = document.createElement("h1");
    h1.align = "center";
    h1.appendChild(document.createTextNode("Danh Sách Thuc Don Cua Loai Thuc Don"));    
    td.appendChild(h1);
    
    if(arr.length == 0)
    {
        Th.innerHTML = "";
        Th.appendChild(table);
    }
        
    //////////////////////////////////////////////////////////////////////////////////
    else
    {
        //xu ly phan trang
        var maxRows = 3;
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
        
        ///////////////////////////////////////////////////////////////////////////////
        tr = document.createElement("tr");
        tbody.appendChild(tr);
        td = document.createElement("td");
        td.align = "right";
        tr.appendChild(td);
        
        
        //var div = document.createElement("div");  
        //td.appendChild(div);                
        //div.style.textAlign = "center";
        //////////////////////////////////////////////////////////////////////////////////
        
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
                a.onclick = XL_LoaiThucDon.HienThiDanhSachThucDon;
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
			            //a.href = "javascript:XL_ThucDon.Th_Danh_sach_ThucDon()";
			            a.href = "#";
                        a.onclick = XL_LoaiThucDon.HienThiDanhSachThucDon;
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
	            //a.href = "javascript:XL_ThucDon.Th_Danh_sach_ThucDon()";
	            a.href = "#";
                a.onclick = XL_LoaiThucDon.HienThiDanhSachThucDon;
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
    	
            var ThucDon = arr[(curRow-1) * 3 + j];////////////
            
            if((j+1) % 3 == 0)//////////
            {
                curRow++;
                j = -1;
            }                
            
           // if(curRow<low)
		    //    continue;
            if(ThucDon.TrangThaiHienThi == false)
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
            hidden.value = ThucDon.MaThucDon;
            form.appendChild(hidden);
            
            var table2 = document.createElement("table");
            table2.id = "table"+i;
            table2.width = "100%";
            table2.cellspacing = "2";
            table2.cellpadding = "2";
            table2.border = "0";        
            form.appendChild(table2);
            table2.style.border = "1px dotted rgb(119, 119, 119)";
            
            var tbody2 = document.createElement("tbody");
            table2.appendChild(tbody2);
            
            //Ten ThucDon an
            var tr2 = document.createElement("tr");
            var td2 = document.createElement("td");
            td2.align = "center";  
            td2.colSpan = 2;
            td2.appendChild(document.createTextNode(ThucDon.TenThucDon));
            tr2.appendChild(td2);
            td2.style.background = "transparent url(./ImageInstock/h3r.gif) repeat-x scroll 0%"          
            td2.style.fontWeight = "bold";
            td2.style.mozBackgroundClip = "-moz-initial"; 
            td2.style.mozBackgroundOrigin = "-moz-initial";
            td2.style.mozBackgroundInlinePolicy = "-moz-initial";
            td2.style.color = "black";
            td2.style.textAlign = "center";
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
            img.src = ThucDon.HinhAnhMinhHoa;
            img.width = 140;
            img.height= 140;
            //img.onclick = XL_ThucDon.Ghi_nhan_ThucDon;
            p.appendChild(img);
            
            p.appendChild(document.createElement("br"));
            var a = document.createElement("a");
            a.href = "javascript:XL_THUC_DON.Ghi_nhan_thuc_don("+ThucDon.MaThucDon+")";
            a.appendChild(document.createTextNode("Chi Tiết"));
            p.appendChild(a);
            td2.appendChild(p);
            tr2.appendChild(td2);
              
            //Don Gia   
            td2 = document.createElement("td");
            td2.width = "50%";
            td2.valign = "middle";
            td2.align = "right";
            div = document.createElement("div");     
            div.id = "proID";
            div.style.display = "none";
            div.appendChild(document.createTextNode(ThucDon.MaThucDon));
            td2.appendChild(div);
            div.style.margin = "10px 0pt";        
            div.style.textAlign = "center";
            div.style.fontSize = "100%";
            div.style.color = "rgb(155, 155, 155)";   
            
            div = document.createElement("div");     
            div.appendChild(document.createTextNode(ThucDon.Gia + " VND"));
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
            input.onclick =  XL_GIO_HANG.Ghi_nhan_dat_hang_thuc_don;
            div.appendChild(input);                
            
            div = document.createElement("div");  
            form = document.createElement("form");
            form.method = "post";
            form.action = "TaoThucDonMoi_KH.aspx";
            div.appendChild(form);
                    
            td2.appendChild(div);                
            div.style.textAlign = "center";
            input = document.createElement("input");
            input.className = "submitbtn";
            input.type = "submit";
            input.name = "customize";        
            input.value = "Customize";
            input.onclick =  XL_ThucDonCaNhan.Ghi_nhan_thuc_don ;        
            form.appendChild(input);               
            
            tr2.appendChild(td2);               
        }
        
        Th.innerHTML = "";
        Th.appendChild(table);
    }
}