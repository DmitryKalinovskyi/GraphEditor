using System;
namespace GraphApplication.Exceptions
{
    public class UnbindedModelViewException: InvalidOperationException
    {
        public UnbindedModelViewException() { }

        public UnbindedModelViewException(string message) : base(message) { }
    }
}
