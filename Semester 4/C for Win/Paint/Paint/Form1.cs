// Nguyen Dang Khoa
// 0512175
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Win32;
using PaintLib;
using System.Runtime.InteropServices;

using HANDLE = System.IntPtr;
using HWND = System.IntPtr;
using HDC = System.IntPtr;
namespace Paint
{
    public partial class Form1 : Form
    {        
//        [DllImport("Dll")]
//        public static extern int _RGB(int R, int G, int B);
        // color hien tai
        private static byte m_R;
        private static byte m_G;
        private static byte m_B;        

        const int distance = 3;
        private POINT m_Start;
        private POINT m_End;
        private POINT[] m_arrPoint;
        private bool flag; // Cho biet dang ve hinh
        private bool flag1;       // Giai quyet van de luu hinh khi ve lai
        private CShape m_Shape; 
        private CShape[] m_arrShape;
        public Form1()
        {            
            InitializeComponent();
            m_Start = new POINT();
            m_End = new POINT();            
        }
        // Gan cac gia tri cho m_Shape
        private void Gan(CShape shape)
        {
            shape.SetDrawMode(GDI.R2_NOTXORPEN);
            shape.SetWidth(int.Parse(tcmbWidth.SelectedItem.ToString()));
            shape.SetPenStyle(Chon(tcmbPenStyle.SelectedItem.ToString()));            
            shape.SetColor(_RGB(m_R, m_G, m_B));
            
        }
        private void New()
        {
            tlbl.Visible = true;
            m_R = 0;
            m_G = 0;
            m_B = 0;
            m_Shape = new CLine();

            flag1 = false;
            flag = false;
            tcmbPenStyle.SelectedIndex = 0;
            tcmbWidth.SelectedIndex = 0;
            m_Start.x = m_Start.y = m_End.x = m_End.y = 0;
            m_arrShape = null;
            m_arrPoint = null;
            UnChecked();
            tButLine.Checked = true;

            
            Gan(m_Shape);
        }
        // Xoa hinh dang ve
        private void Xoa()
        {
            if (flag)
            {
                HDC hdc = (HDC)User.GetDC(panel1.Handle);                
                if (m_Shape.ToString() == "CPolygon" && m_arrPoint != null)
                {
                    POINT[] t = new POINT[2];
                    t[0].x = m_arrPoint[0].x - distance;
                    t[0].y = m_arrPoint[0].y - distance;
                    t[1].x = m_arrPoint[0].x + distance;
                    t[1].y = m_arrPoint[0].y + distance;
                    CRectangle rec = new CRectangle(t[0], t[1]);
                    rec.SetDrawMode(GDI.R2_NOTXORPEN);
                    rec.Draw(hdc);

                    POINT[] t1 = new POINT[2];
                    t1[1] = m_arrPoint[0];
                    CLine line = new CLine();
                    Gan(line);
                    for (int i = 1; i < m_arrPoint.Length; ++i)
                    {
                        // Ve duong thang
                        t1[0] = t1[1];
                        t1[1] = m_arrPoint[i];
                        line.SetPoints(t1);
                        line.Draw(hdc);
                        // Ve o vuong nho tai cac dinh
                        t[0].x = m_arrPoint[i].x - distance;
                        t[0].y = m_arrPoint[i].y - distance;
                        t[1].x = m_arrPoint[i].x + distance;
                        t[1].y = m_arrPoint[i].y + distance;
                        rec.SetPoints(t);
                        rec.Draw(hdc);
                    }

                    // Ve duong thang
                    t1[0] = t1[1];
                    t1[1] = m_End;
                    line.SetPoints(t1);
                    line.Draw(hdc);
                }                
                else
                    m_Shape.Draw(hdc);
                User.ReleaseDC(panel1.Handle, hdc);
            }
        }
        // Unchecked tat ca cac nut nhan
        private void UnChecked()
        {
            tButCircle.Checked = false;
            tButLine.Checked = false;
            tButPolygon.Checked = false;
            tButRectangle.Checked = false;
        }
        public static int _RGB(int R, int G, int B)
        {
            return (R | (G << 8) | (B << 16));
        }
        
