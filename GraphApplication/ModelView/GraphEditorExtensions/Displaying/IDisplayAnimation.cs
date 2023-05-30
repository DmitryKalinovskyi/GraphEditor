using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView.GraphEditorExtensions.Displaying
{
    public interface IDisplayAnimation
    {
        public void UpdateKeyFrameDelay(int delay);
        public void StartAnimation();
        public void PauseAnimation();
        public void StopAnimation();
        public void UnpauseAnimation();
        public void RestoreAnimation();
    }
}
