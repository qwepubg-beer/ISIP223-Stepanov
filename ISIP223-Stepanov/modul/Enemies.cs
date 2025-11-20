using GamePR6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov.modul
{
    internal class Enemies
    {
        public class Enemy
        {
            public string Name { get; set; }
            public double Hp { get; set; }
            public double BHp { get; set; }
            public double Damage { get; set; }
            public int Def { get; set; }
            public string Type { get; set; }
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
        static public Enemy Goblin = new Enemy("Гоблин", 50, 10, 10, "G");
        static public Enemy Skelet = new Enemy("Скелет", 50, 10, 10, "S");
        static public Enemy Mag = new Enemy("Маг", 40, 15, 10, "M");
        static public Enemy Slizen = new Enemy("Слизень", 50, 10, 10, "C");
        static public Enemy Grifin = new Enemy("ГВВ", 100, 24, 20, "G");
        static public Enemy Kov = new Enemy("Ковальский", 120, 20, 20, "S");
        static public Enemy cpp = new Enemy("GordovC++", 72, 26, 11, "M");
        static public Enemy cmm = new Enemy("PestovC--", 78, 16, 6, "S");
        static public Enemy Lev = new Enemy("LEV", 50, 30, 6, "M");
        static public List<Enemy> enemies = new List<Enemy> { Goblin, Skelet, Mag, Slizen };
        static public List<Enemy> Bosses = new List<Enemy> { Grifin, Kov, cpp, cmm, Lev};
    }
}
