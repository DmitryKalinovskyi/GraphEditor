using GraphApplication.ModelViews;
using GraphApplication.ModelViews.GraphEditorExtensions;
using System.Windows;

namespace GraphApplication.Commands.CommandList
{
    public class StartAlgorithmCommand : Command
    {
        private GraphEditorModelView _graphEditorModelView;
        public StartAlgorithmCommand(GraphEditorModelView graphEditorModelView)
        {
            _graphEditorModelView = graphEditorModelView;
        }

        public override void Execute(object? parameter)
        {
            if (_graphEditorModelView.CurrentEditorMode is IAlgorithmImplementer implementer)
            {
                bool result = implementer.ImplementAlgorithm();

                if (result)
                    _graphEditorModelView.AnimationManager.StartAnimation();
            }
            else
            {
                MessageBox.Show("Алгоритм для реалізації не обрано!", "Попередження",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
