using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov
{
    internal class Persons
    {
        class Person
        {
            public string Name;
            public double Hp;
            public double BHp;
            public double Damage;
            public int Def;
            public Person(string name, int hp, int damage = 0, int def = 0)
            {
                Name = name;
                Hp = hp;
                Damage = damage;
                Def = def;
                BHp = hp;

            }

        }
        Person Sperminov = new Person("Сперминов", 100);
    }
}
