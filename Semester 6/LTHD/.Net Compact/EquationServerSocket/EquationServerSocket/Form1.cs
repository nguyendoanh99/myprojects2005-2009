using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace EquationServerSocket
{
    public partial class Form1 : Form
    {
        // Source code: http://www.informit.com/guides/content.aspx?g=dotnet&seqNum=194
        // output a message to the text box.
        private delegate void OutputMessageDelegate(string msg);
        private void OutputMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                // if operating on a thread, invoke a delegate
                // on the UI thread.
                OutputMessageDelegate omd =
                  new OutputMessageDelegate(OutputMessage);
                IAsyncResult arx = this.BeginInvoke(
                  omd, new object[] { msg });
                this.EndInvoke(arx);
                return;
            }
            txtNote.AppendText(msg + "\r\n");
        }

        Socket m_Server;
        byte[] data = new byte[1024];
        int size = 1024;
        public Form1()
        {
            InitializeComponent();
        }

        private void butListen_Click(object sender, EventArgs e)
        {
            m_Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 8999);
            m_Server.Bind(ep);
            m_Server.Listen((int)SocketOptionName.MaxConnections);
            m_Server.BeginAccept(new AsyncCallback(CallAccept), m_Server);
        }
        private void CallAccept(IAsyncResult iar)
        { 
            Socket oldServer = (Socket) iar.AsyncState;
            Socket Client = oldServer.EndAccept(iar);
            String s = "Đã kết nối với " + Client.RemoteEndPoint.ToString();
            s += "\r\nChờ nhận dữ liệu...";
            OutputMessage(s);
            // BeginReceive
            Client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), Client);
        }
        
        private void ReceiveData(IAsyncResult iar)
        {
            // EndReceive
            Socket Client = (Socket) iar.AsyncState;
            int rsize = Client.EndReceive(iar);
            String s = Encoding.ASCII.GetString(data, 0, rsize);
            OutputMessage("Dữ liệu nhận được là \"" + s + "\"");

            // Chuyen XML thanh TamThuc
            TamThuc tt = new TamThuc();
            tt.GetXMLDocument(s);
            Nghiem n = tt.GiaiPT();
            // BeginSend
            String kq = n.ToXMLDocument();
            byte[] mess = Encoding.ASCII.GetBytes(kq);
            Client.BeginSend(mess, 0, mess.Length, SocketFlags.None, new AsyncCallback(SendData), Client);
            OutputMessage("Dữ liệu gửi đi là \"" + kq + "\"");
        }
        private void SendData(IAsyncResult iar)
        {
            // EndSend
            Socket Client = (Socket) iar.AsyncState;
            String s = "Đã gửi dữ liệu thành công\r\n";
            OutputMessage(s);

            // Close & BeginAccept
            Client.Close();
            m_Server.BeginAccept(new AsyncCallback(CallAccept), m_Server);
        }
 
        private void butStop_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}