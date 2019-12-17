using System.Collections;

namespace Codebycandle.Util.Scen
{
    public interface ISceneController
    {
        IEnumerator Start();
        void FadeIn();
        void FadeOut();
    }
}