namespace ShopInventory
{
    // Перечисление категорий товаров
    public enum ProductCategory
    {
        Electronics,
        Clothing,
        Food,
        Books,
        Sports
    }

    // Класс товара
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
        public ProductCategory Category { get; set; }

        public override string ToString()
        {
            return $"Код: {Code}, Название: {Name}, Цена: {Price:C}, " +
                   $"Количество: {Quantity}, В наличии: {(InStock ? "Да" : "Нет")}, " +
                   $"Категория: {Category}";
        }
    }
    class Program
    {
        private static List<Product> products = new List<Product>();
        private static int productCounter = 1;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== СИСТЕМА УЧЕТА ТОВАРОВ ===");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Удалить товар");
                Console.WriteLine("3. Заказать поставку товара");
                Console.WriteLine("4. Продать товар");
                Console.WriteLine("5. Поиск товаров");
                Console.WriteLine("6. Выход");
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
                        OrderSupply();
                        break;
                    case "4":
                        SellProduct();
                        break;
                    case "5":
                        SearchProducts();
                        break;
                    case "6":
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

            Console.Write("Введите название товара: ");
            string name = Console.ReadLine();

            Console.Write("Введите цену товара: ");
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

            Console.WriteLine("Доступные категории:");
            foreach (var cat in Enum.GetValues(typeof(ProductCategory)))
            {
                Console.WriteLine($"{(int)cat}. {cat}");
            }

            Console.Write("Выберите категорию (введите номер): ");
            ProductCategory category;
            while (!Enum.TryParse(Console.ReadLine(), out category) || !Enum.IsDefined(typeof(ProductCategory), category))
            {
                Console.Write("Неверная категория! Выберите из списка: ");
            }

            Product product = new Product
            {
                Code = code,
                Name = name,
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

            product.Quantity += supplyQuantity;
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
            Console.WriteLine($"Текущий товар: {product.Name}, Цена: {product.Price:C}, Доступное количество: {product.Quantity}");

            Console.Write("Введите количество для продажи: ");
            int sellQuantity;
            while (!int.TryParse(Console.ReadLine(), out sellQuantity) || sellQuantity <= 0)
            {
                Console.Write("Неверное количество! Введите положительное число: ");
            }

            if (sellQuantity > product.Quantity)
            {
                Console.WriteLine($"Недостаточно товара! Доступно только {product.Quantity} единиц.");
                return;
            }

            product.Quantity -= sellQuantity;
            decimal totalAmount = sellQuantity * product.Price;

            Console.WriteLine($"Продажа выполнена! Продано: {sellQuantity} единиц, Общая сумма: {totalAmount}");
            Console.WriteLine($"Остаток на складе: {product.Quantity} единиц");
        }
        static void SearchProducts()
        {
            Console.WriteLine("\nПоиск товаров");
            Console.WriteLine("1. Поиск по коду");
            Console.WriteLine("2. Поиск по названию");
            Console.WriteLine("3. Поиск по категории");
            Console.Write("Выберите тип поиска: ");

            string searchType = Console.ReadLine();
            List<Product> searchResults = new List<Product>();

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
                    foreach (var cat in Enum.GetValues(typeof(ProductCategory)))
                    {
                        Console.WriteLine($"{(int)cat}. {cat}");
                    }
                    Console.Write("Выберите категорию (введите номер): ");
                    ProductCategory category;
                    if (Enum.TryParse(Console.ReadLine(), out category) && Enum.IsDefined(typeof(ProductCategory), category))
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

