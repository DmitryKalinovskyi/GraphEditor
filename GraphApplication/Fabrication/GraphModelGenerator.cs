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
            IGraphModel<VertexModel, EdgeModel> graph = new DefaultGraphModel<VertexModel, EdgeModel>(verticles, new List<EdgeModel>());

            for (int i = 0; i < args.VerticlesCount - 1; i++)
            {
                try
                {
                    //we need to select random elements 
                    int next = random.Next(i + 1, args.VerticlesCount - 1);


                    graph.AddEdge(new EdgeModel(verticles[i], verticles[next]));
                }
                catch { }
            }

            return graph;
        }

    }
}
