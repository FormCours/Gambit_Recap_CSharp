#region Méthodes de la démo
void Coffee_StartMachine() // 33s
{
    Console.WriteLine("[Coffee] Machine - Start");
    System.Threading.Thread.Sleep(33_000);
    Console.WriteLine("[Coffee] Machine - End");
}
void Coffee_Serve() // 12s
{
    Console.WriteLine("[Coffee] Serve - Start");
    System.Threading.Thread.Sleep(12_000);
    Console.WriteLine("[Coffee] Serve - End");
}

void Salad_CupVegetables(params string[] vegetables) // 10s + 5s par légumes
{
        Console.WriteLine("[Salade] Cut Vegetables - Start");
    foreach (string vegetable in vegetables)
    {
        System.Threading.Thread.Sleep(10_000);
        Console.WriteLine($"[Salade] Cut Vegetables {vegetable}");
    }
    System.Threading.Thread.Sleep(5_000);
    Console.WriteLine("[Salade] Cut Vegetables - End");
}
void Salad_Prepare() // 10s
{
    Console.WriteLine("[Salad] Prepare - Start");
    System.Threading.Thread.Sleep(10_000);
    Console.WriteLine("[Salad] Prepare - End");
}
void Salad_Dressing() // 5s
{
    Console.WriteLine("[Salad] Dressing - Start");
    System.Threading.Thread.Sleep(5_000);
    Console.WriteLine("[Salad] Dressing - End");
}

void Meal_HeatPan() // 21s
{
    Console.WriteLine("[Meal] HeatPan - Start");
    System.Threading.Thread.Sleep(21_000);
    Console.WriteLine("[Meal] HeatPan - End");
}
void Meal_Cooking() //21s
{
    Console.WriteLine("[Meal] Cooking - Start");
    System.Threading.Thread.Sleep(21_000);
    Console.WriteLine("[Meal] Cooking - End");
}

void Apero() // 4s
{
    Console.WriteLine("[Apero] Serve - Start");
    System.Threading.Thread.Sleep(4_000);
    Console.WriteLine("[Apero] Serve - End");
}
#endregion

#region L'utilisation
Coffee_StartMachine();
Coffee_Serve();
Salad_CupVegetables("Salade", "Tomate", "Pomme", "Ognion");
Salad_Prepare();
Salad_Dressing();
Meal_HeatPan();
Meal_Cooking();
Apero();
#endregion