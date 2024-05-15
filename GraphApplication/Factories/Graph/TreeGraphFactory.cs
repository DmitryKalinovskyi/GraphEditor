using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.Factories.Graph
{
    public class TreeGraphFactory : IGraphFactory
    {
        public int Depth { get; set; } = 3;

        public int ChildrenCount { get; set; } = 3;

        public double Radius { get; set; } = 100;

        public double TurningAngle { get; set; } = 180;

        public DirectedGraphModel CreateDirectedGraph()
        {
            return (DirectedGraphModel)CreateTreeGraph(new DirectedGraphModel());
        }

        public UndirectedGraphModel CreateUndirectedGraph()
        {
            return (UndirectedGraphModel)CreateTreeGraph(new UndirectedGraphModel());
        }

        public IGraphModel CreateTreeGraph(IGraphModel graph)
        {
            if (Depth < 1 || ChildrenCount < 1)
            {
                throw new ArgumentException("Depth and ChildrenCount must be greater than 0.");
            }

            var vertices = new List<VertexModel>();
            var edges = new List<EdgeModel>();

            // Create the root vertex
            var root = new VertexModel(0, new Point(0, 0));
            vertices.Add(root);

            // Recursively create ChildrenCount children for each vertex at depth d
            CreateChildrenRecursively(vertices, edges, root, 0, Depth, ChildrenCount);

            foreach (var vertex in vertices)
                graph.AddVertex(vertex);

            foreach (var edge in edges)
                graph.AddEdge(edge);

            return graph;
        }

        private void CreateChildrenRecursively(List<VertexModel> vertices, List<EdgeModel> edges, VertexModel parent, int currentDepth, int maxDepth, int childrenCount)
        {
            if (currentDepth >= maxDepth)
            {
                return;
            }

            int startIndex = vertices.Count;
            double direction = (TurningAngle / 180.0) * Math.PI; // Change here for graph direction
            double angleIncrement = Math.PI / childrenCount; // Stacking of child nodes in one half-plane relative to the parent node
            double radius = Radius * childrenCount * (1 - (double)currentDepth / maxDepth); // Adjust this value for desired radius

            for (int i = 0; i < childrenCount; i++)
            {
                double xReductionFactor = (currentDepth * Math.Abs(Math.Cos(direction)) + 1);
                double yReductionFactor = (currentDepth * Math.Abs(Math.Sin(direction)) + 1);

                double angle = (i + 0.5) * angleIncrement + direction;
                int x = (int)(parent.X + radius * Math.Cos(angle) / xReductionFactor);
                int y = (int)(parent.Y - radius * Math.Sin(angle) / yReductionFactor);


                var newVertex = new VertexModel(startIndex + i, new Point(x, y));
                vertices.Add(newVertex);
                edges.Add(new WeightedEdgeModel<double>(parent, newVertex));

                // Recursively create childrenCount children for the new vertex
                CreateChildrenRecursively(vertices, edges, newVertex, currentDepth + 1, maxDepth, childrenCount);
            }
        }
    }


}
