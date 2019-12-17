using UnityEngine;
using Zenject;
using TMPro;

namespace Codebycandle.Util.UI.Text
{
    public class AppText:MonoBehaviour
    {
        [Inject] protected SignalBus signalBus;

        private TextMeshProUGUI field;

        private bool initialized;

        private void Start()
        {
            Init();
        }

        #region UTIL (private)
        private void FindVars()
        {
            field = GetComponent<TextMeshProUGUI>();
        }
        #endregion

        #region UTIL (protected)
        protected virtual void Init()
        {
            FindVars();

            initialized = true;
        }
        #endregion

        #region UTIL (public)
        public void SetText(string text, bool doInitCheck = true)
        {
            if(doInitCheck)
            {
                if (!initialized) Init();
            }

            field.SetText(text);
        }
        #endregion
    }
}


