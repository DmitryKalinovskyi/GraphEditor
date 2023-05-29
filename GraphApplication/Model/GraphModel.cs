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
            AdjancencyDictionary[vertex] = new HashSet<VertexModel>();
            _verticles.Add(vertex);
        }

        public void RemoveVertex(VertexModel vertex)
        {
            foreach(var v in AdjancencyDictionary[vertex])
            {
                AdjancencyDictionary[v].Remove(vertex);
            }
            _verticles.Remove(vertex);

            AdjancencyDictionary.Remove(vertex);
        }


        [DataMember]
        private List<EdgeModel> _edges;

        public List<EdgeModel> Edges => _edges;



        public void AddEdge(EdgeModel edge)
        {
            AdjancencyDictionary[edge.Start].Add(edge.End);
            AdjancencyDictionary[edge.End].Add(edge.Start);

            EdgeDictionary[(edge.Start, edge.End)] = edge;
            EdgeDictionary[(edge.End, edge.Start)] = edge;

            _edges.Add(edge);
        }

        public void RemoveEdge(EdgeModel edge)
        {
            AdjancencyDictionary[edge.Start].Remove(edge.End);
            AdjancencyDictionary[edge.End].Remove(edge.Start);

            _edges.Remove(edge);
        }

        private Dictionary<VertexModel, HashSet<VertexModel>> _adjancencyList;
        private Dictionary<(VertexModel, VertexModel), EdgeModel> _edgeDictionary;


        public Dictionary<VertexModel, HashSet<VertexModel>> AdjancencyDictionary
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

        public Dictionary<(VertexModel, VertexModel), EdgeModel> EdgeDictionary
        {
            get
            {
                if(_edgeDictionary == null)
                {
                    _edgeDictionary = new();
                    foreach(var edge in _edges)
                    {
                        EdgeDictionary[(edge.Start, edge.End)] = edge;
                        EdgeDictionary[(edge.End, edge.Start)] = edge;
                    }
                }

                return _edgeDictionary;
            }

            private set
            {
                _edgeDictionary = value;
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
