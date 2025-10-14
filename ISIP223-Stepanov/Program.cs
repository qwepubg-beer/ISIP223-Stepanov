using System;
using System.Xml.Linq;

namespace GamePR6
{
    class Weapon
    {
        public string NameW;
        public int Damage;
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

        public Def(string name_d, int block)

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
        public Person(string name, int hp, int damage = 0, int def = 0, string type = "None")
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
            Person Goblin = new Person("Гоблин", 50, 10, 10, "G");
            Person Skelet = new Person("Скелет", 60, 10, 10, "S");
            Person Mag = new Person("Маг", 40, 15, 10, "M");
            Person Grifin = new Person("ГВВ", 100, 15, 20, "G");
            Person Kov = new Person("Ковальский", 150, 23, 24, "S");
            Person cpp = new Person("GordovC++", 72, 26, 11, "M");
            Person cmm = new Person("PestovC--", 78, 16, 6, "S");
            Random rand = new Random();
            List<Person> enemies = new List<Person> { Goblin, Skelet, Mag };
            List<Person> Bosses = new List<Person> { Grifin, Kov, cpp, cmm };
            Console.WriteLine("Добро пожаловать в игру Спернимонов против нежити");
            Console.WriteLine("Выбирите уровень сложности");
            Console.WriteLine("1 - Сперминов прайм");
            Console.WriteLine("2 - Сперминов в Хогвартсе");
            Console.WriteLine("3 - Сперминов в КипФине");
            string Choose = Console.ReadLine();
            switch (Choose)
            {
                case "1":
                    Sperminov.Damage = Axe.Damage; Sperminov.Def = shield.Block;
                    break;
                case "2":
                    Sperminov.Damage = bow.Damage; Sperminov.Def = iron_armor.Block;
                    break;
                case "3":
                    Sperminov.Damage = Sword.Damage; Sperminov.Def = leather_armor.Block;
                    break;
                default:
                    Sperminov.Damage = bow.Damage; Sperminov.Def = iron_armor.Block;

                    break;
            }
            Console.WriteLine("Нажмите для продолжения\n");
            Console.ReadKey();
            Console.Clear();
            battlesystem(Sperminov, Bosses, enemies);

        }
        static void battle(Person p, Person e)
        {
            while (p.Hp > 0 && e.Hp > 0)
            {
                Random random = new Random();
                if (p.Hp <= 0) { Console.WriteLine("Вы проиграли"); break; }
                Console.WriteLine($"Здоровье Сперминова = {p.Hp}");
                Console.WriteLine($"Здоровье Врага {e.Name} = {e.Hp}");
                Console.WriteLine("Выбирите действие: 1-атака, 2-защита");
                string Choose = Console.ReadLine();
                switch (Choose)
                {
                    case "1": if (random.Next(0, 100) <= 25 && e.Type=="M" ){ Console.WriteLine("Маг отразил вашу атаку");  break; } else {attack(p, e);break; }
                    case "2": defend(p, e); break;
                            default: attack(p, e); break;
                            }
                if (e.Hp > 0) { attack(e, p); }
            }
        }
        static void attack(Person p, Person e)
        {
            Random random = new Random();
            switch (p.Type)
            {
                case "G": if (random.Next(0, 100) <= 40) { Console.WriteLine("Гоблин наносит двойной урон"); e.Hp -= 2*p.Damage; break; } else { e.Hp -= p.Damage; break; }
                default: e.Hp -= p.Damage;break;
            }
           
        }
        static void defend(Person p, Person e)
        {
            Random random = new Random();
            if (random.Next(1, 100) > 50)
            {
                if (e.Type == "S") { Console.WriteLine("Скелет игнорирует защиту"); p.Hp -= e.Damage; }
                else {p.Hp -= e.Damage * ((100 - p.Def) / 100); }
            }
           
        }
        static void CaseorBattle(Person p, Person e)
        {
            Thread.Sleep(1000);
            Console.Clear();
            Random random = new Random();
            if (random.Next(2) == 1)
            {
                Console.WriteLine("Бой начинается");
                battle(p, e);
            }
            else if (random.Next(2) == 0)
            {
                Console.WriteLine("Вам выпал кейс");
                Case(p);
            }
        }
        static void Case(Person p)
        {
            List<double> list = new List<double> { 1.1, 1.15, 1.2, 1.25 };
            Random random = new Random();
            if (random.Next(3) == 0)
            {
                p.Hp = p.BHp;
                Console.WriteLine("Вам выпало зелье регенерации. Вы исцелены");
            }
            else
            {
                if (random.Next(2) == 1)
                {
                    int a = random.Next(4);
                    p.BHp *= list[a];
                    Console.WriteLine($"Вам выпало усиление здоровья в {list[a]}");
                }
                else
                {
                    int a = random.Next(4);
                    p.Damage *= list[a];
                    Console.WriteLine($"Вам выпало усиление урона в {list[a]}");
                }
             }
            Console.WriteLine("Нажмите для продолжения\n");
            Console.ReadKey();
        }
        static void battlesystem(Person p,List<Person> Bosses, List<Person> enemies)
        {
            int round = 0;
            Random rand = new Random();
            while (p.Hp > 0)
            {
                round+=1;
                Console.WriteLine($"Раунд {round}");
                if (round == 10) { Console.WriteLine($"Битва с босом"); CaseorBattle(p, Bosses[rand.Next(0, 4)]); }
                else { CaseorBattle(p, enemies[rand.Next(0, 3)]); }
            }
            Console.WriteLine("Вы проиграли");
        }
 }
}
