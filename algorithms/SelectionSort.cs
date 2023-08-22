namespace projekt_sortowanie.algorithms
{
    internal class SelectionSort : SortClass
    {
        public SelectionSort() : base("Selection") { }

        public override void Sort(int[] tab)
        {
            uint k;
            for (uint i = 0; i < (tab.Length - 1); i++)
            {
                int temp = tab[i];
                k = i;
                for (uint j = i + 1; j < tab.Length; j++)
                    if (tab[j] < temp)
                    {
                        k = j;
                        temp = tab[j];
                    }

                tab[k] = tab[i];
                tab[i] = temp;
            }
        }
    }
}
