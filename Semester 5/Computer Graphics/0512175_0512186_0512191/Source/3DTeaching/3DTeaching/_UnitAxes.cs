using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _UnitAxes
    {
        #region Attributes
        private float mRange; // Chieu dai cua cac truc
        private Boolean mEnable;
        #endregion
        #region Properties
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
        public _UnitAxes(float range)
        {
            Range = range;
            Enable = true;
        }
        #endregion
        public void Draw()
	    {
            if (Enable == false)
                return;

	        Glu.GLUquadric pObj;	// Temporary, used for quadrics
        	
	        // Measurements
	        float fAxisRadius = (float) (0.008 * Range);
            float fAxisHeight = (float)(0.95 * Range);
            float fArrowRadius = (float)(0.015 * Range);
            float fArrowHeight = (float)(0.03 * Range);

            Gl.glPushAttrib(Gl.GL_LIGHTING_BIT);
            Gl.glDisable(Gl.GL_LIGHTING);
	        // Setup the quadric object
	        pObj = Glu.gluNewQuadric();
            Glu.gluQuadricDrawStyle(pObj, Glu.GLU_FILL);
            Glu.gluQuadricNormals(pObj, Glu.GLU_SMOOTH);
            Glu.gluQuadricOrientation(pObj, Glu.GLU_OUTSIDE);
            Glu.gluQuadricTexture(pObj, Glu.GLU_FALSE);
        	
	        ///////////////////////////////////////////////////////
	        // Draw the blue Z axis first, with arrowed head
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Glu.gluCylinder(pObj, fAxisRadius, fAxisRadius, fAxisHeight, 10, 1);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, fAxisHeight);
            Glu.gluCylinder(pObj, fArrowRadius, 0.0f, fArrowHeight, 10, 1);
            Gl.glRotatef(180.0f, 1.0f, 0.0f, 0.0f);
            Glu.gluDisk(pObj, fAxisRadius, fArrowRadius, 10, 1);
            Gl.glPopMatrix();
        	
	        ///////////////////////////////////////////////////////
	        // Draw the Red X axis 2nd, with arrowed head
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glPushMatrix();
            Gl.glRotatef(90.0f, 0.0f, 1.0f, 0.0f);
            Glu.gluCylinder(pObj, fAxisRadius, fAxisRadius, fAxisHeight, 10, 1);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, fAxisHeight);
            Glu.gluCylinder(pObj, fArrowRadius, 0.0f, fArrowHeight, 10, 1);
            Gl.glRotatef(180.0f, 0.0f, 1.0f, 0.0f);
            Glu.gluDisk(pObj, fAxisRadius, fArrowRadius, 10, 1);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        	
	        ///////////////////////////////////////////////////////
	        // Draw the Green Y axis 3rd, with arrowed head
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glPushMatrix();
            Gl.glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
            Glu.gluCylinder(pObj, fAxisRadius, fAxisRadius, fAxisHeight, 10, 1);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, fAxisHeight);
            Glu.gluCylinder(pObj, fArrowRadius, 0.0f, fArrowHeight, 10, 1);
            Gl.glRotatef(180.0f, 1.0f, 0.0f, 0.0f);
            Glu.gluDisk(pObj, fAxisRadius, fArrowRadius, 10, 1);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        	
	        ////////////////////////////////////////////////////////
	        // White Sphere at origin
            Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Glu.gluSphere(pObj, 1.5, 15, 15);
        	
	        // Delete the quadric
            Glu.gluDeleteQuadric(pObj);
            Gl.glPopAttrib();
	    }
    }
}
