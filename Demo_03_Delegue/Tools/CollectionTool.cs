namespace Demo_03_Delegue.Tools
{
    public delegate bool CollectionToolSortDelegate<T>(T item1, T item2);

    public static class CollectionTool
    {
        public static IList<T> ToSort<T>(IList<T> original, CollectionToolSortDelegate<T> test)
        {
            IList<T> tab = [..original];

            for (int i = 0; i < tab.Count; i++)
            {
                for (int k = 0; k < tab.Count - 1; k++)
                {
                    if ( test(tab[k], tab[k+1]) )
                    {
                        T temp = tab[k];
                        tab[k] = tab[k+1];
                        tab[k+1] = temp;
                    }
                }
            }
            return tab;
        }
    }
}
