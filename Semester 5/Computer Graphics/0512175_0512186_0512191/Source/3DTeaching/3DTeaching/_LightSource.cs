using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _LightSource : _ObjectOpenGL
    {
        #region Khai bao thuoc tinh
        private float[] mLightPos; // Vi tri cua nguon sang
        private float[]  mSpotDir; // Huong anh sang
        private float mSpotCutOff;
        // Anh sang phan xa cua nguon sang chinh la mau cua nguon sang
        private float[]  mAmbientLight; // Anh sang xung quanh
        private int mIndex; // Cho biet nguon sang nao
        private Glu.GLUquadric mQuadricCone;
        private Glu.GLUquadric mQuadricSphere;
        #endregion
        #region Khai bao property
        public float[] LightPos
        {
            get
            {
                return mLightPos;
            }
            set
            {

                _Math3D.CopyMatrix(mLightPos, value);
                ChangeMatrix();
            }
        }
        public float[] SpotDir
        {
            get
            {
                return mSpotDir;
            }
            set
            {                
                _Math3D.CopyMatrix(mSpotDir, value);
                ChangeMatrix();                
            }
        }
        public float[] SpecularLight
        {
            get 
            {
                return new float[3] { (float) Red / 255, (float) Green / 255, (float) Blue / 255};
            }
            set
            {
                Red = (int) (value[0] * 255);
                Green = (int) (value[1] * 255);
                Blue = (int) (value[2] * 255);
            }
        }
        public float[] AmbientLight
        {
            get
            {
                return mAmbientLight;
            }
            set
            {
                _Math3D.CopyMatrix(mAmbientLight, value);
            }
        }
        public int Index
        {
            get
            {
                return mIndex;
            }
            set 
            {
                switch (value)
                {
                    case 0:
                        mIndex = Gl.GL_LIGHT0;
                        break;
                    case 1:
                        mIndex = Gl.GL_LIGHT1;
                        break;
                    case 2:
                        mIndex = Gl.GL_LIGHT2;
                        break;
                    case 3:
                        mIndex = Gl.GL_LIGHT3;
                        break;
                    case 4:
                        mIndex = Gl.GL_LIGHT4;
                        break;
                    case 5:
                        mIndex = Gl.GL_LIGHT5;
                        break;
                    case 6:
                        mIndex = Gl.GL_LIGHT6;
                        break;
                    case 7:
                        mIndex = Gl.GL_LIGHT7;
                        break;
                    default:
                        mIndex = Gl.GL_LIGHT0;
                        break;
                }
            }
        }
        public float SpotCutOff
        {
            get
            {
                return mSpotCutOff;
            }
            set
            {
                mSpotCutOff = value;
            }
        }
        protected Glu.GLUquadric QuadricCone
        {
            get
            {
                return mQuadricCone;
            }
        }
        protected Glu.GLUquadric QuandricSphere
        {
            get
            {
                return mQuadricSphere;
            }
        }
        
        #endregion
        #region Khai bao ham rieng
        private void Init(int index, Boolean enable, float[] lightpos,float[] spotdir, float spotcutoff,float[] specularlight, float[] ambientlight)
        {
            
            mLightPos = new float[3];
            mSpotDir = new float[3];                
            mAmbientLight = new float[4];
            SpotCutOff = spotcutoff;
            Index = index;
            mLightPos = lightpos;
            mSpotDir = spotdir;
            ChangeMatrix();
            SpecularLight = specularlight;
            AmbientLight = ambientlight;
            mQuadricCone = Glu.gluNewQuadric();
            mQuadricSphere = Glu.gluNewQuadric();
            Enable = enable;
        }
        private void ChangeMatrix()
        {
            _Vector3D pBegin = new _Vector3D(LightPos);
            _Vector3D pEnd = new _Vector3D(SpotDir);
            // Di chuyen hinh den vi tri tuong ung
            Center[0] = 0;
            Center[1] = 0;
            Center[2] = 0;
            _Affine Iden = new _Affine();
            Iden.Identity();
            Matrix = (float[])Iden;
            _Vector3D v1 = new _Vector3D(0, 0, 1);
            _Vector3D v2 = pEnd - pBegin;
            _Vector3D Normal = _Math3D.FindNormalVector(v1, v2);
            double rad = _Math3D.GetAngleBetweenVectors(v1, v2);
            if (Normal.x != 0 || Normal.y != 0 || Normal.z != 0)
                base.Rotate((float)(rad * 180 / Math.PI), Normal.x, Normal.y, Normal.z);
            base.Translate(pBegin.x - Center[0], pBegin.y - Center[1], pBegin.z - Center[2]);
        }
        #endregion
        #region Khai bao Ham Tao
        public _LightSource(int index)
            : base()
        {
            float[] lightpos = new float[3] { 50, 50, 10 };
            float[] spotdir = new float[3] { 0, 0, 0 };
            float[] ambient = new float[4] { 0.5f, 0.5f, 0.5f, 1 };
            float[] specular = new float[4] { 1, 1, 1, 1 };
            float spotcutoff = 10;
            Init(index, true, lightpos, spotdir, spotcutoff, specular, ambient);
        }
        public _LightSource(int x, int y, int z, int index, float[] spotdir, float spotcutff, float[] specularlight, float[] ambientlight)
            : base()
        {
            float[] lightpos = new float[3] { x, y, z };
            Init(index, true, lightpos, spotdir, spotcutff, specularlight, ambientlight);
        }
        ~_LightSource()
        {
            Glu.gluDeleteQuadric(mQuadricCone);
            Glu.gluDeleteQuadric(mQuadricSphere);
        }
        #endregion
        #region Khai bao phuong thuc            
            // Ham ve
        public override void Draw()
        {
            if (Enable == false)
            {
                Gl.glDisable(mIndex);
                return;
            }
            
            Gl.glEnable(mIndex);
            Gl.glLightfv(mIndex, Gl.GL_POSITION, mLightPos);            
            Gl.glLightfv(mIndex, Gl.GL_DIFFUSE, AmbientLight);
            Gl.glLightfv(mIndex, Gl.GL_SPECULAR, SpecularLight);
//            Gl.glLightf(mIndex, Gl.GL_SPOT_CUTOFF, SpotCutOff);

            Gl.glPushMatrix();
            Gl.glMultMatrixf(base.Matrix);
            Gl.glLightfv(mIndex, Gl.GL_SPOT_DIRECTION, SpotDir);

            // Mau cua bong den la mau cua nguon sang
            Gl.glColor3ub(255, 0, 0);
            Gl.glRotatef(180, 1, 0, 0);
            Glu.gluCylinder(mQuadricCone, 4.0, 0, 6.0, 15, 15);
            // Draw a smaller displaced sphere to denote the light bulb
            // Save the lighting state variables
            Gl.glPushAttrib(Gl.GL_LIGHTING_BIT);
            // Turn off lighting and specify a bright yellow sphere
            Gl.glDisable(Gl.GL_LIGHTING);
            base.Draw();                
            Glu.gluSphere(mQuadricSphere, 3.0, 15, 15);
            // Restore lighting state variables
            Gl.glPopAttrib();
            
            Gl.glPopMatrix();
        }
        public override void Rotate(float Angle, float Ox, float Oy, float Oz)
        {
            float[] p1 = LightPos;
            _Affine rot = new _Affine();
            rot.Rotate(Angle, Ox, Oy, Oz);
            p1 = rot.ConvertPoint(p1);
            _Math3D.CopyMatrix(LightPos, p1);
            ChangeMatrix();
        }
        public override void Rotate(float Angle, _Vector3D v)
        {
            Rotate(Angle, v.x, v.y, v.z);
        }
        public override void Rotate(float Angle, _Vector3D p0, _Vector3D p1)
        {
            _Vector3D v = p1 - p0;
            Translate(-p0.x, -p0.y, -p0.z);
            Rotate(Angle, v);
            Translate(p0.x, p0.y, p0.z);
        }
        public override void Translate(float Ox, float Oy, float Oz)
        {
            float[] p1 = LightPos;
            _Affine tran = new _Affine();
            tran.Translate(Ox, Oy, Oz);
            p1 = tran.ConvertPoint(p1);
            _Math3D.CopyMatrix(LightPos, p1);
            ChangeMatrix();
        }
        public override void Scale(float Ox, float Oy, float Oz)
        {
            return;
        }
        #endregion
 
    }
}
