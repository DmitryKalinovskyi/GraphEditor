using GraphApplication.ModelViews;
using GraphApplication.Views;

namespace GraphApplication.Commands.CommandList
{
    public class CreateProjectTemplateCommand : Command
    {
        private MainWindowModelView _mainWindowsViewModel;

        public CreateProjectTemplateCommand(MainWindowModelView mainWindowModelView)
        {
            _mainWindowsViewModel = mainWindowModelView;
        }

        public override void Execute(object? parameter)
        {
            var projectTemplateWindow = new ProjectTemplateWindow(_mainWindowsViewModel);

            projectTemplateWindow.Owner = App.Current.MainWindow;
            projectTemplateWindow.Show();
        }
    }
}
