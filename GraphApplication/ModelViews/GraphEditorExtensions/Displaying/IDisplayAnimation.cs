namespace GraphApplication.ModelViews.GraphEditorExtensions.Displaying
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
