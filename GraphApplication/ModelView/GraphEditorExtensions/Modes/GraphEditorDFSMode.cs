using GraphApplication.Algorithms;
using GraphApplication.Model;
using GraphApplication.ModelView.GraphEditorExtensions.Displaying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorDFSMode : GraphEditorSelectionMode, IAlgorithmImplementer
    {
        public GraphEditorDFSMode(GraphEditorModelView modelView) : base(modelView)
        {
            _algorithm = new DFSAlgorithm();
        }

        DFSAlgorithm _algorithm;

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            if (_modelView.AnimationManager.IsAnimationActive)
            {
                MessageBox.Show("Завершіть програвання минулого алгоритму!",
                  "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            base.VertexClicked(sender, e);
        }

        public bool Implement()
        {
            List<VertexModelView> selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 1)
            {
                MessageBox.Show("Алгоритм пошуку в глибину реалізувати не можливо, поки не обрано тільки одну вершину!",
                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            IEnumerable<VertexModel> iterator = _algorithm.Implement(_modelView.GraphModelView.Model, selected[0].Model);


            if (iterator == null)
            {
                MessageBox.Show("Шляху між вершинами не існує!", "Інформація",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViewsByModels(iterator);

            DFSDisplayer _displayer = new(_modelView.GraphModelView, vertexModelViews);

            _modelView.AnimationManager.SetAnimation(_displayer);
            return true;
        }

        //private void CancelAnimation()
        //{
        //    if (_displayer != null)
        //    {
        //        _displayer.StopAnimation();
        //        _displayer.RestoreAnimation();
        //        _displayer = null;
        //        _modelView.SelectionManager.DiselectAll();
        //    }
        //}

        public override void OnModeSwitch()
        {
        }
    }
}
