using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.Factories.Graph
{

    public class SnowflakeGraphFactory : IGraphFactory
    {
        public int Depth { get; set; } = 2;

        public int K { get; set; } = 3;

        public double Radius { get; set; } = 100;

        public DirectedGraphModel CreateDirectedGraph()
        {
            return (DirectedGraphModel)CreateSnowflakeGraph(new DirectedGraphModel());
        }

        public UndirectedGraphModel CreateUndirectedGraph()
        {
            return (UndirectedGraphModel)CreateSnowflakeGraph(new UndirectedGraphModel());
        }

        public IGraphModel CreateSnowflakeGraph(IGraphModel graph)
        {
            if (Depth < 1 || K < 1)
            {
                throw new ArgumentException("Depth and k must be greater than 0.");
            }

            var vertices = new List<VertexModel>();
            var edges = new List<EdgeModel>();

            // Create the center vertex
            var center = new VertexModel(0, new Point(0, 0));
            vertices.Add(center);

            // Recursively create k neighbors for each vertex at depth d
            CreateNeighborsRecursively(vertices, edges, center, 1, Depth, K);

            foreach (var vertex in vertices)
                graph.AddVertex(vertex);

            foreach (var edge in edges)
                graph.AddEdge(edge);

            return graph;
        }

        private void CreateNeighborsRecursively(List<VertexModel> vertices, List<EdgeModel> edges, VertexModel parent, int currentDepth, int maxDepth, int k)
        {
            if (currentDepth >= maxDepth)
            {
                return;
            }

            int startIndex = vertices.Count;

            double angleIncrement = 2 * Math.PI / k;
            double radius = Radius / currentDepth; // Adjust this value for desired radius

            for (int i = 0; i < k; i++)
            {
                double angle = i * angleIncrement;
                int x = (int)(parent.X + radius * Math.Cos(angle));
                int y = (int)(parent.Y + radius * Math.Sin(angle));

                var newVertex = new VertexModel(startIndex + i, new Point(x, y));
                vertices.Add(newVertex);
                edges.Add(new WeightedEdgeModel<double>(parent, newVertex));

                // Recursively create k neighbors for the new vertex
                CreateNeighborsRecursively(vertices, edges, newVertex, currentDepth + 1, maxDepth, k);
            }
        }
    }
}
