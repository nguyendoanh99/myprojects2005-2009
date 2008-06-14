using System;
using System.Collections.Generic;
using System.Text;
using Win32;
using HDC = System.IntPtr;
namespace PaintLib
{
    public class CPolygon: CShape
    {
        private POINT[] m_arrPoint;

        public CPolygon()
        {
            m_arrPoint = null;
        }

        public CPolygon(CPolygon p)
        {
            SetPoints(p.m_arrPoint);
        }

        public CPolygon(POINT[] arrPoint)
        {
            SetPoints(arrPoint);
        }
        
        public override int Draw(HDC hdc)
        {
            IntPtr brush = (IntPtr)GDI.GetStockObject(GDI.NULL_BRUSH);
            GDI.SelectObject(hdc, brush);

            IntPtr hPen = (IntPtr)GDI.CreatePen(m_nPenStyle, m_nWidth, m_nColor);
            GDI.SelectObject(hdc, hPen);

            GDI.SetROP2(hdc, m_nDrawMode);            
            int kq = GDI.Polygon(hdc, ref m_arrPoint[0], m_arrPoint.Length);
            GDI.DeleteObject(hPen);
            return kq;
        }

        public override void SetPoints(POINT[] arrPoint)
        {            
            m_arrPoint = new POINT[arrPoint.Length];
            Array.Copy(arrPoint, m_arrPoint, arrPoint.Length);
        }

        public override string ToString()
        {
            return "CPolygon";
        }

        public override void GetPoints(ref POINT[] arrPoint)
        {
            arrPoint = new POINT[m_arrPoint.Length];
            Array.Copy(m_arrPoint, arrPoint, m_arrPoint.Length);
        }
    }
}
