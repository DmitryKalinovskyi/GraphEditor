using GraphApplication.Algorithms;
using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.Animations;
using GraphApplication.Views.Editor.State.Base;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.Views.Editor.State
{
    public class BFSState : SelectionState, IAlgorithmImplementer
    {
        private IBFSAlgorithm _algorithm;

        public BFSState(GraphProjectModelView modelView) : this(modelView, new BFSAlgorithm()) { }

        public BFSState(GraphProjectModelView modelView, IBFSAlgorithm algorithm) : base(modelView)
        {
            _algorithm = algorithm;
        }

        public bool ImplementAlgorithm()
        {
            List<VertexModelView> selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 1)
            {
                MessageBox.Show("Алгоритм пошуку в ширину реалізувати не можливо, поки не обрано тільки одну вершину!",
                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            TraversalAlgorithmResult routeBuildResult = _algorithm.Traverse(_modelView.GraphModelView.Model, selected[0].Model);

            if (routeBuildResult.EdgeModels == null)
                throw new ArgumentNullException("Edge models are null.");

            if (routeBuildResult.VertexModels == null)
                throw new ArgumentNullException("Vertex models are null.");

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViews_By_VertexModels(routeBuildResult.VertexModels);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViews_By_EdgeModels(routeBuildResult.EdgeModels);

            BFSDisplayer _displayer = new(_modelView.GraphModelView, (vertexModelViews, edgesModelViews));

            _modelView.AnimationManager.SetAnimation(_displayer);

            _displayer.StartAnimation();
            return true;
        }
    }
}
