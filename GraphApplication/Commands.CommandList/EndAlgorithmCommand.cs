using GraphApplication.ModelViews;
using System.Windows;

namespace GraphApplication.Commands.CommandList
{
    public class EndAlgorithmCommand : Command
    {
        private GraphEditorAnimationManager _animationManager;
        public EndAlgorithmCommand(GraphEditorAnimationManager animationManager)
        {
            _animationManager = animationManager;
        }

        public override void Execute(object? parameter)
        {
            if (_animationManager.IsAnimationActive == false)
            {
                MessageBox.Show("Немає обраної анімації алгоритма", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _animationManager.StopAnimation();
        }
    }
}
