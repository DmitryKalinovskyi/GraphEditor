using GraphApplication.Binders;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System;
using System.Windows;

namespace GraphApplication.Commands.CommandList
{
    public class ChangeEditorStateCommand : Command
    {
        private GraphProjectModelView _project;

        public ChangeEditorStateCommand(GraphProjectModelView project)
        {
            _project = project;
        }

        public override void Execute(object? parameter)
        {
            string typename = parameter as string ?? throw new Exception("Argument to change editor mode was empty");

            //convert selected mode from obj
            var mode = EditorStateBinder.Convert(typename, _project);

            if (_project.AnimationManager.IsAnimationActive == true
            && mode is IBuildingMode)
            {
                MessageBox.Show("Поки анімація не завершена редагувати граф неможливо!", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _project.EditorState = mode;
        }
    }
}
