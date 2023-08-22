using projekt_sortowanie.algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_sortowanie
{
    internal class FirstPart : PartClass
    {

        public FirstPart(int[] dataSet) : base(dataSet) {}

        public override List<string> Run()
        {
            PrintMessage("Starting generating tables");

            var tables = new Dictionary<string, List<int[]>>()
            {
                {"Static", GenerateListOfStaticTables()},
                {"SortedAsc", GenerateListOfLinearAscTables()},
                {"SortedDesc", GenerateListOfLinearDescTables()},
                {"Random", GenerateListOfRandomTables()},
                {"VShaped", GenerateListOfVShapedTables()},
            };

            PrintMessage("Starting creating sort classes");

            var sortAlgorithms = new List<SortClass>
            {
                new CocktailSort(),
                new HeapSort(),
                new InsertionSort(),
                new SelectionSort()
            }
;
            CalculateTime(sortAlgorithms, tables, "1&2");

            return results;
        }

        

    }
}
