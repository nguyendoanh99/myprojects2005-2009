using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
public class CTranslator
{
    private string _data = "";
    private string _language = "en|fr"; // Anh sang Pháp
    public string Data
    {
        get { return _data; }
        set { _data = value; }
    }
    public string Language
    {
        get { return _language; }
        set { _language = value; }
    }
    public CTranslator()
    {

    }
    public CTranslator(string szData, string szLanguage)
    {
        Data = szData;
        Language = szLanguage;
    }
    // Thực thi
    public string Perform()
    {
        string result = "";
        // Create a new request to the mentioned URL.    
        WebRequest myWebRequest = WebRequest.Create("http://www.google.com/translate_t?langpair=" + Language);

        // Create an instance of the RequestState and assign 
        // 'myWebRequest' to it's request field.    
        RequestState myRequestState = new RequestState();
        myRequestState.request = myWebRequest;
        myWebRequest.ContentType = "application/x-www-form-urlencoded";

        // Set the 'Method' property  to 'POST' to post data to a Uri.
        myRequestState.request.Method = "POST";
        // Start the Asynchronous 'BeginGetRequestStream' method call.    
        IAsyncResult r = (IAsyncResult)myWebRequest.BeginGetRequestStream(
            new AsyncCallback(ReadCallback), myRequestState);
        // Pause the current thread until the async operation completes.
        allDone.WaitOne();
        // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
        WebResponse myWebResponse = myWebRequest.GetResponse();

        Stream streamResponse = myWebResponse.GetResponseStream();
        StreamReader streamRead = new StreamReader(streamResponse, Encoding.Default);
        string tempString = streamRead.ReadToEnd();
        string szMau = "<div id=result_box dir=\"ltr\">";
        int index1 = tempString.IndexOf(szMau) + szMau.Length;
        int index2 = tempString.IndexOf("</div>", index1);
        result = tempString.Substring(index1, index2 - index1);
        result = result.Replace("&#39;", "'");
        result = result.Replace("&quot;", "\"");
        result = result.Replace("&lt;", "<");
        result = result.Replace("&gt;", ">");
        // Close the Stream Object.
        streamResponse.Close();
        streamRead.Close();


        // Release the HttpWebResponse Resource.
        myWebResponse.Close();
        return result;
    }

    public ManualResetEvent allDone = new ManualResetEvent(false);

    private void ReadCallback(IAsyncResult asynchronousResult)
    {
        RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
        WebRequest myWebRequest = myRequestState.request;

        // End the Asynchronus request.
        Stream streamResponse = myWebRequest.EndGetRequestStream(asynchronousResult);

        // Create a string that is to be posted to the uri.
        Uri t = new Uri("http://127.0.0.1/" + Data);
        string data = t.AbsolutePath.Substring(1);
        string postData = "hl=en&ie=UTF8&text=" + data;// Console.ReadLine();
        // Convert the string into a byte array.
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        // Write the data to the stream.
        streamResponse.Write(byteArray, 0, postData.Length);
        streamResponse.Close();
        allDone.Set();
    }
}
public class RequestState
{
    // This class stores the request state of the request.
    public WebRequest request;
    public RequestState()
    {
        request = null;
    }
}