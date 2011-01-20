// JScript File
var mymyDatasource;


function XL_ThongKe()
{

}

var dsHinhThuc = ["Ngày", "Tuần", "Tháng", "Quý", "Năm"];

function XL_ThongKe.LoadHinhThucThongKe(id)
{
    var cmbHinhThuc = document.getElementById(id);
    
    for(var i = 0; i < dsHinhThuc.length; ++i)
    {
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = dsHinhThuc[i];
        nodeOpt.value = dsHinhThuc[i];
        cmbHinhThuc.appendChild(nodeOpt);
    }
}

//LẤY DANH SÁCH MÓN ĂN (MÃ MÓN ĂN, TÊN MÓN ĂN) SHOW LÊN CMB TÊN MÓN ĂN TRONG TIÊU CHÍ THỐNG KÊ
 function XL_ThongKe.LayDSTenMonAn(id)
 {
    var nodeCmb = document.getElementById(id);
    
    var ham = new XL_HAM("He phuc vu/XL_MON_AN");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSTenMonAn"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = "--Chọn món ăn";
        nodeOpt.value = -1;
        nodeCmb.appendChild(nodeOpt);
        
        for(var i =0; i<M.length; i++)
        {
            var mamon = M[i].getAttribute("MaMon");
            var tenmon = M[i].getAttribute("TenMon");
            
            var nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = tenmon;
            nodeOpt.value = mamon;
            nodeCmb.appendChild(nodeOpt);
        }
    }
    else
        alert("Lỗi khi load danh sách món ăn");
 }
 
 //LẤY DANH SÁCH THỰC ĐƠN (MÃ THỰC ĐƠN, TÊN THỰC ĐƠN) SHOW LÊN CMB TÊN MÓN ĂN TRONG TIÊU CHÍ THỐNG KÊ
 function XL_ThongKe.LayDSTenThucDon(id)
 {
    var nodeCmb = document.getElementById(id);
    
    var ham = new XL_HAM("He phuc vu/XL_THUC_DON");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "LayDSTenThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    
    var goc = ham.Thuc_hien();
    if(goc != null)
    {
        var M = goc.childNodes;
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = "--Chọn thực đơn";
        nodeOpt.value = -1;
        nodeCmb.appendChild(nodeOpt);
        
        for(var i =0; i<M.length; i++)
        {
            var mamon = M[i].getAttribute("MaThucDon");
            var tenmon = M[i].getAttribute("TenThucDon");
            
            var nodeOpt = document.createElement("option");
            nodeOpt.innerHTML = tenmon;
            nodeOpt.value = mamon;
            nodeCmb.appendChild(nodeOpt);
        }
    }
    else
        alert("Lỗi khi load danh sách thực đơn");
 }

function XL_ThongKe.LoadCmbNum(nodename, canduoi, cantren)
{
    var node = document.getElementById(nodename);
    
    for(var i = canduoi; i <= cantren; ++i)
    {
        var nodeOpt = document.createElement("option");
        nodeOpt.innerHTML = i;
        nodeOpt.value = i;
        node.appendChild(nodeOpt);
    }
}


function XL_ThongKe.LoadKqThongKeDoanhThu()
{
    var hinhthuc = document.getElementById("cmbHinhThuc").value;
    
    var ngay = document.getElementById("cmbNgayBegin").value;
    var thang = document.getElementById("cmbThangBegin").value;
    var nam = document.getElementById("cmbNamBegin").value;
    
    var ngaybatdau = ngay + "/" + thang + "/" + nam;
    
    ngay = document.getElementById("cmbNgayEnd").value;
    thang = document.getElementById("cmbThangEnd").value;
    nam = document.getElementById("cmbNamEnd").value;
    
    var ngayketthuc = ngay + "/" + thang + "/" + nam;
    
    var ham = new XL_HAM("He phuc vu/XL_ThongKe");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThongKeDoanhThu"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hinhthuc", hinhthuc));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngaybatdau", ngaybatdau));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngayketthuc", ngayketthuc));
    
    var chuoithamso = XL_THAM_SO.Chuoi_danh_sach(ham.Danh_sach_tham_so);
    var strURL = XL_HAM.URL + ham.Ten+XL_HAM.Kieu+"?"+chuoithamso+"&";
    //var strURL = XL_HAM.URL + ham.Ten+XL_HAM.Kieu+"?";
    
    if(hinhthuc == "Ngày")
    {
        XL_ThongKe.ThongKeDoanhThuTheoNgay(strURL);
    }
    else
        XL_ThongKe.ThongKeDoanhThuChung(strURL);
   
};

