using System;
using System.Xml.Linq;

namespace GamePR6
{
    class Weapon
    {
        public string NameW;
        public int  Damage;
        public Weapon(string name_d, int block)

        {
            NameW = name_d;
            Damage = block;
        }
    }
    class Def
    {
        public string NameD;
        public int Block;
        
        public Def( string name_d, int block)
            
        {
            NameD = name_d;
            Block = block;
           
        }
    }
    class Person
    {
        public string Name;
        public double Hp;
        public double BHp;
        public double Damage;
        public int Def;
        public string Type;
        public Person(string name, int hp, int damage=0, int def=0, string type="None")
        {
            Name = name;
            Hp = hp;
            Damage = damage;
            Def = def;
            Type = type;
            BHp = hp;

        }
    }
    class Program
    {
        static Weapon Sword = new Weapon("Меч", 10);
        static Weapon Axe = new Weapon("Топор", 15);
        static Weapon bow = new Weapon("Лук", 12);
        static Def shield = new Def("Щит", 60);
        static Def leather_armor = new Def("Кожанка", 20);
        static Def iron_armor = new Def("Кальчуга", 40);
        
        static void Main(string[] args)
        {
            Person Sperminov = new Person("Сперминов", 100);
            Person Goblin = new Person("Гоблин", 50,10,10,"G");
            Person Skelet = new Person("Скелет", 60, 10, 10, "S");
            Person Mag = new Person("Маг", 40, 15, 10, "M");
            Person Grifin = new Person("ГВВ",100,15,20,"G");
            Person Kov = new Person("Ковальский", 150, 23, 24 , "S");
            Person cpp = new Person("GordovC++", 72, 26, 11, "M");
            Person cmm = new Person("PestovC--", 78, 16, 6, "S");
            Random rand = new Random();
            List<Person> enemies = new List<Person> { Goblin, Skelet, Mag };
            List<Person> Bosses = new List<Person> { Grifin,Kov,cpp,cmm };
            Console.WriteLine("Добро пожаловать в игру Спернимонов против нежити");
            Console.WriteLine("Выбирите уровень сложности");
            Console.WriteLine("1 - Сперминов прайм");
            Console.WriteLine("2 - Сперминов в Хогвартсе");
            Console.WriteLine("3 - Сперминов в КипФине");
            string Choose=Console.ReadLine();
            switch (Choose)
            {
                case "1":Sperminov.Damage = Axe.Damage; Sperminov.Def = shield.Block;
                    break;
                case "2":Sperminov.Damage = bow.Damage; Sperminov.Def = iron_armor.Block;
                    break;
                case "3":Sperminov.Damage = Sword.Damage; Sperminov.Def = leather_armor.Block;
                    break;
                default:Sperminov.Damage = bow.Damage; Sperminov.Def = iron_armor.Block;
   
                    break;
            }
            Console.WriteLine("Нажмите для продолжения\n");
            Console.ReadKey();
            Console.Clear();
            
            for (int i = 0; i <= 10; i++)
            {
                if (i==10) CaseorBattle(Sperminov, Bosses[rand.Next(0,3)]);
                CaseorBattle(Sperminov, enemies[rand.Next(0, 2)]);
            }
            

        }
        static void battle(Person p, Person e)
        {
            while (p.Hp >= 0 && e.Hp >= 0)
            { 
                Console.WriteLine("Выбирите действие");
                string Choose = Console.ReadLine();
                switch(Choose)
                {
                    case "1":attack(p, e);break;
                    case "2":defend(p, e);break;
                    default: attack(p, e); break;
                }
                attack(e, p);
            }
        }
        static void attack(Person p, Person e)
        {
            e.Hp-=p.Damage;
        }
        static double defend(Person p, Person e)
        {
            Random random = new Random();
            if (random.Next(1, 100) > 40)
            {
                return p.Hp-=e.Damage*((100-p.Def)/100);
            }
            else { return p.Hp; }
        }
        static void CaseorBattle(Person p, Person e)
        {
            Random random = new Random();
            if (random.Next(1, 2) == 1)
            {
            Console.WriteLine("Бой начинается");
               battle(p, e);
            }
            //Thread.Sleep
            else
            {
                Console.WriteLine("Вам выпал кейс");
                Case(p);
            }
        }
        static void Case (Person p)
        {
            List<double> list = new List<double> { 1.1, 1.2, 1.3, 1.4 };   
            Random random = new Random();
            if (random.Next(1, 2) == 1)
            {
                p.Hp = p.BHp;
                Console.WriteLine("Вам выпало зелье регенерации. Вы исцелены");
            }
            else
            {
                if (random.Next(1, 2) == 1)
                {
                    int a = random.Next(0, 3);
                    p.BHp *= list[a];
                    Console.WriteLine($"Вам выпало усиление здоровья на {list[a]}");
                }
                else
                {
                    int a = random.Next(0, 3);
                    p.Damage *= list[a];
                    Console.WriteLine($"Вам выпало усиление урона на {list[a]}");
                }
            }
        }
        static void cb(Person p, Person e)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (i == 10) { }
                else { CaseorBattle(p, e); }
            }
        }
}
}
