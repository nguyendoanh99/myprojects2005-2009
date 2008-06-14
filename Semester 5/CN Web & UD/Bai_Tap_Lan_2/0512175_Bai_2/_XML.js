// Hàm đọc file XML 
function LoadXMLDoc(URL)
{
    var XMLDoc;
    
    if (window.ActiveXObject) // IE
    {
        XMLDoc = new ActiveXObject("Microsoft.XMLDOM");
    }
    else
        if (document.implementation && document.implementation.createDocument) // Mozilla, FireFox, Opera, etc.
        {            
            XMLDoc = document.implementation.createDocument("","", null);            
        }
        else
            alert("Your browser cannot handle this script");
    
    XMLDoc.async = false;
    XMLDoc.load(URL);
    return XMLDoc;
}
