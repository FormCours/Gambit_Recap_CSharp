namespace Demo_05_Attribute.Models
{
    public class Character
    {
        public int Pdv { get; private set; }
        public int MaxPdv { get; private set; }

        public Character()
        {
            MaxPdv = Random.Shared.Next(10, 20);
            Pdv = Random.Shared.Next(9, MaxPdv);
        }

        public virtual void Hit(Character character)
        {
            character.TakeDamage(Random.Shared.Next(1, 5));
        }

        protected void TakeDamage(int damage)
        {
            Pdv -= damage;
        }
    }
}
