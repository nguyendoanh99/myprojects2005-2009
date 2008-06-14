// Hàm xóa các khoảng trắng bên trái của chuỗi
function TrimLeft(str)
{
	var _result;
	// Tim vi tri dau tien ma tai do ky khac khoang trang tinh tu trai qua phai
	var i;
	for (i = 0; i < str.length &&  str.charAt(i) == ' '; ++i);
              
    _result = str.substring(i);
	return _result;
}
// Hàm xóa các khoảng trắng bên phải của chuỗi
function TrimRight(str)
{	    
    var _result;
	// Tim ky tu dau tien khac khoang trang tinh tu phai qua trai
	var i;
	for (i = str.length - 1; i >= 0 && str.charAt(i) == ' '; --i);

	_result = str.substring(0, i + 1);
	return _result;
}
// Hàm xóa các khoảng trắng ở 2 đầu của chuỗi
function Trim(str)
{
    var _result;
    _result = TrimLeft(str);
    _result = TrimRight(_result);
    
    return _result;
}
