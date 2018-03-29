﻿/* Copyright (C) <2009-2011> <Thorben Linneweber, Jitter Physics>
* 
*  This software is provided 'as-is', without any express or implied
*  warranty.  In no event will the authors be held liable for any damages
*  arising from the use of this software.
*
*  Permission is granted to anyone to use this software for any purpose,
*  including commercial applications, and to alter it and redistribute it
*  freely, subject to the following restrictions:
*
*  1. The origin of this software must not be misrepresented; you must not
*      claim that you wrote the original software. If you use this software
*      in a product, an acknowledgment in the product documentation would be
*      appreciated but is not required.
*  2. Altered source versions must be plainly marked as such, and must not be
*      misrepresented as being the original software.
*  3. This notice may not be removed or altered from any source distribution. 
*/

namespace TrueSync
{

    /// <summary>
    /// 3x3 Matrix.
    /// </summary>
    public struct TSMatrix4x4
    {
        /// <summary>
        /// M11
        /// </summary>
        public FP M11; // 1st row vector
        /// <summary>
        /// M12
        /// </summary>
        public FP M12;
        /// <summary>
        /// M13
        /// </summary>
        public FP M13;
        /// <summary>
        /// M14
        /// </summary>
        public FP M14;
        /// <summary>
        /// M21
        /// </summary>
        public FP M21; // 2nd row vector
        /// <summary>
        /// M22
        /// </summary>
        public FP M22;
        /// <summary>
        /// M23
        /// </summary>
        public FP M23;
        /// <summary>
        /// M24
        /// </summary>
        public FP M24;
        /// <summary>
        /// M31
        /// </summary>
        public FP M31; // 3rd row vector
        /// <summary>
        /// M32
        /// </summary>
        public FP M32;
        /// <summary>
        /// M33
        /// </summary>
        public FP M33;
        /// <summary>
        /// M34
        /// </summary>
        public FP M34;
        /// <summary>
        /// M41
        /// </summary>
        public FP M41; // 4rd row vector
        /// <summary>
        /// M42
        /// </summary>
        public FP M42;
        /// <summary>
        /// M43
        /// </summary>
        public FP M43;
        /// <summary>
        /// M44
        /// </summary>
        public FP M44;

        internal static TSMatrix4x4 InternalIdentity;

        /// <summary>
        /// Identity matrix.
        /// </summary>
        public static readonly TSMatrix4x4 Identity;
        public static readonly TSMatrix4x4 Zero;

        static TSMatrix4x4()
        {
            Zero = new TSMatrix4x4();

            Identity = new TSMatrix4x4();
            Identity.M11 = FP.One;
            Identity.M22 = FP.One;
            Identity.M33 = FP.One;
            Identity.M44 = FP.One;

            InternalIdentity = Identity;
        }
        /// <summary>
        /// Initializes a new instance of the matrix structure.
        /// </summary>
        /// <param name="m11">m11</param>
        /// <param name="m12">m12</param>
        /// <param name="m13">m13</param>
        /// <param name="m14">m14</param>
        /// <param name="m21">m21</param>
        /// <param name="m22">m22</param>
        /// <param name="m23">m23</param>
        /// <param name="m24">m24</param>
        /// <param name="m31">m31</param>
        /// <param name="m32">m32</param>
        /// <param name="m33">m33</param>
        /// <param name="m34">m34</param>
        /// <param name="m41">m41</param>
        /// <param name="m42">m42</param>
        /// <param name="m43">m43</param>
        /// <param name="m44">m44</param>
        public TSMatrix4x4(FP m11, FP m12, FP m13, FP m14,
            FP m21, FP m22, FP m23, FP m24,
            FP m31, FP m32, FP m33, FP m34,
            FP m41, FP m42, FP m43, FP m44)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M14 = m14;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M24 = m24;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
            this.M34 = m34;
            this.M41 = m41;
            this.M42 = m42;
            this.M43 = m43;
            this.M44 = m44;
        }

