using System;
using System.Xml.Linq;

namespace GamePR6
{
        
    class Program
    {
         static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Добро пожаловать в игру Спернимонов против нежити");
            Console.WriteLine("Выбирите уровень сложности");
            Console.WriteLine("1 - Сперминов прайм");
            Console.WriteLine("2 - Сперминов в Хогвартсе");
            Console.WriteLine("3 - Сперминов в КипФине");
            string Choose = Console.ReadLine();
            switch (Choose)
            {
                case "1":
                    Sperminov.Damage = Weapons.Axe.Damage; Sperminov.Def = shield.Block;
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
        static void battle(Person p, Enemy e)
        {
            while (p.Hp > 0 && e.Hp > 0)
            {
                Random random = new Random();
                if (p.Hp <= 0) { Console.WriteLine("Вы проиграли"); break; }
                Console.WriteLine($"Здоровье Сперминова = {p.Hp}");
                Console.WriteLine($"Здоровье Врага {e.Name} = {e.Hp}");
                Console.WriteLine("Выбирите действие: 1-атака");
                string Choose = Console.ReadLine();

                switch (Choose)
                {
                    case "1": if (random.Next(0, 100) <= 25 && e.Type == "M") { Console.WriteLine("Маг отразил вашу атаку"); break; } else { defend(p, e); break; }

                    default:
                        defend(p, e); break;
                }
                if (e.Hp > 0)
                {
                    defend(e, p);
                }
            }
        }
        static void attack(Person p, Person e, double attack)
        {
            
            e.Hp -= attack;

        }
        static void defend(Person p, Person e)
        {
            double damage = p.Damage;
            Random random = new Random();
            switch (p.Type)
            {
                case "G":
                    if (random.Next(0, 100) <= 40)
                    {
                        Console.WriteLine("Гоблин наносит двойной урон");
                        damage = p.Damage * (100 - e.Def) / 50;
                        break;
                    }
                    else { damage = p.Damage * (100 - e.Def) / 100; break; }

                case "M": damage = p.Damage * (100 - e.Def) / 50; break;

                case "S": Console.WriteLine("Скелет игнорирует защиту"); damage = p.Damage; break;
            }
            attack(p, e, damage);
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
            if (random.Next(2) == 0)
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
        static void battlesystem(Person p, List<Person> Bosses, List<Person> enemies)
        {
            int round = 0;
            Random rand = new Random();

            while (p.Hp > 0)
            {
                foreach (Person a in enemies)
                {
                    a.Hp = a.BHp;
                }
                foreach (Person a in enemies)
                {
                    a.Hp = a.BHp;
                }
                round += 1;
                Console.WriteLine($"Раунд {round}");
                if (round == 10) { Console.WriteLine($"Битва с босом"); battle(p, Bosses[rand.Next(4)]); }
                else { CaseorBattle(p, enemies[rand.Next(3)]); }
            }
            Console.WriteLine("Вы проиграли");
        }
    }
}
