using System;
using System.Collections;
namespace Project
{
    public class Star
    {
        private double stars;

        public Star()
        {
            stars = 0;
        }

        public double Stars
        { get { return stars; } }

        public double CStar(double s)
        {
            return stars += s; 
        }
        public double Redeem(double r)
        {
            return stars -= r;
        }
    }
}


