using GraphApplication.Commands;
using GraphApplication.Factories.Graph;
using GraphApplication.Services.Editor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelViews
{
    public class ProjectTemplateViewModel
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
