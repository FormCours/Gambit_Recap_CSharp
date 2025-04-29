namespace Demo_02_POO
{
    internal class HouseV2
    {
        // Fields
        private int _id;
        private string _color;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Color
        {
            get => _color;
            set => _color = value;
        }
        public bool HasGarden { get; init; }

        public HouseV2(int id, string color)
        {
            _id = id;
            _color = color;
            HasGarden = false;
        }
    }
}
