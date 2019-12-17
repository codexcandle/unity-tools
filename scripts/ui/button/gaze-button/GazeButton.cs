using UnityEngine;
using UnityEngine.UI;

namespace Codebycandle.Util.Inpt
{
    public class GazeButton:MonoBehaviour
    {
        public Image BackgroundImage;
        public Color HighlightColor;
        public Color SelectedColor;

        public int viewIndex;

        private Color normalColor;

        private bool selected;

        public void MakeSelected()
        {
            selected = true;

            SetColor(SelectedColor);
        }

        public void Reset()
        {
            selected = false;

            SetColor(normalColor);
        }

        public void OnGazeEnter()
        {
            SetColor(HighlightColor);
        }

        public void OnGazeExit()
        {
            if(!selected) Reset();
        }

        // public void OnClick(){}

        private void Awake()
        {
            normalColor = BackgroundImage.color;
        }

        private void SetColor(Color c)
        {
            BackgroundImage.color = c;
        }
    }
}