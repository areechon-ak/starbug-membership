using System;
using System.Collections;
namespace Project
{
    public class Sale
    {
        private double total;
        private double stars;
        private Member m;
        private ArrayList saleitem = new ArrayList();

        private ArrayList SaleItem
        { get { return saleitem = new ArrayList(); } }

        public Sale()
        {
            total = 0;
        }

        public void recordSaleItem(int q, Menu m) 
        {
            SaleItem si = new SaleItem(q, m);
            saleitem.Add(si);
            total += si.Total;
        }

        public double Total
        { get { return total; } }
    
        public void Print(Member m)
        {
            Console.WriteLine("Starbug\nRama4 Rd., Pathumwan, "
                + "Bangkok 10330\nTel: 0-2222-1111");
            for (int i = 0; i < saleitem.Count; i++)
                ((SaleItem)saleitem[i]).print();
            this.m = m;
            stars=m.ExchangeStar(total);
            double starsI = Math.Floor(stars);
            Console.WriteLine("Total\t\t\t" + total);
            Console.WriteLine("Total Stars\t\t\t " + starsI);
            
        }

        public void Print()
        {
            Console.WriteLine("Starbug\nRama4 Rd., Pathumwan, "
                + "Bangkok 10330\nTel: 0-2222-1111");
            for (int i = 0; i < saleitem.Count; i++)
                ((SaleItem)saleitem[i]).print();
            Console.WriteLine("Total\t\t\t" + total);

        }

    }

    class SaleItem
    {
        private int quantity;
        private double sale;
        private Menu menu;
        public SaleItem(int q, Menu m)
        {

            quantity = q;
            menu = m;
            sale = q * menu.Price;
        }
        public double Total
        { get { return sale; } }

        public int Quantity
        { get { return quantity; } }

        public string MName
        { get { return menu.Name; } }

        public void print()
        {
            Console.WriteLine(menu.Name + "\t" + quantity + "\t@"
                + menu.Price + "\t" + sale);
        }
    }
}

