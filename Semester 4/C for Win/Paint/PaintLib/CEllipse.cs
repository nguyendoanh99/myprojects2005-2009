using System;
using System.Collections.Generic;
using System.Text;
using Win32;
using HDC = System.IntPtr;
namespace PaintLib
{
    public class CEllipse : CShape
    {
        private POINT m_Start;
        private POINT m_End;

        public CEllipse()
        {            
        }

        public CEllipse(CEllipse p)
        {
            m_Start = new POINT();
            m_End = new POINT();
            m_Start = p.m_Start;
            m_End = p.m_End;
        }

        public CEllipse(POINT start, POINT end)
        {
            m_Start = new POINT();
            m_End = new POINT();
            m_Start = start;
            m_End = end;
        }

        public CEllipse(int x1, int y1, int x2, int y2)
        {
            m_Start = new POINT();
            m_End = new POINT();
            m_Start.x = x1;
            m_Start.y = y1;
            m_End.x = x2;
            m_End.y = y2;
        }

        public override int Draw(HDC hdc)
        {
            IntPtr brush = (IntPtr)GDI.GetStockObject(GDI.NULL_BRUSH);
            GDI.SelectObject(hdc, brush);

            IntPtr hPen = (IntPtr)GDI.CreatePen(m_nPenStyle, m_nWidth, m_nColor);
            GDI.SelectObject(hdc, hPen);

            GDI.SetROP2(hdc, m_nDrawMode);
            int kq = GDI.Ellipse(hdc, m_Start.x, m_Start.y, m_End.x, m_End.y);
            GDI.DeleteObject(hPen);
            return kq;
        }

        public override void SetPoints(POINT[] arrPoint)
        {
            m_Start = new POINT();
            m_End = new POINT();
            m_Start = arrPoint[0];
            m_End = arrPoint[1];
        }

        public override string ToString()
        {
            return "CEllipse";
        }

        public override void GetPoints(ref POINT[] arrPoint)
        {
            arrPoint = new POINT[2];
            arrPoint[0] = m_Start;
            arrPoint[1] = m_End;
        }
    }
}
