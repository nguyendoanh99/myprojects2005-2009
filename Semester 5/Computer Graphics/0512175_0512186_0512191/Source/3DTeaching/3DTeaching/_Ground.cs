using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Ground
    {
        #region Attributes
        private float[] mvPlaneEquation = new float[4]; // Phuong trinh mat phang cua mat dat
        private float mRange;
        private Boolean mEnable;
        #endregion
        #region Properties
        public float[] PlaneEquation
        {
            get
            {
                return mvPlaneEquation;
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
        public float Range
        {
            get
            {
                return mRange;
            }
            set
            {
                mRange = value;
            }
        }
        #endregion
        #region Constructor
        public _Ground(float range)
        {
            Range = range;
            Enable = true;
            // Any three points on the ground (counter clockwise order)
            float[][] points = new float[3][];
            points[0] = new float[3] { 0, 0, 0 };
            points[1] = new float[3] { -10, 0, 0 };
            points[2] = new float[3] { 20, 0, 10 };
            _Math3D.GetPlaneEquation(mvPlaneEquation, points[0], points[1], points[2]);
        }
        #endregion
        #region Public Function
        public void Draw()
        {
            if (Enable == false)
                return;
            // Draw the ground, we do manual shading to a darker green
            // in the background to give the illusion of depth
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3ub(0, 32, 0);
            Gl.glVertex3f(Range, 0.0f, -Range);
            Gl.glVertex3f(-Range, 0.0f, -Range);
            Gl.glColor3ub(0, 255, 0);
            Gl.glVertex3f(-Range, 0.0f, Range);
            Gl.glVertex3f(Range, 0.0f, Range);
            Gl.glEnd();
        }
        #endregion
    }
}
