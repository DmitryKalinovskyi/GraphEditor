using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GraphApplication.Models.GraphRepresentations
{
    [DataContract(IsReference = true)]
    public class GraphModel: IGraphModel
    {
        [DataMember]
        private List<VertexModel> _verticles;

        [DataMember]
        private List<EdgeModel> _edges;

        public List<VertexModel> Verticles => _verticles;

        public List<EdgeModel> Edges => _edges;

        public EventHandler<VertexModel>? OnVertexAdded;
        public EventHandler<EdgeModel>? OnEdgeAdded;

        public EventHandler<VertexModel>? OnVertexRemoved;
        public EventHandler<EdgeModel>? OnEdgeRemoved;

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(VertexModel vertex)
        {
            _verticles.Add(vertex);
            OnVertexAdded?.Invoke(this, vertex);
        }

        /// <summary>
        /// Time complexity O(Vertexes + Edges)
        /// </summary>
        /// <param name="vertex"></param>
        public void RemoveVertex(VertexModel vertex)
        {
            _verticles.Remove(vertex);
            ClearEdgesConnectedTo(vertex);
            OnVertexRemoved?.Invoke(this, vertex);
        }

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(EdgeModel edge)
        {
            _edges.Add(edge);
            OnEdgeAdded?.Invoke(this, edge);
        }

        /// <summary>
        /// Time complexity O(Edges)
        /// </summary>
        /// <param name="edge"></param>
        public void RemoveEdge(EdgeModel edge)
        {
            _edges.Remove(edge);
            OnEdgeRemoved?.Invoke(this, edge);
        }

        public void ClearEdgesConnectedTo(VertexModel vertex)
        {
            var edges = new List<EdgeModel>();
            foreach (var edge in Edges)
            {
                if (edge.Start != vertex && edge.End != vertex)
                    edges.Add(edge);
            }

            _edges = edges;
        }

        public void ClearUnusedEdges()
        {
            var edges = new List<EdgeModel>();
            foreach(var edge in Edges)
            {
                if(edge.Start != null && edge.End != null)
                    edges.Add(edge);
            }

            _edges = edges;
        }

        /// <summary>
        /// Time complexity O(Edges)
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public bool IsConnectionBetween(VertexModel vertex1, VertexModel vertex2)
        {
            return GetEdgeBetween(vertex1, vertex2) != null;
        }

        /// <summary>
        /// Time complexity O(Edges)
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public EdgeModel? GetEdgeBetween(VertexModel vertex1, VertexModel vertex2)
        {
            foreach(var edge in Edges)
            {
                if(edge.Start == vertex1 && edge.End == vertex2) return edge;
            }

            return null;
        }

        //protected virtual void UpdateRepresentations(VertexModel vertex, bool isAdded = true)
        //{
        //    if (isAdded)
        //    {
        //        AdjancencyDictionary[vertex] = new HashSet<VertexModel>();
        //    }
        //    else
        //    {
        //        foreach (var v in AdjancencyDictionary[vertex])
        //        {
        //            AdjancencyDictionary[v].Remove(vertex);
        //        }
        //        AdjancencyDictionary.Remove(vertex);
        //    }
        //}

        //protected virtual void UpdateRepresentations(EdgeModel edge, bool isAdded = true)
        //{
        //    if (isAdded)
        //    {
        //        AdjancencyDictionary[edge.Start].Add(edge.End);
        //        AdjancencyDictionary[edge.End].Add(edge.Start);

        //        EdgeDictionary[(edge.Start, edge.End)] = edge;
        //        EdgeDictionary[(edge.End, edge.Start)] = edge;
        //    }
        //    else
        //    {
        //        EdgeDictionary.Remove((edge.Start, edge.End));
        //        EdgeDictionary.Remove((edge.End, edge.Start));

        //        AdjancencyDictionary[edge.Start].Remove(edge.End);
        //        AdjancencyDictionary[edge.End].Remove(edge.Start);
        //    }
        //}

        //private Dictionary<VertexModel, HashSet<VertexModel>> _adjancencyList;
        //private Dictionary<(VertexModel, VertexModel), EdgeModel> _edgeDictionary;

        //// two default representations for fast algorithm implementing, requires more memory
        //public Dictionary<VertexModel, HashSet<VertexModel>> AdjancencyDictionary
        //{
        //    get
        //    {
        //        if (_adjancencyList == null)
        //            InitializeRepresentations();

        //        return _adjancencyList;
        //    }
        //}
        //public Dictionary<(VertexModel, VertexModel), EdgeModel> EdgeDictionary
        //{
        //    get
        //    {
        //        if (_edgeDictionary == null)
        //            InitializeRepresentations();

        //        return _edgeDictionary;
        //    }
        //}

        //protected virtual void InitializeRepresentations()
        //{
        //    // can be null due to serializing and deserializing
        //    _edgeDictionary = new();
        //    _adjancencyList = new();

        //    //init AdjancencyList
        //    foreach (VertexModel vertex in _verticles)
        //    {
        //        _adjancencyList[vertex] = new HashSet<VertexModel>();
        //    }

        //    //build AdjancencyList
        //    foreach (EdgeModel edge in _edges)
        //    {
        //        _adjancencyList[edge.Start].Add(edge.End);
        //        _adjancencyList[edge.End].Add(edge.Start);
        //    }

        //    //build EdgeDictionary
        //    foreach (var edge in _edges)
        //    {
        //        EdgeDictionary[(edge.Start, edge.End)] = edge;
        //        EdgeDictionary[(edge.End, edge.Start)] = edge;
        //    }

        //}

        public GraphModel(List<VertexModel> verticles, List<EdgeModel> edges)
        {
            _verticles = verticles;
            _edges = edges;
            //_edgeDictionary = new();
            //_adjancencyList = new();

            //InitializeRepresentations();
        }

        public GraphModel() : this(new List<VertexModel>(), new List<EdgeModel>()) { }
    }
}
