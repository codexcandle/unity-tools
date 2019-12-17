using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebycandle.Util.UI
{
    public class AppButton:MonoBehaviour
    {
        [Inject] protected SignalBus signalBus;

        protected Button btn;

        protected bool initialized;

        private void Start()
        {
            Init();
        }

        #region UTIL
        protected virtual void Init()
        {
            FindVars();
        
            Subscribe(true);

            initialized = true;
        }

        protected virtual void FindVars()
        {
            btn = GetComponent<Button>();
        }

        private void Subscribe(bool enable)
        {
            if (enable)
            {
                btn.onClick.AddListener(OnClick);
            }
            else
            {
                btn.onClick.RemoveListener(OnClick);
            }
        }
        #endregion

        #region HANDLERS
        protected virtual void OnClick()
        {
            DispatchReferenceRequest();
        }

        private void OnDestroy()
        {
            if (initialized)
            {
                Subscribe(false);
            }
        }
        #endregion

        #region DISPATCHERS
        protected virtual void DispatchReferenceRequest()
        {
            // ... override
        }
        #endregion
    }
}