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
    public class PrimAlgorithm : IMinSpanningTreeAlgorithm
    {
        private void AddEdgesToPriorityQueue(UndirectedGraphModel graph, VertexModel vertex, PriorityQueue<WeightedEdgeModel<double>, double> pq)
        {
            foreach(var neighbor in graph.GetNeighbors(vertex))
            {
                WeightedEdgeModel<double>? edge = (WeightedEdgeModel<double>?)graph.GetEdgeBetween(vertex, neighbor);

                if (edge == null) throw new InvalidOperationException("Edge was not weighted.");

                pq.Enqueue(edge, edge.Weight);
            }
        }

        public IterativeAlgorithmResult BuildRoute(IGraphModel graph, params object[] args)
        {
            var undirectedGraph = (UndirectedGraphModel)graph;

            var vertex = (VertexModel)args[0];  

            if (undirectedGraph == null) throw new InvalidOperationException("Invalid graph specified.");

            var seen = new HashSet<VertexModel>();

            var pq = new PriorityQueue<WeightedEdgeModel<double>, double>();

            var resultingVertices = new List<VertexModel>();
            var resultingEdges = new List<EdgeModel>();

            resultingVertices.Add(vertex);
            seen.Add(vertex);
            AddEdgesToPriorityQueue(undirectedGraph, vertex, pq);

            while(pq.Count > 0)
            {
                var edge = pq.Dequeue();

                if(seen.Contains(edge.Start) && seen.Contains(edge.End)) { continue; }

                var newVertex = seen.Contains(edge.Start) ? edge.End : edge.Start;
                seen.Add(newVertex);

                resultingEdges.Add(edge);
                resultingVertices.Add(newVertex);
                AddEdgesToPriorityQueue(undirectedGraph, newVertex, pq);
            }

            return new(resultingVertices, resultingEdges);
        }
    }
}
