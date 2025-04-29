namespace Demo_03_Delegue.Models
{
    //delegate void Action(string msg);
    //delegate int Func(string msg);
    //delegate bool Predicate(string cond);

    internal class Tamagochi
    {
        // Events
        public event Action<string>? EventMsg;

        // Field
        private int faim { get; set; } = 50;
        public required string Name { get; set; }
        public bool isAlive {  get { return faim > 0; } }
        
        // Methods
        public void Dormir()
        {
            EventMsg?.Invoke($"{Name} dort");
            faim = faim - 10;
        }
        public void Manger(string repas)
        {
            if(Random.Shared.Next(3) == 0)
            {
                EventMsg?.Invoke($"{Name} mange {repas}");
                faim += 15;
            }
        }
    }
}
