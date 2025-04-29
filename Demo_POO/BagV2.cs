namespace Demo_02_POO
{
    internal class BagV2
    {
        private readonly List<string> _items;

        public IEnumerable<string> Items
        {
            get { return _items.AsReadOnly(); }
        }

        // Indexeur (Props)
        public string this[int index]
        {
            get
            {
                return _items[index];
            }

            set
            {
                _items[index] = value;
            }
        }


        public BagV2()
        {
            _items = new List<string>();
        }
        public void Add(string item)
        {
            _items.Add(item);
        }

    }
}
