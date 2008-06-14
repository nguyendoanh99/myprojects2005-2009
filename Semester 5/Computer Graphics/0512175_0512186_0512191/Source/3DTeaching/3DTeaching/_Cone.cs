using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Cone : _ObjectOpenGL
    {
        #region Khai bao thuoc tinh
        double mBase;
        double mHeight;
        int mSlices;
        int mStacks;
        Glu.GLUquadric mQuadricCone;
        Glu.GLUquadric mQuadricDisk;
        #endregion
        #region Khai bao property
        public double Base
        {
            get
            {
                return mBase;
            }
            set
            {
                mBase = value;
            }
        }
        public double Height
        {
            get
            {
                return mHeight;
            }
            set
            {
                mHeight = value;
            }
        }
        public int Slices
        {
            get
            {
                return mSlices;
            }
            set
            {
                mSlices = value;
            }
        }
        public int Stacks
        {
            get 
            {
                return mStacks;
            }
            set
            {
                mStacks = value;
            }
        }
        protected Glu.GLUquadric QuadricCone
        {
            get
            {
                return mQuadricCone;
            }
        }
        protected Glu.GLUquadric QuandricDisk
        {
            get
            {
                return mQuadricDisk;
            }
        }
        #endregion
        #region Khai bao ham rieng
        private void Init(double Base, double Height, int Slices, int Stacks)
        {
            mBase = Base;
            mHeight = Height;
            mSlices = Slices;
            mStacks = Stacks;
            mQuadricCone = Glu.gluNewQuadric();
            mQuadricDisk = Glu.gluNewQuadric();
            Glu.gluQuadricOrientation(mQuadricDisk, Glu.GLU_INSIDE);
        }
        #endregion
        #region Khai bao Ham Tao
            public _Cone(double Base, double Height, int Slices, int Stacks)
                : base()
            {
                Init(Base, Height, Slices, Stacks);
            }
            public _Cone(float x, float y, float z, double Base, double Height, int Slices, int Stacks)
                : base(x, y, z)
            {
                Init(Base, Height, Slices, Stacks);
            }
            ~_Cone()
            {
                Glu.gluDeleteQuadric(mQuadricCone);
                Glu.gluDeleteQuadric(mQuadricDisk);
            }
        #endregion
        #region Khai bao phuong thuc
            // Ham ve
            public override void Draw()
            {
                if (Enable == false)
                    return;

                base.Draw();
                Gl.glPushMatrix();
                Gl.glMultMatrixf(base.Matrix);
                Gl.glRotatef(-90, 1, 0, 0);
                int texture;
                if (EnableTexture == true)
                {
                    texture = Gl.GL_TRUE;
                    Gl.glColor3b(127, 127, 127);
                }
                else
                {                    
                    texture = Gl.GL_FALSE;
                }

                Glu.gluQuadricTexture(mQuadricCone, texture);
                Glu.gluQuadricTexture(mQuadricDisk, texture);
                
                Glu.gluCylinder(mQuadricCone, mBase, 0, mHeight, mSlices, mStacks);
                Glu.gluDisk(mQuadricDisk, 0, mBase, mSlices, mStacks);
                Gl.glPopMatrix();
            }
        #endregion
        }
}
