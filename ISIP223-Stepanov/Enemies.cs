using GamePR6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov
{
    internal class Enemies
    {
        class Enemy
        {
            public string Name;
            public double Hp;
            public double BHp;
            public double Damage;
            public int Def;
            public string Type;
            public Enemy(string name, int hp, int damage = 0, int def = 0, string type = "None")
            {
                Name = name;
                Hp = hp;
                Damage = damage;
                Def = def;
                Type = type;
                BHp = hp;

            }

        }
        static Enemy Goblin = new Enemy("Гоблин", 50, 10, 10, "G");
        static Enemy Skelet = new Enemy("Скелет", 50, 10, 10, "S");
        static Enemy Mag = new Enemy("Маг", 40, 15, 10, "M");
        static Enemy Grifin = new Enemy("ГВВ", 100, 24, 20, "G");
        static Enemy Kov = new Enemy("Ковальский", 120, 20, 20, "S");
        static Enemy cpp = new Enemy("GordovC++", 72, 26, 11, "M");
        static Enemy cmm = new Enemy("PestovC--", 78, 16, 6, "S");
        static List<Enemy> enemies = new List<Enemy> { Goblin, Skelet, Mag };
        static List<Enemy> Bosses = new List<Enemy> { Grifin, Kov, cpp, cmm };
    }
}
