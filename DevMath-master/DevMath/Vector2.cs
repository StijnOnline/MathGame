using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector2
    {
        public float x;
        public float y;

        public float Magnitude
        {
            get { return (float)Math.Sqrt(x*x + y*y); }
        }

        public Vector2 Normalized
        {
            get { return this / Magnitude; }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        //Added
        public static float Distance(Vector2 a, Vector2 b) {
            return (float)Math.Sqrt(Math.Pow(a.x -b.x,2) + Math.Pow(a.y - b.y, 2));
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            return a + t * (b - a);
        }

        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
            return (float)(Math.Atan2(rhs.y, rhs.x) - Math.Atan2(lhs.y, lhs.x));
        }

        public static Vector2 DirectionFromAngle(float angleDeg)
        {
            float rad = DevMath.DegToRad(angleDeg);
            return new Vector2((float)Math.Cos(rad),(float)Math.Sin(rad));
        }

         
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

         
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return -1 * v;
        }
         
        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x * scalar,lhs.y*scalar);
        }
        //Copied function to allow float to be on either side
        public static Vector2 operator *(float scalar, Vector2 rhs) {
            return new Vector2(rhs.x * scalar, rhs.y * scalar);
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x / scalar, lhs.y / scalar);
        }
        //Copied function to allow float to be on either side
        public static Vector2 operator /(float scalar,Vector2 rhs) {
            return new Vector2(rhs.x / scalar, rhs.y / scalar);
        }
    }
}
