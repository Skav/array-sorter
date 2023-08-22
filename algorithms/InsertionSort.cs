namespace projekt_sortowanie.algorithms
{
    internal class InsertionSort : SortClass
    {
        public InsertionSort() : base ("Insertion"){}

        public override void Sort(int[] tab)
        {
            for (uint i = 1; i < tab.Length; i++)
            {
                uint j = i;
                int temp = tab[j];
                while ((j > 0) && (tab[j - 1] > temp))
                {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = temp;
            }

        }
    }
}
