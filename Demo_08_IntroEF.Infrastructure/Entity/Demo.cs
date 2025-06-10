namespace Demo_08_IntroEF.Infrastructure.Entity
{
    public class Demo
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string? Description { get; set; }
        public required bool IsActive { get; set; }
    }
}
