using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.Animations;
using GraphApplication.Views.Editor.State.Base;

namespace GraphApplication.Views.Editor.State
{
    public class SpanningTreeState : SelectionState, IAlgorithmImplementer
    {
        private IMinSpanningTreeAlgorithm _algorithm;

        public SpanningTreeState(GraphProjectModelView modelView) : this(modelView, new PrimAlgorithm()) { }

        public SpanningTreeState(GraphProjectModelView modelView, IMinSpanningTreeAlgorithm algorithm) : base(modelView)
        {
            _algorithm = algorithm;
        }

        public bool ImplementAlgorithm()
        {

            var selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 1)
            {
                MessageBox.Show("To implement min spanning tree algorithm you need to select exactly one vertex.",
                    "Attentiion!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            var result = _algorithm.FindMinSpanningTree(_modelView.GraphModelView.Model, selected[0].Model);

            if (result.VertexModels == null)
                throw new ArgumentNullException(nameof(result.VertexModels));

            if (result.EdgeModels == null)
                throw new ArgumentNullException(nameof(result.EdgeModels));

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViews_By_VertexModels(result.VertexModels);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViews_By_EdgeModels(result.EdgeModels);

            _modelView.AnimationManager.SetAnimation(new BFSShortestPathDisplayer(_modelView.GraphModelView, (vertexModelViews, edgesModelViews)));
            return true;
        }
    }
}
