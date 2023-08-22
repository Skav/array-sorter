using System;

namespace projekt_sortowanie.algorithms
{
    internal class QuickSort : SortClass
    {
        private Random rand;
        public QuickSort() : base("Quick") {
            this.rand = new Random();
        }
        public QuickSort(int randSeed) : base("Quick") {
            this.rand = new Random(randSeed);
        }

        public override void Sort(int[] tab)
        {
            Sort(tab, 0, tab.Length - 1);
        }

        public void Sort(int[] tab, int left, int right)
        {
            
            int i, j, x;
            i = left;
            j = right;
            x = tab[left];
            do
            {
                while (tab[i] < x) i++;
                while (x < tab[j]) j--;
                if (i <= j)
                {
                    int buf = tab[i];
                    tab[i] = tab[j];
                    tab[j] = buf;
                    i++;
                    j--;
                }
            } while (i <= j);
            

            if (left < j) Sort(tab, left, j);
            if (i < right) Sort(tab, i, right);
        }

        public void SortRightPivot(int[] tab, int left, int right)
        {

            int i, j, x;
            i = left;
            j = right;
            x = tab[right];
            do
            {
                while (tab[i] < x) i++;
                while (x < tab[j]) j--;
                if (i <= j)
                {
                    int buf = tab[i];
                    tab[i] = tab[j];
                    tab[j] = buf;
                    i++;
                    j--;
                }
            } while (i <= j);


            if (left < j) SortRightPivot(tab, left, j);
            if (i < right) SortRightPivot(tab, i, right);
        }

        public void SortRandomPivot(int[] tab, int left, int right)
        {

            int i, j, x;
            i = left;
            j = right;
            /* adding 1 to right because random.Next() never get value of second parameter, 
             * for example if we given a range od (0, 100) number will be choosen only from 0 to 99 
             */
            x = tab[rand.Next(left, right+1)]; 
            
            do
            {
                while (tab[i] < x) i++;
                while (x < tab[j]) j--;
                if (i <= j)
                {
                    int buf = tab[i];
                    tab[i] = tab[j];
                    tab[j] = buf;
                    i++;
                    j--;
                }
            } while (i <= j);


            if (left < j) SortRandomPivot(tab, left, j);
            if (i < right) SortRandomPivot(tab, i, right);
        }

        public void SortMiddlePivot(int[] tab, int left, int right)
        {

            int i, j, x;
            i = left;
            j = right;
            x = tab[(left + right) / 2];
            do
            {
                while (tab[i] < x) i++;
                while (x < tab[j]) j--;
                if (i <= j)
                {
                    int buf = tab[i];
                    tab[i] = tab[j];
                    tab[j] = buf;
                    i++;
                    j--;
                }
            } while (i <= j);


            if (left < j) SortMiddlePivot(tab, left, j);
            if (i < right) SortMiddlePivot(tab, i, right);
        }
    }
}
