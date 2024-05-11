using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Windows;

namespace GraphApplication.Commands.CommandList
{
    public class StartAlgorithmCommand : Command
    {
        private GraphProjectModelView _graphEditorModelView;
        public StartAlgorithmCommand(GraphProjectModelView graphEditorModelView)
        {
            _graphEditorModelView = graphEditorModelView;
        }

        public override void Execute(object? parameter)
        {
            if (_graphEditorModelView.EditorState is IAlgorithmImplementer implementer)
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
