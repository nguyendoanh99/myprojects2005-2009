// Hàm kiểm tra str (dd/mm/yyyy) có phải là kiểu ngày hay không, và có nằm trong [MinDate, MaxDate]
// return "" : ngày hợp lệ
// return !"" : chi tiết các lỗi sai
function CheckDate(str, MinDate, MaxDate)
{
    if (MinDate == null)
        MinDate = new Date(0, 0, 1);
    
    if (MaxDate == null)
        MaxDate = new Date();
        
    var M = str.split("/");
    var _result = "";
    
    if (M.length == 3)
    {
        var dd = M[0];
        var mm = M[1];
        var yyyy = M[2];
        var temp;
        var DaysOfMonth = new Array(12);
        DaysOfMonth[0] = 31;
        DaysOfMonth[1] = 28;
        DaysOfMonth[2] = 31;
        DaysOfMonth[3] = 30;
        DaysOfMonth[4] = 31;
        DaysOfMonth[5] = 30;
        DaysOfMonth[6] = 31;
        DaysOfMonth[7] = 31;
        DaysOfMonth[8] = 30;
        DaysOfMonth[9] = 31;
        DaysOfMonth[10] = 30;
        DaysOfMonth[11] = 31;

        temp = CheckNumber(yyyy, MinDate.getFullYear());
        if (temp != "") 
            _result = _result + temp.replace(yyyy, "Năm (yyyy)") + "\n";
        else
            if (IsBissextile(yyyy) == true)
                DaysOfMonth[1] = 29;
            
        temp = CheckNumber(mm, 1, 12);
        if (temp != "")    
            _result = _result + temp.replace(mm, "Tháng (mm)") + "\n";
        
        temp = CheckNumber(dd, 1, DaysOfMonth[parseInt(mm) - 1]);
        if (temp != "")
            _result = _result + temp.replace(dd, "Ngày (dd)") + "\n";
            
        if (_result == "") // Không có lỗi
        {
            var _date = InitDate(str);
            if (_date < MinDate || _date > MaxDate)
                _result = _result + str + " phải nằm trong khoảng từ ngày " + DateToString(MinDate) + " đến ngày " + DateToString(MaxDate) + ".\n";
        }
    }
    else
        _result = "Kiểu ngày phải gồm 3 thành phần, theo định dạng mm/dd/yyyy.";

    return _result;
}
// Chuyển kiểu date thành string (dd/mm/yyyy)
// return string
function DateToString(_date)
{
    var _result = new String();
    _result = "" + _date.getDate() + "/" + (_date.getMonth() + 1) + "/" + _date.getFullYear();
    
    return _result;
}
// Tạo kiểu Date từ str (dd/mm/yyyy)
// return Date
function InitDate(str)
{
    var M = str.split("/");
    var dd = parseInt(M[0]);
    var mm = parseInt(M[1]);
    var yyyy = parseInt(M[2]);
    var _result = new Date(yyyy, mm - 1, dd);
    
    return _result;
}
// Hàm kiểm tra năm nhuần 
// return true : yyyy là năm nhuần
// return false : yyyy không là năm nhuần
function IsBissextile(yyyy)
{
    return IsPositiveNumber(yyyy) && (((yyyy % 4 == 0) && (yyyy % 100 != 0)) || (yyyy % 400));
}