using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Factories.Graph
{
    public class RandomizedGraphFactory : IGraphFactory
    {
        public int VerticesCount { get; set; } = 100;

        public double MaxX { get; set; } = 100;

        public double MaxY { get; set; } = 100;

        public double MaxWeight { get; set; } = 100;

        public double MinWeight { get; set; } = 1;

        public DirectedGraphModel CreateDirectedGraph()
        {
            return (DirectedGraphModel)CreateRandomizedGraph(new DirectedGraphModel());
        }

        public UndirectedGraphModel CreateUndirectedGraph()
        {
            return (UndirectedGraphModel)CreateRandomizedGraph(new UndirectedGraphModel());
        }
           

        private IGraphModel CreateRandomizedGraph(IGraphModel graph)
        {
            var random = new Random();

            //Generate Verticles 
            var vertices = new List<VertexModel>();
            for (int i = 0; i < VerticesCount; i++)
            {
                double x = random.NextDouble() * MaxX;
                double y = random.NextDouble() * MaxY;

                vertices.Add(new VertexModel(i, x, y));
            }

            for (int i = 0; i < VerticesCount - 1; i++)
            {
                //we need to select random elements 
                int next = random.Next(i + 1, VerticesCount - 1);

                double weightUnrouned = random.NextDouble() * (MaxWeight - MinWeight) + MinWeight;
                double weight = Math.Floor(weightUnrouned * 100) / 100;

                // if verticles not connected, make connection.
                if (graph.IsConnectionBetween(vertices[i], vertices[next]) == false)
                    graph.AddEdge(new WeightedEdgeModel<double>(vertices[i], vertices[next], weight));
            }

            return graph;
        }
    }
}
