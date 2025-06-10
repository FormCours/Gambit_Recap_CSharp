using Demo_08_IntroEF.Infrastructure;

Console.WriteLine("Intro à EF Core");


InfraDataContext context = new InfraDataContext();

var result = context.Demo.Select(s => new
{
    Name = s.Name,
    Desc = s.Description
});

foreach (var item in result)
{
    Console.WriteLine($"{item.Name} - {item.Desc}");
}