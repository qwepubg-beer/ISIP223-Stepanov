using ISIP223_Stepanov.modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov.modul
{
    internal class Persons
    {
        public class Person
        {
            public string Name { get; set; }
            public double Hp { get; set; }
            public double BHp { get; set; }
            public double Damage { get; set; }
            public int Def { get; set; }
            public Person(string name, int hp, int damage = 0, int def = 0)
            {
                Name = name;
                Hp = hp;
                Damage = damage;
                Def = def;
                BHp = hp;

            }

        }
        static public Person SetSperminov()
        {
            string Choose = Console.ReadLine();
            Person Sperminov = new Person("Сперминов", 100);
            switch (Choose)
            { 
               case "1":
                    Sperminov.Damage = Weapons.Axe.Damage; Sperminov.Def = Defends.shield.Block;
                    break;
                case "2":
                    Sperminov.Damage = Weapons.bow.Damage; Sperminov.Def = Defends.iron_armor.Block;
                    break;
                case "3":
                    Sperminov.Damage = Weapons.Sword.Damage; Sperminov.Def = Defends.leather_armor.Block;
                    break;
                default:
                    Sperminov.Damage = Weapons.bow.Damage; Sperminov.Def = Defends.iron_armor.Block;
                    break;
                }
            return Sperminov;
        }
        static void PrintPersonInfo(Person p, Enemies.Enemy e)
        {
            Console.WriteLine($"Здоровье Сперминова = {p.Hp}");
            Console.WriteLine($"Здоровье Врага {e.Name} = {e.Hp}");
            Console.WriteLine("Выбирите действие: 1-атака");
        }
    }
}
