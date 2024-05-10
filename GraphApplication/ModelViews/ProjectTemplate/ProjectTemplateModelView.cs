using GraphApplication.Commands;
using GraphApplication.Factories.Graph;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GraphApplication.ModelViews.ProjectTemplate
{
    public class ProjectTemplateModelView: NotifyModelView
    {
        public IGraphFactory? GraphFactory { get; set; }

        private RelayCommand? _confirmCommand;
        public RelayCommand? ConfirmCommand => _confirmCommand ?? new RelayCommand((param) =>
        {
            var graph = GraphFactory.CreateUndirectedGraph();

            var mainWindow = (App.Current as App).ServiceProvider.GetRequiredService<MainWindowModelView>();
            mainWindow.CreateGraphCommand?.Execute(graph);
        });

    }
}
