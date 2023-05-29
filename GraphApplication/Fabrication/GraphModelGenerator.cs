using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Fabrication
{
    public class GraphModelGenerator
    {
        public object Generate(GraphModelArgs args)
        {
            //Generate Verticles 

            Random random = new Random();

            List<VertexModel> verticles = new List<VertexModel>();
            for (int i = 0; i < args.VerticlesCount; i++)
            {
                double left = random.NextDouble() * args.MaxLeft;
                double top = random.NextDouble() * args.MaxTop;

                verticles.Add(new VertexModel(left, top, i));
            }

            List<EdgeModel> edges = new List<EdgeModel>();

            for(int i = 0; i < args.VerticlesCount - 1; i++)
            {
                //we need to select random elements 
                int next = random.Next(i + 1, args.VerticlesCount - 1);


                edges.Add(new EdgeModel(verticles[i], verticles[next]));
            }

            GraphModel model = new GraphModel(verticles, edges);

            return model;
        }

    }
}
