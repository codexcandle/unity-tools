namespace Codebycandle.Util.Inpt
{
    public class GazeButtonController
    {
        private void OnEnable()
        {
            GazeButtonSet.OnClicked += HandleButtonClick;
        }

        private void OnDisable()
        {
            GazeButtonSet.OnClicked -= HandleButtonClick;
        }

        public virtual void HandleButtonClick(int index){}
    }
}
