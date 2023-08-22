using projekt_sortowanie.algorithms;
using System.Collections.Generic;

namespace projekt_sortowanie
{
    internal class ThirdPart : PartClass
    {
        public ThirdPart(int[] dataSet): base(dataSet){}

        public override List<string> Run()
        {
            PrintMessage("Starting create tables");

            var tables = new Dictionary<string, List<int[]>>()
            {
                {"Random", GenerateListOfRandomTables()},
            };

            PrintMessage("Starting generate algorithms classes");

            var sortAlgorithms = new List<SortClass>
            {
                new QuickSort(),
                new QuickSortIter()
            };

            CalculateTime(sortAlgorithms, tables, "3.1");
            PrintMessage("Endedup calculing time for quick sort with random tables");


            PrintMessage("Stating calculate time for diffrent pivot position for A shaped tables");
            tables = new Dictionary<string, List<int[]>>()
            {
                {"AShaped", GenerateListOfAShapedTables()},
            };

            var quickSort = new QuickSort(this.randSeed);

            foreach (var tableType in tables.Keys)
            {
                foreach(var table in tables[tableType])
                {
                    var tableToSort = new int[table.Length];

                    table.CopyTo(tableToSort, 0);
                    _stopwatch.Restart();
                    _stopwatch.Start();
                    quickSort.SortMiddlePivot(tableToSort, 0, tableToSort.Length - 1);
                    _stopwatch.Stop();

                    PrintMessage("Ended up calculating time for middle pivot");

                    results.Add($"3.2;pivot_center;{tableType};{table.Length};{_stopwatch.ElapsedTicks}");

                    table.CopyTo(tableToSort, 0);
                    _stopwatch.Restart();
                    _stopwatch.Start();
                    quickSort.SortRightPivot(tableToSort, 0, tableToSort.Length-1);
                    _stopwatch.Stop();

                    PrintMessage("Ended up calculating time for right pivot");

                    results.Add($"3.2;pivot_right;{tableType};{table.Length};{_stopwatch.ElapsedTicks}");

                    table.CopyTo(tableToSort, 0);
                    _stopwatch.Restart();
                    _stopwatch.Start();
                    quickSort.SortRandomPivot(tableToSort, 0, tableToSort.Length - 1);
                    _stopwatch.Stop();

                    PrintMessage("Ended up calculating time for random pivot");

                    results.Add($"3.2;pivot_rand;{tableType};{table.Length};{_stopwatch.ElapsedTicks}");
                }
            }

            return results;
        }

        /*
         * This is identical function as Run(), but this function doesn't return anything, 
         * because Thread class doesnt allowed starting function with any return
         * but we can still get results by using getResults() function
         */
        public void RunWithoutReturn()
        {
            PrintMessage("Starting create tables");

            var tables = new Dictionary<string, List<int[]>>()
            {
                {"Random", GenerateListOfRandomTables()},
            };

            PrintMessage("Starting generate algorithms classes");

            var sortAlgorithms = new List<SortClass>
            {
                new QuickSort(),
                new QuickSortIter()
            };

            CalculateTime(sortAlgorithms, tables, "3.1");
            PrintMessage("Endedup calculing time for quick sort with random tables");


            PrintMessage("Stating calculate time for diffrent pivot position for A shaped tables");
            tables = new Dictionary<string, List<int[]>>()
            {
                {"AShaped", GenerateListOfAShapedTables()},
            };

            var quickSort = new QuickSort(this.randSeed);

            foreach (var tableType in tables.Keys)
            {
                foreach (var table in tables[tableType])
                {
                    var tableToSort = new int[table.Length];

                    table.CopyTo(tableToSort, 0);
                    _stopwatch.Restart();
                    _stopwatch.Start();
                    quickSort.SortMiddlePivot(tableToSort, 0, tableToSort.Length - 1);
                    _stopwatch.Stop();

                    PrintMessage("Ended up calculating time for middle pivot");

                    results.Add($"3.2;pivot_center;{tableType};{table.Length};{_stopwatch.ElapsedTicks}");

                    table.CopyTo(tableToSort, 0);
                    _stopwatch.Restart();
                    _stopwatch.Start();
                    quickSort.SortRightPivot(tableToSort, 0, tableToSort.Length - 1);
                    _stopwatch.Stop();

                    PrintMessage("Ended up calculating time for right pivot");

                    results.Add($"3.2;pivot_right;{tableType};{table.Length};{_stopwatch.ElapsedTicks}");

                    table.CopyTo(tableToSort, 0);
                    _stopwatch.Restart();
                    _stopwatch.Start();
                    quickSort.SortRandomPivot(tableToSort, 0, tableToSort.Length - 1);
                    _stopwatch.Stop();

                    PrintMessage("Ended up calculating time for random pivot");

                    results.Add($"3.2;pivot_rand;{tableType};{table.Length};{_stopwatch.ElapsedTicks}");
                }
            }
        }

    }
}
