/*
 * Written by Benjamin Mestdagh (2013)
 * 
 */

using System;

namespace EuclidExtended {
    public class EuclidExtended {
        private long a, b;

        public EuclidExtended (long a, long b) {
            this.a = a;
            this.b = b;
        }

        public EuclidExtendedSolution calculate () {
            long x0, xn = 1;
            long y0, yn = 0;
            long x1 = 0;
            long y1 = 1;
            long r = a % b;

            while (r > 0) {
                q = a / b;
                xn = x0 - q * x1;
                yn = y0 - q * y1;

                x0 = x1;
                y0 = y1;
                x1 = xn;
                y1 = yn;
                a = b;
                b = r;
                r = a % b;
            }

            return new EuclidExtendedSolution (xn, yn, b);
        }

    }
}