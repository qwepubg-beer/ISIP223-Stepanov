using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> users = Core.Context.Product.ToList();
        }
        static void Enter()
        {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            User editUser = Core.Context.User.First(u => u.Login.Contains(login));
           
                Console.WriteLine("Пользователь не найден");
                Console.WriteLine("Хотите зарегестрироваться? Y/N");

            switch (editUser)
            {
                case null:
                    Console.WriteLine("Пользователь не найден");
                    Console.WriteLine("Хотите зарегестрироваться? Y/N");
                    string h = Console.ReadLine();
                    switch(h)
                    {
                        
                    }
                    break;
            }
               
        }
        static void Regestration()
        {

        }
        static void AddtoBacket()
        {

        }
        static void AddPVZ(List<PVZ> pVZs, User user1)
        {
            Console.WriteLine("Выбирите пункт выдачи заказов по номеру");
            for (int i = 0; i >= pVZs.Count() - 1; i++)
            {
                Console.WriteLine($"{i} --- {pVZs[i].PVZ1}");
            }
            /*int choose;
            while (!int.TryParse(Console.ReadLine(), out choose)  choose <= 0  choose >= pVZs.Count())
            {
                Console.Write("Введите корректное значение: ");
            }
            */
        }
    }
}
