using Demo_05_Attribute.Attributes;
using Demo_05_Attribute.Models;
using System.Reflection;

Console.WriteLine("Attribute");
Console.WriteLine("*********\n");

string GetCharacterName(Character character)
{
    // ↓ Récuperation des métadata lié à l'attribut
    var t = character.GetType().GetCustomAttribute<CharacterNameAttribute>();

    return t?.Name ?? character.GetType().Name;
}

void RaiseActionAttribute(Character character)
{
    var actions = character.GetType().GetCustomAttributes<ActionDemoAttribute>();

    foreach (var action in actions)
    {
        action?.Show();
    }
}

Hero h = new Hero();
Console.WriteLine(GetCharacterName(h));
RaiseActionAttribute(h);
Console.WriteLine();

Monster m = new Monster();
Console.WriteLine(GetCharacterName(m));
RaiseActionAttribute(m);
Console.WriteLine();

