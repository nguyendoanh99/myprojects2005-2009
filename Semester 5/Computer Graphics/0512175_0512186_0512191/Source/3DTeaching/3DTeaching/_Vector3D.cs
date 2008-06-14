using System;
using System.Collections.Generic;
using System.Text;

namespace testTAO
{
    class _Vector3D
    {
        #region Attributes
        private float mX;
        private float mY;
        private float mZ;
        #endregion
        #region Properties
        public float x
        {
            get
            {
                return mX;
            }
            set
            {
                mX = value;
            }
        }
        public float y
        {
            get
            {
                return mY;
            }
            set
            {
                mY = value;
            }
        }
        public float z
        {
            get
            {
                return mZ;
            }
            set
            {
                mZ = value;
            }
        }
        #endregion
        #region Private Function
        private void Init(float _x, float _y, float _z)
        {
            mX = _x;
            mY = _y;
            mZ = _z;
        }
        #endregion
        #region Constructor
        public _Vector3D()
        {
            Init(0, 0, 0);
        }
        public _Vector3D(float _x, float _y, float _z)
        {
            Init(_x, _y, _z);
        }
        public _Vector3D(_Vector3D p)
        {
            Init(p.x, p.y, p.z);
        }
        public _Vector3D(float[] P)
        {
            Init(P[0], P[1], P[2]);
        }
        #endregion
        #region Public Function

        #endregion
        #region Operator
        public static _Vector3D operator -(_Vector3D p1, _Vector3D p2)
        {
            _Vector3D result = new _Vector3D();
            result.x = p1.x - p2.x;
            result.y = p1.y - p2.y;
            result.z = p1.z - p2.z;
            return result;
        }
        public static implicit operator  _Vector3D(float[] P)
        {
            return new _Vector3D(P);
        }
        public static explicit operator float[](_Vector3D P)
        {
            float[] result = new float[3];
            result[0] = P.mX;
            result[1] = P.mY;
            result[2] = P.mZ;
            return result;
        }
        #endregion
    }

}
