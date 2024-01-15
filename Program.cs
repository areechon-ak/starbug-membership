using System;
using System.Collections;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList num = new SortedList();

            ArrayList menu = new ArrayList();
            menu.Add(new Menu("Latte", 120));
            menu.Add(new Menu("Capucchino", 130));
            menu.Add(new Menu("Mocha", 140));
            menu.Add(new Menu("Americano", 150));
            menu.Add(new Menu("Chocolate", 120));
            menu.Add(new Menu("Banana Muffin", 60));
            menu.Add(new Menu("Blue Berry Muffin", 70));
            menu.Add(new Menu("Soft Cookie", 50));

            CoffeeFree[] cf = new CoffeeFree[3];
            cf[0] = new CoffeeFree("1 cup", 100, 1);
            cf[1] = new CoffeeFree("2 cup", 300, 2);
            cf[2] = new CoffeeFree("3 cup", 500, 3);


            ArrayList sale = new ArrayList();

            char more;

            Console.Write("menu\n1.Register\n2.Buy\n3.Redeem Coffee\n");
            Console.Write("\nEnter your choice -> ");

            int ch = Convert.ToInt32(Console.ReadLine());
            do
            {
                Sale s = new Sale();
                sale.Add(s);
                if (ch == 1) //Register
                {
                    Console.Write("\n*****************************\n");
                    Console.Write("\nEnter the customer name -> ");
                    string name = Convert.ToString(Console.ReadLine());
                    Console.Write("\nEnter the customer's telephone number -> ");
                    string t = Convert.ToString(Console.ReadLine());
                    Console.Write("\n*****************************\n");
                    Console.Write("\nStaff enter the customer's number card here -> ");
                    string n = Convert.ToString(Console.ReadLine());

                    if (num.Contains(n) == true)
                    {
                        Console.Write("\n*****************************\n");
                        Console.Write("\nthis number card is already register");
                    }
                    else
                    {
                        num.Add(n, new Member(name, t, n));
                    }
                }

                if (ch == 2) //Buy
                {
                    do
                    {
                        Console.Write("\n*** Starbug Welcome ***");
                        for (int i = 0; i < menu.Count; i++)
                        {
                            Console.Write("\n" + (i + 1) + ". " + ((Menu)menu[i]).Name + "\t" + ((Menu)menu[i]).Price);
                        }
                        Console.Write("\nYour selection -> ");
                        int c;
                        try
                        {
                            c = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e) 
                        { 
                            Console.WriteLine("error : Please enter only (1-8)");
                            c = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.Write("\nEnter the quantiy -> ");
                        int q;
                        try
                        {
                            q = Convert.ToInt32(Console.ReadLine());
                            s.recordSaleItem(q, (Menu)menu[c - 1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("error : Please enter only integer");
                            q = Convert.ToInt32(Console.ReadLine());
                        }
                        
                        Console.Write("\nBuy more? (y/n): ");
                        more = Convert.ToChar(Console.ReadLine());
                    } while (more == 'y');
                    Console.Write("\nMember ? (y/n) : ");
                    char type = Convert.ToChar(Console.ReadLine());
                    if (type == 'y')
                    {
                        Console.Write("\nEnter the customer's number card here -> ");
                        string n;
                        try
                        {
                            n = Convert.ToString(Console.ReadLine());
                            s.Print((Member)num[n]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("error : Can not find this number Please enter again ");
                        }
                    }
                    else s.Print();

                }

                if (ch == 3) //Redeem
                {
                    Console.Write("\nEnter the customer's number card here -> ");
                    string n = Convert.ToString(Console.ReadLine());
                    if (num.Contains(n) == true)
                    {
                        Console.WriteLine("\nCustomer Name : " + ((Member)(num[n])).Name);
                        Console.WriteLine("\nTelephone Number : " + ((Member)(num[n])).Tel);
                        double stars = ((Member)(num[n])).Cstars;
                        double starsI = Math.Floor(stars);
                        Console.WriteLine("\nTotal Stars : " + starsI);
                        if (DateTime.Today.Month == 12)
                        {
                            Console.Write("type of redeem coffee\n1.100 stars per 1 cup\n2.300 stars per 2 cup\n3.500 stars per 3 cup");
                            Console.Write("\nEnter the type of free cup -> ");
                            int type = Convert.ToInt32(Console.ReadLine());
                            double rs = cf[type - 1].RStar;
                            if (rs <= ((Member)num[n]).Cstars)
                            {
                                int q = cf[type - 1].Cup;
                                Console.Write("\n\n...............................................");
                                Console.Write("\nStarbug Card Number : " + n);
                                Console.Write("\nCustomer Name : " + ((Member)(num[n])).Name);
                                Console.Write("\nthe amount of free cup : " + q);
                                Console.Write("\nstars for redeeming : " + cf[type - 1].RStar);
                                stars = ((Member)(num[n])).DeductStar(rs);
                                starsI = Math.Floor(stars);
                                Console.Write("\ncurrent points : " + starsI);
                                Console.Write("\n...............................................");
                            }
                            else
                            {
                                Console.Write("\nSTARS ARE NOT ENOUGH!! ");
                            }
                        }
                        else Console.WriteLine("!!WE ARE NOT IN THE CAMPAIGN YET!!");
                    }
                    else Console.Write("\n!!THIS CUSTOMER IS NOT OUR MEMBERSHIP!!");

                }
                Console.Write("\n*****************************\n");
                Console.Write("\nmenu\n1.Register\n2.Buy\n3.Redeem Coffee\n");
                Console.Write("\nEnter your choice -> ");
                ch = Convert.ToInt32(Console.ReadLine());
            } while (ch != 4);

        }
    }
}

