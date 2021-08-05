using UnityEngine;

namespace TowerDungeon.Events
{
    [System.Serializable]
    public struct LoadSceneEventArgs
    {
        [SerializeField]
        private SceneDataSO sceneToLoad;
        public SceneDataSO SceneToLoad { get => sceneToLoad; }

        [SerializeField]
        private bool showLoadingScreen;
        public bool ShowLoadingScreen { get => showLoadingScreen; }

        [SerializeField]
        private bool fadeScreen;
        public bool FadeScreen { get => fadeScreen; }
    }
}
