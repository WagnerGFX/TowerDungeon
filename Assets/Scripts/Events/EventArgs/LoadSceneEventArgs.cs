using UnityEngine;

namespace TowerDungeon.Events
{
    [System.Serializable]
    public struct LoadSceneEventArgs
    {
        [SerializeField]
        private SceneDataSO sceneToLoad;
        public SceneDataSO SceneToLoad { get => sceneToLoad; }

    }
}