        /// <summary>
        /// Multiply two matrices. Notice: matrix multiplication is not commutative.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The product of both matrices.</returns>
        public static TSMatrix4x4 Multiply(TSMatrix4x4 matrix1, TSMatrix4x4 matrix2)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Multiply(ref matrix1, ref matrix2, out result);
            return result;
        }

        /// <summary>
        /// Multiply two matrices. Notice: matrix multiplication is not commutative.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="result">The product of both matrices.</param>
        public static void Multiply(ref TSMatrix4x4 matrix1, ref TSMatrix4x4 matrix2, out TSMatrix4x4 result)
        {
            result.M11 = ((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31) + (matrix1.M14 * matrix2.M41);
            result.M12 = ((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32) + (matrix1.M14 * matrix2.M42);
            result.M13 = ((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33) + (matrix1.M14 * matrix2.M43);
            result.M14 = ((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34) + (matrix1.M14 * matrix2.M44);
            
            result.M21 = ((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31) + (matrix1.M24 * matrix2.M41);
            result.M22 = ((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32) + (matrix1.M24 * matrix2.M42);
            result.M23 = ((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33) + (matrix1.M24 * matrix2.M43);
            result.M24 = ((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M33) + (matrix1.M24 * matrix2.M44);

            result.M31 =  ((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31) + (matrix1.M34 * matrix2.M41);
            result.M32 =  ((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32) + (matrix1.M34 * matrix2.M42);
            result.M33 = ((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33) + (matrix1.M34 * matrix2.M43);
            result.M34 = ((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34) + (matrix1.M34 * matrix2.M44);

            result.M41 = ((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31) + (matrix1.M44 * matrix2.M41);
            result.M42 = ((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32) + (matrix1.M44 * matrix2.M42);
            result.M43 = ((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33) + (matrix1.M44 * matrix2.M43);
            result.M44 = ((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M33) + (matrix1.M44 * matrix2.M44);
        }

        /// <summary>
        /// Matrices are added.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The sum of both matrices.</returns>
        public static TSMatrix4x4 Add(TSMatrix4x4 matrix1, TSMatrix4x4 matrix2)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Add(ref matrix1, ref matrix2, out result);
            return result;
        }

        /// <summary>
        /// Matrices are added.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="result">The sum of both matrices.</param>
        public static void Add(ref TSMatrix4x4 matrix1, ref TSMatrix4x4 matrix2, out TSMatrix4x4 result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M14 = matrix1.M14 + matrix2.M14;

            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M24 = matrix1.M24 + matrix2.M24;

            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
            result.M34 = matrix1.M34 + matrix2.M34;

            result.M41 = matrix1.M41 + matrix2.M41;
            result.M42 = matrix1.M42 + matrix2.M42;
            result.M43 = matrix1.M43 + matrix2.M43;
            result.M44 = matrix1.M44 + matrix2.M44;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <returns>The inverted JMatrix.</returns>
        public static TSMatrix4x4 Inverse(TSMatrix4x4 matrix)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Inverse(ref matrix, out result);
            return result;
        }

        private FP Determinant3x3(FP m11, FP m12, FP m13,
            FP m21, FP m22, FP m23,
            FP m31, FP m32, FP m33)
        {
            return m11 * m22 * m33 + m12 * m23 * m31 + m13 * m21 * m32 -
                m31 * m22 * m13 - m32 * m23 * m11 - m33 * m21 * m12;
        }

        public FP Determinant()
        {
            FP result = 
                M11 * Determinant3x3(M22, M23, M24,
                                  M32, M33, M34, 
                                  M42, M43, M44)
                - M21 * Determinant3x3(M12, M13, M14, 
                                    M32, M33, M34, 
                                    M42, M43, M44)
                + M31 * Determinant3x3(M12, M13, M14, 
                                    M22, M23, M24, 
                                    M42, M43, M44)
                - M41 * Determinant3x3(M12, M13, M14,
                                    M22, M23, M24,
                                    M32, M33, M34);

            return result;
        }

        /// <summary>
        /// Calculates the inverse of a give matrix.
        /// </summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <param name="result">The inverted JMatrix.</param>
        public static void Inverse(ref TSMatrix4x4 matrix, out TSMatrix4x4 result)
        {
            //                                       -1
            // If you have matrix M, inverse Matrix M   can compute
            //
            //     -1       1      
            //    M   = --------- A
            //            det(M)
            //
            // A is adjugate (adjoint) of M, where,
            //
            //      T
            // A = C
            //
            // C is Cofactor matrix of M, where,
            //           i + j
            // C   = (-1)      * det(M  )
            //  ij                    ij
            //
            //     [ a b c d ]
            // M = [ e f g h ]
            //     [ i j k l ]
            //     [ m n o p ]
            //
            // First Row
            //           2 | f g h |
            // C   = (-1)  | j k l | = + ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //  11         | n o p |
            //
            //           3 | e g h |
            // C   = (-1)  | i k l | = - ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //  12         | m o p |
            //
            //           4 | e f h |
            // C   = (-1)  | i j l | = + ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //  13         | m n p |
            //
            //           5 | e f g |
            // C   = (-1)  | i j k | = - ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //  14         | m n o |
            //
            // Second Row
            //           3 | b c d |
            // C   = (-1)  | j k l | = - ( b ( kp - lo ) - c ( jp - ln ) + d ( jo - kn ) )
            //  21         | n o p |
            //
            //           4 | a c d |
            // C   = (-1)  | i k l | = + ( a ( kp - lo ) - c ( ip - lm ) + d ( io - km ) )
            //  22         | m o p |
            //
            //           5 | a b d |
            // C   = (-1)  | i j l | = - ( a ( jp - ln ) - b ( ip - lm ) + d ( in - jm ) )
            //  23         | m n p |
            //
            //           6 | a b c |
            // C   = (-1)  | i j k | = + ( a ( jo - kn ) - b ( io - km ) + c ( in - jm ) )
            //  24         | m n o |
            //
            // Third Row
            //           4 | b c d |
            // C   = (-1)  | f g h | = + ( b ( gp - ho ) - c ( fp - hn ) + d ( fo - gn ) )
            //  31         | n o p |
            //
            //           5 | a c d |
            // C   = (-1)  | e g h | = - ( a ( gp - ho ) - c ( ep - hm ) + d ( eo - gm ) )
            //  32         | m o p |
            //
            //           6 | a b d |
            // C   = (-1)  | e f h | = + ( a ( fp - hn ) - b ( ep - hm ) + d ( en - fm ) )
            //  33         | m n p |
            //
            //           7 | a b c |
            // C   = (-1)  | e f g | = - ( a ( fo - gn ) - b ( eo - gm ) + c ( en - fm ) )
            //  34         | m n o |
            //
            // Fourth Row
            //           5 | b c d |
            // C   = (-1)  | f g h | = - ( b ( gl - hk ) - c ( fl - hj ) + d ( fk - gj ) )
            //  41         | j k l |
            //
            //           6 | a c d |
            // C   = (-1)  | e g h | = + ( a ( gl - hk ) - c ( el - hi ) + d ( ek - gi ) )
            //  42         | i k l |
            //
            //           7 | a b d |
            // C   = (-1)  | e f h | = - ( a ( fl - hj ) - b ( el - hi ) + d ( ej - fi ) )
            //  43         | i j l |
            //
            //           8 | a b c |
            // C   = (-1)  | e f g | = + ( a ( fk - gj ) - b ( ek - gi ) + c ( ej - fi ) )
            //  44         | i j k |
            //
            // Cost of operation
            // 53 adds, 104 muls, and 1 div.
            FP a = matrix.M11, b = matrix.M12, c = matrix.M13, d = matrix.M14;
            FP e = matrix.M21, f = matrix.M22, g = matrix.M23, h = matrix.M24;
            FP i = matrix.M31, j = matrix.M32, k = matrix.M33, l = matrix.M34;
            FP m = matrix.M41, n = matrix.M42, o = matrix.M43, p = matrix.M44;

            FP kp_lo = k * p - l * o;
            FP jp_ln = j * p - l * n;
            FP jo_kn = j * o - k * n;
            FP ip_lm = i * p - l * m;
            FP io_km = i * o - k * m;
            FP in_jm = i * n - j * m;

            FP a11 = (f * kp_lo - g * jp_ln + h * jo_kn);
            FP a12 = -(e * kp_lo - g * ip_lm + h * io_km);
            FP a13 = (e * jp_ln - f * ip_lm + h * in_jm);
            FP a14 = -(e * jo_kn - f * io_km + g * in_jm);

            FP det = a * a11 + b * a12 + c * a13 + d * a14;

            if (TSMath.Abs(det) < FP.Epsilon)
            {
                result = new TSMatrix4x4();
            }

            FP invDet = 1.0f / det;

            result.M11 = a11 * invDet;
            result.M21 = a12 * invDet;
            result.M31 = a13 * invDet;
            result.M41 = a14 * invDet;

            result.M12 = -(b * kp_lo - c * jp_ln + d * jo_kn) * invDet;
            result.M22 = (a * kp_lo - c * ip_lm + d * io_km) * invDet;
            result.M32 = -(a * jp_ln - b * ip_lm + d * in_jm) * invDet;
            result.M42 = (a * jo_kn - b * io_km + c * in_jm) * invDet;

            FP gp_ho = g * p - h * o;
            FP fp_hn = f * p - h * n;
            FP fo_gn = f * o - g * n;
            FP ep_hm = e * p - h * m;
            FP eo_gm = e * o - g * m;
            FP en_fm = e * n - f * m;

            result.M13 = (b * gp_ho - c * fp_hn + d * fo_gn) * invDet;
            result.M23 = -(a * gp_ho - c * ep_hm + d * eo_gm) * invDet;
            result.M33 = (a * fp_hn - b * ep_hm + d * en_fm) * invDet;
            result.M43 = -(a * fo_gn - b * eo_gm + c * en_fm) * invDet;

            FP gl_hk = g * l - h * k;
            FP fl_hj = f * l - h * j;
            FP fk_gj = f * k - g * j;
            FP el_hi = e * l - h * i;
            FP ek_gi = e * k - g * i;
            FP ej_fi = e * j - f * i;

            result.M14 = -(b * gl_hk - c * fl_hj + d * fk_gj) * invDet;
            result.M24 = (a * gl_hk - c * el_hi + d * ek_gi) * invDet;
            result.M34 = -(a * fl_hj - b * el_hi + d * ej_fi) * invDet;
            result.M44 = (a * fk_gj - b * ek_gi + c * ej_fi) * invDet;
        }

        /// <summary>
        /// Multiply a matrix by a scalefactor.
        /// </summary>
        /// <param name="matrix1">The matrix.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <returns>A JMatrix multiplied by the scale factor.</returns>
        public static TSMatrix4x4 Multiply(TSMatrix4x4 matrix1, FP scaleFactor)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Multiply(ref matrix1, scaleFactor, out result);
            return result;
        }

        /// <summary>
        /// Multiply a matrix by a scalefactor.
        /// </summary>
        /// <param name="matrix1">The matrix.</param>
        /// <param name="scaleFactor">The scale factor.</param>
        /// <param name="result">A JMatrix multiplied by the scale factor.</param>
        public static void Multiply(ref TSMatrix4x4 matrix1, FP scaleFactor, out TSMatrix4x4 result)
        {
            FP num = scaleFactor;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M14 = matrix1.M14 * num;

            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M24 = matrix1.M24 * num;

            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
            result.M34 = matrix1.M34 * num;

            result.M41 = matrix1.M41 * num;
            result.M42 = matrix1.M42 * num;
            result.M43 = matrix1.M43 * num;
            result.M44 = matrix1.M44 * num;
        }


        public static TSMatrix4x4 CreateFromQuaternion(TSQuaternion quaternion)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.CreateFromQuaternion(ref quaternion, out result);
            return result;
        }

        /// <summary>
        /// Creates a JMatrix representing an orientation from a quaternion.
        /// </summary>
        /// <param name="quaternion">The quaternion the matrix should be created from.</param>
        /// <param name="result">JMatrix representing an orientation.</param>
        public static void CreateFromQuaternion(ref TSQuaternion quaternion, out TSMatrix4x4 result)
        {
            FP xx = quaternion.x * quaternion.x;
            FP yy = quaternion.y * quaternion.y;
            FP zz = quaternion.z * quaternion.z;

            FP xy = quaternion.x * quaternion.y;
            FP wz = quaternion.z * quaternion.w;
            FP xz = quaternion.z * quaternion.x;
            FP wy = quaternion.y * quaternion.x;
            FP yz = quaternion.y * quaternion.z;
            FP wx = quaternion.x * quaternion.w;

            result.M11 = FP.One - 2 * (yy + zz);
            result.M12 = 2 * (xy + wz);
            result.M13 = 2 * (xz - wy);
            result.M14 = FP.Zero;
            result.M21 = 2 * (xy - wz);
            result.M22 = FP.One - 2 * (zz + xx);
            result.M23 = 2 * (yz + wx);
            result.M24 = FP.Zero;
            result.M31 = 2 * (xz + wy);
            result.M32 = 2 * (yz - wx);
            result.M33 = FP.One - 2 * (yy + xx);
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;
        }

        /// <summary>
        /// Creates the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix which should be transposed.</param>
        /// <returns>The transposed JMatrix.</returns>
        public static TSMatrix4x4 Transpose(TSMatrix4x4 matrix)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Transpose(ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Creates the transposed matrix.
        /// </summary>
        /// <param name="matrix">The matrix which should be transposed.</param>
        /// <param name="result">The transposed JMatrix.</param>
        public static void Transpose(ref TSMatrix4x4 matrix, out TSMatrix4x4 result)
        {
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M14 = matrix.M41;
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M24 = matrix.M42;
            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
            result.M34 = matrix.M43;
            result.M41 = matrix.M14;
            result.M42 = matrix.M24;
            result.M43 = matrix.M34;
            result.M44 = matrix.M44;
        }


        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product of both values.</returns>
        public static TSMatrix4x4 operator *(TSMatrix4x4 value1, TSMatrix4x4 value2)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Multiply(ref value1, ref value2, out result);
            return result;
        }


        public FP Trace()
        {
            return this.M11 + this.M22 + this.M33 + this.M44;
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The sum of both values.</returns>
        public static TSMatrix4x4 operator +(TSMatrix4x4 value1, TSMatrix4x4 value2)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Add(ref value1, ref value2, out result);
            return result;
        }

        /// <summary>
        /// Returns a new matrix with the negated elements of the given matrix.
        /// </summary>
        /// <param name="value">The source matrix.</param>
        /// <returns>The negated matrix.</returns>
        public static TSMatrix4x4 operator -(TSMatrix4x4 value)
        {
            TSMatrix4x4 result;

            result.M11 = -value.M11;
            result.M12 = -value.M12;
            result.M13 = -value.M13;
            result.M14 = -value.M14;
            result.M21 = -value.M21;
            result.M22 = -value.M22;
            result.M23 = -value.M23;
            result.M24 = -value.M24;
            result.M31 = -value.M31;
            result.M32 = -value.M32;
            result.M33 = -value.M33;
            result.M34 = -value.M34;
            result.M41 = -value.M41;
            result.M42 = -value.M42;
            result.M43 = -value.M43;
            result.M44 = -value.M44;

            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The difference of both values.</returns>
        public static TSMatrix4x4 operator -(TSMatrix4x4 value1, TSMatrix4x4 value2)
        {
            TSMatrix4x4 result;
            TSMatrix4x4.Multiply(ref value2, -FP.One, out value2);
            TSMatrix4x4.Add(ref value1, ref value2, out result);
            return result;
        }

        public static bool operator ==(TSMatrix4x4 value1, TSMatrix4x4 value2)
        {
            return value1.M11 == value2.M11 &&
                value1.M12 == value2.M12 &&
                value1.M13 == value2.M13 &&
                value1.M14 == value2.M14 &&
                value1.M21 == value2.M21 &&
                value1.M22 == value2.M22 &&
                value1.M23 == value2.M23 &&
                value1.M24 == value2.M24 &&
                value1.M31 == value2.M31 &&
                value1.M32 == value2.M32 &&
                value1.M33 == value2.M33 &&
                value1.M34 == value2.M34 &&
                value1.M41 == value2.M41 &&
                value1.M42 == value2.M42 &&
                value1.M43 == value2.M43 &&
                value1.M44 == value2.M44;
        }

        public static bool operator !=(TSMatrix4x4 value1, TSMatrix4x4 value2)
        {
            return value1.M11 != value2.M11 ||
                value1.M12 != value2.M12 ||
                value1.M13 != value2.M13 ||
                value1.M14 != value2.M14 ||
                value1.M21 != value2.M21 ||
                value1.M22 != value2.M22 ||
                value1.M23 != value2.M23 ||
                value1.M24 != value2.M24 ||
                value1.M31 != value2.M31 ||
                value1.M32 != value2.M32 ||
                value1.M33 != value2.M33 ||
                value1.M34 != value2.M34 ||
                value1.M41 != value2.M41 ||
                value1.M42 != value2.M42 ||
                value1.M43 != value2.M43 ||
                value1.M44 != value2.M44;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TSMatrix4x4)) return false;
            TSMatrix4x4 other = (TSMatrix4x4)obj;

            return this.M11 == other.M11 &&
                this.M12 == other.M12 &&
                this.M13 == other.M13 &&
                this.M14 == other.M14 &&
                this.M21 == other.M21 &&
                this.M22 == other.M22 &&
                this.M23 == other.M23 &&
                this.M24 == other.M24 &&
                this.M31 == other.M31 &&
                this.M32 == other.M32 &&
                this.M33 == other.M33 &&
                this.M34 == other.M44 &&
                this.M41 == other.M41 &&
                this.M42 == other.M42 &&
                this.M43 == other.M43 &&
                this.M44 == other.M44 ;
        }

        public override int GetHashCode()
        {
            return M11.GetHashCode() ^
                M12.GetHashCode() ^
                M13.GetHashCode() ^
                M14.GetHashCode() ^
                M21.GetHashCode() ^
                M22.GetHashCode() ^
                M23.GetHashCode() ^
                M24.GetHashCode() ^
                M31.GetHashCode() ^
                M32.GetHashCode() ^
                M33.GetHashCode() ^
                M34.GetHashCode() ^
                M41.GetHashCode() ^
                M42.GetHashCode() ^
                M43.GetHashCode() ^
                M44.GetHashCode();
        }

        /// <summary>
        /// Creates a translation matrix.
        /// </summary>
        /// <param name="xPosition">The amount to translate on the X-axis.</param>
        /// <param name="yPosition">The amount to translate on the Y-axis.</param>
        /// <param name="zPosition">The amount to translate on the Z-axis.</param>
        /// <returns>The translation matrix.</returns>
        public static TSMatrix4x4 CreateTranslation(float xPosition, float yPosition, float zPosition)
        {
            TSMatrix4x4 result;

            result.M11 = 1.0f;
            result.M12 = 0.0f;
            result.M13 = 0.0f;
            result.M14 = 0.0f;
            result.M21 = 0.0f;
            result.M22 = 1.0f;
            result.M23 = 0.0f;
            result.M24 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
            result.M34 = 0.0f;

            result.M41 = xPosition;
            result.M42 = yPosition;
            result.M43 = zPosition;
            result.M44 = 1.0f;

            return result;
        }

        /// <summary>
        /// Creates a scaling matrix.
        /// </summary>
        /// <param name="xScale">Value to scale by on the X-axis.</param>
        /// <param name="yScale">Value to scale by on the Y-axis.</param>
        /// <param name="zScale">Value to scale by on the Z-axis.</param>
        /// <returns>The scaling matrix.</returns>
        public static TSMatrix4x4 CreateScale(FP xScale, FP yScale, FP zScale)
        {
            TSMatrix4x4 result;

            result.M11 = xScale;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;
            result.M21 = FP.Zero;
            result.M22 = yScale;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;
            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = zScale;
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a scaling matrix with a center point.
        /// </summary>
        /// <param name="xScale">Value to scale by on the X-axis.</param>
        /// <param name="yScale">Value to scale by on the Y-axis.</param>
        /// <param name="zScale">Value to scale by on the Z-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static TSMatrix4x4 CreateScale(FP xScale, FP yScale, FP zScale, TSVector centerPoint)
        {
            TSMatrix4x4 result;

            FP tx = centerPoint.x * (FP.One - xScale);
            FP ty = centerPoint.y * (FP.One - yScale);
            FP tz = centerPoint.z * (FP.One - zScale);

            result.M11 = xScale;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;
            result.M21 = FP.Zero;
            result.M22 = yScale;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;
            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = zScale;
            result.M34 = FP.Zero;
            result.M41 = tx;
            result.M42 = ty;
            result.M43 = tz;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a scaling matrix.
        /// </summary>
        /// <param name="scales">The vector containing the amount to scale by on each axis.</param>
        /// <returns>The scaling matrix.</returns>
        public static TSMatrix4x4 CreateScale(TSVector scales)
        {
            return CreateScale(scales.x, scales.y, scales.z);
        }

        /// <summary>
        /// Creates a scaling matrix with a center point.
        /// </summary>
        /// <param name="scales">The vector containing the amount to scale by on each axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static TSMatrix4x4 CreateScale(TSVector scales, TSVector centerPoint)
        {
            return CreateScale(scales.x, scales.y, scales.z, centerPoint);
        }

        /// <summary>
        /// Creates a uniform scaling matrix that scales equally on each axis.
        /// </summary>
        /// <param name="scale">The uniform scaling factor.</param>
        /// <returns>The scaling matrix.</returns>
        public static TSMatrix4x4 CreateScale(FP scale)
        {
            return CreateScale(scale, scale, scale);
        }

        /// <summary>
        /// Creates a uniform scaling matrix that scales equally on each axis with a center point.
        /// </summary>
        /// <param name="scale">The uniform scaling factor.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static TSMatrix4x4 CreateScale(FP scale, TSVector centerPoint)
        {
            return CreateScale(scale, scale, scale, centerPoint);
        }

        /// <summary>
        /// Creates a matrix for rotating points around the X-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the X-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static TSMatrix4x4 CreateRotationX(FP radians)
        {
            TSMatrix4x4 result;

            FP c = TSMath.Cos(radians);
            FP s = TSMath.Sin(radians);

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  0  0  1 ]
            result.M11 = FP.One;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;
            result.M21 = FP.Zero;
            result.M22 = c;
            result.M23 = s;
            result.M24 = FP.Zero;
            result.M31 = FP.Zero;
            result.M32 = -s;
            result.M33 = c;
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the X-axis, from a center point.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the X-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static TSMatrix4x4 CreateRotationX(FP radians, TSVector centerPoint)
        {
            TSMatrix4x4 result;

            FP c = TSMath.Cos(radians);
            FP s = TSMath.Sin(radians);

            FP y = centerPoint.y * (FP.One - c) + centerPoint.z * s;
            FP z = centerPoint.z * (FP.One - c) - centerPoint.y * s;

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  y  z  1 ]
            result.M11 = FP.One;
            result.M12 = FP.Zero;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;
            result.M21 = FP.Zero;
            result.M22 = c;
            result.M23 = s;
            result.M24 = FP.Zero;
            result.M31 = FP.Zero;
            result.M32 = -s;
            result.M33 = c;
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = y;
            result.M43 = z;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Y-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Y-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static TSMatrix4x4 CreateRotationY(FP radians)
        {
            TSMatrix4x4 result;

            FP c = TSMath.Cos(radians);
            FP s = TSMath.Sin(radians);

            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  0  0  0  1 ]
            result.M11 = c;
            result.M12 = FP.Zero;
            result.M13 = -s;
            result.M14 = FP.Zero;
            result.M21 = FP.Zero;
            result.M22 = FP.One;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;
            result.M31 = s;
            result.M32 = FP.Zero;
            result.M33 = c;
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Y-axis, from a center point.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Y-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static TSMatrix4x4 CreateRotationY(float radians, TSVector centerPoint)
        {
            TSMatrix4x4 result;

            FP c = TSMath.Cos(radians);
            FP s = TSMath.Sin(radians);

            FP x = centerPoint.x * (FP.One - c) - centerPoint.z * s;
            FP z = centerPoint.x * (FP.One - c) + centerPoint.x * s;

            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  x  0  z  1 ]
            result.M11 = c;
            result.M12 = FP.Zero;
            result.M13 = -s;
            result.M14 = FP.Zero;
            result.M21 = FP.Zero;
            result.M22 = FP.One;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;
            result.M31 = s;
            result.M32 = FP.Zero;
            result.M33 = c;
            result.M34 = FP.Zero;
            result.M41 = x;
            result.M42 = FP.Zero;
            result.M43 = z;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Z-axis.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Z-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static TSMatrix4x4 CreateRotationZ(FP radians)
        {
            TSMatrix4x4 result;

            FP c = TSMath.Cos(radians);
            FP s = TSMath.Sin(radians);

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  0  0  0  1 ]
            result.M11 = c;
            result.M12 = s;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;
            result.M21 = -s;
            result.M22 = c;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;
            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = FP.One;
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix for rotating points around the Z-axis, from a center point.
        /// </summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Z-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static TSMatrix4x4 CreateRotationZ(FP radians, TSVector centerPoint)
        {
            TSMatrix4x4 result;

            FP c = TSMath.Cos(radians);
            FP s = TSMath.Sin(radians);

            FP x = centerPoint.x * (1 - c) + centerPoint.y * s;
            FP y = centerPoint.y * (1 - c) - centerPoint.x * s;

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  x  y  0  1 ]
            result.M11 = c;
            result.M12 = s;
            result.M13 = FP.Zero;
            result.M14 = FP.Zero;
            result.M21 = -s;
            result.M22 = c;
            result.M23 = FP.Zero;
            result.M24 = FP.Zero;
            result.M31 = FP.Zero;
            result.M32 = FP.Zero;
            result.M33 = FP.One;
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;

            return result;
        }

        /// <summary>
        /// Creates a matrix which rotates around the given axis by the given angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="result">The resulting rotation matrix</param>
        public static void CreateFromAxisAngle(ref TSVector axis, FP angle, out TSMatrix4x4 result)
        {
            // a: angle
            // x, y, z: unit vector for axis.
            //
            // Rotation matrix M can compute by using below equation.
            //
            //        T               T
            //  M = uu + (cos a)( I-uu ) + (sin a)S
            //
            // Where:
            //
            //  u = ( x, y, z )
            //
            //      [  0 -z  y ]
            //  S = [  z  0 -x ]
            //      [ -y  x  0 ]
            //
            //      [ 1 0 0 ]
            //  I = [ 0 1 0 ]
            //      [ 0 0 1 ]
            //
            //
            //     [  xx+cosa*(1-xx)   yx-cosa*yx-sina*z zx-cosa*xz+sina*y ]
            // M = [ xy-cosa*yx+sina*z    yy+cosa(1-yy)  yz-cosa*yz-sina*x ]
            //     [ zx-cosa*zx-sina*y zy-cosa*zy+sina*x   zz+cosa*(1-zz)  ]
            //
            FP x = axis.x, y = axis.y, z = axis.z;
            FP sa = TSMath.Sin(angle), ca = TSMath.Cos(angle);
            FP xx = x * x, yy = y * y, zz = z * z;
            FP xy = x * y, xz = x * z, yz = y * z;

            result.M11 = xx + ca * (FP.One - xx);
            result.M12 = xy - ca * xy + sa * z;
            result.M13 = xz - ca * xz - sa * y;
            result.M14 = FP.Zero;
            result.M21 = xy - ca * xy - sa * z;
            result.M22 = yy + ca * (FP.One - yy);
            result.M23 = yz - ca * yz + sa * x;
            result.M24 = FP.Zero;
            result.M31 = xz - ca * xz + sa * y;
            result.M32 = yz - ca * yz - sa * x;
            result.M33 = zz + ca * (FP.One - zz);
            result.M34 = FP.Zero;
            result.M41 = FP.Zero;
            result.M42 = FP.Zero;
            result.M43 = FP.Zero;
            result.M44 = FP.One;
        }

        /// <summary>
        /// Creates a matrix which rotates around the given axis by the given angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>The resulting rotation matrix</returns>
        public static TSMatrix4x4 AngleAxis(FP angle, TSVector axis)
        {
            TSMatrix4x4 result;
            CreateFromAxisAngle(ref axis, angle, out result);
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}", 
                M11.RawValue, M12.RawValue, M13.RawValue, M14.RawValue,
                M21.RawValue, M22.RawValue, M23.RawValue, M24.RawValue,
                M31.RawValue, M32.RawValue, M33.RawValue, M34.RawValue,
                M41.RawValue, M42.RawValue, M43.RawValue, M44.RawValue);
        }

    }

}