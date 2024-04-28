using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Exceptions
{
    public class UnbindedModelViewException : InvalidOperationException
    {
        public UnbindedModelViewException() { }

        public UnbindedModelViewException(string message) : base(message) { }
    }
}
