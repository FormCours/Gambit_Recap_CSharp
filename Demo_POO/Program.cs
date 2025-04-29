using Demo_02_POO;


Person p1 = new Person()
{
    PersonId = 1,
    Name = "Riri",
    Birthdate = new DateTime(1990, 1, 9),
};



HouseV2 h1 = new HouseV2(1, "Rose")
{
    HasGarden = true,
};





BagV1 b1 = new BagV1();
b1.Add("Pomme");
b1.Add("Poire");
b1.Add("Cerise");

string b1_2item = b1.GetItem(1);
b1.SetItem(2, "Banane");


BagV2 b2 = new BagV2();
b2.Add("Pomme");
b2.Add("Poire");
b2.Add("Cerise");

string b2_2item = b2[1];
b2[1] = "Banane";



Car c1 = new Car(1, "VW", "Polo");
Console.WriteLine($"{c1.Brand} vroum vroum");
(c1 as IDisposable)?.Dispose();

using (Car c2 = new(2, "Citroën"))
{
    Console.WriteLine($"{c2.Brand} vroum vroum");
}


void DemoUsingRessource()
{
    // ↓ Création de la ressource
    using Car c = new Car(42, "Toyota");
        
    Console.WriteLine($"{c.Brand} vroum vroum");
    Console.WriteLine($"{c.Brand} fait des drifts");

    // ↓ Fin du using avec la fin de la méthode
}
DemoUsingRessource();
