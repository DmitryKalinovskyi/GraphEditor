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

        public Command? ChangeEditorModeCommand { get; set; }
        #endregion

        public OpenedGraphModelViewsManager OpenedGraphModelViewsManager { get; set; }

        public GraphEditorMode? ActiveMode
        {
            get
            {
                if (OpenedGraphModelViewsManager.SelectedView == null)
                    return null;

                return OpenedGraphModelViewsManager.SelectedView.CurrentEditorMode;
            }
            set
            {
                if (OpenedGraphModelViewsManager.SelectedView == null || value == null)
                    return;

                OpenedGraphModelViewsManager.SelectedView.CurrentEditorMode = value;
                OnPropertyChanged(nameof(ActiveMode));
            }
        }

        public bool ToolBarEnabled { get { return OpenedGraphModelViewsManager.GraphEditorViews.Count() > 0; } }

        public MainWindowModelView(ObservableCollection<GraphEditorModelView> graphViews)
        {
            OpenedGraphModelViewsManager = new(graphViews, new());

            InitializeCommands();

            OpenedGraphModelViewsManager.GraphEditorViews.CollectionChanged += (sender, e) => OnPropertyChanged(nameof(ToolBarEnabled));
        }

        private void InitializeCommands()
        {
            CreateGraphCommand = new CreateGraphCommand(this);
            GenerateGraphCommand = new GenerateGraphCommand(this);
            SaveGraphCommand = new SaveGraphCommand(this);
            RemoveGraphCommand = new RemoveGraphCommand(this);
            LoadGraphCommand = new LoadGraphCommand(this);
            ChangeEditorModeCommand = new ChangeEditorModeCommand(this);
        }

        // Default constructor with basic services
        public MainWindowModelView() : this(new ObservableCollection<GraphEditorModelView>()) { }

        public void CloseAndSave()
        {
            //ask about saving
            IEnumerable<GraphEditorModelView> graphViewsToClose = OpenedGraphModelViewsManager.GraphEditorViews.ToList();

            foreach (GraphEditorModelView view in graphViewsToClose)
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
