using UnityEngine;

namespace Codebycandle.Util.Snd
{
    public interface IAudioController
    {
        void PlayMusic(string id);
        void PlaySound(string id, GameObject generator);
    }
}
