namespace Demo_05_Attribute.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CharacterNameAttribute : Attribute
    {
        public string Name { get; init; }

        public CharacterNameAttribute(string name)
        {
            Name = name;
        }
    }
}
