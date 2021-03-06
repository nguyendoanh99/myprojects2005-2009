using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using SpeechLib;
using System.IO;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   [WebMethod]
    public string Translator(string OriginalText, string code)
   {
       CTranslator t = new CTranslator(OriginalText, code);
       return t.Perform();
   }
    [WebMethod]
    public byte[] TextToSpeak(string text)
    {
        string filename = "temp.wav";
        SpFileStream objFSTRM = new SpFileStream();
        objFSTRM.Open(filename, SpeechStreamFileMode.SSFMCreateForWrite, false);
        SpVoice objVoice = new SpVoice();
        objVoice.AudioOutputStream = objFSTRM;
        objVoice.Volume = 100;
        objVoice.Speak(text, SpeechVoiceSpeakFlags.SVSFDefault);
        objFSTRM.Close();
        objVoice.AudioOutputStream = null;
        // Doc file de chuyen di
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        byte[] kq = new byte[fs.Length];
        fs.Read(kq, 0, kq.Length);
        fs.Close();
        return kq;
    }
}
