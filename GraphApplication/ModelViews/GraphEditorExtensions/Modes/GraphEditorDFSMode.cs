using GraphApplication.Algorithms;
using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.ModelViews.GraphEditorExtensions.Displaying;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.ModelViews.GraphEditorExtensions.Modes
{
    public class GraphEditorDFSMode : GraphEditorSelectionMode, IAlgorithmImplementer
    {
        private IDFSAlgorithm _algorithm;

        public GraphEditorDFSMode(GraphProjectModelView modelView) : this(modelView, new DFSAlgorithm()) { }

        public GraphEditorDFSMode(GraphProjectModelView modelView, IDFSAlgorithm algorithm) : base(modelView)
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

            IterativeAlgorithmResult routeBuildResult = _algorithm.BuildRoute(_modelView.GraphModelView.Model, selected[0].Model);

            if (routeBuildResult.EdgeModels == null)
                throw new ArgumentNullException("Edge models are null.");

            if (routeBuildResult.VertexModels == null)
                throw new ArgumentNullException("Vertex models are null.");

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViews_By_VertexModels(routeBuildResult.VertexModels);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViews_By_EdgeModels(routeBuildResult.EdgeModels);

            DFSDisplayer _displayer = new(_modelView.GraphModelView, (vertexModelViews, edgesModelViews));

            _modelView.AnimationManager.SetAnimation(_displayer);
            return true;
        }
    }
}
