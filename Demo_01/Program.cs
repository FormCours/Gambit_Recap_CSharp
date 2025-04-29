string GetFullname(in string firstname, in string lastname)
{
    string firstname2 = firstname.Trim().ToUpper();
    string lastname2 = lastname.Trim().ToUpper();

    return firstname2 + ' ' + lastname2;
}

IEnumerable<int> GetNumbers(int limit = 20)
{
    Console.WriteLine("Debut");

    int i = 0;
    while(i < limit)
    {   
        yield return i;
        i++;
    }

    Console.WriteLine("Fin");
}

Console.WriteLine("Hello World");
IEnumerable<int> test = GetNumbers(10);

foreach(int nb in test)
{
    if(nb == 5) { break; }

    Console.WriteLine(nb);
}
