using GraphApplication.Algorithms;
using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.ModelView.GraphEditorExtensions.Displaying;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorShortestPathMode : GraphEditorSelectionMode, IAlgorithmImplementer
    {
        private IShortestPathAlgorithm _algorithm;

        public GraphEditorShortestPathMode(GraphEditorModelView modelView) : this(modelView, new BFSShortestPathAlgorithm()) { }

        public GraphEditorShortestPathMode(GraphEditorModelView modelView, IShortestPathAlgorithm algorithm) : base(modelView)
        {
            _algorithm = algorithm;
        }

        // i don't undestand purpose of this code, because MainWindowViewModel disallow to change modes while another algorithm is running.
        //public override void VertexClicked(object sender, RoutedEventArgs e)
        //{
        //    if (_modelView.AnimationManager.IsAnimationActive)
        //    {
        //        MessageBox.Show("Завершіть програвання минулого алгоритму!",
        //           "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }

        //    base.VertexClicked(sender, e);
        //}

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

            IterativeAlgorithmResult routeBuildResult = _algorithm.BuildRoute(_modelView.GraphModelView.Model, start.Model, end.Model);

            if(routeBuildResult.VertexModels == null)
            {
                MessageBox.Show("Шляху між вершинами не існує!", "Інформація",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViewsByModels(routeBuildResult.Item1);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViewsByModels(routeBuildResult.Item2);

            _modelView.AnimationManager.SetAnimation(new BFSShortestPathDisplayer(_modelView.GraphModelView, (vertexModelViews, edgesModelViews)));
            return true;
        }
    }
}
