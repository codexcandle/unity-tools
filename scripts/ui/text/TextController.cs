using UnityEngine;
using UnityEngine.UI;

namespace Codebycandle.Util
{
    /* 
     * PURPOSE:
     *  wrapper for scene-based text object
     */
    public class TextController:MonoBehaviour
    {
        [SerializeField] private Text tf;
        [SerializeField] private int maxLines = 6;

        private int lineCount;

        public void AddText(string txt)
        {
            tf.text += txt + "\n";

            lineCount++;

            if(lineCount > maxLines)
            {
                Reset();
            }
        }

        public void Reset()
        {
            lineCount = 0;

            tf.text = string.Empty;
        }
    }
}