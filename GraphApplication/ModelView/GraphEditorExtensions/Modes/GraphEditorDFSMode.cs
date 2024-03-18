using GraphApplication.Algorithms;
using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.ModelView.GraphEditorExtensions.Displaying;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorDFSMode : GraphEditorSelectionMode, IAlgorithmImplementer
    {
        private IDFSAlgorithm _algorithm;

        public GraphEditorDFSMode(GraphEditorModelView modelView) : this(modelView, new DFSAlgorithm()) { }

        public GraphEditorDFSMode(GraphEditorModelView modelView, IDFSAlgorithm algorithm) : base(modelView)
        {
            _algorithm = algorithm;
        }

        //public override void VertexClicked(object sender, RoutedEventArgs e)
        //{
        //    if (_modelView.AnimationManager.IsAnimationActive)
        //    {
        //        MessageBox.Show("Завершіть програвання минулого алгоритму!",
        //          "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }

        //    base.VertexClicked(sender, e);
        //}

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

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViewsByModels(routeBuildResult.VertexModels);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViewsByModels(routeBuildResult.EdgeModels);

            DFSDisplayer _displayer = new(_modelView.GraphModelView, (vertexModelViews, edgesModelViews));

            _modelView.AnimationManager.SetAnimation(_displayer);
            return true;
        }
    }
}
