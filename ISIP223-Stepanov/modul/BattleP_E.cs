using ISIP223_Stepanov.modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ISIP223_Stepanov.modul.Enemies;

namespace ISIP223_Stepanov.modul
{
     
    internal class BattleP_E
    {
        static void Main(string[] args)
        {
            RandomZ rand = new RandomZ();
            Menu.PrintMenu();
            string Choose = Console.ReadLine();
            Persons.Person Sperminov= Persons.SetSperminov();
            Menu.Continue();
            battlesystem(Sperminov, Bosses, enemies);

        }
        static void battle(Persons.Person p, Enemy e)
        {
            while (p.Hp > 0 && e.Hp > 0)
            {
                RandomZ random = new RandomZ();
                if (p.Hp <= 0) { Console.WriteLine("Вы проиграли"); break; }
                Console.WriteLine($"Здоровье Сперминова = {p.Hp}");
                Console.WriteLine($"Здоровье Врага {e.Name} = {e.Hp}");
                Console.WriteLine("Выбирите действие: 1-атака");
                string Choose = Console.ReadLine();

                switch (Choose)
                {
                    case "1": if (RandomZ.R100() <= 25 && e.Type == "M") { Console.WriteLine("Маг отразил вашу атаку"); break; } else { defend(p, e); break; }

                    default:
                        defend(p, e); break;
                }
                if (e.Hp > 0)
                {
                    defend(e, p);
                }
            }
        }
        static void attack(Persons.Person p, Enemy e, double attack)
        {

            e.Hp -= attack;

        }
        static void defend(Persons.Person p, Enemy e)
        {
            double damage = p.Damage;
            RandomZ random = new RandomZ();
            switch (e.Type)
            {
                case "G":
                    if (RandomZ.R100() <= 40)
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
        static void CaseorBattle(Persons.Person p, Enemy e)
        {
            Thread.Sleep(1000);
            Console.Clear();
            if (RandomZ.R2() == 1)
            {
                Console.WriteLine("Бой начинается");
                battle(p, e);
            }
            else if (RandomZ.R2() == 0)
            {
                Console.WriteLine("Вам выпал кейс");
                Case(p);
            }
        }
        static void Case(Persons.Person p)
        {
            List<double> list = new List<double> { 1.1, 1.15, 1.2, 1.25 };
            RandomZ random = new RandomZ();
            if (RandomZ.R2() == 0)
            {
                p.Hp = p.BHp;
                Console.WriteLine("Вам выпало зелье регенерации. Вы исцелены");
            }
            else
            {
                if (RandomZ.R2() == 1)
                {
                    int a = RandomZ.R4();
                    p.BHp *= list[a];
                    Console.WriteLine($"Вам выпало усиление здоровья в {list[a]}");
                }
                else
                {
                    int a = RandomZ.R4();
                    p.Damage *= list[a];
                    Console.WriteLine($"Вам выпало усиление урона на {list[a]}");
                }
            }
            Console.WriteLine("Нажмите для продолжения\n");
            Console.ReadKey();
        }
        static void battlesystem(Persons.Person p, List<Enemies.Enemy> enemies, List<Enemies.Enemy> bosses)
        {
            int round = 0;
            RandomZ rand = new RandomZ();

            while (p.Hp > 0)
            {
                foreach (Enemies.Enemy a in enemies)
                {
                    a.Hp = a.BHp;
                }
                foreach (Enemies.Enemy a in enemies)
                {
                    a.Hp = a.BHp;
                }
                round += 1;
                Console.WriteLine($"Раунд {round}");
                if (round == 10) { Console.WriteLine($"Битва с босом"); battle(p, Bosses[RandomZ.R4()]); }
                else { CaseorBattle(p, enemies[RandomZ.R3()]); }
            }
            Console.WriteLine("Вы проиграли");
        }
    }
}
