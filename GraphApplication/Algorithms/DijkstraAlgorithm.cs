using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms
{
    public class DijkstraAlgorithm : IShortestPathAlgorithm
    {
        public IterativeAlgorithmResult BuildRoute(IGraphModel graph, params object[] args)
        {
            //var source = (VertexModel)args[0];
            //var target = (VertexModel)args[1];  

            //var seen = new HashSet<VertexModel>();
            //var previous =  new Dictionary<VertexModel, >();
            //var distances = new Dictionary<VertexModel, double>();


        }
    }
}
