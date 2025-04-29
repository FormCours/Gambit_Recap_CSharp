namespace Demo_02_POO
{
    public class HouseV1
    {
        // Fields
        private int _id;
        private string _color;
        private bool _hasGarden;

        // Encapsulation
        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            _id = id;
        }

        public string GetColor()
        {
            return _color.ToLower();
        }
        public void SetColor(string color)
        {
            _color = color;
        }

        public bool HasGarden()
        {
            return _hasGarden;
        }
        public void SetGarden(bool hasGarden)
        {
            _hasGarden = hasGarden;
        }

        // Constructor
        public HouseV1(int id, string color)
        {
            _id = id;
            _color = color;
            _hasGarden = false;
        }
    }
}
