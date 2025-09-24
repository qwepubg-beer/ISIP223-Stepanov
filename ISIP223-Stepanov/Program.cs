using System.Collections.Generic;

namespace ShopInventory
{
    // Перечисление категорий товаров
    public enum Type
    {
        Mystery,
        Thriller,
        Sciencefiction,
        Fantasy,
        Horror
    }

    // Класс товара
    public class Book
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
        public Type Category { get; set; }

        public override string ToString()
        {
            return $"Код: {Code}, Название: {Name}, Цена: {Price:C}, Год: {Year}," +
                   $"Количество: {Quantity},Категория: {Category} , " +
                   $"В наличии: {(InStock ? "Да" : "Нет")}";
        }

    }
    class Program
    {
        private static List<Book> products = new List<Book>();
        private static int productCounter = 1;

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n СИСТЕМА УЧЕТА КНИГ");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу по идентификатору");
                Console.WriteLine("3. Найти книги");
                Console.WriteLine("4. Отсортировать книги по названию или году");
                Console.WriteLine("5. Вывести самую дорогую и самую дешёвую книгу");
                Console.WriteLine("6. Сгруппировать книги по авторам и вывести количество книг каждого автора");
                Console.WriteLine("7. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        RemoveProduct();
                        break;
                    case "3":
                        SearchProducts();
                        break;
                    case "4":
                        Sort();
                        break;
                    case "5":
                        PrintTwoBooks();
                        break;
                    case "6":
                        PrintAthors();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }
        static void AddProduct()
        {
            Console.WriteLine("\nДобавление товара");

            string code = "1" + productCounter.ToString();
            productCounter++;

            Console.Write("Введите название книги: ");
            string name = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();
            Console.Write("Введите год выпуска: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year) || year <= 0 || year >= 2025)
            {
                Console.Write("Неверная дата! Введите корректное значение: ");
            }
            Console.Write("Введите цену книги: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.Write("Неверная цена! Введите корректное значение: ");
            }

            Console.Write("Введите начальное количество: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.Write("Неверное количество! Введите корректное значение: ");
            }

            Console.WriteLine("Доступные жанры книг:");
            foreach (var cat in Enum.GetValues(typeof(Type)))
            {
                Console.WriteLine($"{(int)cat}. {cat}");
            }

            Console.Write("Выберите категорию (введите номер): ");
            Type category;
            while (!Enum.TryParse(Console.ReadLine(), out category) || !Enum.IsDefined(typeof(Type), category))
            {
                Console.Write("Неверная категория! Выберите из списка: ");
            }

            Book product = new Book
            {
                Code = code,
                Name = name,
                Author = author,
                Year = year,
                Price = price,
                Quantity = quantity,
                Category = category
            };

            products.Add(product);
            Console.WriteLine($"Товар успешно добавлен! Код товара: {code}");
        }
        static void RemoveProduct()
        {
            Console.WriteLine("\nУдаление товара");

            Console.Write("Введите код товара для удаления: ");
            string code = Console.ReadLine();

            var product = products.FirstOrDefault(p => p.Code == code);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($"Товар с кодом {code} успешно удален!");
            }
            else
            {
                Console.WriteLine("Товар с таким кодом не найден!");
            }
        }
        static void OrderSupply()
        {
            Console.WriteLine("\nЗаказ товара");

            Console.Write("Введите код товара: ");
            string code = Console.ReadLine();

            var product = products.FirstOrDefault(p => p.Code == code);
            if (product == null)
            {
                Console.WriteLine("Товар с таким кодом не найден!");
                return;
            }

            Console.WriteLine($"Текущий товар: {product.Name}, Количество: {product.Quantity}");

            Console.Write("Введите количество для поставки: ");
            int supplyQuantity;
            while (!int.TryParse(Console.ReadLine(), out supplyQuantity) || supplyQuantity <= 0)
            {
                Console.Write("Неверное количество! Введите положительное число: ");
            }

            product.Year += supplyQuantity;
            Console.WriteLine($"Поставка выполнена! Новое количество: {product.Quantity}");
        }
        static void SellProduct()
        {
            Console.WriteLine("\n Продажа товара");
            Console.Write("Введите код товара: ");
            string code = Console.ReadLine();
            var product = products.FirstOrDefault(p => p.Code == code);
            if (product == null)
            {
                Console.WriteLine("Товар с таким кодом не найден!");
                return;
            }
            Console.WriteLine($"Текущий товар: {product.Name}, Цена: {product.Price:C}, Доступное количество: {product.Year}");

            Console.Write("Введите количество для продажи: ");
            int sellQuantity;
            while (!int.TryParse(Console.ReadLine(), out sellQuantity) || sellQuantity <= 0)
            {
                Console.Write("Неверное количество! Введите положительное число: ");
            }

            if (sellQuantity > product.Year)
            {
                Console.WriteLine($"Недостаточно товара! Доступно только {product.Year} единиц.");
                return;
            }

            product.Year -= sellQuantity;
            decimal totalAmount = sellQuantity * product.Price;

            Console.WriteLine($"Продажа выполнена! Продано: {sellQuantity} единиц, Общая сумма: {totalAmount}");
            Console.WriteLine($"Остаток на складе: {product.Year} единиц");
        }
        static void PrintTwoBooks()
        {
            decimal space = products[0].Price;
            int Ucode = 0;
            int Dcode = 0;
            for (int i = 1; i < products.Count; i++)
            {
                if (space > products[i].Price)
                {
                    space = products[i].Price;
                    Ucode = i;
                }
            }
            for (int i = 1; i < products.Count; i++)
            {
                if (space < products[i].Price)
                {
                    space = products[i].Price;
                    Dcode = i;
                }
            }
            Console.WriteLine("Самая дорогая книга");
            Console.WriteLine(products[Ucode].ToString());
            Console.WriteLine("Самая дешевая книга");
            Console.WriteLine(products[Dcode].ToString());
        }
        static void Sort()
        {
            var flag = false;
            Console.WriteLine("1. Группировка по названию");
            Console.WriteLine("2. Группировка по году");

            string choose = Console.ReadLine();
            while (!flag)
            {
                switch (choose)
                {
                    case "1":
                        var orderedByAge = products.OrderBy(p => p.Year).ToList();
                        Console.WriteLine("Сортировка по году (возрастание):");
                        foreach (var p in orderedByAge)
                            Console.WriteLine(p.ToString());
                        flag = true;
                        break;
                    case "2":
                        var orderedByAge1 = products.OrderBy(p => p.Name).ToList();
                        Console.WriteLine("Сортировка по году (возрастание):");
                        foreach (var p in orderedByAge1)
                            Console.WriteLine(p.ToString());
                        flag = true;
                        break;
                    default: Console.WriteLine("Неверный выбор"); break;
                }
            }
        }
        static void PrintAthors()
        {
            products = products.OrderBy(p => p.Name).ToList();
            Dictionary<string, int> author = new Dictionary<string, int>();
            foreach (Book i in products)
            {
                if (author.ContainsKey(i.Author))
                {
                    author[i.Author]++;
                }
                else
                {
                    author.Add(i.Author, 1);
                }
            }
            PrintDictionary<string, int>(author);
        }
        static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
        static void SearchProducts()
        {
            Console.WriteLine("\nПоиск товаров");
            Console.WriteLine("1. Поиск по коду");
            Console.WriteLine("2. Поиск по названию");
            Console.WriteLine("3. Поиск по категории");
            Console.Write("Выберите тип поиска: ");

            string searchType = Console.ReadLine();
            List<Book> searchResults = new List<Book>();

            switch (searchType)
            {
                case "1":
                    Console.Write("Введите код товара: ");
                    string code = Console.ReadLine();
                    searchResults = products.Where(p => p.Code.Contains(code)).ToList();
                    break;

                case "2":
                    Console.Write("Введите название товара: ");
                    string name = Console.ReadLine();
                    searchResults = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;

                case "3":
                    Console.WriteLine("Доступные категории:");
                    foreach (var cat in Enum.GetValues(typeof(Type)))
                    {
                        Console.WriteLine($"{(int)cat}. {cat}");
                    }
                    Console.Write("Выберите категорию (введите номер): ");
                    Type category;
                    if (Enum.TryParse(Console.ReadLine(), out category) && Enum.IsDefined(typeof(Type), category))
                    {
                        searchResults = products.Where(p => p.Category == category).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Неверная категория!");
                        return;
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор!");
                    return;
            }

            if (searchResults.Count == 0)
            {
                Console.WriteLine("Товары не найдены!");
                return;
            }

            Console.WriteLine("\nРезультаты поиска");
            foreach (var product in searchResults)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }

}