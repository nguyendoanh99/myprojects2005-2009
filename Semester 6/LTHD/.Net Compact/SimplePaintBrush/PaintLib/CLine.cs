using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace PaintLib
{
    public class CLine : CShape
    {
        private Point m_Start;
        private Point m_End;

        public CLine()
        {            
        }

        public CLine(Point start, Point end)
        {
            m_Start = new Point();
            m_End = new Point();
            m_Start = start;
            m_End = end;
        }

        public CLine(CLine p)
        {
            m_Start = new Point();
            m_End = new Point();
            m_Start = p.m_Start;
            m_End = p.m_End;
        }
        public CLine(int x1, int y1, int x2, int y2)
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
            GDI.SetROP2(hdc, m_nDrawMode);
            Point p = new Point();
            GDI.MoveToEx(hdc, m_Start.x, m_Start.y, ref p);

            IntPtr hPen = (IntPtr)GDI.CreatePen(m_nPenStyle, m_nWidth, m_nColor);
            GDI.SelectObject(hdc, hPen);

            int kq = GDI.LineTo(hdc, m_End.x, m_End.y);
            GDI.DeleteObject(hPen);
             */
            Pen pen = new Pen(_Color);
            g.DrawLine(pen, m_Start.X, m_Start.Y, m_End.X, m_End.Y);
            pen.Dispose();
            return 1;
        }

        public override void SetPoints(Point[] arrPoint)
        {
            m_Start = new Point();
            m_End = new Point();
            m_Start = arrPoint[0];
            m_End = arrPoint[1];
        }

        public override void GetPoints(ref Point[] arrPoint)
        {
            arrPoint = new Point[2];
            arrPoint[0] = m_Start;
            arrPoint[1] = m_End;
        }

        public override string ToString()
        {
            return "CLine";
        }
    }
}
