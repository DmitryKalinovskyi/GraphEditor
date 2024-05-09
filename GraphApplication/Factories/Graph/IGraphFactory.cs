using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Factories.Graph
{
    public interface IGraphFactory
    {
        public DirectedGraphModel CreateDirectedGraph();

        public UndirectedGraphModel CreateUndirectedGraph();
    }
}
