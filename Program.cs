using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CrimeAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Crime Analyzer");
            Console.WriteLine("\n");
            Console.WriteLine("This program analyzes crime statistics.");

            if (args.Length >= 2)
            {
                string reportFile = args[1];
                var csvFile = args[0];

                try
                {
                    using (var sr = new StreamReader(csvFile))
                    {
                        List<string> years = new List<string>();
                        List<string> populations = new List<string>();
                        List<string> violentCrimes = new List<string>();
                        List<string> murders = new List<string>();
                        List<string> rapes = new List<string>();
                        List<string> robberies = new List<string>();
                        List<string> aggAssaults = new List<string>();
                        List<string> propertyCrimes = new List<string>();
                        List<string> burglaries = new List<string>();
                        List<string> thefts = new List<string>();
                        List<string> mvts = new List<string>();


                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            //int intLine = System.Convert.ToInt32(line);
                            var values = line.Split(',');

                            int year = Int32.Parse(values[0]);
                            int population = Int32.Parse(values[1]);
                            int violentCrime = Int32.Parse(values[2]);
                            int murder = Int32.Parse(values[3]);
                            int rape = Int32.Parse(values[4]);
                            int robbery = Int32.Parse(values[5]);
                            int aggravatedAssault = Int32.Parse(values[6]);
                            int propertyCrime = Int32.Parse(values[7]);
                            int burglary = Int32.Parse(values[8]);
                            int theft = Int32.Parse(values[9]);
                            int mvt = Int32.Parse(values[10]);
                            CrimeStats crimeStats = new CrimeStats(year, population, violentCrime, murder, rape, robbery, aggravatedAssault, propertyCrime, burglary, theft, mvt);


                            IEnumerable<string> yearQuery =
                            from year1 in years
                            where murder < 15000
                            select year1;
                            foreach (string year1 in yearQuery)
                            {

                                Console.WriteLine(year + "");
                            }
                        }

                        //Question 1
                        string minYear = years[1];
                        string maxYear = years.Last();
                        //int yearRange = maxYear - minYear + 1;
                       
                        
                       /* IEnumerable<string> yearQuery =
                            from year in years
                            where murder < 15000
                            select year;
                        foreach (string year in yearQuery)
                        {
                            Console.WriteLine(year + "");
                        }*/
                        StringBuilder newString = new StringBuilder();
                        newString.Append("Crime Analyzer Report");
                        newString.Append(Environment.NewLine);
                        newString.Append(Environment.NewLine);
                        newString.Append("Period: " + minYear + "-" + maxYear);

                        using (var stream = new StreamWriter(reportFile))
                        {
                            stream.Write(newString.ToString());
                            Console.WriteLine(newString.ToString());
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            else
                {
                    Console.WriteLine("You must provide 2 arguments: .csv file and report file.");
                }
          
        }
    }
}
