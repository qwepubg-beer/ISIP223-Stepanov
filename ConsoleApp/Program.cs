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
            bool flag = true;
            User anonim = new User("", "");
            while (flag)
            {
                PrintMenu(anonim.Login);

                Console.WriteLine("Выбирите действие");
                string choose = Console.ReadLine();
                switch (choose.ToLower())
                {
                    case "l":
                        PrintList(products);
                        Console.WriteLine("Выбирите товар по номеру");
                        string choose2 = Console.ReadLine();
                        Console.WriteLine(choose2);
                        break;
                    case "r":
                        Regestration(anonim);
                        break;
                    case "k":
                        Printbasket(anonim.ID);
                        break;
                    case "v":
                        Enter(anonim);
                        break;
                    case "p":
                        Usssr(anonim);
                        break;
                    default: break;
                }
            }
        }
        static void Enter(User user)
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
                                Regestration(editUser);
                                break;
                            case "n":
                                Console.WriteLine("Продолжить без входа? Y/N");
                                string con = Console.ReadLine();
                                switch (con.ToLower())
                                {
                                    case "n": break;
                                    case "y":
                                        r = false;
                                        Console.Clear();
                                        break;
                                }
                                break;
                            default: break;
                        }
                        break;
                    default:
                        string password = "";
                        while (password != editUser.Password)
                        {
                            Console.WriteLine($"Введите пароль от пользователя {editUser.Login}");
                            password = Console.ReadLine();
                        }
                        Console.WriteLine("Вы авторизировались");
                        user.Login = editUser.Login;
                        break;
                }
            }

        }
        static void PrintMenu(string login)
        {
            Console.WriteLine($"L            R             K         P");
            Console.WriteLine($"Лист товаров Регистрация   Корзина   Пользователь {login}");
        }
        static void Usssr(string login)
        {
            if (login == "") Console.WriteLine("Вы не авторизованы");
            Console.WriteLine("Выбирите действие");
            Console.WriteLine("1-Сменить логин 2-Сменить пароль");
            User editUser = Core.Context.User.First(u => u.Login.Contains(login));
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    Console.WriteLine("Введите логин");
                    string login2 = Console.ReadLine();
                    if (login != login2 || login2 != "")
                    {
                        editUser.Login = login2;
                    }
                    else { Console.WriteLine("Логин пустой или логин не изменен");}
                    break;
                case "1":
                    Console.WriteLine("Введите логин");
                    string password = Console.ReadLine();
                    if (password.Length==8)
                    {
                        editUser.Password = password;
                    }
                    else { Console.WriteLine("Пароль должен быть 8 символов"); }
                    break;
            }

        }
        static void Printbasket(int id)
        {
            if (id != 0)
            {
                List<Busket_Product> products = Core.Context.Busket_Product.ToList();
                var select = from product in products
                             where product.UserID == id
                             select product;
            }

        }
        static void Regestration(User editUser)
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
            Core.Context.User.Add(editUser);
            Core.Context.SaveChanges();
            Thread.Sleep(1000);
            Console.Clear();
        }
        static void AddtoBacket(int number, User user)
        {
            Busket_Product editBucket = new Busket_Product(number, user.ID);
            Core.Context.Busket_Product.Add(editBucket);
            Core.Context.SaveChanges();
        }
        static void PrintList(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i}----{products[i].Name} ----- {products[i].Price}");
            }
        }

        static void AddPVZ(List<PVZ> pVZs, User user1)
        {
            Console.WriteLine("Выбирите пункт выдачи заказов по номеру");
            for (int i = 0; i >= pVZs.Count() - 1; i++)
            {
                Console.WriteLine($"{i} --- {pVZs[i].PVZ1}");
            }

        }
    }
}
