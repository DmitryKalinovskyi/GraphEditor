namespace GraphApplication.Views.Editor.Animations
{
    public interface IAnimation
    {
        public int AnimationKeyFrameDelay { get; set; }

        public void StartAnimation();
        public void PauseAnimation();
        public void StopAnimation();
        public void UnpauseAnimation();
        public void RestoreAnimation();
    }
}
