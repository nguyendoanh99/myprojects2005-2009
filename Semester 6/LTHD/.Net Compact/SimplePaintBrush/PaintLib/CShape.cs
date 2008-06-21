using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace PaintLib
{
    public abstract class CShape
    {
        private int m_nDrawMode;
        private int m_nWidth;
        private int m_nPenStyle;
        private Color m_Color;
        private Color m_Fill;
        public abstract int Draw(Graphics g);
        public CShape()
        {
            m_nDrawMode = 0;
            m_nWidth = 0;
            m_nPenStyle = 0;
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
        public void SetColor(Color nColor)
        {
            m_Color = nColor;
        }
        public Color GetColor()
        {
            return m_Color;
        }
        #region Properties
        public int DrawMode
        {
            get
            {
                return GetDrawMode();
            }
            set
            {
                SetDrawMode(value);
            }
        }
        public int Width
        {
            get
            {
                return GetWidth();
            }
            set
            {
                SetWidth(value);
            }
        }
        public int PenStyle
        {
            get
            {
                return GetPenStyle();
            }
            set
            {
                SetPenStyle(value);
            }
        }
        public Color _Color
        {
            get
            {
                return GetColor();
            }
            set
            {
                SetColor(value);
            }
        }
        public Color Fill
        {
            get
            {
                return m_Fill;
            }
            set
            {
                m_Fill = value;
            }
        }
        #endregion
        public abstract void SetPoints(Point[] arrPoint);
        public abstract void GetPoints(ref Point[] arrPoint);
    }
}