#region Méthodes de la démo
async Task Coffee_StartMachine() // 33s
{
    Console.WriteLine("[Coffee] Machine - Start");
    await Task.Delay(33_000);
    Console.WriteLine("[Coffee] Machine - End");
}
async Task Coffee_Serve() // 12s
{
    Console.WriteLine("[Coffee] Serve - Start");
    await Task.Delay(12_000);
    Console.WriteLine("[Coffee] Serve - End");
}

async Task Salad_CupVegetables(params string[] vegetables) // 10s + 5s par légumes
{
        Console.WriteLine("[Salade] Cut Vegetables - Start");
    foreach (string vegetable in vegetables)
    {
        await Task.Delay(10_000);
        Console.WriteLine($"[Salade] Cut Vegetables {vegetable}");
    }
    await Task.Delay(5_000);
    Console.WriteLine("[Salade] Cut Vegetables - End");
}
async Task Salad_Prepare() // 10s
{
    Console.WriteLine("[Salad] Prepare - Start");
    await Task.Delay(10_000);
    Console.WriteLine("[Salad] Prepare - End");
}
async Task Salad_Dressing() // 5s
{
    Console.WriteLine("[Salad] Dressing - Start");
    await Task.Delay(5_000);
    Console.WriteLine("[Salad] Dressing - End");
}

async Task Meal_HeatPan() // 21s
{
    Console.WriteLine("[Meal] HeatPan - Start");
    await Task.Delay(21_000);
    Console.WriteLine("[Meal] HeatPan - End");
}
async Task Meal_Cooking() //21s
{
    Console.WriteLine("[Meal] Cooking - Start");
    await Task.Delay(21_000);
    Console.WriteLine("[Meal] Cooking - End");
}

async Task Apero() // 4s
{
    Console.WriteLine("[Apero] Serve - Start");
    await Task.Delay(4_000);
    Console.WriteLine("[Apero] Serve - End");
}
#endregion

#region Méthode Agregation
async Task Coffee() {
    await Coffee_StartMachine();
    await Coffee_Serve();
}
async Task Salad()
{
    await Salad_CupVegetables("Salade", "Tomate", "Pomme", "Ognion");
    await Salad_Prepare();
    await Salad_Dressing();
}

async Task Meal()
{
    await Meal_HeatPan();
    await Meal_Cooking();
}
#endregion

#region L'utilisation
Console.WriteLine("Debut !!!");

Task coffeeTask = Coffee();
Task saladTask = Salad();
Task mealTask = Meal();
Task aperoTask = Apero();

List<Task> tasks = [ coffeeTask, saladTask, mealTask, aperoTask ];
while(tasks.Count > 0)
{
    Task finishedTask = await Task.WhenAny(tasks);

    if (finishedTask == coffeeTask)
    {
        Console.WriteLine("[Coffee] Finish");
    }
    if (finishedTask == saladTask)
    {
        Console.WriteLine("[Salad] Finish");
    }
    if (finishedTask == mealTask)
    {
        Console.WriteLine("[Meal] Finish");
    }
    if (finishedTask == aperoTask)
    {
        Console.WriteLine("[Apero] Finish");
    }

    await finishedTask;
    tasks.Remove(finishedTask);
}

Console.WriteLine("Fin !!!");
#endregion