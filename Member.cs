using System;
using System.Collections;
namespace Project
{
    public class Member
    {
        private string name;
        private string tel;
        private string CardNumber;
        private double Cstar;
        private Star star;
        private CoffeeFree cf;
        

        public Member(string n, string t, string num)
        {
            name = n;
            tel = t;
            CardNumber = num;
            star = new Star();
        }

        public string Name
        { get { return name; } }
        public string Tel
        { get { return tel; } }
        public double Cstars
        { get { return Cstar; } }

        public double ExchangeStar(double t)
        {
            double s = t / 100;
            Cstar=star.CStar(s) ;
            return Cstar;
        }
        public double DeductStar(double rs)
        {
            Cstar = star.Redeem(rs);
            return Cstar;
        }
    }
}
