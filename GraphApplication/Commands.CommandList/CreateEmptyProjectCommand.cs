using GraphApplication.Models;
using GraphApplication.Models.Graph;
using GraphApplication.ModelViews;
using GraphApplication.Views;

namespace GraphApplication.Commands.CommandList
{
    public class CreateEmptyProjectCommand : Command
    {
        private MainWindowModelView _mainWindowModelView;

        public CreateEmptyProjectCommand(MainWindowModelView mainWindowModelView) {
            _mainWindowModelView = mainWindowModelView;
        }

        public override void Execute(object? parameter)
        {
            // load from application settings default graph model.
            GraphProjectModel editorModel = new(new UndirectedGraphModel());

            var project = new GraphProjectModelView(editorModel, "");

            _mainWindowModelView.OpenedProjectsService.AddProjectAndSelect(project);
        }
    }
}
