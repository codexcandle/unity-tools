using UnityEngine;

namespace Codebycandle.Util.Snd
{
    public class NoiseObject:MonoBehaviour
    {
        private static Color COLOR_DEFAULT = Color.black;
        private static Color COLOR_ACTIVE = Color.green;

        public void Activate(bool active, string soundEventName = "")
        {
            if(active)
            {
                TriggerSoundEvent(soundEventName);

                SetColor(COLOR_ACTIVE);
            }
            else
            {
                Reset();
            }
        }

        void Awake()
        {
            Reset();
        }

        private void SetColor(Color color)
        {
            gameObject.GetComponent<Renderer>().material.color = color;
        }

        private void TriggerSoundEvent(string eventName)
        {
            // AkSoundEngine.PostEvent(eventName, gameObject);

            // TODO - make "audio mangager" ref dynamic! (decouple from "wwise")
            ////// WwiseAudioManager.Instance.PlaySound(eventName, gameObject);
        }

        private void Reset()
        {
            SetColor(COLOR_DEFAULT);
        }
    }
}