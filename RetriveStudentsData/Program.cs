using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetriveStudentsData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\abdul\\Music\\Practice Exercises\\simplilearn\\SimplilearnPracticeProject\\StudentData1.txt";

            if (File.Exists(filePath))
            {
                string schoolName = "";
                bool isHeaderLine = true;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    schoolName = reader.ReadLine();
                    Console.WriteLine($"School Name: {schoolName}");
                    Console.WriteLine("Name \tAge \t Dept \t Batch \t Grade");
                    Console.WriteLine("---------------------------------------");
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (isHeaderLine)
                        {
                            isHeaderLine = false;
                            continue; 
                        }


                        string[] values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                        if (values.Length == 5)
                        {
                            string name = values[0];
                            int age = int.Parse(values[1]);
                            string department = values[2];
                            string batch = values[3];
                            double grade = double.Parse(values[4]);


                            Console.WriteLine($"{name,-5}\t{age,-2}\t{department,-3}\t{batch,-4}\t{grade,-4}");
                        }
                        else
                        {

                            Console.WriteLine("Invalid data format in the file.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            Console.ReadKey();
        }
    }
}
