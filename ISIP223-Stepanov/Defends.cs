using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov
{
    internal class Defends
    {
        class Def
        {
            public string NameD;
            public int Block;

            public Def(string name_d, int block)

            {
                NameD = name_d;
                Block = block;

            }
        }
        static Def shield = new Def("Щит", 60);
        static Def leather_armor = new Def("Кожанка", 20);
        static Def iron_armor = new Def("Кальчуга", 40);
    }
}
