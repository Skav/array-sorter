using projekt_sortowanie.algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_sortowanie
{
    internal abstract class PartClass
    {
        protected Stopwatch _stopwatch = new Stopwatch();
        protected int noOfTables;
        protected int[] tablesLenghts;
        protected int randSeed;
        protected int minRandValue;
        protected int maxRandValue;
        protected List<string> results = new List<string>();

        public PartClass(int[] dataSet)
        {
            this.noOfTables = dataSet[0];
            this.tablesLenghts = GenerateTableLenghts(dataSet[3], this.noOfTables, dataSet[1], dataSet[2]);
            this.randSeed = dataSet[4];
            this.minRandValue = dataSet[5];
            this.maxRandValue = dataSet[6];
        }

        public abstract List<string> Run();

        protected void CalculateTime(List<SortClass> sortAlgorithms, Dictionary<string, List<int[]>> tables, string partOfProject)
        {
            PrintMessage("Executing sort algorithms for simple tables");
            //Execute sorting functions to avoid incorrect results in first iterations
            foreach (var algorithm in sortAlgorithms)
                algorithm.Sort(new int[] { 1, 2, 3, 4 });


            foreach (var tableType in tables.Keys)
            {
                PrintMessage($"Started calculating time for {tableType} tables");
                foreach (var table in tables[tableType])
                {
                    var tableToSort = new int[table.Length];

                    foreach (var algorith in sortAlgorithms)
                    {
                        table.CopyTo(tableToSort, 0);
                        _stopwatch.Restart();
                        _stopwatch.Start();
                        algorith.Sort(tableToSort);
                        _stopwatch.Stop();

                        results.Add($"{partOfProject};{algorith.SortType};{tableType};{table.Length};{_stopwatch.ElapsedTicks}");
                    }
                }
            }
        }

        protected int[] GenerateTableLenghts(int randSeed, int noOfTables, int minTableLenght, int maxTableLenght)
        {
            Random random = new Random(randSeed);
            var lenghts = new int[noOfTables];

            for (int i = 0; i < noOfTables; i++)
                lenghts[i] = random.Next(minTableLenght, maxTableLenght + 1);

            return lenghts;

        }

        protected void PrintMessage(string text)
        {
            Console.WriteLine($"===== {text} =====");
        }

        protected List<int[]> GenerateListOfStaticTables()
        {
            var listOfTables = new List<int[]>();

            for (int i = 0; i < this.noOfTables; i++)
                listOfTables.Add(NumberGenerator.GenerateStableTable(this.tablesLenghts[i], 5));

            return listOfTables;
        }

        protected List<int[]> GenerateListOfLinearAscTables()
        {
            var listOfTables = new List<int[]>();

            for (int i = 0; i < this.noOfTables; i++)
                listOfTables.Add(NumberGenerator.GenerateAscendingTable(this.tablesLenghts[i]));

            return listOfTables;
        }

        protected List<int[]> GenerateListOfLinearDescTables()
        {
            var listOfTables = new List<int[]>();

            for (int i = 0; i < this.noOfTables; i++)
                listOfTables.Add(NumberGenerator.GenerateDescengingTable(this.tablesLenghts[i]));

            return listOfTables;
        }

        protected List<int[]> GenerateListOfRandomTables()
        {
            return NumberGenerator.GenerateListOfRandomTables(this.tablesLenghts, this.randSeed, this.minRandValue, this.maxRandValue);
        }

        protected List<int[]> GenerateListOfVShapedTables()
        {
            var listOfTables = new List<int[]>();

            for (int i = 0; i < this.noOfTables; i++)
                listOfTables.Add(NumberGenerator.GenerateVShapeTable(this.tablesLenghts[i]));

            return listOfTables;
        }

        protected List<int[]> GenerateListOfAShapedTables()
        {
            var listOfTables = new List<int[]>();

            for (int i = 0; i < this.noOfTables; i++)
                listOfTables.Add(NumberGenerator.GenerateAShapeTable(this.tablesLenghts[i]));

            return listOfTables;
        }

        public List<string> getResults()
        {
            return this.results;
        }


    }
}
