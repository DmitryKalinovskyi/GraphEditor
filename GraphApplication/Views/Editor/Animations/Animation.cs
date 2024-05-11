using System.Threading;

namespace GraphApplication.Views.Editor.Animations
{
    public abstract class Animation : IAnimation
    {
        public int AnimationKeyFrameDelay { get; set; }

        protected Thread _animationThread;

        protected bool _isStarted;

        protected bool _isCanceled;

        protected bool _isPaused;

        public Animation()
        {
            _isStarted = false;
            _isPaused = false;
            _isCanceled = false;
        }

        public void StartAnimation()
        {
            if (_isStarted) return;

            _isStarted = true;
            _animationThread.Start();
        }

        public void StopAnimation()
        {
            _isCanceled = true;
            RestoreAnimation();
        }

        public abstract void RestoreAnimation();

        public void PauseAnimation()
        {
            _isPaused = true;
            _animationThread.Suspend();
        }

        public void UnpauseAnimation()
        {
            _isPaused = false;
            _animationThread.Resume();
        }

        public void UpdateKeyFrameDelay(int delay)
        {
            AnimationKeyFrameDelay = delay;
        }
    }
}
