using System;

namespace GraphApplication.ModelView.GraphEditorExtensions
{
    public static class EditorModeConverter
    {
        public static GraphEditorMode Convert(string modeName, params object[] args)
        {
            string fullName = $"GraphApplication.ModelView.GraphEditorExtensions.Modes.{modeName}";

            Type type = Type.GetType(fullName) ?? 
                throw new Exception("Failed to convert modeName to the modeType! Possible incorrect name of mode."); 

            object instance = Activator.CreateInstance(type, args) ?? 
                throw new Exception($"Failed to create instance of type {type.Name}.");

            return (GraphEditorMode)instance ?? throw new ArgumentException($"Class with name {modeName} is not GraphEditorMode.");
        }
    }
}
