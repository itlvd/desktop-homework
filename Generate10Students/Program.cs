using System;
using System.Text;

namespace Generate10Students
{
    internal class Program
    {
        private static int numberStudent = 10;
        static void Main(string[] args)
        {
            string namesPath = @"../../../names.txt";
            string addressesPath = @"../../../addresses.txt";
            List<Student> stu = GenerateStudentInfor.GetInFo(namesPath, addressesPath, numberStudent);
            stu = stu.OrderByDescending(x => x.Score).ToList();


            double sum = 0.0;
            foreach (Student student in stu)
            {
                sum+= student.Score;
            }

            Console.WriteLine("Medium score of 10 student: " + Math.Round(sum/numberStudent, 2) + "\n\n");

            for(int i= 0; i < 3; i++)
            {
                Console.WriteLine(stu[i]);
            }
            Console.ReadKey();
        }
    }

    class CustomRandom {

        private static HashSet<int> randomSetInt(int minValue, int maxValue, int amount)
        {
            HashSet<int> set = new HashSet<int>();

            Random rng = new Random();

            while (set.Count < amount)
            {
                set.Add(rng.Next(minValue, maxValue));
            }

            return set;
        }
        
        public static T[] RandomDifferent<T>(T[] array, int amount)
        {
            T[] result = new T[amount];

            HashSet<int> set = randomSetInt(0, array.Length, amount);
            int i = 0;
            foreach (int index in set)
            {
                result[i++] = array[index];
            }

            return result;
        }

        public static string[] GenerateMSSV(int amount) {
            string[] result = new string[amount];

            HashSet<int> randomMSSV = randomSetInt(0, 999999, amount);

            int i = 0;
            Random random= new Random();
            
            foreach (int mssv in randomMSSV)
            {
                StringBuilder stringBuilder= new StringBuilder();

                stringBuilder.Append(random.Next(18,20));

                stringBuilder.Append(mssv.ToString().PadLeft(6,'0'));

                result[i++] = stringBuilder.ToString();
            }

            return result;
        }
    };

    class Student
    {
        private string id;
        private string name;
        private string address;
        private double score;

        public Student(string id, string name, string address, double score)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.score = score;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public double Score { get => score; set => score = value; }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: " + this.id + "\n");
            sb.Append("Name: " + this.name + "\n");
            sb.Append("Address: " + this.address + "\n");
            sb.Append("Score: " + this.score + "\n");

            return sb.ToString();
        }
    }

    class GenerateStudentInfor
    {

        public static List<Student> GetInFo(string namesPath, string addressesPath, int numberStudent)
        {
            string[] namesFile = File.ReadAllLines(namesPath);
            string[] addressesFile = File.ReadAllLines(addressesPath);

            Random rand = new Random();

            string[] names = CustomRandom.RandomDifferent(namesFile, numberStudent);
            string[] addresses = CustomRandom.RandomDifferent(addressesFile, numberStudent);
            string[] mssv = CustomRandom.GenerateMSSV(numberStudent);

            List<Student> student = new List<Student>();

            for(int i = 0; i < numberStudent; i++)
            {
                student.Add( new Student(mssv[i], names[i], addresses[i], Math.Round( rand.NextDouble() * 10, 2)));
            }

            return student;
        }

    }
}