function XL_ThongKe.LoadKqThongKeMonAn()
{
    var mamon = document.getElementById('cmbMonAn').value;
    if(mamon == -1)
    {
        alert("Hãy chọn tên món ăn!");
        return;
    }
    var hinhthuc = document.getElementById("cmbHinhThuc").value;
    
    var ngay = document.getElementById("cmbNgayBegin").value;
    var thang = document.getElementById("cmbThangBegin").value;
    var nam = document.getElementById("cmbNamBegin").value;
    
    var ngaybatdau = ngay + "/" + thang + "/" + nam;
    
    ngay = document.getElementById("cmbNgayEnd").value;
    thang = document.getElementById("cmbThangEnd").value;
    nam = document.getElementById("cmbNamEnd").value;
    
    var ngayketthuc = ngay + "/" + thang + "/" + nam;
    
    var ham = new XL_HAM("He phuc vu/XL_ThongKe");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThongKeMonAn"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mamon", mamon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hinhthuc", hinhthuc));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngaybatdau", ngaybatdau));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngayketthuc", ngayketthuc));
    
    var chuoithamso = XL_THAM_SO.Chuoi_danh_sach(ham.Danh_sach_tham_so);
    var strURL = XL_HAM.URL + ham.Ten+XL_HAM.Kieu+"?"+chuoithamso+"&";
    //var strURL = XL_HAM.URL + ham.Ten+XL_HAM.Kieu+"?";
    
    if(hinhthuc == "Ngày")
    {
        XL_ThongKe.ThongKeSanPhamTheoNgay(strURL);
    }
    else
        XL_ThongKe.ThongKeSanPhamChung(strURL);
   
};

 function XL_ThongKe.LoadKqThongKeThucDon()
{
    var mathucdon = document.getElementById('cmbThucDon').value;
    if(mathucdon == -1)
    {
        alert("Hãy chọn tên thực đơn!");
        return;
    }
    
    var hinhthuc = document.getElementById("cmbHinhThuc").value;
    
    var ngay = document.getElementById("cmbNgayBegin").value;
    var thang = document.getElementById("cmbThangBegin").value;
    var nam = document.getElementById("cmbNamBegin").value;
    
    var ngaybatdau = ngay + "/" + thang + "/" + nam;
    
    ngay = document.getElementById("cmbNgayEnd").value;
    thang = document.getElementById("cmbThangEnd").value;
    nam = document.getElementById("cmbNamEnd").value;
    
    var ngayketthuc = ngay + "/" + thang + "/" + nam;
    
    var ham = new XL_HAM("He phuc vu/XL_ThongKe");
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("xac_nhan", "ThongKeThucDon"));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("t", new Date().getTime()));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("mathucdon", mathucdon));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("hinhthuc", hinhthuc));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngaybatdau", ngaybatdau));
    ham.Danh_sach_tham_so.push(new XL_THAM_SO("ngayketthuc", ngayketthuc));
    
    var chuoithamso = XL_THAM_SO.Chuoi_danh_sach(ham.Danh_sach_tham_so);
    var strURL = XL_HAM.URL + ham.Ten+XL_HAM.Kieu+"?"+chuoithamso+"&";
    //var strURL = XL_HAM.URL + ham.Ten+XL_HAM.Kieu+"?";
    
    if(hinhthuc == "Ngày")
    {
        XL_ThongKe.ThongKeSanPhamTheoNgay(strURL);
    }
    else
        XL_ThongKe.ThongKeSanPhamChung(strURL);
   
};
 
 
  function XL_ThongKe.ThongKeDoanhThuTheoNgay(strURL)
  { 
  
    
    var myDataSource = new YAHOO.util.DataSource(encodeURI(strURL));  
  
  //test
    mymyDatasource = myDataSource; 
  
              
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "Record", // Name of the node for each result
        fields : [
            { key: "NgayBatDau" },
            { key: "DoanhThu" }
        ],
        metaNode : "DANH_SACH", // Name of the node holding meta data
        metaFields : {
            totalRecords : "totalRecords"
    }
    };            

    var myConfigs = {
        // Set up pagination
//        initialRequest: "sort=id&dir=asc&startIndex=0&results=10", // Initial request for first page of data
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 20
        }),
        // Sorting and pagination will be routed to the server via generateRequest
        dynamicData : false
    };
    var myColumnDefs = [
        { key: "NgayBatDau", label:"Ngày" }, 
        { key: "DoanhThu", label:"Doanh thu" }
    ];
    var myDataTable = new YAHOO.widget.DataTable("divKq", myColumnDefs, myDataSource, myConfigs);

   // Update totalRecords on the fly with value from server
    myDataTable.handleDataReturnPayload = function(oRequest, oResponse, oPayload) {
        oPayload.totalRecords = parseInt(oResponse.meta.totalRecords);
        return oPayload;
    }
    
   	// Get a Column
   // var oColumn = myDataTable.getColumn(1);

    // Hide Column
    //myDataTable.hideColumn(oColumn)
   
   TaoChartDoanhThu();
};

