using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;

namespace GraphApplication.Fabrication
{
    public class GraphModelGenerator
    {
        public object Generate(GraphModelArgs args)
        {
            //Generate Verticles 

            Random random = new Random();


            List<VertexModel> verticles = new();
            for (int i = 0; i < args.VerticlesCount; i++)
            {
                double left = random.NextDouble() * args.MaxLeft;
                double top = random.NextDouble() * args.MaxTop;

                verticles.Add(new VertexModel(i, left, top));
            }
            IGraphModel<VertexModel, EdgeModel> graph = new UndirectedGraphModel(verticles, new List<EdgeModel>());

            for (int i = 0; i < args.VerticlesCount - 1; i++)
            {
                try
                {
                    //we need to select random elements 
                    int next = random.Next(i + 1, args.VerticlesCount - 1);


                    double weight = Math.Floor(random.NextDouble() * 10000) / 100;

                    graph.AddEdge(new WeightedEdgeModel<double>(verticles[i], verticles[next], weight));
                }
                catch { }
            }

            return graph;
        }

    }
}
