﻿using GraphApplication.Fabrication;
using GraphApplication.Models;
using GraphApplication.ModelViews.GraphEditorExtensions;
using GraphApplication.Services;
using GraphApplication.Services.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace GraphApplication.ModelViews
{
    public class MainWindowModelView : NotifyModelView
    {
        #region Commands
        private RelayCommand? _createGraphCommand;
        public RelayCommand CreateGraphCommand
        {
            get
            {
                return _createGraphCommand ??= new RelayCommand(obj =>
                     {
                             GraphEditorModelView modelView;

                             if (obj is GraphModel)
                             {
                                 GraphEditorModel graphModel = new GraphEditorModel(obj as GraphModel);

                                 modelView = new GraphEditorModelView(graphModel, "");
                             }
                             else
                             {
                                 GraphEditorModel graphModel = new GraphEditorModel();

                                 modelView = new GraphEditorModelView(graphModel, "");
                             }


                             SelectedView = modelView;
                             GraphEditorViews.Add(modelView);

                         //    MessageBox.Show("Відбулася помилка виконання команди: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                     });
            }
        }

        private RelayCommand? _generateGraphCommand;
        public RelayCommand GenerateGraphCommand
        {
            get
            {
                return _generateGraphCommand ??= new RelayCommand(obj =>
                    {
                            GraphModelArgs args = new GraphModelArgs();
                            args.MaxTop = 2000;
                            args.MaxLeft = 2000;
                            args.Deegre = 3;
                            args.VerticlesCount = 100;

                            GraphModelGenerator generator = new GraphModelGenerator();

                            object generated = generator.Generate(args);

                            CreateGraphCommand.Execute(generated);
                    });
            }
        }

        private RelayCommand? _saveGraphCommand;
        public RelayCommand SaveGraphCommand
        {
            get
            {
                return _saveGraphCommand ??= new RelayCommand(obj =>
                    {
                        var view = obj != null ? obj as GraphEditorModelView : SelectedView;
                        if (view == null)
                            return;

                        if (_openedGraphEditorModelViews.ContainsKey(view))
                        {
                            view.IsSaved = true;
                            _fileService.Save(_openedGraphEditorModelViews[view], view.Model);
                        }
                        else // create as new file
                        {
                            var saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "XML files (*.xml)|*.xml";

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string path = saveFileDialog.FileName;

                                view.IsSaved = true;
                                _fileService.Save(path, view.Model);
                                _openedGraphEditorModelViews[view] = path;
                                view.Name = System.IO.Path.GetFileName(path);
                            }
                        }
                    });
            }
        }

        private RelayCommand? _removeGraphCommand;
        public RelayCommand RemoveGraphCommand
        {
            get
            {
                return _removeGraphCommand ??= new RelayCommand(obj =>
                     {
                             if (obj is GraphEditorModelView modelView)
                             {
                                 if (modelView.IsSaved == false)
                                 {
                                     //promt to save or not
                                     MessageBoxResult result = MessageBox.Show($"Граф({modelView.GraphNameFormat}) не збережено, ви бажаєте його зберегти?",
                                         "Попередження", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                                     if (result == MessageBoxResult.Yes)
                                     {
                                         SaveGraphCommand.Execute(modelView);
                                     }
                                     else if (result == MessageBoxResult.Cancel)
                                     {
                                         return;
                                     }
                                 }

                                 GraphEditorViews.Remove(modelView);
                                 _openedGraphEditorModelViews.Remove(modelView);
                                 if (GraphEditorViews.Count == 0)
                                 {
                                     SelectedView = null;
                                 }
                                 else
                                     SelectedView = GraphEditorViews[0];

                             }
                     });
            }
        }

        private RelayCommand? _loadGraphCommand;
        public RelayCommand LoadGraphCommand
        {
            get
            {
                return _loadGraphCommand ??= new RelayCommand(obj =>
                     {
                             //propmt load location
                             var openFileDialog = new OpenFileDialog();
                             openFileDialog.Filter = "XML files (*.xml)|*.xml";

                             if (openFileDialog.ShowDialog() == true)
                             {
                                 string path = openFileDialog.FileName;
                                 if (_openedGraphEditorModelViews.ContainsValue(path))
                                 {
                                     MessageBox.Show("Такий граф вже відкритий!", "Попередження", MessageBoxButton.OK, MessageBoxImage.Information);
                                     return;
                                 }

                                 string name = System.IO.Path.GetFileName(path);

                                 GraphEditorModel modelView = _fileService.Open(path);

                                 if (modelView == null)
                                     throw new Exception();

                                 GraphEditorModelView graphEditorModelView = new GraphEditorModelView(modelView, name, true);
                                 _openedGraphEditorModelViews[graphEditorModelView] = path;

                                 GraphEditorViews.Add(graphEditorModelView);
                                 SelectedView = graphEditorModelView;
                             }
                     });
            }
        }

        private RelayCommand? _changeEditorModeCommand;
        public RelayCommand ChangeEditorModeCommand
        {
            get
            {
                return _changeEditorModeCommand ??= new RelayCommand(obj =>
                    {
                        if (SelectedView == null)
                            return;


                        string typename = obj as string ?? throw new Exception("Argument to change editor mode was empty");

                        //convert selected mode from obj
                        var mode = EditorModeConverter.Convert(typename, SelectedView);
                        if (mode == null)
                            throw new Exception("Failed to get new mode instance");

                        if (SelectedView.AnimationManager.IsAnimationActive == true
                        && mode is IBuildingMode)
                        {
                            MessageBox.Show("Поки анімація не завершена редагувати граф неможливо!", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        ActiveMode = mode;
                    });
            }
        }

        #endregion

        // Use dictionary to limit opening the same graph few times
        private Dictionary<GraphEditorModelView, string> _openedGraphEditorModelViews;

        private IFileService<GraphEditorModel> _fileService;

        private ObservableCollection<GraphEditorModelView> _graphEditorViews;

        public ObservableCollection<GraphEditorModelView> GraphEditorViews
        {
            get { return _graphEditorViews; }
            set
            {
                _graphEditorViews = value;
                OnPropertyChanged(nameof(GraphEditorViews));
                OnPropertyChanged(nameof(ToolBarEnabled));
            }
        }

        private GraphEditorModelView? _selectedView;

        public GraphEditorModelView? SelectedView
        {
            get { return _selectedView; }
            set
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
                OnPropertyChanged(nameof(ActiveMode));
            }
        }

        public GraphEditorMode? ActiveMode
        {
            get
            {
                if (SelectedView == null)
                    return null;

                return SelectedView.CurrentEditorMode;
            }
            set
            {
                if (SelectedView == null || value == null)
                    return;

                SelectedView.CurrentEditorMode = value;
                OnPropertyChanged(nameof(ActiveMode));
            }
        }

        public bool ToolBarEnabled { get { return GraphEditorViews.Count() > 0; } }

        public MainWindowModelView(ObservableCollection<GraphEditorModelView> graphViews, IFileService<GraphEditorModel> fileService)
        {
            _fileService = fileService;
            _openedGraphEditorModelViews = new Dictionary<GraphEditorModelView, string>();
            _graphEditorViews = graphViews;

            GraphEditorViews.CollectionChanged += (sender, e) => OnPropertyChanged(nameof(ToolBarEnabled));
        }

        // Default constructor with basic services
        public MainWindowModelView() : this(new ObservableCollection<GraphEditorModelView>(), new XMLFileService<GraphEditorModel>()) { }

        public void CloseAndSave()
        {
            //ask about saving
            IEnumerable<GraphEditorModelView> graphViewsToClose = GraphEditorViews.ToList();

            foreach (GraphEditorModelView view in graphViewsToClose)
            {
                RemoveGraphCommand.Execute(view);
            }
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseAndSave();
        }
    }
}