function XL_ThongKe.ThongKeDoanhThuChung(strURL)
 {       
    //test
    //MakeMyChart();
    
         
    var myDataSource = new YAHOO.util.DataSource(encodeURI(strURL));    
    
    //test
    mymyDatasource = myDataSource; 
            
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "Record", // Name of the node for each result
        fields : [
            { key: "NgayBatDau" },
            { key: "NgayKetThuc" },
            { key: "DoanhThu" }
        ],
        metaNode : "DANH_SACH", // Name of the node holding meta data
        metaFields : {
            totalRecords : "totalRecords"
    }
    };            

    var myConfigs = {
        // Set up pagination
//        initialRequest: "sort=id&dir=asc&startIndex=0&results=10", // Initial request for first page of data
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 20
        }),
        // Sorting and pagination will be routed to the server via generateRequest
        dynamicData : false
    };
    var myColumnDefs = [
        { key: "NgayBatDau", label:"Ngày bắt đầu" }, 
         { key: "NgayKetThuc", label:"Ngày kết thúc" }, 
        { key: "DoanhThu", label:"Doanh thu" }
    ];
    var myDataTable = new YAHOO.widget.DataTable("divKq", myColumnDefs, myDataSource, myConfigs);

   // Update totalRecords on the fly with value from server
    myDataTable.handleDataReturnPayload = function(oRequest, oResponse, oPayload) {
        oPayload.totalRecords = parseInt(oResponse.meta.totalRecords);
        return oPayload;
    }
    
   	// Get a Column
    //var oColumn = myDataTable.getColumn(1);

    // Hide Column
    //myDataTable.hideColumn(oColumn)
    
    TaoChartDoanhThu();
};


