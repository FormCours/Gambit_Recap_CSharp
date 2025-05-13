using Demo_04_Reflexion;


Console.WriteLine("Reflexion");

Mystery mystery = new Mystery();
mystery.Show();

var t1 = (System.Reflection.TypeInfo)typeof(Mystery);
var t2 = t1.DeclaredProperties.First(n => n.Name == "Value");
t2.SetValue(mystery, 42);

mystery.Show();
