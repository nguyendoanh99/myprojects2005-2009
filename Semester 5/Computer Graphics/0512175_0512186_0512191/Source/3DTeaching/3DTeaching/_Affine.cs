using System;
using System.Collections.Generic;
using System.Text;

namespace testTAO
{
    class _Affine
    {
        #region Attributes
        private float[] mMatrix;
        #endregion
        #region Properties
        public float this[int index]
        {
            get
            {
                return mMatrix[index];
            }
            set
            {
                mMatrix[index] = value;
            }
        }
        #endregion
        #region Contructors
        public _Affine()
        {
            mMatrix = new float[16];
        }
        public _Affine(_Affine P)
        {
            mMatrix = new float[16];
            _Math3D.CopyMatrix(mMatrix, P.mMatrix);
        }
        #endregion
        #region Public Function
        // Ma tran bien doi cua Phep quay quanh vector co goc la goc toa do
        public void Rotate(float angle, float x, float y, float z)
        {
            float[] result = new float[3];
            double s = Math.Sin(Math.PI * angle / 180.0);
            double c = Math.Abs(s) == 1 ? 0 : Math.Cos(Math.PI * angle / 180.0);
            double temp1c = 1 - c;
            double d = Math.Sqrt(x * x + y * y + z * z);
            if (d == 0)
                return ;

            x = (float)(x / d);
            y = (float)(y / d);
            z = (float)(z / d);
            this[0] = (float) (x * x * temp1c + c);
            this[1] = (float) (y * x * temp1c + z * s);
            this[2] = (float) (z * x * temp1c - y * s);
            this[3] = 0;
            this[4] = (float) (x * y * temp1c - z * s);
            this[5] = (float) (y * y * temp1c + c);
            this[6] = (float) (z * y * temp1c + x * s);
            this[7] = 0;
            this[8] = (float) (x * z * temp1c + y * s);
            this[9] = (float) (y * z * temp1c - x * s);
            this[10] = (float) (z * z * temp1c + c);
            this[11] = 0;
            this[12] = 0;
            this[13] = 0;
            this[14] = 0;
            this[15] = 1;
        }
        public void Rotate(float angle, _Vector3D v)
        {
            Rotate(angle, v.x, v.y, v.z);
        }
        // Quay quanh truc bat ky
        public void Rotate(float angle, _Vector3D p0, _Vector3D p1)
        {
            _Vector3D v = p1 - p0;
            _Affine tran1 = new _Affine();
            _Affine rot = new _Affine();
            _Affine tran2 = new _Affine();
            tran1.Translate(-p0.x, -p0.y, -p0.z);
            rot.Rotate(angle, v);
            tran2.Translate(p0.x, p0.y, p0.z);
            _Affine temp = tran1 + rot + tran2;
            _Math3D.CopyMatrix(mMatrix, temp.mMatrix);
        }
        // Ma tran bien doi cua phep co gian
        public void Scale(float Ox, float Oy, float Oz)
        {
            this[0] = Ox;
            this[1] = 0;
            this[2] = 0;
            this[3] = 0;
            this[4] = 0;
            this[5] = Oy;
            this[6] = 0;
            this[7] = 0;
            this[8] = 0;
            this[9] = 0;
            this[10] = Oz;
            this[11] = 0;
            this[12] = 0;
            this[13] = 0;
            this[14] = 0;
            this[15] = 1;
        }
        // Ma tran bien doi cua phep di chuyen
        public void Translate(float Ox, float Oy, float Oz)
        {
            this[0] = 1;
            this[1] = 0;
            this[2] = 0;
            this[3] = 0;
            this[4] = 0;
            this[5] = 1;
            this[6] = 0;
            this[7] = 0;
            this[8] = 0;
            this[9] = 0;
            this[10] = 1;
            this[11] = 0;
            this[12] = Ox;
            this[13] = Oy;
            this[14] = Oz;
            this[15] = 1;
        }       
        // ma tran bien doi cua phep doi xung truc 
        public void Axisymmetric(float[] p1, float[] p2)
        {
            float A = p2[0] - p1[0];
            float B = p2[1] - p1[1];
            float C = p2[2] - p1[2];
            float _A = A * A;
            float _B = B * B;
            float _C = C * C;
            float temp1 = _A + _B + _C;
            float temp2 = (A * p1[0] + B * p1[1] + C * p1[2]) / temp1;
            this[0] = 2 * _A / temp1 - 1;
            this[1] = 2 * B * A / temp1;
            this[2] = 2 * C * A / temp1;
            this[3] = 0;
            this[4] = 2 * A * B / temp1;
            this[5] = 2 * _B / temp1 - 1;
            this[6] = 2 * C * B / temp1;
            this[7] = 0;
            this[8] = 2 * A * C / temp1;
            this[9] = 2 * B * C / temp1;
            this[10] = 2 * _C / temp1 - 1;
            this[12] = 2 * (p1[0] - A * temp2);
            this[13] = 2 * (p1[1] - B * temp2);
            this[14] = 2 * (p1[2] - C * temp2);
            this[15] = 1;
        }
        public void Axisymmetric(_Vector3D v)
        {
            Axisymmetric(new float[3] { 0, 0, 0 }, (float[])v);
        }
        // Tra ve diem moi sau khi ap dung phep bien doi affine
        public float[] ConvertPoint(float[] p)
        {
            float[] result = new float[3];
            result[0] = p[0] * this[0] + p[1] * this[4] + p[2] * this[8] + this[12];
            result[1] = p[0] * this[1] + p[1] * this[5] + p[2] * this[9] + this[13];
            result[2] = p[0] * this[2] + p[1] * this[6] + p[2] * this[10] + this[14];
            return result;
        }
        // ma tran don vi
        public void Identity()
        {
            this[0] = 1;
            this[1] = 0;
            this[2] = 0;
            this[3] = 0;
            this[4] = 0;
            this[5] = 1;
            this[6] = 0;
            this[7] = 0;
            this[8] = 0;
            this[9] = 0;
            this[10] = 1;
            this[11] = 0;
            this[12] = 0;
            this[13] = 0;
            this[14] = 0;
            this[15] = 1;
        }
        public static explicit operator float[](_Affine P)
        {
            float[] result = new float[16];
            _Math3D.CopyMatrix(result, P.mMatrix);
            return result;
        }
        #endregion
        #region Operators
        public static _Affine operator+(_Affine T1, _Affine T2)
        {
            _Affine result = new _Affine();
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                    result[i * 4 + j] =
                        T1[i * 4] * T2[j] +
                        T1[i * 4 + 1] * T2[4 + j] +
                        T1[i * 4 + 2] * T2[2 * 4 + j];
            return result;
        }
        #endregion
    }
}