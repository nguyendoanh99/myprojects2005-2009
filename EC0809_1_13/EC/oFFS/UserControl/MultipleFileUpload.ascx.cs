using System;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class MultipleFileUpload : System.Web.UI.UserControl
{   
    public event MultipleFileUploadClick Click;

    private int _UpperLimit = 0;

    public int UpperLimit
    {
        get { return _UpperLimit; }
        set { _UpperLimit = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(typeof(Page), "MyScript", GetJavaScript());
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        // Fire the event.        
        Click(this, new FileCollectionEventArgs(this.Request));        
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        
        JavaScript.Append("<script type='text/javascript'>");
        JavaScript.Append("var Id = 0;\n");
        JavaScript.AppendFormat("var MAX = {0};\n", _UpperLimit);
        JavaScript.AppendFormat("var DivFiles = document.getElementById('{0}');\n", pnlFiles.ClientID);

        JavaScript.Append("function CreateFile()");
        JavaScript.Append("{\n");
        JavaScript.Append("var IpFile = GetTopFile();\n");
        JavaScript.Append("if(IpFile == null || IpFile.value == null || IpFile.value.length == 0)\n");
        JavaScript.Append("{\n");
        JavaScript.Append("return;\n");
        JavaScript.Append("}\n");
        JavaScript.Append("var NewIpFile = document.createElement('input');\n");
        JavaScript.Append("NewIpFile.id = NewIpFile.name = 'IpFile_' + Id++;\n");
        JavaScript.Append("NewIpFile.type = 'file';\n");
        JavaScript.Append("DivFiles.insertBefore(NewIpFile,IpFile);\n");
        JavaScript.Append("return NewIpFile;\n");
        JavaScript.Append("}\n");       

        JavaScript.Append("function GetTopFile()\n");
        JavaScript.Append("{\n");
        JavaScript.Append("var Inputs = DivFiles.getElementsByTagName('input');\n");
        JavaScript.Append("var IpFile = null;\n");
        JavaScript.Append("for(var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)\n");
        JavaScript.Append("{\n");
        JavaScript.Append("IpFile = Inputs[n];\n");
        JavaScript.Append("break;\n");
        JavaScript.Append("}\n");
        JavaScript.Append("return IpFile;\n");
        JavaScript.Append("}\n");

        JavaScript.Append("function DisableTop()\n");
        JavaScript.Append("{\n");        
        JavaScript.Append("CreateFile();\n");
        JavaScript.Append("GetTopFile().disabled = true;\n");
        JavaScript.Append("return true;\n");
        JavaScript.Append("}\n");
        JavaScript.Append("</script>");

        return JavaScript.ToString();
    }
}

public class FileCollectionEventArgs : EventArgs
{
    private HttpRequest _HttpRequest;

    public HttpFileCollection PostedFiles
    {
        get
        {
            return _HttpRequest.Files;
        }
    }

    public bool HasFiles
    {
        get { return _HttpRequest.Files.Count > 0 ? true : false; }
    }

    public double Size
    {
        get
        {
            double Size = 0D;

            if (_HttpRequest.Files[0].ContentLength >= 0)
                Size += _HttpRequest.Files[0].ContentLength;

            return Math.Round(Size / 1024D, 2);
        }
    }

    public FileCollectionEventArgs(HttpRequest oHttpRequest)
    {
        _HttpRequest = oHttpRequest;
    }
}

public delegate void MultipleFileUploadClick(object sender, FileCollectionEventArgs e);