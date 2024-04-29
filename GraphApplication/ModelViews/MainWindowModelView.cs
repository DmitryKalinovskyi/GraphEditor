using GraphApplication.Commands;
using GraphApplication.Commands.CommandList;
using GraphApplication.Fabrication;
using GraphApplication.Models;
using GraphApplication.ModelViews.GraphEditorExtensions;
using GraphApplication.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace GraphApplication.ModelViews
{
    public class MainWindowModelView : NotifyModelView
    {
        #region Commands
        public Command? CreateGraphCommand { get; set; }

        public Command? GenerateGraphCommand { get; set; }

        public Command? SaveGraphCommand { get; set; }

        public Command? RemoveGraphCommand { get; set; }

        public Command? LoadGraphCommand { get; set; }
        #endregion

        public OpenedGraphModelViewsManager OpenedGraphModelViewsManager { get; set; }

        public GraphEditorMode? ActiveMode
        {
            get
            {
                if (OpenedGraphModelViewsManager.SelectedView == null)
                    return null;

                return OpenedGraphModelViewsManager.SelectedView.EditorMode;
            }
            set
            {
                if (OpenedGraphModelViewsManager.SelectedView == null || value == null)
                    return;

                OpenedGraphModelViewsManager.SelectedView.EditorMode = value;
                OnPropertyChanged(nameof(ActiveMode));
            }
        }

        public MainWindowModelView(ObservableCollection<GraphProjectModelView> graphViews)
        {
            OpenedGraphModelViewsManager = new(graphViews, new());

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            CreateGraphCommand = new CreateGraphCommand(this);
            GenerateGraphCommand = new GenerateGraphCommand(this);
            SaveGraphCommand = new SaveGraphCommand(this);
            RemoveGraphCommand = new RemoveGraphCommand(this);
            LoadGraphCommand = new LoadGraphCommand(this);
        }

        // Default constructor with basic services
        public MainWindowModelView() : this(new ObservableCollection<GraphProjectModelView>()) { }

        public void CloseAndSave()
        {
            //ask about saving
            IEnumerable<GraphProjectModelView> graphViewsToClose = OpenedGraphModelViewsManager.GraphEditorViews.ToList();

            foreach (GraphProjectModelView view in graphViewsToClose)
            {
                RemoveGraphCommand?.Execute(view);
            }
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseAndSave();
        }
    }
}
