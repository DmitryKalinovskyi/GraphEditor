using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView.GraphEditorExtensions.Displaying
{
    public interface IDisplayAnimation
    {
        public void StartAnimation();
        public void StopAnimation();
        public void RestoreAnimation();
    }
}
