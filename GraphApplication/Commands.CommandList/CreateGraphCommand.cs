using GraphApplication.Models;
using GraphApplication.Models.Graph;
using GraphApplication.ModelViews;
using GraphApplication.Views;

namespace GraphApplication.Commands.CommandList
{
    public class CreateGraphCommand : Command
    {
        private MainWindowModelView _mainWindowModelView;

        public CreateGraphCommand(MainWindowModelView mainWindowModelView) {
            _mainWindowModelView = mainWindowModelView;
        }

        public override void Execute(object? parameter)
        {
            GraphProjectModelView modelView;

            if (parameter is IGraphModel graphModel)
            {
                GraphProjectModel editorModel = new GraphProjectModel(graphModel);

                modelView = new GraphProjectModelView(editorModel, "");
            }
            else
            {
                GraphProjectModel editorModel = new();

                modelView = new GraphProjectModelView(editorModel, "");
            }


            _mainWindowModelView.OpenedGraphModelViewsManager.SelectedView = modelView;
            _mainWindowModelView.OpenedGraphModelViewsManager.GraphEditorViews.Add(modelView);
        }
    }
}
