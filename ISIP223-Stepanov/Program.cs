string a = "Комсомольцы трудились день и ночь, не покладая рук, не вставая с постели. \r\nЛетом, мы с пацанами ходили в поход с ночевкой, и с собой взяли только необходимое. Картошку, палатку и Марию Ивановну. \r\nУмер М. Ю. Лермонтов на Кавказе, но любил он его не поэтому! \r\nПлюшкин навалил у себя в углу целую кучу и каждый день туда подкладывал. \r\nЛенский вышел на дуэль в панталонах. Они разошлись и раздался выстрел. \r\nДантес не стоил выеденного яйца Пушкина \r\nВо двор въехали две лошади. Это были сыновья Тараса Бульбы. \r\nОнегину нравился Байрон, поэтому он и повесил его над кроватью. \r\nГерасим поставил на пол блюдечко, и стал тыкать в него мордочкой. \r\nУ Онегина было тяжело внутри, и он пришел к Татьяне облегчиться. \r\nАндрей Болконский часто ездил поглядеть тот дуб, на который он был похож как две капли воды. \r\nЛермонтов родился у бабушки в деревне, когда его родители жили в Петербурге. \r\nГерасим налил Муме щей. \r\nБедная Лиза рвала цветы и этим кормила свою мать. \r\nХлестаков сел в бричку и крикнул: \"Гони, голубчик, в аэропорт! \" \r\nОтец Чацкого умер в детстве. \r\nВдруг Герман услыхал скрип рессор. Это была старая княгиня. \r\nУ Ростовых было три дочери: Наташа, Соня и Николай. \r\nИз всех женских прелестей у Марии Болконской были только глаза. \r\nТарас сел на коня. Конь согнулся, а потом засмеялся. \r\nДуша Татьяны полна любви и ждёт не дождётся, как бы обдать ею кого-нибудь. \r\nШел полк французов и кутузов. \r\nОнегин был богатый человек: по утрам он сидел в уборной, а потом ехал в цирк. \r\nПетр Первый соскочил с пьедестала и побежал за Евгением, громко цокая копытами. \r\nНос Гоголя наполнен глубочайшим содержанием. \r\nГлухонемой Герасим не любил сплетен и говорил только правду. \r\nТургенева не удовлетворяют ни отцы, ни дети. \r\nТакие девушки, как Ольга, уже давно надоели Онегину, да и Пушкину тоже. \r\nС Михаилом Юрьевичем Лермонтовым я познакомилась в детском саду. \r\nГерасим ел за четверых, а работал один. \r\nБазаров любил разных насекомых и делал им прививки. \r\nПугачев пожаловал шубу и лошадь со своего плеча. \r\nУ Чичикова много положительных черт: он всегда выбрит и пахнет. \r\nБазаров умер молодым человеком и сбыча его мечт не произошла. \r\nСыновья приехали к Тарасу и стали с ним знакомиться. \r\nЧичиков ехал в карете с поднятым задом. \r\nПо дороге в Богучарово Андрей Болконский, как старый дуб, расцвел и зазеленел. \r\nФамусов осуждает свою дочь за то, что Софья с самого утра и уже с мужчиной. \r\nНаташа была истинно русской натурой, очень любила природу и часто ходила на двор. \r\nГерасим бросил Татьяну и связался с Муму. \r\nГрушницкий тщательно целил в лоб, пуля оцарапала колено. \r\nПоэты XIX века были легкоранимыми людьми: их часто убивали на дуэлях. \r\nЗдесь он впервые узнал разговорную русскую речь от няни Арины Родионовны. \r\nПервые успехи Пьера Безухова в любви были плохие - он сразу женился. \r\nВ результате из Тихона вырос не мужчина, а самый настоящий овца. \r\nЯзык у Базарова был тупой, но потом заострился в спорах. \r\nМне нравится то, что с таким талантом Пушкин не побоялся стать народным поэтом. \r\nТроекуров был хотя не глуп, но немного с приветом. \r\nТак как Печорин - человек лишний, то и писать о нем - лишняя трата времени.";
Redactor();
     static void Redactor()
    {
        string a = Console.ReadLine();
    if (a.Length >= 100)
    {
        bool flag = false;
        while (true)
        {
            List<StText> Stext = new List<StText>();
            a=Sort(a);
            
            Console.WriteLine($" Количество слов: {Count(a)},количество предложений {Pred(a)}");
            Console.WriteLine("1-Количество гласных и согласных");
            Console.WriteLine("2-Самое короткое и самое длинное слово");
            Console.WriteLine("3-Частота букв");
            Console.WriteLine("4-Статистика прошлого текста");
            Console.WriteLine("0-Конец");
            string b = Console.ReadLine();
            switch (b)
            {
                case "1": Console.WriteLine($" Количество гласных {Gl(a)} , согласных {Sg(a)}"); break;
                case "2": Console.WriteLine($" Самое короткое слово: {Short(a)},самое длинное: {LONG(a)}"); break;
                case "0": flag = true; break;
                case "3": PrintDictionary<char, int>(Word(a)); break;
                case "4":
                    if (Stext.Count() > 0) StText.PrintStText(Stext[Stext.Count-1]);break;
            }
            StText Text1 = (Count(a), Sg(a), Gl(a), Short(a), LONG(a), Word(a), Pred(a));
            Stext.Add(Text1);   
        }
    
    }
        else { Console.WriteLine("Текст слишком маленький"); }
     }
    static int Count(string a)
    {
        int p = 1;
        for (int i = 0; i < a.Length; i++)
        {

            if (a[i] == ' ') p += 1;
        }
        return p;

    }
    static string Sort(string a)
    {
        List<char> Znak =new List<char> { ',' , ';',':','-'};
        for (int i = 0; i < a.Length; i++)
        {
           foreach (char s in Znak) { if (s == a[i]) a.Remove(i, 1); }
        }
        return a;
    }

    static int Gl(string a)
    {
        List<char> Znak = new List<char> { 'а', 'о', 'э', 'ю','у', 'е', 'и', 'я', 'ы' };
        int gl = 0;
        int sg = 0;
        for (int i = 0; i < a.Length; i++)
        {
            foreach (char s in Znak) { if (s == a[i]) gl +=1; else sg += 1; }
        }
        return gl;
    }
     static int Sg(string a)
    {
        List<char> Znak = new List<char> { 'а', 'о', 'э', 'ю', 'у', 'е', 'и', 'я', 'ы' };
        int gl = 0;
        int sg = 0;
        for (int i = 0; i < a.Length; i++)
        {
            foreach (char s in Znak) { if (s == a[i]) gl += 1; else sg += 1; }
        }
        Console.WriteLine($"Гласных:{gl} Согласных:{sg}");
        return sg;
    }
     static Dictionary<char,int> Word(string a)
    {
        Dictionary<char, int> dict = new Dictionary<char, int> {
    {'а', 0}, {'б', 0}, {'в', 0}, {'г', 0}, {'д', 0}, {'е', 0}, {'ё', 0},
    {'ж', 0}, {'з', 0}, {'и', 0}, {'й', 0}, {'к', 0}, {'л', 0}, {'м', 0},
    {'н', 0}, {'о', 0}, {'п', 0}, {'р', 0}, {'с', 0}, {'т', 0}, {'у', 0},
    {'ф', 0}, {'х', 0}, {'ц', 0}, {'ч', 0}, {'ш', 0}, {'щ', 0}, {'ъ', 0},
    {'ы', 0}, {'ь', 0}, {'э', 0}, {'ю', 0}, {'я', 0}}; ;
        List<char> russianLetters = new List<char>
{
    'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
    'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
    'ы', 'ь', 'э', 'ю', 'я'};
        for (int i = 0; i < a.Length; i++)
        {
            foreach (char s in russianLetters) { if (s == a[i]) dict[s]+=1;}
        }
        return dict;
    }
     static int Pred(string a)
    {
        string[] List = a.Split(' ');
        List<string> H = new List<string>(List);
        int pr = 0;
        List<char> Znak = new List<char> { '.', '?', '!'};
        foreach (string i in H)
        {
            char u = i[i.Length -1]; 
            foreach (char s in Znak) { if (s == u) pr++; }
        }
        return pr;
    }
     static string Short(string a)
    {
        string[] List = a.Split(' ');
        List<string> H = new List<string>(List);
        string shrt="";
        string space=H[0];
        foreach(string i in H)
        {
            shrt = (space.Length > i.Length) ? i:space;
        }
      return shrt;
    }
    static string LONG(string a)
    {
        string[] List = a.Split(' ');
        List<string> H = new List<string>(List);
        string shrt = "";
        string space = H[0];
        foreach (string i in H)
        {
            shrt = (space.Length < i.Length) ? i : space;
        }
        return shrt;
    }
static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
{
    foreach (var pair in dictionary)
    {
        Console.WriteLine($"{pair.Key}: {pair.Value}");
    }
} 

public class StText
{
    public int Count { get; set;}
    public int Sg { get; set; }
    public int Gl { get; set; }
    public string Short { get; set; }
    public string Long { get; set; }
    public Dictionary<char,int > Dictionary { get; set; }
    public int Pr { get; set; }
   
    public StText(int count, int sg, int gl, string @short, string @long, Dictionary<char, int> dictionary,int pr)
    {
        Count = count;
        Pr = pr;
        Sg = sg;
        Gl = gl;
        Short = @short;
        Long = @long;
        Dictionary = dictionary;
    }
        static public void PrintStText(StText a)
    {
        Console.WriteLine($" Количество слов: {a.Count},количество предложений {a.Pr}");
        Console.WriteLine($" Количество гласных {a.Gl} , согласных {a.Sg}"); 
        Console.WriteLine($" Самое короткое слово: {a.Short},самое длинное: {a.Long}"); 
        foreach (var pair in   a.Dictionary)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

    }
    public static implicit operator StText((int, int, int, string, string, Dictionary<char, int>, int) v)
    {
        throw new NotImplementedException();
    }
}