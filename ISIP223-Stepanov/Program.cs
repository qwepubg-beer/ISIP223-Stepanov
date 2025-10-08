using System.Xml.Linq;

namespace GamePR6
{
    class Weapon
    {
        public string NameW;
        public int  Damage;
        public Weapon(string name, int damage)
        {
            NameW = name;
            Damage = damage;
        }
    }
    class Def : Weapon
    {
        public string NameD;
        public int Block;
        public Def(string name_w, int damage, string name_d, int block)
            : base(name_w, damage)
        {
            NameD = name_d;
            Damage = damage;
        }
    }
    class Player : Def
    {
        public string NameP;
        public float Hp;
        public float BHp;
        public Player(string name_w, int damage, string name_d, int block, string name_p, int hp)
            : base(name_w, damage, name_p, hp)
        {
            NameP = name_p;
            Hp = hp;
            BHp= hp;
        }
    }

    class Enemy
    {
        public string Name;
        public float Hp;
        public int Damage;
        public int Def;
        public string Type;
        public Enemy(string name, int hp, int damage, int def, string type)
        {
            Name = name;
            Hp = hp;
            Damage = damage;
            Def = def;
            Type = type;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (i == 10) { }
                else { CaseorBattle()}
            }
        }
        void battle(Player p, Enemy e)
        {
            while (p.Hp >= 0 && e.Hp >= 0)
            {
                attack(p, e, 1);
                attack(p, e, 2);
            }
        }
        void attack(Player p, Enemy e, int a)
        {
            if (a == 1) {e.Hp-=defend(p.Damage,e.Def);}
            if (a == 2) { p.Hp -= defend(e.Damage, p.Block); }
        }
        float defend(int damage,int defend)
        {
            Random random = new Random();
            if (random.Next(1, 100) < defend)
            {
                return damage;
            }
            else { return 0; }
        }
        void CaseorBattle(Player p, Enemy e)
        {
            Random random = new Random();
            if (random.Next(1, 2) == 1)
            {
               battle(p, e);
            }
            else
            {
                Case();
            }
        }
        void Case ()
        {
            List<Def> list = new List<Def>();
            List<string> strings = new List<string>();
            Random random = new Random();
            if (random.Next(1, 2) == 1)
            {
                
            }
            else
            {
                
            }
        }
    }
}
