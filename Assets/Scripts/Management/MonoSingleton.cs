using UnityEngine;

namespace TowerDungeon.Management
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;

                //Only if the object is in the scene's root
                if (transform.parent == null)
                    DontDestroyOnLoad(gameObject);

                OnAwake();
            }
            else
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Replacement for the Awake() method. Only called when the instance is valid.
        /// </summary>
        protected virtual void OnAwake() { }

    }
}