using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class DijkstraAlgorithm : IShortestPathAlgorithm
    {
        private void Dijkstra(Dictionary<VertexModel, VertexModel?> previous, IGraphModel graph, VertexModel source, VertexModel target)
        {
            var pq = new PriorityQueue<VertexModel, double>();

            var seen = new HashSet<VertexModel>();

            var distances = new Dictionary<VertexModel, double>();
            foreach (var vertex in graph.GetVertices())
                distances[vertex] = double.MaxValue;

            previous[source] = null;

            distances[source] = 0;
            pq.Enqueue(source, 0);

            while (pq.Count > 0)
            {
                var vertex = pq.Dequeue();
                if (seen.Contains(vertex)) continue;

                seen.Add(vertex);

                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    if (seen.Contains(neighbor)) continue;

                    var edge = (WeightedEdgeModel<double>?)graph.GetEdgeBetween(vertex, neighbor);

                    if (edge == null)
                        throw new ArgumentNullException(nameof(edge));

                    // relax distance.
                    double relaxed = distances[vertex] + edge.Weight;

                    if (relaxed < distances[neighbor])
                    {
                        previous[neighbor] = vertex;
                        distances[neighbor] = relaxed;
                        pq.Enqueue(neighbor, relaxed);
                    }
                }
            }
        }

        //private ShortestPathResult BuildPath(IGraphModel graph, VertexModel source, VertexModel target)
        //{

        //}


        public ShortestPathResult FindShortestPath(IGraphModel graph, VertexModel source, VertexModel target, params object[] args)
        {
            // finding shortest path consist of two things, use dijkstra algorithm, and then build route using shortest distance to each vertex.


            var previous = new Dictionary<VertexModel, VertexModel?>();

            Dijkstra(previous, graph, source, target);

            if (previous.ContainsKey(target) == false)
            {
                return ShortestPathResult.FailedToFindShortestPathResult;
            }

            // build route
            var edges = new List<EdgeModel>();
            var vertices = new List<VertexModel>();

            var tempVertex = target;
            vertices.Add(target);

            while (tempVertex != source)
            {
                var prev = previous[tempVertex];
                if (prev == null)
                    throw new InvalidOperationException("Unexpected behaviour of the algorihtm.");

                var edge = graph.GetEdgeBetween(prev, tempVertex);
                if (edge == null)
                    throw new InvalidOperationException("Unexpected behaviour of the algorihtm.");

                vertices.Add(prev);
                edges.Add(edge);
                tempVertex = prev;
            }

            vertices.Reverse();
            edges.Reverse();

            return new(vertices, edges);
        }
    }
}
