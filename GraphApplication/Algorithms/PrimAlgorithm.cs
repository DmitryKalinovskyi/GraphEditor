using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class PrimAlgorithm : IMinSpanningTreeAlgorithm
    {
        private void AddEdgesToPriorityQueue(IGraphModel graph, VertexModel vertex, PriorityQueue<WeightedEdgeModel<double>, double> pq)
        {
            foreach (var neighbor in graph.GetNeighbors(vertex))
            {
                WeightedEdgeModel<double>? edge = (WeightedEdgeModel<double>?)graph.GetEdgeBetween(vertex, neighbor);

                if (edge == null) throw new InvalidOperationException("Edge was not weighted.");

                pq.Enqueue(edge, edge.Weight);
            }
        }

        public MinSpanningTreeResult FindMinSpanningTree(IGraphModel graph, VertexModel source, params object[] args)
        {
            var seen = new HashSet<VertexModel>();

            var pq = new PriorityQueue<WeightedEdgeModel<double>, double>();

            var resultingVertices = new List<VertexModel>();
            var resultingEdges = new List<EdgeModel>();

            resultingVertices.Add(source);
            seen.Add(source);
            AddEdgesToPriorityQueue(graph, source, pq);

            while (pq.Count > 0)
            {
                var edge = pq.Dequeue();

                if (seen.Contains(edge.Start) && seen.Contains(edge.End)) { continue; }

                var newVertex = seen.Contains(edge.Start) ? edge.End : edge.Start;
                seen.Add(newVertex);

                resultingEdges.Add(edge);
                resultingVertices.Add(newVertex);
                AddEdgesToPriorityQueue(graph, newVertex, pq);
            }

            return new(resultingVertices, resultingEdges);
        }

        public MinSpanningTreeResult FindMinSpanningTreeForest(IGraphModel graph, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
