#region INFO
/*
SOURCE:
https://www.youtube.com/watch?v=EZ3Uyu8Ps60

USAGE:
public class SomeManager:Singleton<SomeManager>
{
    protected override void Awake()
    {
        base.Awake();
    }
}
*/
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebycandle.Util.Arch
{
    public abstract class Singleton<T>:MonoBehaviour where T:Singleton<T>
    {
        public static T Instance;

        protected virtual void Awake()
        {
            if(Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this as T;

            DontDestroyOnLoad(this);
        }
    }
}