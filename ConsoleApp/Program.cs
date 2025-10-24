using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = Core.Context.Product.ToList();
            User anonim = new User();
        }
        static void Enter()
        {
            bool r = true;
            while (r)
            {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            User editUser = Core.Context.User.First(u => u.Login.Contains(login));
            switch (editUser)
                {
                    case null:
                        Console.WriteLine("Пользователь не найден");
                        Console.WriteLine("Хотите зарегестрироваться? Y/N");
                        string h = Console.ReadLine();
                        switch (h.ToLower())
                        { 
                            case "y":
                                Regestration();
                                break;
                            case "n":
                                Console.WriteLine("Продолжить без входа? Y/N");
                                string con= Console.ReadLine();
                                switch (con.ToLower())
                                {
                                    case "n":break;
                                    case "y":r = false; 
                                        Console.Clear();
                                        break;
                                }
                            break;
                            default:break;
                        }
                        break;
                    default:
                        string password = "";
                        while( password!= editUser.Password)
                        {
                            Console.WriteLine($"Введите пароль от пользователя {editUser.Login}");
                            password = Console.ReadLine();
                        }
                        Console.WriteLine("Вы авторизировались");
                        break;
                }
            }
               
        }
        static void Regestration()
        {
            Console.WriteLine("Введите логин");
            string login1 = Console.ReadLine();
            string password1 = "";
            bool flag = password1 != null || password1.Length >= 8;
            while (!flag)
            {
                Console.WriteLine("Введите пароль(до 8 символов)");
                password1 = Console.ReadLine();
            }
            Console.WriteLine($"Ваш пароль: {password1}");
            Thread.Sleep(1000);
            Console.Clear();
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
