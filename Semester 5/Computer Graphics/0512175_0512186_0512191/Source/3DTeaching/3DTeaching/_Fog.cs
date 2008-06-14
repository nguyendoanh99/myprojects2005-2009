using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Fog
    {
        #region Attributes
        private int[] mColor; // mau cua suong mu
        private float mStart; // diem bat dau cua suong mu
        private float mEnd; // diem ket thuc cua suong mu
        private int mDensity; // Do day dac cua suong mu
        private Boolean mEnable; // Bat/ tat che do suong mu
        #endregion
        #region Properties
        public int Red
        {
            get
            {
                return mColor[0];
            }
            set
            {
                mColor[0] = value;
            }
        }
        public int Green
        {
            get
            {
                return mColor[1];
            }
            set
            {
                mColor[1] = value;
            }
        }
        public int Blue
        {
            get
            {
                return mColor[2];
            }
            set
            {
                mColor[2] = value;
            }
        }
        public int Alpha
        {
            get
            {
                return mColor[3];
            }
            set
            {
                mColor[3] = value;
            }
        }
        public int[] Color
        {
            get
            {
                return mColor;
            }
            set
            {
                mColor = value;
            }
        }
        public int Density
        {
            get
            {
                return mDensity;
            }
            set
            {
                mDensity = value;
            }
        }
        public float Start
        {
            get
            {
                return mStart;
            }
            set
            {
                mStart = value;
            }
        }
        public float End 
        {
            get
            {
                return mEnd;
            }
            set
            {
                mEnd = value;
            }
        }
        public Boolean Enable
        {
            get
            {
                return mEnable;
            }
            set
            {
                mEnable = value;
            }
        }
        #endregion
        #region Private Fuction
        private void Init(int[] color, float start, float end, int density)
        {
            this.Color = color;
            this.Start = start;
            this.End = end;
            this.Density = density;
            this.Enable = true;
        }
        #endregion
        #region Constructors
        public _Fog()
        {
            Init(new int[4] { 25, 25, 25, 100 }, 10, 100, 50);
        }
        public _Fog(float start, float end)
        {
            Init(new int[4] { 25, 25, 25, 100 }, start, end, 50);
        }
        public _Fog(int[] color, float start, float end, int density)
        {
            Init(color, start, end, density);
        }
        #endregion
        #region Public  Function
        public void Apply()
        {
            if (Enable == true)
            {
                float[] tempColor = new float[4];
                tempColor[0] = mColor[0] / 255.0f;
                tempColor[1] = mColor[1] / 255.0f;
                tempColor[2] = mColor[2] / 255.0f;
                tempColor[3] = mColor[3] / 100.0f;
                Gl.glEnable(Gl.GL_FOG);
                Gl.glFogfv(Gl.GL_FOG_COLOR, tempColor);   // Set fog color to match background
                Gl.glFogf(Gl.GL_FOG_START, Start);         // How far away does the fog start
                Gl.glFogf(Gl.GL_FOG_END, End);          // How far away does the fog stop
                Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_LINEAR);     // Which fog equation do I use?
                Gl.glFogf(Gl.GL_FOG_DENSITY, Density / 100.0f);
            }
            else
            {
                Gl.glDisable(Gl.GL_FOG);
            }
        }
        #endregion
    }
}
