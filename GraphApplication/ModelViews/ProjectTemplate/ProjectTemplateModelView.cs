using GraphApplication.Commands;
using GraphApplication.Factories.Graph;
using GraphApplication.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GraphApplication.ModelViews.ProjectTemplate
{
    public class ProjectTemplateModelView : NotifyModelView
    {
        public IGraphFactory? GraphFactory { get; set; }

        private RelayCommand? _confirmCommand;
        public RelayCommand? ConfirmCommand => _confirmCommand ?? new RelayCommand((param) =>
        {
            var graph = GraphFactory.CreateUndirectedGraph();

            var mainWindow = (App.Current as App).ServiceProvider.GetRequiredService<MainWindowModelView>();

            var projectModel = new GraphProjectModel(graph);

            mainWindow.OpenedProjectsService.AddProjectAndSelect(new GraphProjectModelView(projectModel, ""));
        });

    }
}
