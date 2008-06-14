using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Shadow
    {
        #region Attributes
        private float[] mShadowMat = new float[16]; // Ma tran bien doi ung voi nguon sang va mat dat
        private _Ground mGround; // tham chieu den mat dat
        private Boolean mEnable;
        #endregion
        #region Properties
        public float[] ShadowMatrix
        {
            get
            {
                return mShadowMat;
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
        #region Constructors
        public _Shadow(_Ground ground)
        {
            Enable = true;
            mGround = ground;
        }
        #endregion
        #region Public Function
        // Tinh ma tran bien doi ung voi LightSource moi
        public void CalculatorMatrix(_LightSource lightsource)
        {
            float[] temp = new float[3];
            temp[0] = lightsource.LightPos[0] - lightsource.SpotDir[0];
            temp[1] = lightsource.LightPos[1] - lightsource.SpotDir[1];
            temp[2] = lightsource.LightPos[2] - lightsource.SpotDir[2];
            _Math3D.MakePlanarShadowMatrix(mShadowMat, mGround.PlaneEquation, temp);
        }
        // Ve bong cua cac hinh khoi
        public void Draw(List<_ObjectOpenGL> lstObj)
        {
            if (Enable == false)
                return;
            Gl.glPushMatrix();
            // Save the lighting state variables
            Gl.glPushAttrib(Gl.GL_LIGHTING_BIT);
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_DEPTH_TEST);            

            // Multiply by shadow projection matrix
            Gl.glMultMatrixf(mShadowMat);
            int[] color;
            int[] black = new int[4] { 0, 0, 0, 1 };
            Boolean temp;
            for (int i = 0; i < lstObj.Count; ++i)
            {
                color = lstObj[i].Color;
                temp = lstObj[i].EnableTexture;
                lstObj[i].Color = black;
                lstObj[i].EnableTexture = false;
                lstObj[i].Draw();
                lstObj[i].Color = color;
                lstObj[i].EnableTexture = temp;
            }   
            
            // Restore lighting state variables
            Gl.glPopAttrib();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            // Restore the projection to normal
            Gl.glPopMatrix();
        }
        #endregion
    }
}
