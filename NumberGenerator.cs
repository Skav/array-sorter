using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_sortowanie
{
    public class NumberGenerator
    {

        public static int[] GenerateStableTable(int lenght, int value)
        {
            int[] table = new int[lenght];

            for (int i = 0; i < lenght; i++)
                table[i] = value;

            return table;
        }

        public static int[] GenerateAscendingTable(int lenght)
        {
            var table = new int[lenght];

            for(int i = 0; i < lenght; i++)
            {
                table[i] = i;   
            }

            return table;
        }

        public static int[] GenerateDescengingTable(int lenght)
        {
            var table = new int[lenght];

            for( int i = 0; i < lenght; i++)
            {
                table[i] = lenght - 1 - i;
            }

            return table;
        }

        public static int[] GenerateRandomTable(int lenght, int seed, int minValue, int maxValue)
        {
            var random = new Random(seed); // sets seed to generate random numbers, it is useful if we want to has the same results in generating "random" numbers every time
            var table = new int[lenght];

            for (int i = 0; i < lenght; i++)
                table[i] = random.Next(minValue, maxValue+1); // adding 1 to maxValue to be sure, the upper limit has value of maxValue, not values only below it

            return table;

        }

        public static List<int[]> GenerateListOfRandomTables(int[] tablesLenghts, int seed, int minValue, int maxValue)
        {
            var random = new Random(seed); // sets seed to generate random numbers, it is useful if we want to has the same results in generating "random" numbers every time
            var randomTablesList = new List<int[]>();

            foreach (var tableLength in tablesLenghts) 
            {
                var table = new int[tableLength];
                for (int i = 0; i < tableLength; i++)
                    table[i] = random.Next(minValue, maxValue + 1);

                randomTablesList.Add(table);
            }
                
            return randomTablesList;
        }

        public static int[] GenerateAShapeTable(int lenght)
        {
            bool isEven = lenght % 2 == 0;
            var table = new int[lenght];
            int middleIndex = lenght / 2;
            table[middleIndex] = lenght;

            if (isEven)
                table[middleIndex + 1] = lenght;

            int maxValue = lenght - 1;
            for (int i = middleIndex - 1; i >= 0; i--)
            {
                table[i] = maxValue;
                maxValue -= 2;
            }

            maxValue = lenght - 2;
            int offset = (isEven) ? 2 : 1;
            for (int i = middleIndex + offset; i < lenght; i++)
            {
                table[i] = maxValue;
                maxValue -= 2;
            }

            return table;
        }

        public static int[] GenerateVShapeTable(int lenght)
        {
            bool isEven = lenght % 2 == 0;
            var table = new int[lenght];
            int middleIndex = lenght / 2;
            table[middleIndex] = 0;

            if (isEven)
                table[middleIndex + 1] = 0;

            int maxValue = lenght - 1;
            for (int i = 0; i < middleIndex; i++)
            {
                table[i] = maxValue;
                maxValue -= 2;
            }

            maxValue = lenght - 2;
            int offset = (isEven) ? 1 : 0;
            for (int i = lenght - 1; i > middleIndex + offset; i--)
            {
                table[i] = maxValue;
                maxValue -= 2;
            }

            return table;
        }
    }
}
