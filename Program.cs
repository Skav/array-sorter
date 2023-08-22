using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projekt_sortowanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fo = new FileOperator();
            var dataSet = new int[] {};
            int choosenOption;
            var isRunning = true;
            while (isRunning)
            {
                DrawMenu();
                while (!int.TryParse(Console.ReadLine(), out choosenOption) || choosenOption < 1 || choosenOption > 5)
                    Console.WriteLine("Incorrect value, try again: ");

                switch (choosenOption)
                {
                    case 1:
                        var dataSetValues = createDataSetCSV();
                        Console.WriteLine($"Data set saved to: {fo.CreateDataSetFile(dataSetValues)}");
                        break;

                    case 2:
                        var avaliableFiles = fo.GetAllDataSetFiles();
                        DrawFileToChoose(avaliableFiles.Keys.ToArray());

                        var filePaths = fo.GetAllDataSetFiles().Values.ToArray();
                        int choosedFile;
                        while (!int.TryParse(Console.ReadLine(), out choosedFile) || choosedFile < 1 || choosedFile > filePaths.Length)
                            Console.Write("\nInvalid input, try again");

                        dataSet = fo.ReadDataSetFromFile(filePaths[choosedFile - 1]);
                        Console.WriteLine($"Load data from file: {filePaths[choosedFile - 1]}");
                        break;

                    case 3:
                        if (dataSet == null || dataSet.Length == 0)
                        {
                            Console.WriteLine("You need to load data set first!");
                            break;
                        }

                        var firstPart = new FirstPart(dataSet);
                        var path = fo.CreateResultsFile("1&2", firstPart.Run());

                        Console.WriteLine("===== Calculing ended sucessfuly =====");
                        Console.WriteLine($"Result file saved to: {path}");
                        break;

                    case 4:
                        if (dataSet == null || dataSet.Length == 0)
                        {
                            Console.WriteLine("You need to load data set first!");
                            break;
                        }

                        // Creating new theard to avoid problems with StackOverflow exception
                        var results = new List<string>();
                        var thirdPart = new ThirdPart(dataSet);
                        var thread = new Thread(new ThreadStart(thirdPart.RunWithoutReturn), 64 * 1024 * 1024);
                        thread.Start();
                        thread.Join();

                        results = thirdPart.getResults();
                        var pathToFile = fo.CreateResultsFile("3", results);

                        Console.WriteLine("===== Calculing ended sucessfuly =====");
                        Console.WriteLine($"Result file saved to: {pathToFile}");
                        break;

                    case 5:
                        isRunning = false;
                        break;
                }
            }
        }

        static void DrawMenu()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("1. Generate data set");
            Console.WriteLine("2. Load data set");
            Console.WriteLine("3. Start calculating data for 1st and 2nd part of project");
            Console.WriteLine("4. Start calculating data for 3rd part of project");
            Console.WriteLine("5. Exit");
            Console.WriteLine("=====================");

            Console.Write("\n\nChoose option: ");
        }

        static void DrawFileToChoose(string[] files)
        {
            Console.WriteLine("=====================");
            for(int i = 0; i< files.Length; i++)
                Console.WriteLine($"{i+1}. {files[i]}");
            Console.WriteLine("=====================");
            Console.Write("Choose file you want to load: ");
        }

        /*
         * CSV file layout
         * number_of_tables_in_every_table; table_min_lenght; table_max_lenght;random_seed_for_jump; random_seed_for_generate_random_table; minValue; maxValue 
         * */
        static string createDataSetCSV()
        {
            int noOfTables, tableMinLenght, tableMaxLenght, randJumpSeed, randSeed, minRandValue, maxRandValue;

            Console.Write("\nEnter number of tables for every table type: ");
            while (!int.TryParse(Console.ReadLine(), out noOfTables) || noOfTables <= 0 || noOfTables > int.MaxValue)
                Console.WriteLine("Incorrect value, please try again: ");

            Console.Write($"\nEnter a min. lenght of table (0-{int.MaxValue}): ");
            while (!int.TryParse(Console.ReadLine(), out tableMinLenght) || tableMinLenght < 0 || tableMinLenght > int.MaxValue)
                Console.WriteLine("Incorrect value, please try again: ");

            Console.Write($"\nEnter a max. lenght of table ({tableMinLenght}-{int.MaxValue}): ");
            while (!int.TryParse(Console.ReadLine(), out tableMaxLenght) || tableMaxLenght < tableMinLenght || tableMaxLenght > int.MaxValue)
                Console.WriteLine("Incorrect value, please try again: ");

            Console.Write($"\nEnter a inteeger seed for random generate jump of table lenght ({int.MinValue} - {int.MaxValue}): ");
            while (!int.TryParse(Console.ReadLine(), out randJumpSeed))
                Console.WriteLine("Incorrect value, please try again: ");
            
            Console.Write($"\nEnter a inteeger seed for random generate value in random table ({int.MinValue} - {int.MaxValue}): ");
            while (!int.TryParse(Console.ReadLine(), out randSeed))
                Console.WriteLine("Incorrect value, please try again: ");

            Console.Write($"\nEnter a min. value of number in random table ({int.MinValue} - {int.MaxValue}): ");
            while (!int.TryParse(Console.ReadLine(), out minRandValue))
                Console.WriteLine("Incorrect value, please try again: ");

            Console.Write($"\nEnter a max. value of number in random table ({minRandValue}-{int.MaxValue}): ");
            while (!int.TryParse(Console.ReadLine(), out maxRandValue) || maxRandValue < minRandValue)
                Console.WriteLine("Incorrect value, please try again: ");

            return $"{noOfTables};{tableMinLenght};{tableMaxLenght};{randJumpSeed};{randSeed};{minRandValue};{maxRandValue}";
        }
    }
}
