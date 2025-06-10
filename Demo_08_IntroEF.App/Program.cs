using Demo_08_IntroEF.Infrastructure;
using Demo_08_IntroEF.Infrastructure.Entity;

Console.WriteLine("- Intro à EF Core");
InfraDataContext context = new InfraDataContext();

Console.WriteLine("Demo 01");
Console.WriteLine("*******");
var result = context.Demo.Select(s => new
{
    Name = s.Name,
    Desc = s.Description
});

foreach (var item in result)
{
    Console.WriteLine($"{item.Name} - {item.Desc}");
}

Console.WriteLine("Demo 02");
Console.WriteLine("*******");

context.Pet.Add(new Pet() { Name = "Le Chien" });
context.Pet.AddRange([
    new Pet() { Name = "Le Chat" }, 
    new Pet() { Name = "Rexy" },
    new Pet() { Name = "Robert" }
]);
context.SaveChanges();

