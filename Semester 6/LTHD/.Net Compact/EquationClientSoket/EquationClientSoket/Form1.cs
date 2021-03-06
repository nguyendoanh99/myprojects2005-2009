using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace EquationClientSoket
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

        byte[] data = new byte[1024];
        int size = 1024;
        public Form1()
        {
            InitializeComponent();
        }

        private void butReceive_Click(object sender, EventArgs e)
        {
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("192.168.2.10"), 8999);
            newSocket.BeginConnect(iep, new AsyncCallback(Connected), newSocket);
            OutputMessage("Bắt đầu Connect...");
        }
        private void Connected(IAsyncResult iar)
        {
            Socket server = (Socket)iar.AsyncState;
            try
            {
                // EndConnect
                server.EndConnect(iar);
                OutputMessage("Đã connect tới " + server.RemoteEndPoint.ToString());
                String str = "Chào bạn";
                byte[] mess = Encoding.UTF8.GetBytes(str);
                
                // BeginSend
                server.BeginSend(mess, 0, mess.Length, SocketFlags.None, new AsyncCallback(SendData), server);
                OutputMessage("Bắt đầu truyền dữ liệu...");                
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        private void SendData(IAsyncResult iar)
        {
            // EndSend
            Socket server = (Socket)iar.AsyncState;
            int sSend = server.EndSend(iar);
         
            // BeginReceive
            server.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), server);
            OutputMessage("Bắt đầu nhận dữ liệu");
        }
        private void ReceiveData(IAsyncResult iar)
        {
            // EndReceive
            Socket server = (Socket)iar.AsyncState;
            int rec = server.EndReceive(iar);
            string s = Encoding.UTF8.GetString(data, 0, rec);
            OutputMessage("Dữ liệu nhận được là " + s);
            
            // Close
            server.Close();
        }
    }
}