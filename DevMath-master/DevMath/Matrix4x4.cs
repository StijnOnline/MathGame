using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath {
    public class Matrix4x4 {
        public float[][] m = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

        public Matrix4x4() {
        }

        public static Matrix4x4 Identity {
            get {
                return new Matrix4x4() {
                    m = new float[4][] {
                            new float[4] { 1, 0, 0, 0 },
                            new float[4] { 0, 1, 0, 0 },
                            new float[4] { 0, 0, 1, 0 },
                            new float[4] { 0, 0, 0, 1 }
                    }
                };
            }
        }


        public float Determinant {
            get {
                return
                 m[0][ 3] * m[1][ 2] * m[2][ 1] * m[3][ 0] - m[0][ 2] * m[1][ 3] * m[2][ 1] * m[3][ 0] -
                 m[0][ 3] * m[1][ 1] * m[2][ 2] * m[3][ 0] + m[0][ 1] * m[1][ 3] * m[2][ 2] * m[3][ 0] +
                 m[0][ 2] * m[1][ 1] * m[2][ 3] * m[3][ 0] - m[0][ 1] * m[1][ 2] * m[2][ 3] * m[3][ 0] -
                 m[0][ 3] * m[1][ 2] * m[2][ 0] * m[3][ 1] + m[0][ 2] * m[1][ 3] * m[2][ 0] * m[3][ 1] +
                 m[0][ 3] * m[1][ 0] * m[2][ 2] * m[3][ 1] - m[0][ 0] * m[1][ 3] * m[2][ 2] * m[3][ 1] -
                 m[0][ 2] * m[1][ 0] * m[2][ 3] * m[3][ 1] + m[0][ 0] * m[1][ 2] * m[2][ 3] * m[3][ 1] +
                 m[0][ 3] * m[1][ 1] * m[2][ 0] * m[3][ 2] - m[0][ 1] * m[1][ 3] * m[2][ 0] * m[3][ 2] -
                 m[0][ 3] * m[1][ 0] * m[2][ 1] * m[3][ 2] + m[0][ 0] * m[1][ 3] * m[2][ 1] * m[3][ 2] +
                 m[0][ 1] * m[1][ 0] * m[2][ 3] * m[3][ 2] - m[0][ 0] * m[1][ 1] * m[2][ 3] * m[3][ 2] -
                 m[0][ 2] * m[1][ 1] * m[2][ 0] * m[3][ 3] + m[0][ 1] * m[1][ 2] * m[2][ 0] * m[3][ 3] +
                 m[0][ 2] * m[1][ 0] * m[2][ 1] * m[3][ 3] - m[0][ 0] * m[1][ 2] * m[2][ 1] * m[3][ 3] -
                 m[0][ 1] * m[1][ 0] * m[2][ 2] * m[3][ 3] + m[0][ 0] * m[1][ 1] * m[2][ 2] * m[3][ 3];
            }
        }

        public Matrix4x4 Inverse {
            get {
                float determinant = Determinant;
                if(determinant == 0) {
                    throw new Exception("Inverse does not exist");
                }

                //do magic
            }
        }

        public static Matrix4x4 Translate(Vector3 translation) {
            return new Matrix4x4() {
                m = new float[4][] {
                        new float[4] { 1, 0, 0, translation.x },
                        new float[4] { 0, 1, 0, translation.y },
                        new float[4] { 0, 0, 1, translation.z },
                        new float[4] { 0, 0, 0, 1 }
                    }
            };
        }

        public static Matrix4x4 Rotate(Vector3 rotation) {
            //Er zijn 2 manieren om deze te berekenen
            return RotateX(rotation.x) * RotateY(rotation.y) * RotateZ(rotation.z);
        }

        public static Matrix4x4 RotateX(float rotation) {
            return new Matrix4x4() {
                m = new float[4][] {
                            new float[4] { 1, 0, 0, 0 },
                            new float[4] { 0,(float)Math.Cos(rotation), (float)-Math.Sin(rotation), 0 },
                            new float[4] { 0, (float)Math.Sin(rotation), (float)Math.Cos(rotation), 0 },
                            new float[4] { 0, 0, 0, 1 }
                    }
            };
        }

        public static Matrix4x4 RotateY(float rotation) {
            return new Matrix4x4() {
                m = new float[4][] {
                            new float[4] { (float)Math.Cos(rotation), 0, (float)Math.Sin(rotation), 0 },
                            new float[4] { 0, 1, 0, 0 },
                            new float[4] { -(float)Math.Sin(rotation), 0, (float)Math.Cos(rotation), 0 },
                            new float[4] { 0, 0, 0, 1 }
                    }
            };
        }

        public static Matrix4x4 RotateZ(float rotation) {
            return new Matrix4x4() {
                m = new float[4][] {
                        new float[4] { (float)Math.Cos(rotation), -(float)Math.Sin(rotation), 0, 0 },
                        new float[4] { (float)Math.Sin(rotation), (float)Math.Cos(rotation), 0, 0 },
                        new float[4] { 0, 0, 1, 0 },
                        new float[4] { 0, 0, 0, 1 }
                    }
            };
        }

        public static Matrix4x4 Scale(Vector3 scale) {
            return new Matrix4x4() {
                m = new float[4][] {
                            new float[4] { scale.x, 0,       0,       0 },
                            new float[4] { 0,       scale.y, 0,       0 },
                            new float[4] { 0,       0,       scale.z, 0 },
                            new float[4] { 0,       0,       0,       1 }
                    }
            };
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs) {
            return new Matrix4x4() {
                m = new float[4][] {
                            CalculateRow(rhs.m[0],lhs),
                            CalculateRow(rhs.m[1],lhs),
                            CalculateRow(rhs.m[2],lhs),
                            CalculateRow(rhs.m[3],lhs)
                    }
            };
        }

        //Added 
        private static float[] CalculateRow(float[] lhs, Matrix4x4 rhs) {
            return new float[] {
                rhs.m[0][0] * lhs[0] + rhs.m[1][0] * lhs[1] + rhs.m[2][0] * lhs[2] + rhs.m[3][0] * lhs[3],
                rhs.m[0][1] * lhs[0] + rhs.m[1][1] * lhs[1] + rhs.m[2][1] * lhs[2] + rhs.m[3][1] * lhs[3],
                rhs.m[0][2] * lhs[0] + rhs.m[1][2] * lhs[1] + rhs.m[2][2] * lhs[2] + rhs.m[3][2] * lhs[3],
                rhs.m[0][3] * lhs[0] + rhs.m[1][3] * lhs[1] + rhs.m[2][3] * lhs[2] + rhs.m[3][3] * lhs[3]
            };
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs) {
            return new Vector4() {
                x = lhs.m[0][0] * rhs.x + lhs.m[0][1] * rhs.y + lhs.m[0][2] * rhs.z + lhs.m[0][3] * rhs.w,
                y = lhs.m[1][0] * rhs.x + lhs.m[1][1] * rhs.y + lhs.m[1][2] * rhs.z + lhs.m[1][3] * rhs.w,
                z = lhs.m[2][0] * rhs.x + lhs.m[2][1] * rhs.y + lhs.m[2][2] * rhs.z + lhs.m[2][3] * rhs.w,
                w = lhs.m[3][0] * rhs.x + lhs.m[3][1] * rhs.y + lhs.m[3][2] * rhs.z + lhs.m[3][3] * rhs.w
            };
        }



    }
}
