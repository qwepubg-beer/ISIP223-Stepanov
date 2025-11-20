using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov.modul
{
    internal class Weapons
    {
        static public Weapon Sword = new Weapon("Меч", 10);
        static public Weapon Axe = new Weapon("Топор", 15);
        static public Weapon bow = new Weapon("Лук", 12);
        public class Weapon
        {
            public string NameW;
            public int Damage;
            public Weapon(string name_d, int block)

            {
                NameW = name_d;
                Damage = block;
            }
        }
        
    }
}
