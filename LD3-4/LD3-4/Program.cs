﻿using System;
using System.Collections.Generic;

namespace LD3_4
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
            List<Student> students = new List<Student>();


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
                    case "0":
                        return false;
                    default:
                        return true;
                }
            }
            //------------------------------------------- 
        }
        // --- STUDENTO PRIDEJIMO I LISTA FUNKCIJA
        public static void addStudent(List<Student> students)
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

               students.Add(st);
            }
        }
        // --- ATSPAUSDINTI GRAZU STUDENTU SARASA SU STRING FORMATAIS
        public static void printStudentList(List<Student> students)
        {
            Program p = new Program();
            Console.WriteLine("{0,-20} {1,-10} {2, 20}", "Surname", "Name", "Final points(Avg.)");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,20:N2} ", students[i].Surname, students[i].Name, p.finalPoints(students[i].HW, students[i].Exam));
            }
            Console.WriteLine("...");
        }
        // --- FUNKCIJA SPAUSDINTI STUDENTU SARASA SU MEDIANA
        public static void printStudentListMedian(List<Student> students)
        {

            Program p = new Program();
            Console.WriteLine("{0,-20} {1,-10} {2, 20} {3, 20}", "Surname", "Name", "Final points(Avg.)", " / Final points (Med.)");
            Console.WriteLine("---------------------------------------------------------------------------");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,20:N2} {3,20:N2} ", students[i].Surname, students[i].Name, p.finalPoints(students[i].HW, students[i].Exam), p.median(students[i].HW));
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
        public static void addStudentRandom(List<Student> students)
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

                students.Add(st);
            }
        }
        
    }
}
