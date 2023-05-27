using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView.GraphEditorExtensions
{
    public static class EditorModeConverter
    {
        public static GraphEditorMode Convert(string modeName, params object[] args)
        {
            string fullName = $"GraphApplication.ModelView.GraphEditorExtensions.{modeName}";

            Type type = Type.GetType(fullName);

            if (type == null)
                throw new Exception("Помилка конвертування режиму редактора!");

            if(!typeof(GraphEditorMode).IsAssignableFrom(type))
                throw new Exception("Обраний клас не наслідується від класу режима редактора");

            return (GraphEditorMode)Activator.CreateInstance(type, args);
        }

    }
}
