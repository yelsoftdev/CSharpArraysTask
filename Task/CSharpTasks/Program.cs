using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpTasks
{
    public class Program
    {
        private static List<Person> persons = new List<Person>();
        private static void GetPeopleDetails()
        {
            persons.Add(new Person { name = "Ram", age = 40 });
            persons.Add(new Person { name = "Raja", age = 55 });
            persons.Add(new Person { name = "Ramarao", age = 44 });
        }
        static void Main(string[] args)
        {
            int taskNo;
            Console.Write("\nTask details");
            Console.Write("\n***********************");
            Console.Write("\n1 - An array of integers and show only even integers");
            Console.Write("\n2 - Check if the text is a number or not");
            Console.Write("\n3 - Multiplication of two integer numbers, but not using the operator *. You must use consecutive sums");
            Console.Write("\n4 - To read a text file and make a copy in another file by changing the lowercase letters to uppercase.");
            Console.Write("\n5 - ArrayList to store and display a list of people.");
            Console.Write("\n***********************\n");
            Console.Write("\nEnter a number to view the task details:");
            taskNo = Convert.ToInt32(Console.ReadLine());
            switch (taskNo)
            {
                case 1:
                    GetEvenIntegers();
                    break;
                case 2:
                    bool checkIsNumber = IsNumber();
                    if (checkIsNumber)
                        Console.Write("\nYou are entered text is Number");
                    else
                        Console.Write("\nYou are entered text is Not a Number");
                    break;
                case 3:
                    MultiplyNumbersWithoutStar();
                    break;
                case 4:
                    ConvertTextFileToUppercase();
                    break;
                case 5:
                    PrintListOfPeoples(); // Prints the data of the people going through the list of data //
                    break;
                default:
                    Console.Write("\nPlease enter valid task number");
                    break;
            }
            Console.Write("\n\n");
        }

        private static void GetEvenIntegers()
        {
            int i, n = 10;
            int[] arrNos = new int[n];
            try
            {
                Console.Write("\n\nAn array of integers and show only even integers:\n");
                Console.Write("------------------------------------------------------\n");
                Console.Write("Enter {0} elements in the array :\n", n);
                for (i = 0; i < n; i++)
                {
                    Console.Write(String.Format($"element - {i} : "));
                    arrNos[i] = Convert.ToInt32(Console.ReadLine());
                }
                var arrEvenNos = arrNos.Where(n => n % 2 == 0).Select(x => x).ToArray();
                if (arrEvenNos.Count() > 0)
                {
                    Console.Write("\nThe Even elements are : \n");
                    foreach (var evenNo in arrEvenNos)
                    {
                        Console.Write(String.Format($"{evenNo} "));
                    }
                }
                else
                {
                    Console.Write("\nYou are not entered even numbers. \n");
                }
            }
            catch (Exception ex)
            {
                Console.Write("\nYou are entered invalid numbers. \n");
            }
        }

        private static bool IsNumber()
        {
            try
            {
                double d;
                Console.Write("\nEnter a text to check number or not:");
                string strText = Convert.ToString(Console.ReadLine());
                return double.TryParse(strText, out d);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static void MultiplyNumbersWithoutStar()
        {
            try
            {
                int firstNo, secondNo, result = 0, i = 0;
                Console.Write("\nEnter the first number:");
                firstNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter the second number:");
                secondNo = Convert.ToInt32(Console.ReadLine());
                while (i < secondNo)
                {
                    result += firstNo;
                    i++;
                }
                Console.WriteLine(String.Format($"\n{firstNo} x {secondNo} = {result}\n"));
            }
            catch (Exception ex)
            {
                Console.Write("\nYou are entered invalid numbers. \n");
            }
        }

        private static void ConvertTextFileToUppercase()
        {
            try
            {
                string fileFolder = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                fileFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(fileFolder).FullName).FullName).FullName + @"\Files";
                string inputFileName = fileFolder + @"\InputTextFile.txt";
                string outputFileName = fileFolder + @"\OutputTextFile.txt";
                string contents = File.ReadAllText(inputFileName);
                contents = contents.ToUpper();
                File.WriteAllText(outputFileName, contents);
                Console.Write(String.Format($"\nInput file texts converted to upper case and appended to {outputFileName} \n"));
            }
            catch (Exception ex)
            {
                Console.Write("\nSome errors occured. \n");
            }
        }

        private static void PrintListOfPeoples()
        {
            try
            {
                GetPeopleDetails();// 
                Console.Write("\nList of Peoples");
                Console.Write("\n*************************");
                Console.Write("\nName\t\t Age\n");
                foreach (var person in persons)
                {
                    Console.Write(String.Format($"\n{person.name}\t\t {person.age}"));
                }
            }
            catch (Exception ex)
            {
                Console.Write("\nSome errors occured. \n");
            }
        }
    }
}
