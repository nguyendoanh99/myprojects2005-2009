using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Sphere : _ObjectOpenGL
    {
        #region Khai bao thuoc tinh
        double mBase;
        double mHeight;
        int mSlices;
        int mStacks;
        Glu.GLUquadric mQuadric;
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
        protected Glu.GLUquadric Quadric
        {
            get
            {
                return mQuadric;
            }
        }
        #endregion
        #region Khai bao ham rieng
        private void Init(double Base, int Slices, int Stacks)
        {
            mBase = Base;
            mSlices = Slices;
            mStacks = Stacks;
            mQuadric = Glu.gluNewQuadric();
            //Glu.gluQuadricOrientation(mQuadricDisk, Glu.GLU_INSIDE);
        }
        #endregion
        #region Khai bao Ham Tao
            public _Sphere(double Base, double Height, int Slices, int Stacks)
                : base()
            {
                Init(Base, Slices, Stacks);
            }
            public _Sphere(float x, float y, float z, double Base, int Slices, int Stacks)
                : base(x, y, z)
            {
                Init(Base, Slices, Stacks);
            }
            ~_Sphere()
            {
                Glu.gluDeleteQuadric(mQuadric);
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

                Glu.gluQuadricTexture(mQuadric, texture);
                Glu.gluSphere(mQuadric, mBase, mSlices, mStacks);
                Gl.glPopMatrix();
            }
        #endregion
    }
}
