using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            Core.Context.SaveChanges();
            List<Product> products = Core.Context.Product.ToList();
            List<History> hs = Core.Context.History.ToList();
            List<PVZ> pVZs = Core.Context.PVZ.ToList();
            List<Basket_Product> products_B = Core.Context.Basket_Product.ToList();
            bool flag = true;
            User anonim = new User("", "");
            while (flag)
            {
                PrintList(products);
                Console.WriteLine("\n");
                if (anonim.Login == "")
                { PrintMenu(anonim.Login); }
                else { PrintMenu2 (anonim.Login); }
                Console.WriteLine("Выбирите действие");
                string choose = Console.ReadLine();
                switch (choose.ToLower())
                {
                    case "b": 
                        if(anonim.Login!="") 
                        {
                        Console.WriteLine("Выбирите товар по номеру");
                        int choose2;
                        while (!int.TryParse(Console.ReadLine(), out choose2) || choose2 <= 0)
                         {
                                Console.Write("Неверное количество! Введите корректное значение: ");
                        }
                            AddtoBacket(choose2, anonim);
                        }
                        else
                        {
                            Console.WriteLine("Вы не авторизованы");
                        }

                            break;
                    case "r":
                        Regestration(anonim);
                        break;
                    case "k":
                        Printbasket(anonim, products_B,products);
                        break;
                    case "v":
                        Enter(anonim);
                        break;
                    case "p":
                        Usssr(anonim,pVZs,hs);
                        break;
                    default: break;
                }
                
                Thread.Sleep(1500);
                Console.Clear();
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
                switch (editUser.Login)
                {
                    case"":
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
                        user.ID = editUser.ID;
                        user.Login = editUser.Login;
                        user.PvzID = editUser.PvzID;
                        user.Money = editUser.Money;
                        r =false;
                        break;
                }
            }

        }
        static void PrintMenu(string login)
        {
            Console.WriteLine($"B              V    R             K         P");
            Console.WriteLine($"Купить товар   Вход Регистрация   Корзина   Пользователь {login}");
        }
        static void PrintMenu2(string login)
        {
            Console.WriteLine($"B              K         P");
            Console.WriteLine($"Купить товар   Корзина   Пользователь {login}");
        }
        static void Usssr(User anonim, List<PVZ> pVZs, List<History> hs)
        {
            if (anonim.Login == "") Console.WriteLine("Вы не авторизованы");
            else { 
                Console.WriteLine("Выбирите действие");
            Console.WriteLine("1-Сменить логин 2-Сменить пароль 3-Поменять пункт выдачи 4-ИНФО 5-История_покупок");
            User editUser = Core.Context.User.First(u => u.Login.Contains(anonim.Login));
                  string choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Введите новый логин");
                        string login2 = Console.ReadLine();
                        if (anonim.Login != login2 || login2 != "")
                        {
                            anonim.Login = login2;
                            editUser.Login = login2;
                            Core.Context.SaveChanges();
                        }
                        else { Console.WriteLine("Логин пустой или логин не изменен"); }
                        break;
                    case "2":
                        Console.WriteLine("Введите новый пароль");
                        string password = Console.ReadLine();
                        if (password.Length <= 8 && password.Length > 0)
                        {
                            editUser.Password = password;
                            Core.Context.SaveChanges();
                        }
                        else { Console.WriteLine("Пароль должен быть до 8 символов"); }
                        break;
                    case "3":
                        AddPVZ(editUser, pVZs);
                        break;
                    case "4":
                        PVZ y = Core.Context.PVZ.First(u => u.ID== editUser.PvzID);
                        Console.WriteLine($" логин:{editUser.Login} пароль:{editUser.Password} Пункт выдачи: {y.Adress} Ваш баланс: {editUser.Money}");
                        Thread.Sleep(1000);
                        break;
                    case "5":
                        PrintHistory(editUser.Login, hs);
                        Thread.Sleep(1000);
                        break;
                    default:break;
                }
            }
        }
        static void Printbasket(User anonim, List<Basket_Product> products, List<Product> pr)
        {

            
            User editUser = Core.Context.User.First(u => u.Login.Contains(anonim.Login));
            var select = (from product in products
                          where product.UserID == editUser.ID
                          select product.ProductID).ToList();
            if (anonim.Login == "") { Console.WriteLine("Вы не авторизованы"); }
            else
            {
                int sum = 0;
                foreach (var p in select)
                {
                    Product U = Core.Context.Product.First(u => u.ID == p);
                    Console.WriteLine($"{U.Name} ----- {U.Price}");
                    sum += U.Price;
                }
                //Console.WriteLine("Сумма заказа = ", sum);
                Console.WriteLine(sum);
                Console.WriteLine("Заказать y/n");
                string choose = Console.ReadLine();
                switch (choose.ToLower())
                {
                    case "y":
                        if (sum > editUser.Money /*&& editUser.PVZID != null*/)
                        {
                            Console.WriteLine("Недостаточно средств или не указан пункт выдачи");

                        }
                        else
                        {
                            Console.WriteLine("Товары куплен курьер Гордов доставит их вам");
                            editUser.Money -=sum;
                            Core.Context.SaveChanges();
                            foreach (var p in products)
                            {
                                if (p.UserID == editUser.ID)
                                {
                                    History history = new History(p.ProductID, editUser.ID, DateTime.Today);
                                    Core.Context.History.Add(history);
                                    Core.Context.SaveChanges();
                                    Core.Context.Basket_Product.Remove(p);
                                    Core.Context.SaveChanges();
                                }
                            }

                        }
                        break;
                    default: break;

                }
            }
        }
            static void PrintHistory(string login, List<History> hs)
            {
                if(login!="")
            { 
                User editUser = Core.Context.User.First(u => u.Login.Contains(login));
                var select = (from product in hs
                              where product.UserID == editUser.ID
                              select product).ToList();
                foreach (var p in select)
                {
                    Product Pr = Core.Context.Product.First(u => u.ID == p.ProductID);
                    Console.WriteLine($"{Pr.Name} ----- {Pr.Price}----- {p.Date}");
                    
                }
            }
            else { Console.WriteLine("Вы не авторизованы"); }
        }
        
        static void Regestration(User editUser)
        {
            Console.WriteLine("Введите логин"); 
            string login1 = Console.ReadLine();
            string password1 = "";
            bool flag = password1.Length >0 && password1.Length <= 8;
            Console.WriteLine("Введите пароль(до 8 символов)");
            password1 = Console.ReadLine();
            while (flag)
            {
                Console.WriteLine("Введите пароль(до 8 символов)");
                password1 = Console.ReadLine();
            }
            Console.WriteLine($"Ваш пароль: {password1}");
            
            User user = new User (login1,password1 );
            editUser.Login = user.Login;
            editUser.Password = user.Password;
            editUser.PvzID = user.PvzID;
            editUser.Money = user.Money;
            Core.Context.User.Add(user);
            Core.Context.SaveChanges();
        }
        static void AddtoBacket(int number, User user)
        {
            User editUser = Core.Context.User.First(u => u.Login.Contains(user.Login));
            Basket_Product editBucket = new Basket_Product(number, editUser.ID);
            Core.Context.Basket_Product.Add(editBucket);
            Core.Context.SaveChanges();
        }
        static void PrintList(List<Product> products)
        {
            foreach (Product product in products) 
            {
                Console.WriteLine($"{product.ID}----{product.Name} ----- {product.Price}");
            }
        }

        static void AddPVZ(User user1,List<PVZ> pVZs)
        {
            Console.WriteLine("Выбирите пункт выдачи заказов по номеру");
            foreach(var P in pVZs)
            {
                Console.WriteLine($"Номер: {P.ID}----Место: {P.Adress}");
            }
            int pvz;
            while (!int.TryParse(Console.ReadLine(), out pvz) || pvz< 0)
            {
                Console.Write("Неверное количество! Введите корректное значение: ");
            }
            user1.PvzID = pvz;
            Core.Context.SaveChanges();
        }
    }
}
