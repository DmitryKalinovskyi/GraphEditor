using GraphApplication.Models;
using GraphApplication.ModelViews;
using GraphApplication.Services;
using GraphApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApplication.Commands.CommandList
{
    public class CloseProjectCommand : Command
    {
        private MainWindowModelView _mainWindowsViewModel;

        public CloseProjectCommand(MainWindowModelView mainWindowModelView)
        {
            _mainWindowsViewModel = mainWindowModelView;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is GraphProjectModelView modelView)
            {
                if (modelView.IsSaved == false)
                {
                    //promt to save or not
                    MessageBoxResult result = MessageBox.Show($"Граф({modelView.GraphNameFormat}) не збережено, ви бажаєте його зберегти?",
                        "Попередження", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                         _mainWindowsViewModel.SaveProjectCommand?.Execute(modelView);
                    }
                    else if (result == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }

                _mainWindowsViewModel.OpenedProjectsService.RemoveProject(modelView);
            }
        }
    }
}
