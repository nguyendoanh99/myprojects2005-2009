using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Cubic : _ObjectOpenGL
    {
        #region Khai bao thuoc tinh
        double mSide; // Chieu dai cua mot canh
        #endregion
        #region Khai bao property
        public double Side
        {
            get
            {
                return mSide;
            }
            set
            {
                mSide = value;
            }
        }
        #endregion
        #region Khai bao ham rieng
        private void Init(double Side)
        {
            mSide = Side;
        }
        #endregion
        #region Khai bao Ham Tao
            public _Cubic(double Side)
                : base()
            {
                Init(Side);
            }
            public _Cubic(float x, float y, float z, double Side)
                : base(x, y, z)
            {
                Init(Side);
            }
        #endregion
        #region Khai bao phuong thuc
            // Ham ve
            public override void Draw()
            {
                if (Enable == false)
                    return;

                float temp = (float)(mSide / 2);
                base.Draw();
                Gl.glPushMatrix();
                Gl.glMultMatrixf(base.Matrix);

                int texture;
                if (EnableTexture == true)
                {
                    texture = Gl.GL_TRUE;
                    Gl.glColor3b(127, 127, 127);
                    #region Ve hinh hop, co texture
                    Gl.glBegin(Gl.GL_QUADS);
                    // Front Face
                    Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                    Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-temp, -temp, temp);
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(temp, -temp, temp);
                    Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(temp, temp, temp);
                    Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-temp, temp, temp);
                    // Back Face
                    Gl.glNormal3f(0.0f, 0.0f, -1.0f);
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-temp, -temp, -temp);
                    Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-temp, temp, -temp);
                    Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(temp, temp, -temp);
                    Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(temp, -temp, -temp);
                    // Top Face
                    Gl.glNormal3f(0.0f, 1.0f, 0.0f);
                    Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-temp, temp, -temp);
                    Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-temp, temp, temp);
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(temp, temp, temp);
                    Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(temp, temp, -temp);
                    // Bottom Face
                    Gl.glNormal3f(0.0f, -1.0f, 0.0f);
                    Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-temp, -temp, -temp);
                    Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(temp, -temp, -temp);
                    Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(temp, -temp, temp);
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-temp, -temp, temp);
                    // Right face
                    Gl.glNormal3f(1.0f, 0.0f, 0.0f);
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(temp, -temp, -temp);
                    Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(temp, temp, -temp);
                    Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(temp, temp, temp);
                    Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(temp, -temp, temp);
                    // Left Face
                    Gl.glNormal3f(-1.0f, 0.0f, 0.0f);
                    Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-temp, -temp, -temp);
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-temp, -temp, temp);
                    Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-temp, temp, temp);
                    Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-temp, temp, -temp);
                    Gl.glEnd();
                }
                else
                {
                    texture = Gl.GL_FALSE;
                    #region Ve hinh hop, khong co texture
                    Gl.glBegin(Gl.GL_QUADS);
                    // Front Face
                    Gl.glNormal3f(0.0f, 0.0f, 1.0f);
                    Gl.glVertex3f(-temp, -temp, temp);
                    Gl.glVertex3f(temp, -temp, temp);
                    Gl.glVertex3f(temp, temp, temp);
                    Gl.glVertex3f(-temp, temp, temp);
                    // Back Face
                    Gl.glNormal3f(0.0f, 0.0f, -1.0f);
                    Gl.glVertex3f(-temp, -temp, -temp);
                    Gl.glVertex3f(-temp, temp, -temp);
                    Gl.glVertex3f(temp, temp, -temp);
                    Gl.glVertex3f(temp, -temp, -temp);
                    // Top Face
                    Gl.glNormal3f(0.0f, 1.0f, 0.0f);
                    Gl.glVertex3f(-temp, temp, -temp);
                    Gl.glVertex3f(-temp, temp, temp);
                    Gl.glVertex3f(temp, temp, temp);
                    Gl.glVertex3f(temp, temp, -temp);
                    // Bottom Face
                    Gl.glNormal3f(0.0f, -1.0f, 0.0f);
                    Gl.glVertex3f(-temp, -temp, -temp);
                    Gl.glVertex3f(temp, -temp, -temp);
                    Gl.glVertex3f(temp, -temp, temp);
                    Gl.glVertex3f(-temp, -temp, temp);
                    // Right face
                    Gl.glNormal3f(1.0f, 0.0f, 0.0f);
                    Gl.glVertex3f(temp, -temp, -temp);
                    Gl.glVertex3f(temp, temp, -temp);
                    Gl.glVertex3f(temp, temp, temp);
                    Gl.glVertex3f(temp, -temp, temp);
                    // Left Face
                    Gl.glNormal3f(-1.0f, 0.0f, 0.0f);
                    Gl.glVertex3f(-temp, -temp, -temp);
                    Gl.glVertex3f(-temp, -temp, temp);
                    Gl.glVertex3f(-temp, temp, temp);
                    Gl.glVertex3f(-temp, temp, -temp);
                    Gl.glEnd();
                    #endregion

                    #endregion
                }

                
                
                Gl.glPopMatrix();
            }
        #endregion
    }
}
