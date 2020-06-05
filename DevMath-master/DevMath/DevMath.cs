using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class DevMath
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + t * (b-a);
        }

        public static float DistanceTraveled(float startVelocity, float acceleration, float time)
        {
            return (float)(startVelocity + 0.5f * acceleration * time) * time;
        }

        public static float Clamp(float value, float min, float max)
        {
            return Math.Min(Math.Max(value,min),max);
        }

        public static float RadToDeg(float angle)
        {
            return angle / (float)Math.PI * 180f;
        }

        public static float DegToRad(float angle)
        {
            return angle  * (float)Math.PI / 180f;
        }
    }
}
