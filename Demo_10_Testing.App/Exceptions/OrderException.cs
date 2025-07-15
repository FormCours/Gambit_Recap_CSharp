using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10_Testing.App.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message) { }
    }

    public class OrderNotFoundException : OrderException
    {
        public OrderNotFoundException(string message) : base(message) { }
    }

    public class OrderInvalidException : OrderException
    {
        public OrderInvalidException(string message) : base(message) { }
    }

}