function XL_ThongKe.ThongKeSanPhamTheoNgay(strURL)
  {            
    var myDataSource = new YAHOO.util.DataSource(encodeURI(strURL));          
    
    //test
    mymyDatasource = myDataSource; 
      
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "Record", // Name of the node for each result
        fields : [
            { key: "NgayBatDau" },
            { key: "SoLuongBan" }
        ],
        metaNode : "DANH_SACH", // Name of the node holding meta data
        metaFields : {
            totalRecords : "totalRecords"
    }
    };            

    var myConfigs = {
        // Set up pagination
//        initialRequest: "sort=id&dir=asc&startIndex=0&results=10", // Initial request for first page of data
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 20
        }),
        // Sorting and pagination will be routed to the server via generateRequest
        dynamicData : false
    };
    var myColumnDefs = [
        { key: "NgayBatDau", label:"Ngày" }, 
        { key: "SoLuongBan", label:"Số lượng bán" }
    ];
    var myDataTable = new YAHOO.widget.DataTable("divKq", myColumnDefs, myDataSource, myConfigs);

   // Update totalRecords on the fly with value from server
    myDataTable.handleDataReturnPayload = function(oRequest, oResponse, oPayload) {
        oPayload.totalRecords = parseInt(oResponse.meta.totalRecords);
        return oPayload;
    }
    
   	// Get a Column
    var oColumn = myDataTable.getColumn(1);

    // Hide Column
    //myDataTable.hideColumn(oColumn)
    
    TaoChartSoLuong();
};

    function XL_ThongKe.ThongKeSanPhamChung(strURL)
  {            
    var myDataSource = new YAHOO.util.DataSource(encodeURI(strURL));        
    
    //test
    mymyDatasource = myDataSource; 
        
    myDataSource.responseType = YAHOO.util.DataSource.TYPE_XML;
    myDataSource.responseSchema = {            
        resultNode : "Record", // Name of the node for each result
        fields : [
            { key: "NgayBatDau" },
            { key: "NgayKetThuc" },
            { key: "SoLuongBan" }
        ],
        metaNode : "DANH_SACH", // Name of the node holding meta data
        metaFields : {
            totalRecords : "totalRecords"
    }
    };            

    var myConfigs = {
        // Set up pagination
//        initialRequest: "sort=id&dir=asc&startIndex=0&results=10", // Initial request for first page of data
        paginator : new YAHOO.widget.Paginator({
            rowsPerPage    : 20
        }),
        // Sorting and pagination will be routed to the server via generateRequest
        dynamicData : false
    };
    var myColumnDefs = [
        { key: "NgayBatDau", label:"Ngày bắt đầu" }, 
         { key: "NgayKetThuc", label:"Ngày kết thúc" }, 
        { key: "SoLuongBan", label:"Số lượng bán" }
    ];
    var myDataTable = new YAHOO.widget.DataTable("divKq", myColumnDefs, myDataSource, myConfigs);

   // Update totalRecords on the fly with value from server
    myDataTable.handleDataReturnPayload = function(oRequest, oResponse, oPayload) {
        oPayload.totalRecords = parseInt(oResponse.meta.totalRecords);
        return oPayload;
    }
    
   	// Get a Column
    //var oColumn = myDataTable.getColumn(1);

    // Hide Column
    //myDataTable.hideColumn(oColumn)
    
    TaoChartSoLuong();
};

function MakeMyChart()
{
    YAHOO.widget.Chart.SWFURL = "./build/charts/assets/charts.swf";
	
	//used to format x axis labels
	YAHOO.example.numberToCurrency = function( value )
	{
		return YAHOO.util.Number.format(Number(value), {prefix: "$", thousandsSeparator: ","});
	}
	
	//manipulating the DOM causes problems in ie, so create after window fires "load"
	YAHOO.util.Event.addListener(window, "load", function()
	{ 
	
	//--- data
   
		YAHOO.example.annualIncome =
		[
			{ year: 2003, revenue: 1246852, expense: 1123359, income: 123493 },
			{ year: 2004, revenue: 2451876, expense: 2084952, income: 366920 },
			{ year: 2005, revenue: 2917246, expense: 2587151, income: 330095 },
			{ year: 2006, revenue: 3318185, expense: 3087456, income: 230729 }
		];
   
		var incomeData = new YAHOO.util.DataSource( YAHOO.example.annualIncome );
		incomeData.responseType = YAHOO.util.DataSource.TYPE_JSARRAY;
		incomeData.responseSchema = { fields: [ "year", "revenue", "expense", "income" ] };
   
	//--- chart
   
		var seriesDef =
		[
			{
				xField: "revenue",
				displayName: "Revenue"
			},
			{
				xField: "expense",
				displayName: "Expense"
			},
			{
				type: "line",
				xField: "income",
				displayName: "Income"
			}
		];
   
		var currencyAxis = new YAHOO.widget.NumericAxis();
		currencyAxis.labelFunction = "YAHOO.example.numberToCurrency";
   
		var mychart = new YAHOO.widget.BarChart( "chart", incomeData,
		{
			series: seriesDef,
			yField: "year",
			xAxis: currencyAxis,
			//only needed for flash player express install
			expressInstall: "./build/charts/assets/expressinstall.swf"
		});
   
	//--- data table
	
		var columns =
		[
			{ key: "year", sortable: true, resizeable: true },
			{ key: "revenue", formatter: "currency", sortable: true, resizeable: true },
			{ key: "expense", formatter: "currency", sortable: true, resizeable: true },
			{ key: "income", formatter: "currency", sortable: true, resizeable: true }
		];
		var mytable = new YAHOO.widget.DataTable( "datatable", columns, incomeData,
			{ sortedBy: { key: "year", dir: "asc" }
		});
	});

}

