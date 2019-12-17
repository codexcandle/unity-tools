﻿// SOURCE:  website about singletons in unity (?)
// PURPOSE: "generic" template for singleton class
// EXAMPLE: public class MyAudioController:GenericSingletonClass<MyAudioController>{}
using UnityEngine;

namespace Codebycandle.Util.Arch
{
    public class GenericSingletonClass<T>:MonoBehaviour where T:Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if(instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        public virtual void Awake()
        {
            if(instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}