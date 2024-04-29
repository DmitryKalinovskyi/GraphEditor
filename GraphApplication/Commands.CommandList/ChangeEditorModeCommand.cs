using GraphApplication.ModelViews;
using GraphApplication.ModelViews.GraphEditorExtensions;
using System;
using System.Windows;

namespace GraphApplication.Commands.CommandList
{
    public class ChangeEditorModeCommand : Command
    {
        private GraphProjectModelView _project;

        public ChangeEditorModeCommand(GraphProjectModelView project) 
        {
            _project = project; 
        }

        public override void Execute(object? parameter)
        {
            string typename = parameter as string ?? throw new Exception("Argument to change editor mode was empty");

            //convert selected mode from obj
            var mode = EditorModeConverter.Convert(typename, _project) ?? 
                throw new Exception("Failed to get new mode instance");

            if (_project.AnimationManager.IsAnimationActive == true
            && mode is IBuildingMode)
            {
                MessageBox.Show("Поки анімація не завершена редагувати граф неможливо!", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _project.EditorMode = mode;
        }
    }
}