function TaoChartDoanhThu()
{
    YAHOO.widget.Chart.SWFURL = "./build/charts/assets/charts.swf";
	
	//used to format x axis labels
	
	YAHOO.example.numberToCurrency = function( value )
	{
		return YAHOO.util.Number.format(Number(value), {suffix: "đ", thousandsSeparator: ","});
	}
		
   		var incomeData = mymyDatasource;
		
		 incomeData.responseType = YAHOO.util.DataSource.TYPE_XML;
        incomeData.responseSchema = {            
            resultNode : "Record", // Name of the node for each result
            fields : [
                { key: "NgayBatDau"},
                 { key: "NgayKetThuc"},
                { key: "DoanhThu", parser: "number"}
            ],
            metaNode : "DANH_SACH", // Name of the node holding meta data
            metaFields : {
                totalRecords : "totalRecords"
        }};   
	//--- chart
   
		var seriesDef =
		[
			{
			    
				xField: "DoanhThu",
				displayName: "DoanhThu"
			}
		];
   
	    var currencyAxis = new YAHOO.widget.NumericAxis();
	    currencyAxis.labelFunction = "YAHOO.example.numberToCurrency";
   
		var mychart = new YAHOO.widget.BarChart( "chart", incomeData,
		{
			series: seriesDef,
			yField: "NgayBatDau",
			xAxis: currencyAxis,
			//only needed for flash player express install
			expressInstall: "./build/charts/assets/expressinstall.swf"
		});
		
		
}


function TaoChartSoLuong()
{
    YAHOO.widget.Chart.SWFURL = "./build/charts/assets/charts.swf";
	
	//used to format x axis labels
	
	/*
	YAHOO.example.numberToCurrency = function( value )
	{
		return YAHOO.util.Number.format(Number(value), {suffix: "đ", thousandsSeparator: ","});
	}
	*/	
   		var incomeData = mymyDatasource;
		
		 incomeData.responseType = YAHOO.util.DataSource.TYPE_XML;
        incomeData.responseSchema = {            
            resultNode : "Record", // Name of the node for each result
            fields : [
                { key: "NgayBatDau"},
                { key: "NgayKetThuc"},
                { key: "SoLuongBan", parser: "number"}
                
            ],
            metaNode : "DANH_SACH", // Name of the node holding meta data
            metaFields : {
                totalRecords : "totalRecords"
        }};   
	//--- chart
   
		var seriesDef =
		[
			{
				xField: "SoLuongBan",
				displayName: "Số lượng bán"
			}
		];
   
	    //var currencyAxis = new YAHOO.widget.NumericAxis();
	    //currencyAxis.labelFunction = "YAHOO.example.numberToCurrency";
   
		var mychart = new YAHOO.widget.BarChart( "chart", incomeData,
		{
			series: seriesDef,
			yField: "NgayBatDau",
			//xAxis: currencyAxis,
			//only needed for flash player express install
			expressInstall: "./build/charts/assets/expressinstall.swf"
		});
}