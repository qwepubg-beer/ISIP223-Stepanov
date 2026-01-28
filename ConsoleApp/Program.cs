using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleApp;

namespace Avtoservis
{
       class Order
    {
        public string NameDetail { get; set; }
        public bool IsBuy { get; set; }
        public Order(string name, bool isBuy = false)
        {
            NameDetail = name;
            IsBuy = isBuy;
        }
    }
    class Program
    {
        static Details detail1 = new Details("Мотор", 100000, 50000,1, 2);
        static Details detail2 = new Details("Шина", 2000, 400, 1,16);
        static Details detail3 = new Details("Диск", 5000, 5000, 1,12);
        static Details detail4 = new Details("СтеклоЛоб", 15000, 5000,1, 2);
        static Details detail5 = new Details("СтеклоБок", 10000, 4000,1, 3);
        static Details detail6 = new Details("Бак", 20000, 7000,1, 3);
        static Details detail7 = new Details("Зеркало", 7000, 4000,1, 4);
        static void Main(string[] args)
        {
            Servises Gordov = new Servises ("Gordov",200000 );
            List<Details> details = new List<Details> { detail1, detail2, detail3, detail4, detail5, detail6, detail7 };
            Send(details,Gordov);
            int hod = 0;
            while (Gordov.Money > 0 && CountDetails(details)>0)
            {
                hod++;
                if (hod%2==0)
                {
                    Send2(details, Gordov);
                }
                Console.WriteLine("Выбирите действие");
                Console.WriteLine("1---Купить деталь");
                Console.WriteLine("2---Принять заказ");
                string choose =Console.ReadLine();
                switch(choose)
                {
                    case"1":
                        BayDetail(details, Gordov);
                        break;
                    case "2":
                        Offer(details[Rand(details)], Gordov ,details);
                        break;
                        default:
                        Offer(details[Rand(details)], Gordov, details);
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        static public void BayDetail(List<Details> Names, Servises avtoservis)
        {
            Console.WriteLine("Выбирите деталь по названию");
            for (int i = 0; i <= Names.Count-1; i++)
            {
                Console.WriteLine($"{i}---{Names[i].Name}");
            }
            int Detail_Name;
            while (!int.TryParse(Console.ReadLine(), out Detail_Name) || Detail_Name < 0)
            {
                Console.Write("Введите корректное значение!!!");
            }
            int Qa;
            Console.WriteLine("Введите колличество");
            while (!int.TryParse(Console.ReadLine(), out Qa) || Qa < 0)
            {
                Console.Write("Введите корректное значение!!!");
            }
            if (Names[Detail_Name].PriceMoney * Qa <= avtoservis.Money)
            {
                avtoservis.Money -= Names[Detail_Name].PriceMoney * Qa;
                Names[Detail_Name].Quantity += Qa;
                Console.WriteLine($"Детали куплены");
            }
            else
            {
                Console.WriteLine($"Але бизнес, где деньги");
            }
        }
        static public void Send(List<Details> Names,Servises servis)
        {
            Core.Context.Servises.Add(servis);
            Core.Context.SaveChanges();
            foreach (Details Name in Names)
            {
                Core.Context.Details.Add(Name);
            }
            Core.Context.SaveChanges();
        }
        static public void Send2(List<Details> Names, Servises servis)
        {
            Servises editServis = Core.Context.Servises.First(u => u.Name.Contains(servis.Name));
            Core.Context.SaveChanges();
            foreach (Details Name in Names)
            {
                Details editDetail = Core.Context.Details.First(u => u.Name.Contains(Name.Name));
            }
            Core.Context.SaveChanges();
        }
        static public void PrintDetals()
        {
            List<Details> Names = Core.Context.Details.ToList();
            foreach (Details detail in Names)
            {
                Console.WriteLine($"Название:{detail.Name} Стоимоть: {detail.PriceMoney} Колличество: {detail.Quantity}");
            }
        }
        static int CountDetails(List<Details> Names)
        {
            var total = 0;
            for (int i = 0; i < Names.Count; i++)
            {
                total += (int)Names[i].Quantity;
            }
            return total;
        }
        static public void Offer(Details detail, Servises servis,List<Details> details)
        {
            PrintDetals();
            Console.WriteLine("\n");
            Console.WriteLine($"Вам поступил новый заказ");
            Console.WriteLine($"У меня сломалась деталь {detail.Name}.Почините?");
            Console.WriteLine("1-Принять/2-Откланить");
            string choose = Console.ReadLine();
            bool flag = false;
            switch (choose)
            {
                case "1":
                    foreach(Details details1 in details)
                    {
                        if (details1.Name==detail.Name && detail.Quantity>=1)
                        {
                            details1.Quantity -= 1;
                            servis.Money += details1.SetMoney;
                            flag = true;
                        }
                }
                    if (flag) Console.WriteLine("Спасибо Максим, заеду к вам еще раз");
                    else { 
                        Console.WriteLine("У вас не было нужной детали,вы получите штраф");
                        int det = Rand(details);
                        details[det].Quantity -= 1;
                        servis.Money -= details[det].SetMoney/2;
                    }
                    break;
                        
                case "2":
                    Console.WriteLine("Вы получите штраф за отказ");
                    servis.Money -= 10000;
                    break;
            }
        }
        static int Rand( List<Details> ts)
        {
            Random rnd = new Random();
            return rnd.Next(ts.Count-1);
        }
    }
}
