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

            IterativeAlgorithmResult routeBuildResult = _algorithm.BuildRoute(_modelView.GraphModelView.Model, selected[0].Model);

            if (routeBuildResult.VertexModels == null)
                throw new ArgumentNullException(nameof(routeBuildResult.VertexModels));

            if (routeBuildResult.EdgeModels == null)
                throw new ArgumentNullException(nameof(routeBuildResult.EdgeModels));

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViews_By_VertexModels(routeBuildResult.VertexModels);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViews_By_EdgeModels(routeBuildResult.EdgeModels);

            _modelView.AnimationManager.SetAnimation(new BFSShortestPathDisplayer(_modelView.GraphModelView, (vertexModelViews, edgesModelViews)));
            return true;
        }
    }
}
