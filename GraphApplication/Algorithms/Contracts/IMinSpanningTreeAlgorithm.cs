using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms.Contracts
{
    public interface IMinSpanningTreeAlgorithm
    {
        public MinSpanningTreeResult FindMinSpanningTree(IGraphModel graph, VertexModel source, params object[] args);

        public MinSpanningTreeResult FindMinSpanningTreeForest(IGraphModel graph, params object[] args);
    }
}
