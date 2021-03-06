using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace EquationClientSocketPPC
{
    public partial class Form1 : Form
    {
        String m_strSent;
        int m_Size = 1024;
        byte[] m_Data = new byte[1024];
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
            txtKetQua.Text = msg;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void butGiaiPT_Click(object sender, EventArgs e)
        {
            String strA = txtA.Text;
            String strB = txtB.Text;
            String strC = txtC.Text;
            String strIP = txtIPServer.Text;
            String strPort = txtPort.Text;
            
            // Ket xuat chuoi thanh XML
            m_strSent = KetXuatXML(strA, strB, strC);

            // BeginConnect
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(strIP), int.Parse(strPort));
            newSocket.BeginConnect(iep, new AsyncCallback(Connected), newSocket);
        }

        private void Connected(IAsyncResult iar)
        {
            Socket server = (Socket)iar.AsyncState;
            try
            {
                // EndConnect
                server.EndConnect(iar);              
                byte[] mess = Encoding.ASCII.GetBytes(m_strSent);

                // BeginSend
                server.BeginSend(mess, 0, mess.Length, SocketFlags.None, new AsyncCallback(SendData), server);            }
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
            server.BeginReceive(m_Data, 0, m_Size, SocketFlags.None, new AsyncCallback(ReceiveData), server);            
        }
        private void ReceiveData(IAsyncResult iar)
        {
            try
            {
                // EndReceive
                Socket server = (Socket)iar.AsyncState;
                int rec = server.EndReceive(iar);
                string s = Encoding.ASCII.GetString(m_Data, 0, rec);

                Nghiem n = Nghiem.XMLtoNghiem(s);
                OutputMessage(n.ToString());

                // Close
                server.Close();
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
            
        }

        private String KetXuatXML(String strA, String strB, String strC)
        {
            string kq = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            kq += "<TAMTHUC A=\"" + strA + "\"";
            kq += " B=\"" + strB + "\"";
            kq += " C=\"" + strC + "\"";
            kq += "/>";
            return kq;
        }
    }
}