using System;
namespace Project
{
    public class Menu
    {
        private string name;
        private double price;

        public Menu(string n, double p)
        {
            name = n;
            price = p;
        }

        public string Name
        { get { return name; } }

        public double Price
        { get { return price; } }
    }
}