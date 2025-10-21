using System.Data.SqlTypes;

namespace Avtoservis
{
    class Servis
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public Servis(string name, decimal money)
        {
            Name = name;
            Money = money;
        }
    }
    class Detail
    {
        public string Name { get; set; }
        public decimal PriceMoney { get; set; }
        public decimal SetMoney { get; set; }
        public int Quantity { get; set; }
        public Detail(string name, decimal priceMoney, decimal setMoney, int quantity,int servisID = 1)
        {
            Name = name;
            PriceMoney = priceMoney;
            SetMoney = setMoney;
            Quantity = quantity;
        }

    }
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
        static Detail detail1 = new Detail("Мотор", 100000,50000,2);
        static Detail detail2 = new Detail("Шина", 2000, 400, 16);
        static Detail detail3 = new Detail("Диск", 5000, 5000, 12);
        static Detail detail4 = new Detail("СтеклоЛоб", 15000, 5000, 2);
        static Detail detail5 = new Detail("СтеклоБок", 10000, 4000, 3);
        static Detail detail6 = new Detail("Бак", 20000, 7000, 3);
        static Detail detail7 = new Detail("Зеркало", 7000, 4000, 4);
       static void Main(string[] args)
        {
            Servis Gordovservis = new Servis("Gordov", 200000);
            List<Detail> details = new List<Detail> { detail1, detail2, detail3, detail4, detail5, detail6, detail7 };
        }
        static public void BayDetail(List<Detail> Names, Servis avtoservis)
        {
            Console.WriteLine("Выбирите деталь по названию");
            for (int i = 0; i <= Names.Count; i++)
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
        static public void Send(List<Detail> Names)
        {
            //отправка на бд
        }
        static public void PrintDetals(List<Detail> Names)
        {
            foreach (Detail detail in Names)
            {
                Console.WriteLine($"Название:{detail.Name} Стоимоть: {detail.PriceMoney} Колличество: {detail.Quantity}");
            }
        }
        static public void Offer(Detail detail, Servis servis)
        {
            PrintDetals();
            Console.WriteLine($"Вам поступил новый заказ");
            Console.WriteLine($"У меня сломалась деталь {detail.Name}.Почините?");
            Console.WriteLine("1-Принять/2-Откланить");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    
                        if()
                    break;
                case "2": break;
            }
        }
    }
}
