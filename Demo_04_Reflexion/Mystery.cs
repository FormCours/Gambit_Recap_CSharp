using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_04_Reflexion
{
    public class Mystery
    {
        private int _value;

        protected int Value
        {
            get => _value;
            private set => _value = value;
        }

        public Mystery()
        {
            Value = Random.Shared.Next(0, 100);
        }

        public void Show()
        {
            Console.WriteLine($"La valeur est {Value}");
        }
    }
}
