using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Fabrication
{
    public interface IObjectGenerator
    {
        public object Generate(GeneratorArgs args);
    }
}
