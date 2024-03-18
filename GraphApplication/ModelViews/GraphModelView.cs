using GraphApplication.Models.GraphRepresentations;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Policy;
using System.Windows.Automation.Peers;

namespace GraphApplication.ModelViews
{
    /// <summary>
    /// Implement interaction interface with GraphModel
    /// </summary>
    public class GraphModelView : NotifyModelView
    {
        public GraphModel Model { get; set; }

        public GraphModelView(): this(new()){ }

        public GraphModelView(GraphModel model)
        {
            Model = model;
        }
        
        // TODO: add methods to create edge between two verticles, add verticle
        // when edge or vertex is added view should be updated
        // better to implement comamnds, this allow client to manage command history if needed.

        // TODO: add methods to remove verticle and edges
        // when removing verticles you should remove edge that connected to verticle also.
        // you can add warning when removing verticle that have connected edges.
        // this warning can be offed in settings.
        
        // Sounds challenging with c# oop ;?

        // problems:
        
        // #1
        // we have graph model, graph model contains edgeModels, and vertexModels,
        // and you need to create ModelViews for each model, to keep mvvm interaction.

        // how we can get modelView based by model?

        // - list searching (too slow)
        // - using hashing
        // - assign special id, and use special service :O

        // #2

        

        //private GraphModel _model;

        //public int VertexCount { get { return VertexModelViews.Count(); } }
        //public int EdgeCount { get { return EdgeModelViews.Count(); } }


        //// Dictionary to get ModelView by Model
        //public Dictionary<VertexModel, VertexModelView> VertexModelViewAssociation { get; private set; }
        //public Dictionary<EdgeModel, EdgeModelView> EdgeModelViewAssociation { get; private set; }

        //public List<VertexModelView> GetVertexModelViewsByModels(IEnumerable<VertexModel> models)
        //{
        //    List<VertexModelView> vertexModelViews = new List<VertexModelView>();

        //    if (models == null || models.Count() == 0)
        //        return vertexModelViews;

        //    foreach (VertexModel model in models)
        //        vertexModelViews.Add(VertexModelViewAssociation[model]);

        //    return vertexModelViews;
        //}

        //public List<EdgeModelView> GetEdgeModelViewsByModels(IEnumerable<EdgeModel> models)
        //{
        //    List<EdgeModelView> edgeModelViews = new List<EdgeModelView>();

        //    if (models == null || models.Count() == 0)
        //        return edgeModelViews;

        //    foreach (EdgeModel model in models)
        //        edgeModelViews.Add(EdgeModelViewAssociation[model]);

        //    return edgeModelViews;
        //}

        //public GraphModel Model
        //{
        //    get { return _model; }

        //    set
        //    {
        //        _model = value;

        //        //create all modelViews elements 
        //        InitializeDependentModelViews();
        //    }
        //}

        //protected void InitializeDependentModelViews()
        //{
        //    VertexModelViewAssociation = new Dictionary<VertexModel, VertexModelView>();
        //    EdgeModelViewAssociation = new Dictionary<EdgeModel, EdgeModelView>();

        //    VertexModelViews = new ObservableCollection<VertexModelView>();

        //    Model.Verticles.ForEach(vertexModel =>
        //    {
        //        VertexModelView modelView = new VertexModelView(vertexModel);
        //        VertexModelViewAssociation[vertexModel] = modelView;

        //        VertexModelViews.Add(modelView);
        //    });

        //    EdgeModelViews = new ObservableCollection<EdgeModelView>();

        //    Model.Edges.ForEach(edge =>
        //    {
        //        EdgeModelView modelView = new(edge, VertexModelViewAssociation[edge.Start], VertexModelViewAssociation[edge.End]);
        //        EdgeModelViewAssociation[modelView.Model] = modelView;

        //        EdgeModelViews.Add(modelView);
        //    });

        //    VertexModelViews.CollectionChanged += OnVertexCollectionChanged;

        //    EdgeModelViews.CollectionChanged += OnEdgeCollectionChanged;

        //    OnPropertyChanged(nameof(Model));
        //    OnPropertyChanged(nameof(VertexCount));
        //    OnPropertyChanged(nameof(EdgeCount));
        //}

        //private void OnEdgeCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.NewItems != null)
        //        foreach (EdgeModelView edgeModelView in e.NewItems)
        //        {
        //            EdgeModelViewAssociation[edgeModelView.Model] = edgeModelView;
        //            Model.AddEdge(edgeModelView.Model);
        //        }

        //    if (e.OldItems != null)
        //        foreach (EdgeModelView edgeModelView in e.OldItems)
        //        {
        //            EdgeModelViewAssociation.Remove(edgeModelView.Model);
        //            Model.RemoveEdge(edgeModelView.Model);
        //        }

        //    OnPropertyChanged(nameof(EdgeCount));

        //}

        //private void OnVertexCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.NewItems != null)

        //        foreach (VertexModelView vertexModelView in e.NewItems)
        //        {
        //            VertexModelViewAssociation[vertexModelView.Model] = vertexModelView;
        //            Model.AddVertex(vertexModelView.Model);
        //        }

        //    if (e.OldItems != null)
        //    {
        //        HashSet<VertexModelView> old = new HashSet<VertexModelView>();
        //        foreach (VertexModelView vertexModelView in e.OldItems)
        //        {
        //            old.Add(vertexModelView);

        //            VertexModelViewAssociation.Remove(vertexModelView.Model);
        //            Model.RemoveVertex(vertexModelView.Model);
        //        }

        //        EdgeModelViews = new ObservableCollection<EdgeModelView>(
        //                        EdgeModelViews.Where(edge => old.Contains(edge.Start) == false && old.Contains(edge.End) == false));


        //        EdgeModelViews.CollectionChanged += OnEdgeCollectionChanged;
        //    }

        //    OnPropertyChanged(nameof(VertexCount));
        //}

        //private ObservableCollection<VertexModelView> _vertexModelViews;
        //public ObservableCollection<VertexModelView> VertexModelViews
        //{
        //    get { return _vertexModelViews; }
        //    set
        //    {
        //        _vertexModelViews = value;
        //        OnPropertyChanged(nameof(VertexModelViews));
        //        OnPropertyChanged(nameof(VertexCount));

        //    }
        //}
        //private ObservableCollection<EdgeModelView> _edgeModelViews;
        //public ObservableCollection<EdgeModelView> EdgeModelViews
        //{
        //    get { return _edgeModelViews; }
        //    set
        //    {
        //        _edgeModelViews = value;
        //        OnPropertyChanged(nameof(EdgeModelViews));
        //        OnPropertyChanged(nameof(EdgeCount));

        //    }
        //}

        //public GraphModelView(GraphModel model)
        //{
        //    Model = model;
        //}

        //public GraphModelView()
        //{
        //    Model = new GraphModel();
        //}

        //public int GetFreeIndex()
        //{

        //    bool[] used = new bool[VertexModelViews.Count];

        //    foreach (var view in VertexModelViews)
        //    {
        //        int index = view.Model.Id;
        //        if (index >= used.Length)
        //            continue;

        //        used[index] = true;
        //    }

        //    int i = 0;
        //    for (; i < used.Length; i++)
        //    {
        //        if (used[i] == false)
        //            break;
        //    }

        //    return i;
        //}
    }
}
