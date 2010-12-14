using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PaintLib;
namespace SimplePainBrush
{
    public partial class Form1 : Form
    {
        private Color m_Color;
        private Color m_Fill;
        private Point m_Start;
        private Point m_End;
        private bool flag; // Cho biet dang ve hinh
        private CShape m_Shape;
        private List<CShape> m_arrShape = new List<CShape>();
        public String ColorToString(Color c)
        {
            String s = "";
            s += String.Format("{0:X}", c.R).PadLeft(2, '0');
            s += String.Format("{0:X}", c.G).PadLeft(2, '0');
            s += String.Format("{0:X}", c.B).PadLeft(2, '0');
            return s;
        }
        Bitmap bmpNew = null;
        public Form1()
        {
            InitializeComponent();
            m_Start = new Point();
            m_End = new Point();
            m_Shape = new CLine();            
            flag = false;            
            toolBar1.Buttons[0].Pushed = true;
            m_Color = Color.Black;
            m_Fill = Color.White;
            mnuColor.Text = "Color(" + ColorToString(m_Color) + ")";
            mnuFill.Text = "Fill(" + ColorToString(m_Fill) + ")";

            CreateBitmap();
        }

        private void CreateBitmap()
        {
            // Create a bitmap and a Graphics object for the bitmap.
            bmpNew = new Bitmap(500, 500);
            Graphics gbmp = Graphics.FromImage(bmpNew);

            //Clear the bitmap background.
            gbmp.Clear(Color.LightGray);

            // Get a Graphics object for the form.
            Graphics g = CreateGraphics();

            // Copy the bitmap to the window at (x,y) location.
            g.DrawImage(bmpNew, 0, 0);

            // Clean up when we are done.
            g.Dispose();
            gbmp.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmpNew, 0, 0);
//             foreach (CShape t in m_arrShape)
//             {
//                 t.Draw(e.Graphics);
//             }        
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            m_End.X = e.X;
            m_End.Y = e.Y;                
            flag = !flag;
            if (flag) // bat dau ve
            {                
                m_Start.X = e.X;
                m_Start.Y = e.Y;                
            }
            else
            {
                // Chuyen toa do 2 diem thanh mang cac diem
                Point[] T = new Point[2];
                T[0] = m_Start;
                T[1] = m_End;                
                
                // Them tham so cho hinh can ve
                m_Shape.SetPoints(T);
                m_Shape._Color = m_Color;
                m_Shape.Fill = m_Fill;

                // Ve
                Graphics grImage = Graphics.FromImage(bmpNew);
                Graphics gr = this.CreateGraphics();
                m_Shape.Draw(gr); // ve len man hinh
                m_Shape.Draw(grImage); // ve len anh (trong vung nho)
                gr.Dispose();
                grImage.Dispose();
                
                // Them hinh vao tap hop
                m_arrShape.Add(m_Shape);
                
                switch (m_Shape.ToString())
                {
                    case "CLine":
                        m_Shape = new CLine();
                        break;
                    case "CEllipse":
                        m_Shape = new CEllipse();
                        break;                    
                }
            }           
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            foreach (ToolBarButton tbb in toolBar1.Buttons)
            {
                if (tbb == e.Button)
                    tbb.Pushed = true;
                else
                    tbb.Pushed = false;
            }

            if (e.Button.ImageIndex == 1) // Line
            {
                if (m_Shape is CLine)
                    return;

                m_Shape = new CLine();
            }
            else
            {
                if (m_Shape is CEllipse)
                    return;

                m_Shape = new CEllipse();
            }

        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            ChooseColorDlg ccdlg = new ChooseColorDlg();
            ccdlg.Init(this);
            if (ccdlg.ShowDialog(ref m_Color))
            {
                Invalidate();
                mnuColor.Text = "Color(" + ColorToString(m_Color) + ")";
            }                   
        }

        private void mnuFill_Click(object sender, EventArgs e)
        {
            ChooseColorDlg ccdlg = new ChooseColorDlg();
            ccdlg.Init(this);
            if (ccdlg.ShowDialog(ref m_Fill))
            {
                Invalidate();                
                mnuFill.Text = "Fill(" + ColorToString(m_Fill) + ")";
            }    
        }            
    }
}