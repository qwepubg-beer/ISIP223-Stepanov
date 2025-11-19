using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov
{
    internal class Weapons
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
        static Weapon Sword = new Weapon("Меч", 10);
        static Weapon Axe = new Weapon("Топор", 15);
        static Weapon bow = new Weapon("Лук", 12);
    }
}
