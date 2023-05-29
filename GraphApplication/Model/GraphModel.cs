using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{
    [DataContract(IsReference = true)]
    public class GraphModel
    {
        [DataMember]
        private List<VertexModel> _verticles;

        public List<VertexModel> Verticles => _verticles;

        public void AddVertex(VertexModel vertex)
        {
            AdjancencyList[vertex] = new HashSet<VertexModel>();
            _verticles.Add(vertex);

            Trace.WriteLine("Adjancency list updated!");

        }

        public void RemoveVertex(VertexModel vertex)
        {
            foreach(var v in AdjancencyList[vertex])
            {
                AdjancencyList[v].Remove(vertex);
            }
            _verticles.Remove(vertex);


            Trace.WriteLine("Adjancency list updated!");

            AdjancencyList.Remove(vertex);
        }


        [DataMember]
        private List<EdgeModel> _edges;

        public List<EdgeModel> Edges => _edges;



        public void AddEdge(EdgeModel edge)
        {
            AdjancencyList[edge.Start].Add(edge.End);
            AdjancencyList[edge.End].Add(edge.Start);

            _edges.Add(edge);

            Trace.WriteLine("Adjancency list updated!");

        }

        public void RemoveEdge(EdgeModel edge)
        {
            AdjancencyList[edge.Start].Remove(edge.End);
            AdjancencyList[edge.End].Remove(edge.Start);

            _edges.Remove(edge);

            Trace.WriteLine("Adjancency list updated!");

        }

        private Dictionary<VertexModel, HashSet<VertexModel>> _adjancencyList;
        public Dictionary<VertexModel, HashSet<VertexModel>> AdjancencyList
        {
            get
            {
                if (_adjancencyList == null)
                    _adjancencyList = BuildAdjancencyList();

                return _adjancencyList;
            }
            private set
            {
                _adjancencyList = value;
            }
        }

        protected virtual Dictionary<VertexModel, HashSet<VertexModel>> BuildAdjancencyList()
        {
            Dictionary<VertexModel, HashSet<VertexModel>> adjancencyList = new();

            //init AdjancencyList
            foreach (VertexModel vertex in _verticles)
            {
                adjancencyList[vertex] = new HashSet<VertexModel>();
            }

            //build AdjancencyList
            foreach (EdgeModel edge in _edges)
            {
                adjancencyList[edge.Start].Add(edge.End);
                adjancencyList[edge.End].Add(edge.Start);
            }

            return adjancencyList;
        }

        public GraphModel(List<VertexModel> verticles, List<EdgeModel> edges)
        {
            _verticles = verticles;
            _edges = edges;

            _adjancencyList = BuildAdjancencyList();
        }

        

        public GraphModel()
        {
            _verticles = new List<VertexModel>();
            _edges = new List<EdgeModel>();

            _adjancencyList = BuildAdjancencyList();
        }
    }
}
