namespace projekt_sortowanie.algorithms
{
    internal class QuickSortIter : SortClass
    {
        public QuickSortIter() : base("QuickIter") { }

        public override void Sort(int[] tab)
        {
            int i, j, l, r, sp;
            int[] stackLeft = new int[tab.Length],
                stackRight = new int[tab.Length];
            sp = 0;
            stackLeft[sp] = 0;
            stackRight[sp] = tab.Length - 1;

            do
            {
                l = stackLeft[sp];
                r = stackRight[sp];
                sp--;

                do
                {
                    int x;
                    i = l;
                    j = r;
                    x = tab[(l + r) / 2];
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

                    if (i < r)
                    {
                        sp++;
                        stackLeft[sp] = i;
                        stackRight[sp] = r;
                    }

                    r = j;
                } while (l < r);
            } while (sp >= 0);
        }
    }
}
