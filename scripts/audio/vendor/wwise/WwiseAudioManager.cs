using Codebycandle.Util.Arch;
using UnityEngine;

namespace Codebycandle.Util.Snd
{
    public class WwiseAudioManager:GenericSingletonClass<WwiseAudioManager>, IAudioController
    {
        private bool musicStarted;

        public void PlayMusic(string id)
        {
            // TODO - make "group id" dynamic
            //// AkSoundEngine.SetState("MainStateGroup", id);

            if(!musicStarted)
            {
                // TODO - confirm if below is needed?
                // - but then MUST ALSO send "event" to trigger?
                // PlaySound(gameObject, "StartGame");

                musicStarted = true;
            }
        }

        public void PlaySound(string id, GameObject generator)
        {
            ///// AkSoundEngine.PostEvent(id, generator);
        }

        override public void Awake()
        {
            base.Awake();
        }
    }
}