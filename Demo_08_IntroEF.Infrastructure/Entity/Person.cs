namespace Demo_08_IntroEF.Infrastructure.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public string Fullname { get => $"{Firstname} {Lastname}"; }
        public DateTime CreateAt { get; set; }
    }
}
