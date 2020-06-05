using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath {
    public class Rigidbody {
        public Vector2 Velocity {
            get; private set;
        }

        public float mass = 1.0f;
        public float force = 150.0f;
        public float dragCoefficient = .47f;

        public void AddForce(Vector2 forceDirection, float deltaTime) {

            //Magic Formula if forceDirection is NOT normalized
            //Velocity = (1 / dragCoefficient) * (float)Math.Exp(-dragCoefficient / mass * deltaTime) * (dragCoefficient * Velocity + forceDirection) - forceDirection / dragCoefficient;

            //Magic Formula if forceDirection IS normalized
            //Vector2 force = forceDirection * (mass * mass / this.force);
            //Velocity = (1 / dragCoefficient) * (float)Math.Exp(-dragCoefficient / mass * deltaTime) * (dragCoefficient * Velocity + force) - force / dragCoefficient;
        }
    }
}
