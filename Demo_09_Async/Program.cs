#region Méthodes de la démo
async Task Coffee_StartMachineAsync() // 33s
{
    Console.WriteLine("[Coffee] Machine - Start");
    await Task.Delay(33_000);
    Console.WriteLine("[Coffee] Machine - End");
}
async Task Coffee_ServeAsync() // 12s
{
    Console.WriteLine("[Coffee] Serve - Start");
    await Task.Delay(12_000);
    Console.WriteLine("[Coffee] Serve - End");
}

async Task Salad_CupVegetablesAsync(params string[] vegetables) // 10s + 5s par légumes
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
async Task Salad_PrepareAsync() // 10s
{
    Console.WriteLine("[Salad] Prepare - Start");
    await Task.Delay(10_000);
    Console.WriteLine("[Salad] Prepare - End");
}
async Task Salad_DressingAsync() // 5s
{
    Console.WriteLine("[Salad] Dressing - Start");
    await Task.Run(() =>
    {
        // Thread en arriere plan
        // Cas pratique -> Un gros traitement sur le CPU
        for (int i = 0; i < 500; i++)
        {
            Thread.Sleep(10);
            i++;
        }
    });
    Console.WriteLine("[Salad] Dressing - End");
}

async Task Meal_HeatPanAsync() // 21s
{
    Console.WriteLine("[Meal] HeatPan - Start");
    await Task.Delay(21_000);
    Console.WriteLine("[Meal] HeatPan - End");
}
async Task Meal_CookingAsync() //21s
{
    Console.WriteLine("[Meal] Cooking - Start");
    await Task.Delay(21_000);
    Console.WriteLine("[Meal] Cooking - End");
}

async Task AperoAsync() // 4s
{
    Console.WriteLine("[Apero] Serve - Start");
    await Task.Delay(4_000);
    Console.WriteLine("[Apero] Serve - End");
}
#endregion

#region Méthode Agregation
async Task CoffeeAsync() {
    await Coffee_StartMachineAsync();
    await Coffee_ServeAsync();
}
async Task SaladAsync()
{
    await Salad_CupVegetablesAsync("Salade", "Tomate", "Pomme", "Ognion");
    await Salad_PrepareAsync();
    await Salad_DressingAsync();
}

async Task MealAsync()
{
    await Meal_HeatPanAsync();
    await Meal_CookingAsync();
}
#endregion

#region L'utilisation
Console.WriteLine("Debut !!!");

Task coffeeTask = CoffeeAsync();
Task saladTask = SaladAsync();
Task mealTask = MealAsync();
Task aperoTask = AperoAsync();

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