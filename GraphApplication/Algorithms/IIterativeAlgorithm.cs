using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms
{
    public interface IIterativeAlgorithm
    {
        public (IEnumerable<VertexModel>?, IEnumerable<EdgeModel>?) Implement(GraphModel graph, params object[] args);
    }
}
