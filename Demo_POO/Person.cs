namespace Demo_02_POO
{
    public class Person
    {
        public int PersonId { get; set; }
        public required string Name { get; set; } 
        public DateTime? Birthdate { get; set; }

        public void SayHello()
        {
            throw new System.NotImplementedException();
        }
    }
}
