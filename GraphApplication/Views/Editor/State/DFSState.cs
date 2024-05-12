using GraphApplication.Algorithms;
using GraphApplication.Algorithms.Contracts;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.Animations;
using GraphApplication.Views.Editor.State.Base;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.Views.Editor.State
{
    public class DFSState : SelectionState, IAlgorithmImplementer
    {
        private IDFSAlgorithm _algorithm;

        public DFSState(GraphProjectModelView modelView) : this(modelView, new DFSAlgorithm()) { }

        public DFSState(GraphProjectModelView modelView, IDFSAlgorithm algorithm) : base(modelView)
        {
            _algorithm = algorithm;
        }

        public bool ImplementAlgorithm()
        {
            List<VertexModelView> selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 1)
            {
                MessageBox.Show("Алгоритм пошуку в глибину реалізувати не можливо, поки не обрано тільки одну вершину!",
                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            var result = _algorithm.Traverse(_modelView.GraphModelView.Model, selected[0].Model);

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViews_By_VertexModels(result.VertexModels);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViews_By_EdgeModels(result.EdgeModels);

            DFSDisplayer _displayer = new(_modelView.GraphModelView, (vertexModelViews, edgesModelViews));

            _modelView.AnimationManager.SetAnimation(_displayer);
            return true;
        }
    }
}
