using GraphApplication.Algorithms;
using GraphApplication.Model;
using GraphApplication.ModelView.GraphEditorExtensions.Displaying;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorShortestPathMode : GraphEditorSelectionMode, IAlgorithmImplementer
    {
        public GraphEditorShortestPathMode(GraphEditorModelView modelView) : base(modelView)
        {
            _algorithm = new BFSShortestPathAlgorithm();
        }

        BFSShortestPathAlgorithm _algorithm;

        BFSShortestPathDisplayer? _displayer;

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            if (_displayer != null)
            {
                CancelAnimation();
            }

            base.VertexClicked(sender, e);
        }

        public void Implement()
        {
            if (_displayer != null)
                CancelAnimation();

            var selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 2)
            {
                MessageBox.Show("Алгоритм пошуку найкоротшого шляху реалізувати не можна, поки не обрано дві вершини!",
                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            VertexModelView start = selected[0];
            VertexModelView end = selected[1];

            IEnumerable<VertexModel> iterator = _algorithm.Implement(_modelView.GraphModelView.Model, start.Model, end.Model);

            if(iterator == null)
            {
                MessageBox.Show("Шляху між вершинами не існує!", "Інформація",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViewsByModels(iterator);

            _displayer = new(_modelView.GraphModelView, vertexModelViews);

            _displayer.StartAnimation();
        }

        private void CancelAnimation()
        {
            if (_displayer != null)
            {
                _displayer.StopAnimation();
                _displayer.RestoreAnimation();
                _displayer = null;
                _modelView.SelectionManager.DiselectAll();
            }
        }

        public override void OnModeSwitch()
        {
            CancelAnimation();
        }
    }
}
