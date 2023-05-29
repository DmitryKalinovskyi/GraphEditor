using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms
{
    public class DFSAlgorithm : IIterativeAlgorithm
    {
        public IEnumerable<VertexModel> Implement(GraphModel graph, params object[] args)
        {
            VertexModel startPoint = args[0] as VertexModel ?? throw new ArgumentException("Початкова точка не вказана! ");

            HashSet<VertexModel> visited = new HashSet<VertexModel>();

            List<VertexModel> ans = new List<VertexModel>();

            Stack<VertexModel> stack = new Stack<VertexModel>();

            stack.Push(startPoint);
            visited.Add(startPoint);

            while (stack.Count > 0)
            {
                VertexModel topElement = stack.Pop();

                ans.Add(topElement);

                foreach (VertexModel neighbor in graph.AdjancencyList[topElement])
                {
                    if (visited.Contains(neighbor) == false)
                    {
                        stack.Push(neighbor);
                        visited.Add(neighbor);
                    }
                }

            }

            return ans;
        }
    }
}
