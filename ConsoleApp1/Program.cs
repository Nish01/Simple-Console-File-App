using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

           
            string filePath = @"c:\temp\MyTest.txt";
            if (!File.Exists(filePath))
            {              
                string[] lines = { "5, 8, 13, 54, 3, 10", "7, 8, 9"};
                File.WriteAllLines(filePath, lines);
            }

            string fPath = @"c:\temp\averages.txt";
            File.Delete(fPath);

            string line;
            using (StreamReader sr = File.OpenText(filePath))
            {

                while ((line = sr.ReadLine()) != null)
                     {

                   // Console.WriteLine("First  " + line);
                     var splitted = line.Split(new[] { ", " },
                                           StringSplitOptions.RemoveEmptyEntries);
                    var doubles = splitted.Select(x => double.Parse(x)).ToArray();

                    double sum = 0;
                    int count = 0;
                    foreach (var a in doubles)
                    {
                        if (a%2 != 0){
                            sum += a;
                            count++;
                        }
                    }

                    sum = sum / count;

                    if (!File.Exists(fPath))
                    {
                       File.WriteAllText(fPath, sum + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText(fPath, sum + Environment.NewLine);
                        //append to file
                    }
                }
  
            }


           // Console.ReadKey();

        }
    }
}
