// Hàm kiểm tra str có phải là một số dương hay không
// return true: là số dương
// return false: không phải là số dương
function IsPositiveNumber(str)
{
    var _result = true;
    
    if (isNaN(str) == true)        
        _result = false;
    else
        if (parseInt(str) <= 0)
            _result = false;    
          
    return _result;
}
// Hàm kiểm tra str có phải là kiểu số hay không, và có nằm trong [MinNumber, MaxNumber]
// return "" : đúng
// return !"" : chi tiết các lỗi sai
function CheckNumber(str, MinNumber, MaxNumber)
{
    var _result = "";
    if (MinNumber == null)
        MinNumber = Number.NEGATIVE_INFINITY;
    
    if (MaxNumber == null)
        MaxNumber = Number.POSITIVE_INFINITY;
        
    if (str == "" || isNaN(str) == true)
    {
        _result = str + " phải là kiểu số.";
    }
    else
    {
        var temp = parseInt(str);
 
        if (temp < MinNumber || temp > MaxNumber)       
        {
            if (MinNumber == Number.NEGATIVE_INFINITY)
                _result = str + " phải nhỏ hơn hay bằng " + MaxNumber + ".";        
            else
                if (MaxNumber == Number.POSITIVE_INFINITY)
                    _result = str + " phải lớn hơn hay bằng " + MinNumber + ".";        
                else
                    _result = str + " phải thuộc [" + MinNumber + "," + MaxNumber + "].";        
        }
    }
          
    return _result;   
}