using GraphApplication.Views.Editor.State.Base;
using System;

namespace GraphApplication.Binders
{
    public static class EditorStateBinder
    {
        public static EditorState Convert(string stateName, params object[] args)
        {
            // TODO: bind string to namespace
            string fullName = $"GraphApplication.Views.Editor.State.{stateName}";

            Type type = Type.GetType(fullName) ??
                throw new Exception("Failed to convert modeName to the modeType! Possible incorrect name of mode.");

            object instance = Activator.CreateInstance(type, args) ??
                throw new Exception($"Failed to create instance of type {type.Name}.");

            return (EditorState)instance ?? throw new ArgumentException($"{nameof(instance)} is not {nameof(EditorState)}.");
        }
    }
}
