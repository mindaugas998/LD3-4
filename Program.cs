using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Linq;


namespace LD3_4_v1.0
{
    class Student
    {
        public string Surname;
        public string Name;
        public int[] HW;
        public int Exam;

        public string surname { get => Surname; set => Surname = value; }
        public string name { get => Name; set => Name = value; }
        public int[] hw { get => HW; set => HW = value; }
        public int exam { get => Exam; set => Exam = value; }
    }
    class Program
    {


        static void Main(string[] args)
        {
            LinkedList<Student> students = new LinkedList<Student>();
            LinkedList<Student> studentPassed = new LinkedList<Student>();
            LinkedList<Student> studentFailed = new LinkedList<Student>();

            //--- MENU ----------------------------------- 
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
            bool MainMenu()
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) add student(s)");
                Console.WriteLine("2) print all students");
                Console.WriteLine("3) print all students with median");
                Console.WriteLine("4) add students with random homework and exam results");
                Console.WriteLine("5) add students from file");
                Console.WriteLine("6) generate 4 files consisting of 10000, 100000, 1000000 and 10000000 students");
                Console.WriteLine("7) divide records into failed and passed");
                Console.WriteLine("0) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        addStudent(students);
                        return true;
                    case "2":
                        printStudentList(students);
                        return true;
                    case "3":
                        printStudentListMedian(students);
                        return true;
                    case "4":
                        addStudentRandom(students);
                        return true;
                    case "5":
                        addStudentFromFile(students);
                        return true;
                    case "6":
                        generateLargeStudents(students);
                        return true;
                    case "7":
                        divideStudents(studentPassed, studentFailed);
                        return true;
                    case "0":
                        return false;
                    default:
                        return true;
                }
            }
            //------------------------------------------- 
        }
        // --- STUDENTO PRIDEJIMO I LISTA FUNKCIJA
        public static void addStudent(LinkedList<Student> students)
        {
            Console.WriteLine("how many students will you add?: ");
            int userInputtedStudentCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < userInputtedStudentCount; i++)
            {
                Console.WriteLine("Enter student surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter student name: ");
                string name = Console.ReadLine();
                List<int> homework = new List<int>();
                bool keepEntering = true;
                string input = "";
                int y = 0;
                Console.WriteLine("Type 'stop' to stop entering homework results");
                while (keepEntering)
                {
                    Console.WriteLine("Enter homework result {0}: ", y + 1);
                    input = Console.ReadLine();

                    if (input == "stop")
                    {
                        keepEntering = false;
                        break;
                    }
                    else
                    {
                        homework.Add(int.Parse(input));
                        y++;
                    }
                }
                Console.WriteLine("Enter exam result: ");
                int exam = int.Parse(Console.ReadLine());
                Student st = new Student();
                st.surname = surname;
                st.name = name;
                st.hw = homework.ToArray();
                st.exam = exam;

                students.AddLast(st);
            }
        }
        // --- ATSPAUSDINTI GRAZU STUDENTU SARASA SU STRING FORMATAIS
        public static void printStudentList(LinkedList<Student> students)
        {
            try
            {
                Program p = new Program();
                Console.WriteLine("{0,-20} {1,-10} {2, 20}", "Surname", "Name", "Final points(Avg.)");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine("{0,-20} {1,-10} {2,20:N2} ", students.ElementAt(i).Surname, students.ElementAt(i).Name, p.finalPoints(students.ElementAt(i).HW, students.ElementAt(i).Exam));
                }
                Console.WriteLine("...");
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                Console.WriteLine("Key not found.");
                System.Environment.Exit(1);
            }
        }
        // --- FUNKCIJA SPAUSDINTI STUDENTU SARASA SU MEDIANA
        public static void printStudentListMedian(LinkedList<Student> students)
        {

            Program p = new Program();
            Console.WriteLine("{0,-20} {1,-10} {2, 20} {3, 20}", "Surname", "Name", "Final points(Avg.)", " / Final points (Med.)");
            Console.WriteLine("---------------------------------------------------------------------------");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,20:N2} {3,20:N2} ", students.ElementAt(i).Surname, students.ElementAt(i).Name, p.finalPoints(students.ElementAt(i).HW, students.ElementAt(i).Exam), p.median(students.ElementAt(i).HW));
            }
            Console.WriteLine("...");

        }
        // --- SKAICIUOJAM FINALPOINTS VALUE
        public double finalPoints(int[] hw, int egzam)
        {
            double sum = 0;
            int count = hw.Length;
            for (int i = 0; i < count; i++)
            {
                sum = sum + hw[i];
            }
            double average_of_hw = sum / count;
            return 0.3 * average_of_hw + 0.7 * egzam;

        }
        // --- SKAICIUOJAM MEDIANA
        public decimal median(int[] arr)
        {
            int[] temp = arr;
            int arrLenght = temp.Length;

            Array.Sort(temp);
            decimal median;

            if (arrLenght % 2 == 0)
            {
                int elem1 = temp[(arrLenght / 2) - 1];
                int elem2 = temp[(arrLenght / 2)];
                median = (elem1 + elem2) / 2;
            }
            else
            {
                median = temp[(arrLenght / 2)];
            }
            return median;
        }
        // --- FUNKCIJA PRIDET STUDENTUS SU RANDOM NAMŲ DARBŲ IR EGZŲ REZULTATAIS
        public static void addStudentRandom(LinkedList<Student> students)
        {
            Console.WriteLine("how many students will you add?: ");
            int userInputtedStudentCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < userInputtedStudentCount; i++)
            {
                Console.WriteLine("Enter student surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter student name: ");
                string name = Console.ReadLine();
                int[] homework = new int[5];
                Random r = new Random();

                for (int y = 0; y < 5; y++)
                {
                    homework[y] = r.Next(1, 10);
                }
                int exam = r.Next(1, 10);

                Student st = new Student();
                st.surname = surname;
                st.name = name;
                st.hw = homework;
                st.exam = exam;

                students.AddLast(st);
            }
        }
        // PRIDEDAM STUDENTUS I LISTA IS FAILO 
        public static void addStudentFromFile(LinkedList<Student> students)
        {
            StreamReader file = new StreamReader(@"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students.txt");
            string line;

            string header = file.ReadLine();
            header = null;

            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(" ");
                Student st = new Student();

                string surname = data[0];
                string name = data[1];
                int[] hw = new int[5];
                int y = 0;
                for (int i = 2; i <= 6; i++)
                {
                    hw[y] = int.Parse(data[i]);
                    y++;
                }
                int exam = int.Parse(data[7]);

                st.surname = surname;
                st.name = name;
                st.hw = hw;
                st.exam = exam;
                //Console.WriteLine("surname: " + st.name + " name: " + st.name + " hw: " + st.hw[0]+" " + st.hw[1] + " " + st.hw[2] + " " + st.hw[3] + " " + st.hw[4] + " exam: "+st.exam);
                students.AddLast(st);
            }
            file.Close();
            Console.WriteLine("Read complete.");
        }
        public static void generateLargeStudents(LinkedList<Student> students)
        {
            Stopwatch fileCreationTime = Stopwatch.StartNew();
            string students10k = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10k.txt";
            string students100k = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students100k.txt";
            string students1mil = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students1mil.txt";
            string students10mil = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10mil.txt";

            Random r = new Random();

            var input10k = new StreamWriter(students10k);
            var input100k = new StreamWriter(students100k);
            var input1mil = new StreamWriter(students1mil);
            var input10mil = new StreamWriter(students10mil);

            Stopwatch tenThousand_fileCreationTime = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                string surname = "Surname" + i;
                string name = "Name" + i;
                int[] homework = new int[5];
                for (int y = 0; y <= 4; y++)
                {
                    homework[y] = r.Next(1, 11);
                }
                int exam = r.Next(1, 11);

                input10k.WriteLine(surname + " " + name + " " + homework[0] + " " + homework[1] + " " + homework[2] + " " + homework[3] + " " + homework[4] + " " + exam);
            }
            tenThousand_fileCreationTime.Stop();
            Stopwatch hundredThousand_fileCreationTime = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                string surname = "Surname" + i;
                string name = "Name" + i;
                int[] homework = new int[5];
                for (int y = 0; y <= 4; y++)
                {
                    homework[y] = r.Next(1, 11);
                }
                int exam = r.Next(1, 10);

                input100k.WriteLine(surname + " " + name + " " + homework[0] + " " + homework[1] + " " + homework[2] + " " + homework[3] + " " + homework[4] + " " + exam);
            }
            hundredThousand_fileCreationTime.Stop();
            Stopwatch million_fileCreationTime = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                string surname = "Surname" + i;
                string name = "Name" + i;
                int[] homework = new int[5];
                for (int y = 0; y <= 4; y++)
                {
                    homework[y] = r.Next(1, 11);
                }
                int exam = r.Next(1, 11);

                input1mil.WriteLine(surname + " " + name + " " + homework[0] + " " + homework[1] + " " + homework[2] + " " + homework[3] + " " + homework[4] + " " + exam);
            }
            million_fileCreationTime.Stop();
            Stopwatch tenMillion_fileCreationTime = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                string surname = "Surname" + i;
                string name = "Name" + i;
                int[] homework = new int[5];
                for (int y = 0; y <= 4; y++)
                {
                    homework[y] = r.Next(1, 11);
                }
                int exam = r.Next(1, 11);

                input10mil.WriteLine(surname + " " + name + " " + homework[0] + " " + homework[1] + " " + homework[2] + " " + homework[3] + " " + homework[4] + " " + exam);
            }
            tenMillion_fileCreationTime.Stop();
            fileCreationTime.Stop();
            Console.WriteLine("It took {0} miliseconds to create and fill all files.", fileCreationTime.ElapsedMilliseconds);
            Console.WriteLine("It took {0} miliseconds to create 10 000 records.", tenThousand_fileCreationTime.ElapsedMilliseconds);
            Console.WriteLine("It took {0} miliseconds to create 100 000 records.", hundredThousand_fileCreationTime.ElapsedMilliseconds);
            Console.WriteLine("It took {0} miliseconds to create 1 000 000 records.", million_fileCreationTime.ElapsedMilliseconds);
            Console.WriteLine("It took {0} miliseconds to create 10 000 000 records.", tenMillion_fileCreationTime.ElapsedMilliseconds);
        }
        public static void divideStudents(LinkedList<Student> studentPassed, LinkedList<Student> studentFailed)
        {
            Program method = new Program();
            string students10k = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10k.txt";
            string students100k = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students100k.txt";
            string students1mil = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students1mil.txt";
            string students10mil = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10mil.txt";

            string students10k_p = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10k_p.txt";
            string students100k_p = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students100k_p.txt";
            string students1mil_p = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students1mil_p.txt";
            string students10mil_p = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10mil_p.txt";

            string students10k_f = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10k_f.txt";
            string students100k_f = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students100k_f.txt";
            string students1mil_f = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students1mil_f.txt";
            string students10mil_f = @"C:\Users\006ic\source\repos\LD3-4 v0.5\LD3-4 v0.5\students10mil_f.txt";

            var input10k_p = new StreamWriter(students10k_p);
            var input100k_p = new StreamWriter(students100k_p);
            var input1mil_p = new StreamWriter(students1mil_p);
            var input10mil_p = new StreamWriter(students10mil_p);

            var input10k_f = new StreamWriter(students10k_f);
            var input100k_f = new StreamWriter(students100k_f);
            var input1mil_f = new StreamWriter(students1mil_f);
            var input10mil_f = new StreamWriter(students10mil_f);

            // divide 10k records ---------------------------------------------------------------------------------
            Stopwatch tenThousand_splittingDuration = Stopwatch.StartNew();
            StreamReader file = new StreamReader(students10k);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(" ");
                Student st = new Student();

                string surname = data[0];
                string name = data[1];
                int[] hw = new int[5];
                int y = 0;
                for (int i = 2; i <= 6; i++)
                {
                    hw[y] = int.Parse(data[i]);
                    y++;
                }
                int exam = int.Parse(data[7]);

                double finalpoints = method.finalPoints(hw, exam);

                st.surname = surname;
                st.name = name;
                st.hw = hw;
                st.exam = exam;

                if (finalpoints < 5) { studentFailed.AddLast(st); }
                else { studentPassed.AddLast(st); }
            }
            tenThousand_splittingDuration.Stop();
            Stopwatch tenThousand_writingDuration = Stopwatch.StartNew();
            foreach (var item in studentFailed)
            {
                input10k_f.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            foreach (var item in studentPassed)
            {
                input10k_p.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            tenThousand_writingDuration.Stop();
            studentPassed.Clear();
            studentFailed.Clear();
            file.Close();
            // ------------------------------------------------------------------------------------------------------
            // divide 100k records ---------------------------------------------------------------------------------
            Stopwatch hundredThousand_splittingDuration = Stopwatch.StartNew();
            StreamReader file1 = new StreamReader(students100k);
            string line1;
            while ((line1 = file1.ReadLine()) != null)
            {
                string[] data = line1.Split(" ");
                Student st = new Student();

                string surname = data[0];
                string name = data[1];
                int[] hw = new int[5];
                int y = 0;
                for (int i = 2; i <= 6; i++)
                {
                    hw[y] = int.Parse(data[i]);
                    y++;
                }
                int exam = int.Parse(data[7]);

                double finalpoints = method.finalPoints(hw, exam);

                st.surname = surname;
                st.name = name;
                st.hw = hw;
                st.exam = exam;

                if (finalpoints < 5) { studentFailed.AddLast(st); }
                else { studentPassed.AddLast(st); }
            }
            hundredThousand_splittingDuration.Stop();
            Stopwatch hundredThousand_writingDuration = Stopwatch.StartNew();
            foreach (var item in studentFailed)
            {
                input100k_f.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            foreach (var item in studentPassed)
            {
                input100k_p.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            hundredThousand_writingDuration.Stop();
            studentPassed.Clear();
            studentFailed.Clear();
            file1.Close();
            // ------------------------------------------------------------------------------------------------------
            // divide 1 mil records ---------------------------------------------------------------------------------
            Stopwatch million_splittingDuration = Stopwatch.StartNew();
            StreamReader file2 = new StreamReader(students1mil);
            string line2;
            while ((line2 = file2.ReadLine()) != null)
            {
                string[] data = line2.Split(" ");
                Student st = new Student();

                string surname = data[0];
                string name = data[1];
                int[] hw = new int[5];
                int y = 0;
                for (int i = 2; i <= 6; i++)
                {
                    hw[y] = int.Parse(data[i]);
                    y++;
                }
                int exam = int.Parse(data[7]);

                double finalpoints = method.finalPoints(hw, exam);

                st.surname = surname;
                st.name = name;
                st.hw = hw;
                st.exam = exam;

                if (finalpoints < 5) { studentFailed.AddLast(st); }
                else { studentPassed.AddLast(st); }
            }
            million_splittingDuration.Stop();
            Stopwatch million_writingDuration = Stopwatch.StartNew();
            foreach (var item in studentFailed)
            {
                input1mil_f.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            foreach (var item in studentPassed)
            {
                input1mil_p.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            million_writingDuration.Stop();
            studentPassed.Clear();
            studentFailed.Clear();
            file2.Close();
            // ------------------------------------------------------------------------------------------------------
            // divide 10 mil records ---------------------------------------------------------------------------------
            Stopwatch tenMillion_splittingDuration = Stopwatch.StartNew();
            StreamReader file3 = new StreamReader(students10mil);
            string line3;
            while ((line3 = file3.ReadLine()) != null)
            {
                string[] data = line3.Split(" ");
                Student st = new Student();

                string surname = data[0];
                string name = data[1];
                int[] hw = new int[5];
                int y = 0;
                for (int i = 2; i <= 6; i++)
                {
                    hw[y] = int.Parse(data[i]);
                    y++;
                }
                int exam = int.Parse(data[7]);

                double finalpoints = method.finalPoints(hw, exam);

                st.surname = surname;
                st.name = name;
                st.hw = hw;
                st.exam = exam;

                if (finalpoints < 5) { studentFailed.AddLast(st); }
                else { studentPassed.AddLast(st); }
            }
            tenMillion_splittingDuration.Stop();
            Stopwatch tenMillion_writingDuration = Stopwatch.StartNew();
            foreach (var item in studentFailed)
            {
                input1mil_f.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            foreach (var item in studentPassed)
            {
                input1mil_p.WriteLine(item.surname + " " + item.name + " " + item.hw[0] + " " + item.hw[1] + " " + item.hw[2] + " " + item.hw[3] + " " + item.hw[4] + " " + item.exam);
            }
            tenMillion_writingDuration.Stop();
            studentPassed.Clear();
            studentFailed.Clear();
            file3.Close();
            // ------------------------------------------------------------------------------------------------------
            Console.WriteLine("Time elapsed to divide 10k records: {0} ms", tenThousand_splittingDuration.ElapsedMilliseconds);
            Console.WriteLine("Time elapsed to output divided 10k records: {0} ms", tenThousand_writingDuration.ElapsedMilliseconds);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Time elapsed to divide 100k records: {0} ms", hundredThousand_splittingDuration.ElapsedMilliseconds);
            Console.WriteLine("Time elapsed to output divided 100k records: {0} ms", hundredThousand_writingDuration.ElapsedMilliseconds);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Time elapsed to divide 1 million records: {0} ms", million_splittingDuration.ElapsedMilliseconds);
            Console.WriteLine("Time elapsed to output divided 1 million records: {0} ms", million_writingDuration.ElapsedMilliseconds);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Time elapsed to divide 10 million records: {0} ms", tenMillion_splittingDuration.ElapsedMilliseconds);
            Console.WriteLine("Time elapsed to output divided 10 million records: {0} ms", tenMillion_writingDuration.ElapsedMilliseconds);

        }



    }
}
