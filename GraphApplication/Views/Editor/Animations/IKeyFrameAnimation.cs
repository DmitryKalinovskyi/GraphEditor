namespace GraphApplication.Views.Editor.Animations
{
    public interface IKeyFrameAnimation
    {
        public int AnimationKeyFrameDelay { get; set; }

        public void StartAnimation();
        public void AutoPlay();
        public void PauseAnimation();
        public void UnpauseAnimation();

        public void MoveToNextFrame();
        public void MoveToPreviousFrame();

        public void UndoAnimation();
    }
}
