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

            }
        }
    }
}

