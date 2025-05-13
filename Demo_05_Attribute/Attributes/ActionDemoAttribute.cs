namespace Demo_05_Attribute.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ActionDemoAttribute : Attribute
    {
        public void Show()
        {
            int val = Random.Shared.Next(0, 100);
            Console.WriteLine($"Valeur : {val}");
        }
    }
}
