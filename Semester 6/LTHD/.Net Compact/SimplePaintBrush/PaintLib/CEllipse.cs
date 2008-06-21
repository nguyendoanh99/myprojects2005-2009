using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace PaintLib
{
    public class CEllipse : CShape
    {
        private Point m_Start;
        private Point m_End;

        public CEllipse()
        {            
        }

        public CEllipse(CEllipse p)
        {
            m_Start = new Point();
            m_End = new Point();
            m_Start = p.m_Start;
            m_End = p.m_End;
        }

        public CEllipse(Point start, Point end)
        {
            m_Start = new Point();
            m_End = new Point();
            m_Start = start;
            m_End = end;
        }

        public CEllipse(int x1, int y1, int x2, int y2)
        {
            m_Start = new Point();
            m_End = new Point();
            m_Start.X = x1;
            m_Start.Y = y1;
            m_End.X = x2;
            m_End.Y = y2;
        }

        public override int Draw(Graphics g)
        {
            /*
            IntPtr brush = (IntPtr)GDI.GetStockObject(GDI.NULL_BRUSH);
            GDI.SelectObject(hdc, brush);

            IntPtr hPen = (IntPtr)GDI.CreatePen(m_nPenStyle, m_nWidth, m_nColor);
            GDI.SelectObject(hdc, hPen);
            
            GDI.SetROP2(hdc, m_nDrawMode);
             */
            Pen pen = new Pen(_Color);
            SolidBrush sb = new SolidBrush(Fill);
            int width = m_End.X - m_Start.X;
            int height = m_End.Y - m_Start.Y;            
            g.FillEllipse(sb, m_Start.X, m_Start.Y, width, height);
            g.DrawEllipse(pen, m_Start.X, m_Start.Y, width, height);
//            GDI.DeleteObject(hPen);
            pen.Dispose();
            sb.Dispose();
            return 1;
        }

        public override void SetPoints(Point[] arrPoint)
        {
            m_Start = new Point();
            m_End = new Point();
            m_Start = arrPoint[0];
            m_End = arrPoint[1];
        }

        public override string ToString()
        {
            return "CEllipse";
        }

        public override void GetPoints(ref Point[] arrPoint)
        {
            arrPoint = new Point[2];
            arrPoint[0] = m_Start;
            arrPoint[1] = m_End;
        }
    }
}