        private int Chon(string str)
        {
            int kq = GDI.PS_SOLID;
            switch(str)
            {
                case "PS_SOLID":
                    kq = GDI.PS_SOLID;
                    break;
                case "PS_DASH":
                    kq = GDI.PS_DASH;
                    break;
                case "PS_DOT":
                    kq = GDI.PS_DOT;
                    break;
                case "PS_DASHDOT":
                    kq = GDI.PS_DASHDOT;
                    break;
                case "PS_DASHDOTDOT":
                    kq = GDI.PS_DASHDOTDOT;
                    break;
                case "PS_NULL":
                    kq = GDI.PS_NULL;
                    break;
                case "PS_INSIDEFRAME":
                    kq = GDI.PS_INSIDEFRAME;
                    break;
            }
            return kq;
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            New();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = e.X.ToString() + " : " + e.Y.ToString();

            if (flag)
            {
                POINT[] T = new POINT[2];
                T[0] = m_Start;
                T[1] = m_End;
                HDC hdc = (HDC)User.GetDC(panel1.Handle);

                if (flag1 == false)
                {
                    if (m_Shape.ToString() == "CPolygon")
                    {
                        CShape shape = new CLine();
                        shape.SetPoints(T);
                        Gan(shape);
                        shape.Draw(hdc);
                    }
                    else
                    {
                        m_Shape.SetPoints(T);
                        m_Shape.Draw(hdc);
                    }
                }

                flag1 = false;
                if (m_Shape.ToString() == "CEllipse")
                {
                    int temp = Math.Min(Math.Abs(e.X - m_Start.x), Math.Abs(e.Y - m_Start.y));
                    m_End.x = m_Start.x + Math.Sign(e.X - m_Start.x)*temp;
                    m_End.y = m_Start.y + Math.Sign(e.Y - m_Start.y)*temp;
                }
                else
                {
                    m_End.x = e.X;
                    m_End.y = e.Y;
                }

                T[1] = m_End;
                if (m_Shape.ToString() == "CPolygon")
                {
                    CShape shape = new CLine();
                    shape.SetPoints(T);
                    Gan(shape);
                    shape.Draw(hdc);
                }
                else
                {                    
                    m_Shape.SetPoints(T);
                    m_Shape.Draw(hdc);
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = !flag;
            if (flag) // bat dau ve
            {
                tlbl.Visible = false;
                tcmbPenStyle.Enabled = false;
                tcmbWidth.Enabled = false;
                m_Start.x = m_End.x = e.X;
                m_Start.y = m_End.y = e.Y;
                if (m_Shape.ToString() == "CPolygon")
                {
                    HDC hdc = (HDC)User.GetDC(panel1.Handle);
                    CRectangle rec = new CRectangle(m_End.x - distance, m_End.y - distance, m_End.x + distance, m_End.y + distance);
                    rec.SetDrawMode(GDI.R2_NOTXORPEN);
                    rec.Draw(hdc);
                    User.ReleaseDC(panel1.Handle, hdc);                    

                    m_arrPoint = new POINT[1];                    
                    m_arrPoint[0] = m_End;
                }
            }
            else                
            {
                HDC hdc = (HDC)User.GetDC(panel1.Handle);
                if (m_Shape.ToString() == "CPolygon")
                {
                    if (e.Clicks != 2)
                    {
                        m_Start = m_End;
                        flag = !flag;
                        CRectangle rec = new CRectangle(m_End.x - distance, m_End.y - distance, m_End.x + distance, m_End.y + distance);
                        rec.SetDrawMode(GDI.R2_NOTXORPEN);
                        rec.Draw(hdc);
                        User.ReleaseDC(panel1.Handle, hdc);

                        Array.Resize<POINT>(ref m_arrPoint, m_arrPoint.Length + 1);
                        m_arrPoint[m_arrPoint.Length - 1] = m_End;                        
                        return;
                    }
                    else
                    {
                        m_Shape.SetPoints(m_arrPoint);
                        foreach (POINT t in m_arrPoint)
                        {
                            CRectangle rec = new CRectangle(t.x - distance, t.y - distance, t.x + distance, t.y + distance);
                            rec.SetDrawMode(GDI.R2_NOTXORPEN);
                            rec.Draw(hdc);
                        }
                        m_arrPoint = null;
                    }
                }

                m_Shape.SetDrawMode(GDI.R2_COPYPEN);
                m_Shape.Draw(hdc);                
                
                // Them hinh vao tap hop
                if (m_arrShape == null)
                    m_arrShape = new CShape[1];
                else
                    Array.Resize<CShape>(ref m_arrShape, m_arrShape.Length + 1);
                m_arrShape[m_arrShape.Length - 1] = m_Shape;

                switch (m_Shape.ToString())
                {
                    case "CLine":
                        m_Shape = new CLine();
                        break;
                    case "CEllipse":
                        m_Shape = new CEllipse();
                        break;
                    case "CPolygon":
                        m_Shape = new CPolygon();
                        break;
                    case "CRectangle":
                        m_Shape = new CRectangle();
                        break;
                }
                Gan(m_Shape);

                User.ReleaseDC(panel1.Handle, hdc);

                tcmbPenStyle.Enabled = true;
                tcmbWidth.Enabled = true;
                tlbl.Visible = true;
            }            
        }

        private void tButLine_Click(object sender, EventArgs e)
        {
            UnChecked();
            tButLine.Checked = true;
            Xoa();
            flag = false;
            m_Shape = new CLine();
            Gan(m_Shape);
        }

        private void tButCircle_Click(object sender, EventArgs e)
        {
            UnChecked();
            tButCircle.Checked = true;
            Xoa();
            flag = false;
            m_Shape = new CEllipse();
            Gan(m_Shape);
        }

        private void tButRectangle_Click(object sender, EventArgs e)
        {
            UnChecked();
            tButRectangle.Checked = true;
            Xoa();
            flag = false;
            m_Shape = new CRectangle();
            Gan(m_Shape);
        }

        private void tButPolygon_Click(object sender, EventArgs e)
        {
            UnChecked();
            tButPolygon.Checked = true;
            Xoa();
            flag = false;
            m_Shape = new CPolygon();
            m_Shape.SetWidth(int.Parse(tcmbWidth.SelectedItem.ToString()));
            m_Shape.SetPenStyle(Chon(tcmbPenStyle.SelectedItem.ToString()));
            m_Shape.SetColor(_RGB(m_R, m_G, m_B));
        }

        private void tcmbPenStyle_SelectedIndexChanged(object sender, EventArgs e)
        {   
            m_Shape.SetPenStyle(Chon(tcmbPenStyle.SelectedItem.ToString()));
        }

        private void tcmbWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
/*            ++dem;
            toolStripLabel2.Text = dem.ToString();

            if (flag)
            {
                HDC hdc = (HDC)User.GetDC(panel1.Handle);
                POINT[] T = new POINT[2];
                T[0] = m_Start;
                T[1] = m_End;

                flag1 = true;
                m_Shape.SetPoints(T);
                m_Shape.Draw(hdc);
                User.ReleaseDC(panel1.Handle, hdc);
            }         
*/            m_Shape.SetWidth(int.Parse(tcmbWidth.SelectedItem.ToString()));            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            HDC hdc = (HDC)User.GetDC(panel1.Handle);

            if (m_arrShape != null)
            {
                foreach (CShape t in m_arrShape)
                {
                    t.Draw(hdc);
                }
            }

            if (flag)
            {
                if (m_Shape.ToString() == "CPolygon" && m_arrPoint != null)
                {
                    POINT[] t = new POINT[2];
                    t[0].x = m_arrPoint[0].x - distance;
                    t[0].y = m_arrPoint[0].y - distance;
                    t[1].x = m_arrPoint[0].x + distance;
                    t[1].y = m_arrPoint[0].y + distance;
                    CRectangle rec = new CRectangle(t[0], t[1]);                    
                    rec.SetDrawMode(GDI.R2_COPYPEN);
                    rec.Draw(hdc);

                    POINT[] t1 = new POINT[2];
                    t1[1] = m_arrPoint[0];
                    CLine line = new CLine();
                    line.SetDrawMode(GDI.R2_COPYPEN);
                    Gan(line);
                    for (int i = 1; i < m_arrPoint.Length; ++i)
                    {
                        // Ve duong thang
                        t1[0] = t1[1];
                        t1[1] = m_arrPoint[i];
                        line.SetPoints(t1);
                        line.Draw(hdc);
                        // Ve o vuong nho tai cac dinh
                        t[0].x = m_arrPoint[i].x - distance;
                        t[0].y = m_arrPoint[i].y - distance;
                        t[1].x = m_arrPoint[i].x + distance;
                        t[1].y = m_arrPoint[i].y + distance;
                        rec.SetPoints(t);
                        rec.Draw(hdc);
                    }

                    // Ve duong thang
                    t1[0] = t1[1];
                    t1[1] = m_End;
                    line.SetPoints(t1);
                    line.Draw(hdc);
                }
                else
                    m_Shape.Draw(hdc);
            }
                
            User.ReleaseDC(panel1.Handle, hdc);           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
            panel1.Hide();
            panel1.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && flag)
            {
                Xoa();
                flag = false;
            }            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Chi mo duoc OptionDialog khi chua ve
            if (!flag)
            {
                if (e.Alt && e.KeyCode == Keys.O)
                {
                    Options f = new Options();
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        tcmbPenStyle.Text = f.cmbStyle.Text;
                        tcmbWidth.Text = f.cmbWidth.Text;
                        m_R = byte.Parse(f.txtR.Text);
                        m_G = byte.Parse(f.txtG.Text);
                        m_B = byte.Parse(f.txtB.Text);
                        Gan(m_Shape);
                    }
                }
            }
        }
    }
}