using UnityEngine;
using System.Collections;

namespace Codebycandle.Util.UI.Text
{
    public class TimerText:AppText
    {
        #region UTIL-PUBLIC
        public void SetTimerText(int totalSeconds)
        {
            // sanitize
            if(totalSeconds < 0) return;

            int minCount = totalSeconds / 60;
            int secCount = totalSeconds % 60;

            string secText = (secCount >= 10) ? secCount.ToString() : ("0" + secCount); 

            string txt = minCount + ":" + secText; 

            SetText(txt);
        }
        #endregion
    }
}