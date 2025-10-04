using System.Reflection;

namespace university
{
    class Person
    {
        public string FIO;
        public DateOnly Birthday;
        public string Gender;

        public Person(string fio, DateOnly birthday, string gender)
        {
            FIO = fio;
            Birthday = birthday;
            Gender = gender;
        }
        public virtual void Print()
        {
            Console.WriteLine($"FIO: {FIO}\nBirthday: {Birthday}\nGender: {Gender} ");
        }
    }

    class Student : Person
    {
        private int StudentNumberID;
        
        private int CourseNumber;
        private string TheHealthGroup;

        public Student(int id, string fio, DateOnly birthday, string gender, string TheHealthGroup, int CourseNumber)
            : base(fio, birthday, gender)
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

        public Teacher(string fio, DateOnly birthday, string gender, string subject, int PCExperience)
            : base(fio, birthday, gender)
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
        public Curs(string name, string Subject, int ExperienceYears, string FIO, DateOnly Birthday, string Gender)
        : base(FIO, Birthday, Gender, Subject, ExperienceYears)
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
        public void Add(Student student)
        {
            Student_Curs.Add(student);
        }
    }
    class Program
    {
        List<Teacher> Teachers = new List<Teacher>();
        List<Student> Students = new List<Student>();
        List<Curs> curs = new List<Curs>();
        void Main(string[] args)
        {
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Выбирите действие из списка");
                string choose= Console.ReadLine();   
                Console.WriteLine("1. Добавить Студента");
                Console.WriteLine("2. Добавить Учителя");
                Console.WriteLine("3. Добавить Курс");
                Console.WriteLine("3. Запись студента на курс");
                Console.WriteLine("0. Выход");
                switch (choose)
                {
                    case "1":break;
                    case "2": break;
                    case "3": break;
                    case "4": break;
                    case "0":flag = true; break;
                    default:break;
                }
            }
        }
        void ADD_curs()
        {
            Console.WriteLine("Введите название курса");
            string Name = Console.ReadLine();
            Console.WriteLine("Выбирите преподавателя по фамилии");
            string LastName = Console.ReadLine();
            foreach (Teacher i in Teachers)
            {
                string[] stringArray = i.FIO.Split(' ');
                                
                if (stringArray[0]==LastName)
                {
                    Console.WriteLine("Введите название курса: ");
                    string name = Console.ReadLine();
                    Curs k1 = new Curs(name,i.Subject,i.ExperienceYears,i.FIO,i.Birthday,i.Gender);
                    curs.Add(k1);
                }
                else
                {
                    Console.WriteLine("Преподаватель не найден");
                }
                
            }
        }
        void ADD_Teacher()
        {
            Console.WriteLine("\nДобавление учителя");
            Console.WriteLine("Введите фио: ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите гендер: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения: ");
            DateOnly year;
            while (!DateOnly.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Неверная дата! Введите корректное значение: ");
            }
            Console.WriteLine("Введите предмет: ");
            string sbj = Console.ReadLine();
             Console.WriteLine("Введите стаж в годах: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.Write("Неверное количество! Введите корректное значение: ");
            }
           Teacher t1 = new Teacher(fio, year,gender,sbj,quantity);
           Teachers.Add(t1);
                
        }
        void ADD_Stusent()
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
                    curs[n].Add(i);
                    Console.WriteLine("Студент добавлен");
                }
                
            }
        }
        void ADD_Stusent_curs()
               
        {
            Console.WriteLine("\nДобавление студента");
            Console.WriteLine("Введите фио: ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите гендер: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения: ");
            DateOnly year;
            while (!DateOnly.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Неверная дата! Введите корректное значение: ");
            }
            Console.WriteLine("Введите предмет: ");
            string sbj = Console.ReadLine();
            Console.WriteLine("Введите стаж в годах: ");
            int StudentNumberID;
            while (!int.TryParse(Console.ReadLine(), out StudentNumberID) || StudentNumberID <= 0)
            {
                Console.Write("Неверное количество! Введите корректное значение: ");
            }
            Teacher t1 = new Teacher(fio, year, gender, sbj, StudentNumberID);
            Teachers.Add(t1);
        }
        static void PrintCurs(List<Curs> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}--{list[i].Name}");
            }
        }
    }
}

