using System;
using System.Collections.Generic;
using System.Text;
using Win32;
using HDC = System.IntPtr;
namespace PaintLib
{
    public abstract class CShape
    {
        protected int m_nDrawMode;
        protected int m_nWidth;
        protected int m_nPenStyle;
        protected int m_nColor;
        public abstract int Draw(HDC hdc);
        public CShape()
        {
            m_nDrawMode = GDI.R2_COPYPEN;
            m_nWidth = 0;
            m_nPenStyle = GDI.PS_SOLID;
        }
        public void SetDrawMode(int nDrawMode)
        {
            m_nDrawMode = nDrawMode;
        }
        public int GetDrawMode()
        {
            return m_nDrawMode;
        }
        public void SetWidth(int nWidth)
        {
            m_nWidth = nWidth;           
        }
        public int GetWidth()
        {
            return m_nWidth;
        }
        public void SetPenStyle(int nPenStyle)
        {
            m_nPenStyle = nPenStyle;
        }
        public int GetPenStyle()
        {
            return m_nPenStyle;
        }
        public void SetColor(int nColor)
        {
            m_nColor = nColor;
        }
        public int GetColor()
        {
            return m_nColor;
        }
        public abstract void SetPoints(POINT[] arrPoint);
        public abstract void GetPoints(ref POINT[] arrPoint);
    }
}