using GraphApplication.ModelViews;
using GraphApplication.ModelViews.GraphEditorExtensions;
using System;
using System.Windows;

namespace GraphApplication.Commands.CommandList
{
    public class ChangeEditorModeCommand : Command
    {
        private MainWindowModelView _mainWindowsViewModel;

        public ChangeEditorModeCommand(MainWindowModelView mainWindowModelView) 
        {
            _mainWindowsViewModel = mainWindowModelView;
        }

        public override void Execute(object? parameter)
        {
            if (_mainWindowsViewModel.OpenedGraphModelViewsManager.SelectedView == null)
                return;

            string typename = parameter as string ?? throw new Exception("Argument to change editor mode was empty");

            //convert selected mode from obj
            var mode = EditorModeConverter.Convert(typename, _mainWindowsViewModel.OpenedGraphModelViewsManager.SelectedView) ?? 
                throw new Exception("Failed to get new mode instance");

            if (_mainWindowsViewModel.OpenedGraphModelViewsManager.SelectedView.AnimationManager.IsAnimationActive == true
            && mode is IBuildingMode)
            {
                MessageBox.Show("Поки анімація не завершена редагувати граф неможливо!", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _mainWindowsViewModel.ActiveMode = mode;
        }
    }
}
