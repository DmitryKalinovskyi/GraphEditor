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
    public class ShortestPathState : SelectionState, IAlgorithmImplementer
    {
        private IShortestPathAlgorithm _algorithm;

        public ShortestPathState(GraphProjectModelView modelView) : this(modelView, new DijkstraAlgorithm()) { }

        public ShortestPathState(GraphProjectModelView modelView, IShortestPathAlgorithm algorithm) : base(modelView)
        {
            _algorithm = algorithm;
        }

        public bool ImplementAlgorithm()
        {

            var selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 2)
            {
                MessageBox.Show("Алгоритм пошуку найкоротшого шляху реалізувати не можна, поки не обрано дві вершини!",
                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            VertexModelView start = selected[0];
            VertexModelView end = selected[1];

            var result = _algorithm.FindShortestPath(_modelView.GraphModelView.Model, start.Model, end.Model);

            if (result == ShortestPathResult.FailedToFindShortestPathResult)
            {
                MessageBox.Show("Шляху між вершинами не існує!", "Інформація",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (result.VertexModels == null)
                throw new ArgumentNullException("Edge models are null.");


            if (result.EdgeModels == null)
                throw new ArgumentNullException("Edge models are null.");

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViews_By_VertexModels(result.VertexModels);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViews_By_EdgeModels(result.EdgeModels);

            _modelView.AnimationManager.SetAnimation(new BFSShortestPathDisplayer(_modelView.GraphModelView, (vertexModelViews, edgesModelViews)));
            return true;
        }
    }
}
