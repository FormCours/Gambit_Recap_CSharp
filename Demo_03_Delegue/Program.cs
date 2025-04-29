using Demo_03_Delegue.Models;
using Demo_03_Delegue.Tools;

// Utilisation en tant que "Callback"
// **********************************
IList<int> numbers = [5, 9, 3, -5, 5, 1, 6];
IList<string> names = ["Della", "Riri", "Balthazar", "Loulou"];

IList<int> trier1 = CollectionTool.ToSort(numbers, (v1, v2) => v1 > v2);
IList<int> trier2 = CollectionTool.ToSort(numbers, (v1, v2) => v1 < v2);
IList<string> trier3 = CollectionTool.ToSort(names, CompareName);

bool CompareName(string name1, string name2)
{
    return string.Compare(name1.ToLower(), name2.ToLower()) == 0;
}

void ShowCollection<T>(string message, IList<T> list)
{
    Console.Write($"{message} : ");
    foreach (T val in list)
    {
        Console.Write(val + " > ");
    }
    Console.WriteLine();
}

ShowCollection("Original", numbers);
ShowCollection("Trier 1", trier1);
ShowCollection("Trier 2", trier2);

ShowCollection("Names", names);
ShowCollection("Trier 3", trier3);


// Utilisation en tant que "Event"
// *******************************
Tamagochi tamagochi = new Tamagochi() { Name = "Toto" };

tamagochi.EventMsg += Tamagochi_EventMsg;
void Tamagochi_EventMsg(string msg)
{
    Console.WriteLine($"EVENT : {msg}");
}
//tamagochi.EventMsg += delegate (string msg)
//{
//    Console.WriteLine("Il s'est passé un truc !");
//};
//tamagochi.EventMsg += (string msg) =>  Console.WriteLine("Il s'est passé un truc !");

while (tamagochi.isAlive)
{
    tamagochi.Manger("Pomme");
    tamagochi.Dormir();

    Task.Delay(100).Wait();
}
Console.WriteLine($"RIP {tamagochi.Name}");