using UnityEngine;
using UnityEngine.UI;

namespace Codebycandle.Util.UI
{
    public class AppSlider:MonoBehaviour
    {
        private Slider slider;

        #region MONO-B
        void Start()
        {
            Init();
        }
        #endregion

        #region UTIL-PRIVATE
        private void Init()
        {
            FindVars();
        }

        private void FindVars()
        {
            slider = GetComponent<Slider>();
        }
        #endregion

        #region UTIL-PUBLIC
        public void Init(int min, int max, int value)
        {
            // sanitize
            if(min >= max) return;

            slider.minValue = min;
            slider.maxValue = max;
            slider.value = value;
        }

        public void SetValue(int value)
        {
            // sanitize
            if((value < slider.minValue) || 
                (value > slider.maxValue)) return;

            slider.value = value;
        }
        #endregion        
    }
}