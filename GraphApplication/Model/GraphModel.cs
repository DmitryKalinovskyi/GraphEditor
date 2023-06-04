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
        [DataMember]
        private List<EdgeModel> _edges;

        public List<VertexModel> Verticles => _verticles;

        public List<EdgeModel> Edges => _edges;

        public void AddVertex(VertexModel vertex)
        {
            UpdateRepresentations(vertex);

            _verticles.Add(vertex);
        }

        public void RemoveVertex(VertexModel vertex)
        {
            UpdateRepresentations(vertex, false);

            _verticles.Remove(vertex);
        }

        public void AddEdge(EdgeModel edge)
        {
            UpdateRepresentations(edge);
            _edges.Add(edge);
        }

        public void RemoveEdge(EdgeModel edge)
        {
            UpdateRepresentations(edge, false);
            _edges.Remove(edge);
        }

        protected virtual void UpdateRepresentations(VertexModel vertex, bool isAdded = true)
        {
            if (isAdded)
            {
                AdjancencyDictionary[vertex] = new HashSet<VertexModel>();
            }
            else
            {
                foreach (var v in AdjancencyDictionary[vertex])
                {
                    AdjancencyDictionary[v].Remove(vertex);
                }
                AdjancencyDictionary.Remove(vertex);
            }
        }

        protected virtual void UpdateRepresentations(EdgeModel edge, bool isAdded = true)
        {
            if (isAdded)
            {
                AdjancencyDictionary[edge.Start].Add(edge.End);
                AdjancencyDictionary[edge.End].Add(edge.Start);

                EdgeDictionary[(edge.Start, edge.End)] = edge;
                EdgeDictionary[(edge.End, edge.Start)] = edge;
            }
            else
            {
                EdgeDictionary.Remove((edge.Start, edge.End));
                EdgeDictionary.Remove((edge.End, edge.Start));

                AdjancencyDictionary[edge.Start].Remove(edge.End);
                AdjancencyDictionary[edge.End].Remove(edge.Start);
            }
        }

        private Dictionary<VertexModel, HashSet<VertexModel>> _adjancencyList;
        private Dictionary<(VertexModel, VertexModel), EdgeModel> _edgeDictionary;

        // two default representations for fast algorithm implementing, requires more memory
        public Dictionary<VertexModel, HashSet<VertexModel>> AdjancencyDictionary
        {
            get
            {
                if (_adjancencyList == null)
                    InitializeRepresentations();

                return _adjancencyList;
            }
        }
        public Dictionary<(VertexModel, VertexModel), EdgeModel> EdgeDictionary
        {
            get
            {
                if(_edgeDictionary == null)
                    InitializeRepresentations();   

                return _edgeDictionary;
            }
        }

        protected virtual void InitializeRepresentations()
        {
            _adjancencyList = new();

            //init AdjancencyList
            foreach (VertexModel vertex in _verticles)
            {
                _adjancencyList[vertex] = new HashSet<VertexModel>();
            }

            //build AdjancencyList
            foreach (EdgeModel edge in _edges)
            {
                _adjancencyList[edge.Start].Add(edge.End);
                _adjancencyList[edge.End].Add(edge.Start);
            }

            //build EdgeDictionary
            _edgeDictionary = new();
            foreach (var edge in _edges)
            {
                EdgeDictionary[(edge.Start, edge.End)] = edge;
                EdgeDictionary[(edge.End, edge.Start)] = edge;
            }

        }

        public GraphModel(List<VertexModel> verticles, List<EdgeModel> edges)
        {
            _verticles = verticles;
            _edges = edges;

            InitializeRepresentations();
        }
        
        public GraphModel()
        {
            _verticles = new List<VertexModel>();
            _edges = new List<EdgeModel>();

            InitializeRepresentations();
        }
    }
}
