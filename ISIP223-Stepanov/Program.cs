namespace university
{
    class Person
    {
        private string FIO;
        private DateOnly Birthday;
        private string Gender;

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
        private bool PCExperience;
        private int CourseNumber;
        private string TheHealthGroup;

        public Student(int id, string fio, DateOnly birthday, string gender, bool PCExperience, string TheHealthGroup, int CourseNumber)
            : base(fio, birthday, gender)
        {
            StudentNumberID = id;
            this.PCExperience = PCExperience;
            this.CourseNumber = CourseNumber;
            this.TheHealthGroup = TheHealthGroup;
        }

        public override void Print()
        {
            Console.WriteLine("Student");
            base.Print();
            Console.WriteLine($"StudentNumberID: {StudentNumberID}\nPCExperience: {PCExperience}\nTheHealthGroup: {TheHealthGroup}\nCourseNumber: {CourseNumber}\n");
        }
    }

    class Teacher : Person
    {
        private string Subject;
        private int ExperienceYears;

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
    }
    class Program
    {
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
            foreach Teacher i in Teachers
            {
                var arr=i.FIO.Split(' ');
                if(arr[0]==LastName)
                {
                    curs 
                }
                
            }
        }
        void ADD_Teacher()
        {
            
        }
        void ADD_Stusent()
        {

        }
        void ADD_Stusent_curs()
        {

        }
    }
}

