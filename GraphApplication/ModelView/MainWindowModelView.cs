using GraphApplication.Model;
using GraphApplication.ModelView.GraphEditorExtensions;
using GraphApplication.Services;
using GraphApplication.Services.Commands;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApplication.ModelView
{
    public class MainWindowModelView: NotifyModelView
    {
        #region Commands


        private RelayCommand _createGraphCommand;
        public RelayCommand CreateGraphCommand
        {
            get 
            {
                return _createGraphCommand ??
                     (_createGraphCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                             // we can load our graph model
                             GraphEditorModel graphModel = new GraphEditorModel("graph1", new List<GraphObjectModel> { new VertexModel(0, 0, "Node 1"), new VertexModel(100, 100, "Node 2") , new VertexModel(250, 250, "Node 3") });

                             GraphEditorModelView modelView = new GraphEditorModelView(graphModel);

                             SelectedView = modelView;
                             GraphEditorViews.Add(modelView);
                             


                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show("Відбулася помилка виконання команди: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                         }
                     }));
            }
        }


        private RelayCommand _removeGraphCommand;
        public RelayCommand RemoveGraphCommand
        {
            get
            {
                return _removeGraphCommand ??
                     (_removeGraphCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                             if(obj is GraphEditorModelView modelView) 
                             {
                                 GraphEditorViews.Remove(modelView);  
                             }
                         }
                         catch (Exception ex)
                         {
                         }
                     }));
            }
        }

        private RelayCommand _loadGraphCommand;
        public RelayCommand LoadGraphCommand
        {
            get
            {
                return _loadGraphCommand ??
                     (_loadGraphCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                         }
                         catch (Exception ex)
                         {
                         }
                     }));
            }
        }

        private RelayCommand _changeEditorModeCommand;

        public RelayCommand ChangeEditorModeCommand
        {
            get
            {
                return _changeEditorModeCommand ??
                    (_changeEditorModeCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            if (SelectedView == null)
                                return;

                            string typename = obj as string;

                            if (typename == null)
                                throw new Exception("Argument to change editor mode was empty");

                            //convert selected mode from obj
                            SelectedView.CurrentEditorMode = EditorModeConverter.Convert(typename, SelectedView);

                        }
                        catch(Exception ex)
                        {
                            Trace.WriteLine(ex);
                        }
                    }));
            }
        }

        #endregion



        private IFileService<GraphEditorModel> _fileService;

        private ObservableCollection<GraphEditorModelView> _graphEditorViews;

        public ObservableCollection<GraphEditorModelView> GraphEditorViews
        {
            get { return _graphEditorViews; }
            set
            {
                _graphEditorViews = value;
                OnPropertyChanged(nameof(GraphEditorViews));
            }
        }

        private GraphEditorModelView? _selectedView;

        public GraphEditorModelView? SelectedView
        {
            get { return _selectedView;  }
            set
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }




        public MainWindowModelView(ObservableCollection<GraphEditorModelView>  graphViews, IFileService<GraphEditorModel> fileService)
        {
            GraphEditorViews = graphViews;
            _fileService = fileService;
        }
    }
}
