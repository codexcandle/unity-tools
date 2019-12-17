using System.Collections;
using System.Collections.Generic;

namespace Codebycandle.Util.Debug
{
    public static class AppLog
    {
        public static void Log(string text)
        {
            UnityEngine.Debug.Log("APP LOG: " + text);
        }

        public static void LogWarning(string text)
        {
            UnityEngine.Debug.LogWarning("APP WARNING: " + text);            
        }
    }
}