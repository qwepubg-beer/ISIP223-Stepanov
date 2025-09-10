void sort(double[] a, string[]b)//сортировка
{
    int n=a.Length;
    bool wap;
    for (int i = 0; i < n-1; i++)
    {
        wap = false;
        for(int j=0;j< n-1;j++)
        {
            if (a[j] > a[j+1])
            {
                double d=a[j];
                string da = b[j];
                a[j]=a[j+1];
                b[j] = b[j + 1];
                a[j+1]=d;
                b[j + 1] = da;
                wap = true;
            }
        }
        if (!wap) break;
    }
}
void Statistics(double[]a)
{
    int n = a.Length;
    Console.WriteLine($"Max= {a.Max()}");
    Console.WriteLine($"Min= {a.Min()}");
    int sum = 0;
    foreach (int i in a) sum += i;
    Console.WriteLine($"Sum= {sum}");
    Console.WriteLine($"Sred= {sum/n}");//статистика
}
void Get(double[] a, string[] b,int s)//получить по индексу
{
    Console.WriteLine($"{a[s]} : {b[s]}");
}
void Search(double[] a, string[] b, string s)//поиск по названию
{
    int n = Array.IndexOf(b, s);
    if (n == -1) Console.WriteLine("Не найдено");
    else Console.WriteLine($"{a[n]} : {b[n]}");
}
void Print(double[] a, string[] b)
{
    for(int i = 0;i<a.Length;i++)
    {
        Console.WriteLine($"{a[i]} : {b[i]}");
    }
}
Console.WriteLine("введите количество операций");
string n = Console.ReadLine();
int number=Convert.ToInt32(n);
double[] ints = new double[number];
string[] strings = new string[number];
if (number >= 2 && number <=40) 
{ 
    for( int i=0;i<=number-1; i++ )
    {
        string S = Console.ReadLine();
        string[] words = S.Split(new char[] { ';' });
        double number3=Convert.ToDouble(words[1]);
        ints[i]=(number3);
        strings[i] = (words[0]);
    }
}
else { Console.WriteLine("Неверное число"); }

Console.WriteLine("1. Вывод данных");
Console.WriteLine("2. Статистика");
Console.WriteLine("3. Сортировка по цене");
Console.WriteLine("4. Конвертация валюты");
Console.WriteLine("5. Поиск по названию");
Console.WriteLine("0. Выход");
string menu = Console.ReadLine();
bool flag = true;
while (flag)
{
    switch (menu)
    {
        case "1":
            Print(ints, strings);
            break;
        case "2":
            Statistics(ints);
            break;
        case "3":
            sort(ints, strings);
            break;
        case "4":
            double money = 1;
            Console.WriteLine("выбирите валюту");
            Console.WriteLine("1-рубль");
            Console.WriteLine("2-белоруский рубль");
            Console.WriteLine("3-доллар рубль");
            Console.WriteLine("4-юани");
            Console.WriteLine("5-своя валюта");
            string t = Console.ReadLine();
            switch (t)
            {
                case "1":
                    break;
                case "2":
                    money = 24.94;
                    break;
                case "3":
                    money = 84.75;
                    break;
                case "4":
                    money = 11.90;
                    break;
                case "5":
                    Console.WriteLine("введите стоимость валюты к рублю");
                    string money1 = Console.ReadLine();
                    double number2 = Convert.ToDouble(money1);
                    money = number2;
                    for (int i = 0; i < ints.Length - 1; i++)
                        ints[i] = ints[i] / money;
                    break;
            }
            break;
        case "5":
            Console.WriteLine("введите название");
            string uuu = Console.ReadLine();
            Search(ints, strings, uuu);
                        break;
        case "0":
            flag = false;
            break;
    }
}