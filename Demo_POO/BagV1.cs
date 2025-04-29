namespace Demo_02_POO
{
    internal class BagV1
    {
        private readonly List<string> _items;

        public IEnumerable<string> Items { 
            get { return _items.AsReadOnly(); }
        }

        // Indexeur (Méthode)
        public string GetItem(int index)
        {
            return _items[index];
        }
        public void SetItem(int index, string value)
        {
            _items[index] = value;
        }


        public BagV1()
        {
            _items = new List<string>();
        }
        public void Add(string item)
        {
            _items.Add(item);
        }



    }
}
