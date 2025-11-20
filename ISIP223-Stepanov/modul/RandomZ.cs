using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIP223_Stepanov.modul;
namespace ISIP223_Stepanov.modul
{
    internal class RandomZ
    {
        static public Random rand = new Random();
        static public int R100()
        {
            return rand.Next(0, 100);
        }
        static public int R4()
        {
            return rand.Next(0, 4);
        }
        static public int R5()
        {
            return rand.Next(0, 3);


        }
        static public int R2()
        {
            return rand.Next(0, 2);
        }
        static public int UpHp()
        {
            return rand.Next(0, 40);
        }
        static public int UpDamage()
        {
            return rand.Next(0, 10);
        }
        static public bool Freze() 
        {
            if (RandomZ.R100() <= 25)
                return true;
            else return false;
        }
        static public bool DoubleDamage()
        {
            if (RandomZ.R100() <= 40)
                return true;
            else return false;
        }
        
    }
}
