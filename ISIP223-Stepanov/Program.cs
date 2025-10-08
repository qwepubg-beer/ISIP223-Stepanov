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

        }
        void battle(Person p, Person e)
        {
            while (p.Hp >= 0 && e.Hp >= 0)
            {
                attack(p, e);
                attack(e, p);
            }
        }
        void attack(Person p, Person e)
        {
           e.Hp-=defend(p.Damage,e.Def);
        }
        double defend(double damage,double defend)
        {
            Random random = new Random();
            if (random.Next(1, 100) < 40)
            {
                return damage/100*(100-defend);
            }
            else { return 0; }
        }
        void CaseorBattle(Person p, Person e)
        {
            Random random = new Random();
            if (random.Next(1, 2) == 1)
            {
               battle(p, e);
            }
            else
            {
                Case(p);
            }
        }
        void Case (Person p)
        {
            List<double> list = new List<double> { 1.1, 1.2, 1.3, 1.4 };   
            Random random = new Random();
            if (random.Next(1, 2) == 1)
            {
                p.Hp = p.BHp;
                Console.WriteLine("Вы исцелены");
            }
            else
            {
                if (random.Next(1, 2) == 1)
                {
                    int a = random.Next(0, 3);
                    p.BHp *= list[a];
                }
                else
                {
                    int a = random.Next(0, 3);
                    p.Damage *= list[a];
                }
            }
        }
        void cb(Person p, Person e)
        {

            for (int i = 0; i <= 10; i++)
            {
                if (i == 10) { }
                else { CaseorBattle(p, e); }
            }
        }
}
}
