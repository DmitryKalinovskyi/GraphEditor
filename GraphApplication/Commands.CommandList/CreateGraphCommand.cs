using GraphApplication.Models;
using GraphApplication.Models.GraphRepresentations;
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
            GraphEditorModelView modelView;

            if (parameter is GraphModel)
            {
                GraphEditorModel graphModel = new GraphEditorModel(parameter as GraphModel);

                modelView = new GraphEditorModelView(graphModel, "");
            }
            else
            {
                GraphEditorModel graphModel = new GraphEditorModel();

                modelView = new GraphEditorModelView(graphModel, "");
            }


            _mainWindowModelView.OpenedGraphModelViewsManager.SelectedView = modelView;
            _mainWindowModelView.OpenedGraphModelViewsManager.GraphEditorViews.Add(modelView);
        }
    }
}
