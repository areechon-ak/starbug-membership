using System;
namespace Project
{
    class CoffeeFree
    {
        private string type;
        private int rStar;
        private double stars;
        private int cup;
        private Member m;

        public CoffeeFree(string ty, int rs, int c)
        {
            type = ty;
            rStar = rs;
            cup = c;

        }
        public string Type
        {
            get { return type; }
        }
        public double RStar
        {
            get { return rStar; }
        }
        public int Cup
        {
            get { return cup; }
        }

    }
}
