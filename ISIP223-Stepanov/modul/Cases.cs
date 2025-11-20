using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov.modul
{
    internal class Cases
    {
        static public  void Case(Persons.Person p)
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
                    int a = RandomZ.UpHp();
                    p.BHp += a;
                    Console.WriteLine($"Вам выпало усиление здоровья на {a}");
                }
                else
                {
                    int a = RandomZ.UpDamage();
                    p.Damage += a;
                    Console.WriteLine($"Вам выпало усиление урона на {a}");
                }
            }
            Menu.Continue();
        }
       
    }
}
