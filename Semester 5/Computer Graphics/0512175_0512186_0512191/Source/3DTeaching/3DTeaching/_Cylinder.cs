using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Cylinder : _ObjectOpenGL
    {
        #region Khai bao thuoc tinh
        double mBase;
        double mHeight;
        int mSlices;
        int mStacks;
        Glu.GLUquadric mQuadricCylinder;
        Glu.GLUquadric mQuadricDisk1;
        Glu.GLUquadric mQuadricDisk2;
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
        protected Glu.GLUquadric QuadricCylinder
        {
            get
            {
                return mQuadricCylinder;
            }
        }
        protected Glu.GLUquadric QuandricDisk1
        {
            get
            {
                return mQuadricDisk1;
            }
        }
        protected Glu.GLUquadric QuandricDisk2
        {
            get
            {
                return mQuadricDisk2;
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
            mQuadricCylinder = Glu.gluNewQuadric();
            mQuadricDisk1 = Glu.gluNewQuadric();
            mQuadricDisk2 = Glu.gluNewQuadric();
            Glu.gluQuadricOrientation(mQuadricDisk1, Glu.GLU_INSIDE);
        }
        #endregion
        #region Khai bao Ham Tao
            public _Cylinder(double Base, double Height, int Slices, int Stacks)
                : base()
            {
                Init(Base, Height, Slices, Stacks);
            }
            public _Cylinder(float x, float y, float z, double Base, double Height, int Slices, int Stacks)
                : base(x, y, z)
            {
                Init(Base, Height, Slices, Stacks);
            }
        ~_Cylinder()
            {
                Glu.gluDeleteQuadric(mQuadricCylinder);
                Glu.gluDeleteQuadric(mQuadricDisk1);
                Glu.gluDeleteQuadric(mQuadricDisk2);
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

                Glu.gluQuadricTexture(mQuadricCylinder, texture);
                Glu.gluQuadricTexture(mQuadricDisk1, texture);
                Glu.gluQuadricTexture(mQuadricDisk2, texture);
                
                Glu.gluCylinder(mQuadricCylinder, mBase, mBase, mHeight, mSlices, mStacks);
                Glu.gluDisk(mQuadricDisk1, 0, mBase, mSlices, mStacks);
                Gl.glTranslatef(0.0f, 0.0f, (float) mHeight);
                Glu.gluDisk(mQuadricDisk2, 0, mBase, mSlices, mStacks);
                Gl.glPopMatrix();
            }
        #endregion
    }
}
