namespace university
{
    class Person
    {
        public string FIO;
        
        public string Gender;

        public Person(string fio,string gender)
        {
            FIO = fio;
            
            Gender = gender;
        }
        public virtual void Print()
        {
            Console.WriteLine($"FIO: {FIO}\n Gender: {Gender} ");
        }
    }

    class Student : Person
    {
        private int StudentNumberID;
        
        private int CourseNumber;
        private string TheHealthGroup;

        public Student(int id, string fio, string gender, string TheHealthGroup, int CourseNumber)
            : base(fio, gender)
        {
            StudentNumberID = id;
            
            this.CourseNumber = CourseNumber;
            this.TheHealthGroup = TheHealthGroup;
        }

        public override void Print()
        {
            Console.WriteLine("Student");
            base.Print();
            Console.WriteLine($"StudentNumberID: {StudentNumberID}\nTheHealthGroup: {TheHealthGroup}\nCourseNumber: {CourseNumber}\n");
        }
    }

    class Teacher : Person
    {
        public string Subject;
        public int ExperienceYears;

        public Teacher(string fio, string gender, string subject, int PCExperience)
            : base(fio, gender)
        {
            Subject = subject;
            ExperienceYears = PCExperience;
        }

        public override void Print()
        {
            Console.WriteLine("Teacher");
            base.Print();
            Console.WriteLine($"Subject: {Subject}\nExperienceYears: {ExperienceYears}\n");
        }
    }
    class Curs : Teacher
    {
        public string Name;
        public Curs(string name, string Subject, int ExperienceYears, string FIO, string Gender)
        : base(FIO, Gender, Subject, ExperienceYears)
        {
            this.Name = name;
        }
        public override void Print()
        {
            Console.WriteLine("Curs:");
            Console.WriteLine($"curs: {Name}");
            base.Print();
        }
        public List<Student> Student_Curs;
        
    }
    class Program
    {
       
        /*
        Student Dima = new Student(1000, "Dima", "мэн", "питонист", 3);
        Student David = new Student(1001, "David", "мэн", "1", 3);
        Teacher Max = new Teacher("Max", "мэн", "c#", 3);
        Curs Pytnon = new Curs("Питон", "с#", 3, "Max", "мэн");
         */  
         static void Main(string[] args)
        {
            List<Teacher> Teachers = new List<Teacher>();
            List<Student> Students = new List<Student>();
            List<Curs> curs = new List<Curs>();
            bool flag = false;
                
            while (!flag)
            {
                Console.WriteLine("1. Добавить Студента");
                Console.WriteLine("2. Добавить Учителя");
                Console.WriteLine("3. Добавить Курс");
                Console.WriteLine("4. Запись студента на курс");
                Console.WriteLine("5. Список студентов");
                Console.WriteLine("6. Список студентов");
                Console.WriteLine("0. Выход");
                Console.WriteLine("Выбирите действие из списка");
                string choose= Console.ReadLine();   
               switch (choose)
                {
                    case "1": ADD_Student(Students); break;
                    case "2": ADD_Teacher(Teachers); break;
                    case "3": ADD_curs(Teachers,curs); break;
                    case "4": ADD_Student_curs(Students,curs); break;
                    case "5": PrintStudents(Students); break;
                    case "6": PrintTeachers(Teachers); break;
                    case "0":flag = true; break;
                    default:break;
                }
            }
        }
        static void ADD_curs(List<Teacher> Teachers, List<Curs> curs)
        {
            Console.WriteLine("Выбирите преподавателя курса по фамилии");
            string LastName = Console.ReadLine();
            foreach (Teacher i in Teachers)
            {
                string[] stringArray = i.FIO.Split(' ');
                                
                if (stringArray[0]==LastName)
                {
                    Console.WriteLine("Введите название курса: ");
                    string name = Console.ReadLine();
                    Curs k1 = new Curs(name,i.Subject,i.ExperienceYears,i.FIO,i.Gender);
                    curs.Add(k1);
                    Console.WriteLine("Успешное добавление\n");
                }
                else
                {
                    Console.WriteLine("Преподаватель не найден");
                }
                
            }
        }
        static void ADD_Teacher(List<Teacher> Teachers)
        {
            Console.WriteLine("\nДобавление учителя");
            Console.WriteLine("Введите фио: ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите гендер: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите предмет: ");
            string sbj = Console.ReadLine();
             Console.WriteLine("Введите стаж в годах: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.Write("Неверное количество! Введите корректное значение: ");
            }
           Teacher t1 = new Teacher(fio,gender,sbj,quantity);
           Teachers.Add(t1);
            Console.WriteLine("Успешное добавление\n");
        }
        static void ADD_Student_curs(List<Student> Students, List<Curs>curs)
        {
            Console.WriteLine("\nДобавление студента на курс");
            Console.WriteLine("Выбирите студента по фамилии");
            string LastName = Console.ReadLine();
            foreach (Student i in Students)
            {
                string[] stringArray = i.FIO.Split(' ');

                if (stringArray[0] == LastName)
                {
                    Console.WriteLine("Выбирите курс по номеру");
                    PrintCurs(curs);
                    int n;
                    while (!int.TryParse(Console.ReadLine(), out n)|| n>=curs.Count)
                    {
                        Console.Write("Неверная номер! Введите корректное значение: ");
                    }
                    curs[n].Student_Curs.Add(i);
                    Console.WriteLine("Студент добавлен");
                }
                
            }
        }
        static void ADD_Student(List<Student> Students)
        {
            Console.WriteLine("\nДобавление студента");
            Console.WriteLine("Введите фио: ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите гендер: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите ид: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Неверный id! Введите корректное значение: ");
            }
            Console.WriteLine("Введите номер курса: ");
            int curs;
            while (!int.TryParse(Console.ReadLine(), out curs))
            {
                Console.Write("Неверный id! Введите корректное значение: ");
            }
            Console.WriteLine("Введите группу здоровья: ");
            string Hgroup = Console.ReadLine();
            Student t1 = new Student(id, fio, gender, Hgroup ,curs);
            Students.Add(t1);
            Console.WriteLine("Успешное добавление\n");
        }
        static void PrintCurs(List<Curs> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}--{list[i].Name}");
            }
        }
        static void PrintStudents(List<Student> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}--{list[i].FIO}");
            }
        }
        static void PrintTeachers(List<Teacher> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{(i+1)}--{list[i].FIO}");
            }
        }
    }
}
