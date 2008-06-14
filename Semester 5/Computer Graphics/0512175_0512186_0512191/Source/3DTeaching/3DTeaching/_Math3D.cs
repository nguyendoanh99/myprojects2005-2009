using System;
using System.Collections.Generic;
using System.Text;

namespace testTAO
{
    class _Math3D
    {
        //////////////////////////////////////////////////////////////////////////////////////
        // Get Square of a vectors length
        // Only for three component vectors
        public static float GetVectorLengthSquared(float[] u)
        { return (u[0] * u[0]) + (u[1] * u[1]) + (u[2] * u[2]); }
        public static float GetVectorLengthSquared(_Vector3D u)
        {
            return GetVectorLengthSquared((float[]) u);
        }
        ///////////////////////////////////////////////////////////////////////////////////////
        // Scale Vectors (in place)
        public static void ScaleVector3(float[] v, float scale) 
	    { v[0] *= scale; v[1] *= scale; v[2] *= scale; }
        public static _Vector3D ScaleVector3(_Vector3D v, float scale)
        {
            float[] temp = (float[])v;
            ScaleVector3(temp, scale);
            return temp;
        }
        //////////////////////////////////////////////////////////////////////////////////////
        // Get lenght of vector
        // Only for three component vectors.
        public static float GetVectorLength(float[] u)
        { return (float)(Math.Sqrt((double)(GetVectorLengthSquared(u)))); }
        public static float GetVectorLength(_Vector3D u)
        {
            return GetVectorLength((float[])u);
        }
        //////////////////////////////////////////////////////////////////////////////////////
        // Normalize a vector
        // Scale a vector to unit length. Easy, just scale the vector by it's length
        public static void NormalizeVector(float[] u)
	        { ScaleVector3(u, 1.0f / GetVectorLength(u)); }
        public static _Vector3D NormalizeVector(_Vector3D u)
        {
            float[] temp = (float[])u;
            NormalizeVector(temp);
            return temp;
        }
        //////////////////////////////////////////////////////////////////////////////////////
        // Cross Product
        // u x v = result
        // We only need one version for floats, and one version for doubles. A 3 component
        // vector fits in a 4 component vector. If  M3DVector4d or M3DVector4f are passed
        // we will be OK because 4th component is not used.
        public static void CrossProduct(float[] result, float[] u, float[] v)
        {
	        result[0] = u[1]*v[2] - v[1]*u[2];
	        result[1] = -u[0]*v[2] + v[0]*u[2];
	        result[2] = u[0]*v[1] - v[0]*u[1];
        }
        public static _Vector3D CrossProduct(_Vector3D u, _Vector3D v)
        {
            float[] result = new float[3];
            CrossProduct(result, (float[])u, (float[])v);
            return result;
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        // Calculate the plane equation of the plane that the three specified points lay in. The
        // points are given in clockwise winding order, with normal pointing out of clockwise face
        // planeEq contains the A,B,C, and D of the plane equation coefficients
        // (source code: SuperBible4)
        public static void GetPlaneEquation(float[] planeEq, float[] p1, float[] p2, float[] p3)
        {
            // Get two vectors... do the cross product
            float[] v1 = new float[3];
            float[] v2 = new float[3];

            // V1 = p3 - p1
            v1[0] = p3[0] - p1[0];
            v1[1] = p3[1] - p1[1];
            v1[2] = p3[2] - p1[2];

            // V2 = P2 - p1
            v2[0] = p2[0] - p1[0];
            v2[1] = p2[1] - p1[1];
            v2[2] = p2[2] - p1[2];

            // Unit normal to plane - Not sure which is the best way here
            CrossProduct(planeEq, v1, v2);
            NormalizeVector(planeEq);
            // Back substitute to get D
            planeEq[3] = -(planeEq[0] * p3[0] + planeEq[1] * p3[1] + planeEq[2] * p3[2]);
        }
        ///////////////////////////////////////////////////////////////////////////
        // Creae a projection to "squish" an object into the plane.
        // Use m3dGetPlaneEquationf(planeEq, point1, point2, point3);
        // to get a plane equation.
        // (source code: SuperBible4)
        public static void MakePlanarShadowMatrix(float[] proj, float[] planeEq, float[] vLightPos)
        {
	        // These just make the code below easier to read. They will be 
	        // removed by the optimizer.	
	        float a = planeEq[0];
	        float b = planeEq[1];
	        float c = planeEq[2];
	        float d = planeEq[3];

	        float dx = -vLightPos[0];
	        float dy = -vLightPos[1];
	        float dz = -vLightPos[2];

	        // Now build the projection matrix
	        proj[0] = b * dy + c * dz;
	        proj[1] = -a * dy;
	        proj[2] = -a * dz;
	        proj[3] = 0.0f;

	        proj[4] = -b * dx;
	        proj[5] = a * dx + c * dz;
	        proj[6] = -b * dz;
	        proj[7] = 0.0f;

	        proj[8] = -c * dx;
	        proj[9] = -c * dy;
	        proj[10] = a * dx + b * dy;
	        proj[11] = 0.0f;

	        proj[12] = -d * dx;
	        proj[13] = -d * dy;
	        proj[14] = -d * dz;
	        proj[15] = a * dx + b * dy + c * dz;
	        // Shadow matrix ready
	    }
        // Tinh chieu dai cua vector
        // (source code: SuperBible4)
        public static float GetDistance(_Vector3D u, _Vector3D v)
	    {
            float x = u.x - v.x;
            x = x * x;

            float y = u.y - v.y;
            y = y * y;

            float z = u.z - v.z;
            z = z * z;

            return (float)Math.Sqrt(x + y + z);
        }
        // Angle between vectors, only for three component vectors. Angle is in radians...
        // (source code: SuperBible4)
        public static float GetAngleBetweenVectors(float[] u, float[] v)
        {
            float dTemp = (float) ((u[0]*v[0] + u[1]*v[1] + u[2]*v[2])
                / (Math.Sqrt(u[0] * u[0] + u[1] * u[1] + u[2] * u[2])
                * Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2])));
            return (float)Math.Acos(dTemp);
        }
        public static float GetAngleBetweenVectors(_Vector3D u, _Vector3D v)
        {
            return GetAngleBetweenVectors((float[])u, (float[])v);
        }
        // Tim vector phap tuyen cua mat phang 
        // (source code: SuperBible4)
        public static float[] FindNormalVector(float[] u, float[] v)
        {
            float[] result = new float[3];
            result[0] = u[1] * v[2] - v[1] * u[2];
            result[1] = -u[0] * v[2] + v[0] * u[2];
            result[2] = u[0] * v[1] - v[0] * u[1];
            return result;
        }
        public static float[] FindNormalVector(float[] point1, float[] point2, float[] point3)
        {
            float[] v1 = new float[3];
            float[] v2 = new float[3];

            // Calculate two vectors from the three points. Assumes counter clockwise
            // winding!
            v1[0] = point1[0] - point2[0];
            v1[1] = point1[1] - point2[1];
            v1[2] = point1[2] - point2[2];

            v2[0] = point2[0] - point3[0];
            v2[1] = point2[1] - point3[1];
            v2[2] = point2[2] - point3[2];
            return FindNormalVector(v1, v2);
        }
        public static _Vector3D FindNormalVector(_Vector3D v1, _Vector3D v2)
        {
            return FindNormalVector((float[]) v1, (float[]) v2);
        }      
        
        // Copy matrix Src sang Des
        public static void CopyMatrix(float[] Des, float[] Src)
        {
            for (int i = 0; i < Src.Length; ++i)
                Des[i] = Src[i];
        }
    }
}
