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
        public void Dijkstra(Dictionary<VertexModel, VertexModel?> previous, UndirectedGraphModel graph, VertexModel source, VertexModel target)
        {
            var pq = new PriorityQueue<VertexModel, double>();

            var seen = new HashSet<VertexModel>();

            var distances = new Dictionary<VertexModel, double>();
            foreach(var vertex in graph.GetVertices())
                distances[vertex] = double.MaxValue;

            previous[source] = null;

            distances[source] = 0;
            pq.Enqueue(source, 0);

            while(pq.Count > 0)
            {
                var vertex = pq.Dequeue();
                if (seen.Contains(vertex)) continue;
                
                seen.Add(vertex);

                foreach(var neighbor in graph.GetNeighbors(vertex))
                {
                    if(seen.Contains(neighbor)) continue;

                    var edge = (WeightedEdgeModel<double>?)graph.GetEdgeBetween(vertex, neighbor);

                    if (edge == null)
                        throw new ArgumentNullException(nameof(edge));

                    // relax distance.
                    double relaxed = distances[vertex] + edge.Weight;

                    if(relaxed < distances[neighbor])
                    {
                        previous[neighbor] = vertex;
                        distances[neighbor] = relaxed;
                        pq.Enqueue(neighbor, relaxed);
                    }
                }
            }
        }

        public IterativeAlgorithmResult BuildRoute(IGraphModel graph, params object[] args)
        {
            var source = (VertexModel)args[0];
            var target = (VertexModel)args[1];

            var undirectedGraph = (UndirectedGraphModel)graph;
            if (undirectedGraph == null)
                throw new ArgumentException("Algorithm can be implemented only with undirected graph.");


            var previous = new Dictionary<VertexModel, VertexModel?>();

            Dijkstra(previous, undirectedGraph, source, target);

            if (previous.ContainsKey(target) == false)
            {
                return IterativeAlgorithmResult.FailedToBuildRouteResult;
            }

            
            // build route
            var edges = new List<EdgeModel>();
            var vertices = new List<VertexModel>();

            var tempVertex = target;
            vertices.Add(target);

            while(tempVertex != source)
            {
                var prev = previous[tempVertex];
                if (prev == null)
                    throw new InvalidOperationException("Unexpected behaviour of the algorihtm.");

                var edge = undirectedGraph.GetEdgeBetween(prev, tempVertex);
                if(edge == null)
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
