namespace projekt_sortowanie.algorithms
{
    internal abstract class SortClass
    {
        public string SortType { get; }

        public SortClass(string sortType)
        {
            this.SortType = sortType;
        }

        public abstract void Sort(int[] table);
    }
}
