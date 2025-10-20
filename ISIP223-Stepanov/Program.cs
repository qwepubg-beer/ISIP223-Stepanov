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
        public Detail(string name, decimal priceMoney, decimal setMoney, int quantity)
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
        static void Main(string[] args)
        {

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
