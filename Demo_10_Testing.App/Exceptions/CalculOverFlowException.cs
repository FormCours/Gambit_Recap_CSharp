using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10_Testing.App.Exceptions
{
    public class CalculOverFlowException : Exception
    {
        public string OperationType { get; init; }

        public CalculOverFlowException(string operationType, string message) : base(message)
        {
            OperationType = operationType;
        }
    }
}
