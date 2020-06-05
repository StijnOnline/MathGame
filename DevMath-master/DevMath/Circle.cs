using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Circle
    {
        public Vector2 Position
        {
            get; set;
        }

        public float Radius
        {
            get; set;
        }

        public bool CollidesWith(Circle circle)
        {
            //return (Vector2.Distance(Position, circle.Position) < Radius + circle.Radius);
            return Math.Pow(Position.x - circle.Position.x, 2) + Math.Pow(Position.y - circle.Position.y, 2) < Math.Pow(Radius + circle.Radius, 2);
        }
    }
}
