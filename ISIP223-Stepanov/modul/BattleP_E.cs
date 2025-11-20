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
        static public void StartGame()
        {
            RandomZ rand = new RandomZ();
            Menu.PrintMenu();
            string Choose = Console.ReadLine();
            Persons.Person Sperminov= Persons.SetSperminov(Choose);
            Menu.Continue();
            Console.Clear();    
            battlesystem(Sperminov,enemies,Bosses);

        }
        static void battle(Persons.Person p, Enemy e)
        {
            while (p.Hp > 0 && e.Hp > 0)
            {
                if (p.Hp <= 0) { Console.WriteLine("Вы проиграли"); break; }
                Console.WriteLine($"Здоровье Сперминова = {p.Hp}");
                Console.WriteLine($"Здоровье Врага {e.Name} = {e.Hp}");
                Console.WriteLine("Выбирите действие: 1-атака");
                string Choose = Console.ReadLine();

                switch (Choose)
                {
                    case "1": if (RandomZ.Freze() && e.Type == "M") { Console.WriteLine("Маг отразил вашу атаку"); break; } else { defend2(p, e); break; }
                    default:
                    defend2(p, e); break;
                }
                if (e.Hp > 0)
                {
                    defend(p, e);
                }
            }
        }
        static void attack(Persons.Person p, Enemy e, double attack,bool flag)
        {

            if (flag) { e.Hp -= attack; }
            else { p.Hp -= attack; }
        }
        
        static void defend(Persons.Person p, Enemy e)
        {
            double damage = e.Damage * (100 - e.Def)/100;
            
            switch (e.Type)
            {
                case "G":
                    
                    if (RandomZ.DoubleDamage())
                    {
                        Console.WriteLine("Гоблин наносит двойной урон");
                        damage *=2;
                        break;
                    }
                    else {break; }
                case "С":
                    damage -= 2;
                    break;

                case "S":
                    Console.WriteLine("Скелет игнорирует защиту"); 
                    damage = e.Damage; break;
            }
            attack(p, e, damage,false);
        }
        static void defend2(Persons.Person p, Enemy e)
        {
             double damage = p.Damage*(100 - e.Def)/100;
             attack(p, e, damage,true);
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
            else 
            {
                Console.WriteLine("Вам выпал кейс");
                Cases.Case(p);
            }
        }
        static void battlesystem(Persons.Person p, List<Enemies.Enemy> enemies, List<Enemies.Enemy> bosses)
        {
            int round = 0;
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
                Console.WriteLine($"бой номер {round}");
                if (round == 10) { Console.WriteLine($"Битва с босом"); battle(p, Bosses[RandomZ.R5()]); }
                else { CaseorBattle(p, enemies[RandomZ.R4()]); }
            }
            Console.WriteLine("Вы проиграли");
        }
    }
}
