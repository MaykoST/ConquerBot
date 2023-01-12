using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProxy
{
    public class MyMath
    {
        public static double LevelDifference(byte Lev1, byte Lev2)
        {
            if (Lev1 > Lev2)
            {
                double Rt = (Lev1 - Lev2 + 7) / 5;
                return Rt = ((Rt - 1) * 0.8) + 1;
            }
            return 1;
        }
        public static bool ChanceSuccess(double Chance)
        {
            int e = Constants.Rnd.Next(int.MaxValue);
            double a = ((double)e / (double)int.MaxValue) * 100;
            return Chance >= a;
        }
        public static double PointDirecton(double x1, double y1, double x2, double y2)
        {
            double direction = 0;

            double AddX = x2 - x1;
            double AddY = y2 - y1;
            double r = (double)Math.Atan2(AddY, AddX);

            if (r < 0) r += (double)Math.PI * 2;

            direction = 360 - (r * 180 / (double)Math.PI);
            return direction;
        }
        public static double PointDirecton2(double x1, double y1, double x2, double y2)
        {
            double direction = 0;

            double AddX = x2 - x1;
            double AddY = y2 - y1;
            double r = (double)Math.Atan2(AddY, AddX);

            direction = (r * 180 / (double)Math.PI);
            return direction;
        }
        public static double RadianToDegree(double r)
        {
            if (r < 0) r += (double)Math.PI * 2;

            double direction = 360 - (r * 180 / (double)Math.PI);
            return direction;
        }
        public static double DegreeToRadian(double degr)
        {
            return degr * Math.PI / 180;
        }
        public static double PointDirectonRad(double x1, double y1, double x2, double y2)
        {
            double AddX = x2 - x1;
            double AddY = y2 - y1;
            double r = (double)Math.Atan2(AddY, AddX);

            return r;
        }
        public static int PointDistance(double x1, double y1, double x2, double y2)
        {
            return (int)Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
        }
        public static bool InBox(double x1, double y1, double x2, double y2, byte Range)
        {
            return (Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2)) <= Range);
        }
        public static bool Inside(UInt16 pStartX, UInt16 pStartY, UInt16 pEndX, UInt16 pEndY, UInt16 pX, UInt16 pY)
        {
            if (pX >= pStartX && pX <= pEndX && pY >= pStartY && pY <= pEndY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
