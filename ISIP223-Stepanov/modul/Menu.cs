using ISIP223_Stepanov.modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Stepanov.modul
{
    internal class Menu
    {
        static public void PrintMenu()
        {
            Console.WriteLine("Добро пожаловать в игру Сперминов против нежити");
            Console.WriteLine("Выбирите уровень сложности");
            Console.WriteLine("1 - Сперминов прайм");
            Console.WriteLine("2 - Сперминов в Хогвартсе");
            Console.WriteLine("3 - Сперминов в КипФине");
        }
        static public void Continue()
        {
            Console.WriteLine("Нажмите для продолжения\n");
            Console.ReadKey();
            Console.Clear();
        }
        static public void PrintPersonInfo(Persons.Person p, Enemies.Enemy e)
        {
            Console.WriteLine($"Здоровье Сперминова = {p.Hp}");
            Console.WriteLine($"Здоровье Врага {e.Name} = {e.Hp}");
            Console.WriteLine("Выбирите действие: 1-атака");
        }
    }
}
