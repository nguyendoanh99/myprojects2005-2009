using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using System.Drawing;
namespace testTAO
{
    class _Texture
    {
        #region Attributes
        private Boolean mEnable;
        private int[] mTexture = new int[1];			// Storage For One Texture ( NEW )
        #endregion
        #region Properties
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
        #region Constructor
        public _Texture()
        {
            Enable = false;
        }
        public _Texture(String strFile)
        {
            Enable = false;
            LoadTexture(strFile);
        }
        #endregion
        #region Public Function
        public Boolean LoadTexture(String strFile)
        {
            
            Gl.glGenTextures(1, mTexture);					// Create The Texture
            Bitmap b = null;
            try
            {
                b = new Bitmap(strFile);
            }
            catch (Exception e)
            {
                return false;
            }
            int hw = (b.Width > b.Height) ? b.Height : b.Width;

            for (int i = 0; true; ++i)
            {
                if (hw < Math.Pow(2, i))
                {
                    hw = (int)Math.Pow(2, i - 1);
                    break;
                }
            }
            // Typical Texture Generation Using Data From The Bitmap
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mTexture[0]);

            byte[] bit = new byte[hw * hw * 3];
            int index = 0;
            Color color;

            for (int i = 0; i < hw; ++i)
                for (int j = 0; j < hw; ++j)
                {
                    color = b.GetPixel(i, j);
                    bit[index++] = color.R;
                    bit[index++] = color.G;
                    bit[index++] = color.B;
                }
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 3, hw, hw, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, bit);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mTexture[0]);
            return true;
        }
        // Cho ap dung texture
        public void Apply()
        {
            if (Enable == true)
                Gl.glEnable(Gl.GL_TEXTURE_2D);
            else
                Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
        #endregion
    }
}
