using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
namespace testTAO
{
    class _Vector : _ObjectOpenGL
    {
        #region Attributes
        private _Vector3D mBegin;
        private _Vector3D mEnd;        
        private Glu.GLUquadric pObj;
        #endregion
        #region Properties
        public _Vector3D pBegin
        {
            get
            {
                return mBegin;
            }
            set
            {
                mBegin = value;
                ChangeMatrix();
            }
        }
        public _Vector3D pEnd
        {
            get
            {
                return mEnd;
            }
            set
            {
                mEnd = value;
                ChangeMatrix();
            }
        }
        #endregion
        #region Private Functions
        private void Init(_Vector3D p1, _Vector3D p2)
        {
            mBegin = p1;
            mEnd = p2;
            ChangeMatrix();
            pObj = Glu.gluNewQuadric();
            Glu.gluQuadricDrawStyle(pObj, Glu.GLU_FILL);
            Glu.gluQuadricNormals(pObj, Glu.GLU_SMOOTH);
            Glu.gluQuadricOrientation(pObj, Glu.GLU_OUTSIDE);
            Glu.gluQuadricTexture(pObj, Glu.GLU_FALSE);
        }
        // Ham tinh lai ma tran cua vector khi co su thay doi vi tri 2 dau cua vector
        private void ChangeMatrix()
        {
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
        #region Constructors
        public _Vector()
        {
            _Vector3D p1 = new _Vector3D(0, 0, 0);
            _Vector3D p2 = new _Vector3D(1, 1, 1);
            Init(p1, p2);
        }
        public _Vector(_Vector3D p)
        {
            _Vector3D p1 = new _Vector3D(0, 0, 0);
            Init(p1, p);
        }
        public _Vector(_Vector3D p1, _Vector3D p2)
        {
            Init(p1, p2);
        }
        public _Vector(_Vector P)
        {
            Init(P.pBegin, P.pEnd);
        }
        ~_Vector()
        {
            Glu.gluDeleteQuadric(pObj);
        }
        #endregion
        #region Public Functions
        public override void Rotate(float Angle, float Ox, float Oy, float Oz)
        {
            float[] p1 = new float[3] { pBegin.x, pBegin.y, pBegin.z };
            float[] p2 = new float[3] { pEnd.x, pEnd.y, pEnd.z };
            _Affine rot = new _Affine();
            rot.Rotate(Angle, Ox, Oy, Oz);
            p1 = rot.ConvertPoint(p1);
            p2 = rot.ConvertPoint(p2);
            mBegin = new _Vector3D(p1);
            mEnd = new _Vector3D(p2);
            ChangeMatrix();
        }
        public override void Rotate(float Angle, _Vector3D v)
        {
            Rotate(Angle, v.x, v.y, v.z);
        }
        // Quay quanh truc p0p1
        public override void Rotate(float Angle, _Vector3D p0, _Vector3D p1)
        {
            _Vector3D v = p1 - p0;
            Translate(-p0.x, -p0.y, -p0.z);
            Rotate(Angle, v);
            Translate(p0.x, p0.y, p0.z);
        }        
        public override void Translate(float Ox, float Oy, float Oz)
        {
            float[] p1 = new float[3] { pBegin.x, pBegin.y, pBegin.z };
            float[] p2 = new float[3] { pEnd.x, pEnd.y, pEnd.z };
            _Affine tran = new _Affine();
            tran.Translate(Ox, Oy, Oz);
            p1 = tran.ConvertPoint(p1);
            p2 = tran.ConvertPoint(p2);
            mBegin = new _Vector3D(p1);
            mEnd = new _Vector3D(p2);
            ChangeMatrix();
        }
        public override void Scale(float Ox, float Oy, float Oz)
        {
            return;
        }
        public override void Draw()
        {
            if (Enable == false)
                return ;

            float range = 100;
            float height = _Math3D.GetDistance(pBegin, pEnd);
            float fAxisRadius = (float)(0.008 * range);
            float fAxisHeight = (float)(0.95 * height);
            float fArrowRadius = (float)(0.015 * range);
            float fArrowHeight = (float)(0.03 * height);
            
            Gl.glPushMatrix();
                base.Draw();
                Gl.glMultMatrixf(Matrix);
                // Ve hinh
                Glu.gluCylinder(pObj, fAxisRadius, fAxisRadius, fAxisHeight, 10, 1);
                Gl.glPushMatrix();
                    Gl.glTranslatef(0.0f, 0.0f, fAxisHeight);
                    Glu.gluCylinder(pObj, fArrowRadius, 0.0f, fArrowHeight, 10, 1);
                    Gl.glRotatef(180.0f, 1.0f, 0.0f, 0.0f);
                    Glu.gluDisk(pObj, fAxisRadius, fArrowRadius, 10, 1);
                Gl.glPopMatrix();            
            Gl.glPopMatrix();
        }
        #endregion

    }
}
