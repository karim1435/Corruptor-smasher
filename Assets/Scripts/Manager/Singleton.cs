using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class Singleton<T>:MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = GameObject.FindObjectOfType<T>();

                    if (_instance==null)
                    {
                        GameObject singleton = new GameObject(typeof(T).Name);
                        _instance = singleton.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
        protected virtual void Awake()
        {
            if (_instance==null)
                _instance = this as T;
            else
                Destroy(gameObject);
        }
    }
}
