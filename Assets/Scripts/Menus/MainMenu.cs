using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon.Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private EventManagerSO globalEventManager;

        [SerializeField]
        private float buttonFunctionDelay = 0.5f;

        [Header("Scene Data")]
        [SerializeField]
        private SceneDataSO sceneMenuChooseChar;
        [SerializeField]
        private SceneDataSO sceneMenuCredits;
        [SerializeField]
        private SceneDataSO sceneMenuRank;

        private void LoadChoosePanel()
            => globalEventManager.OnLoadSceneRequested.RaiseEvent(sceneMenuChooseChar, this);

        private void LoadCredits()
            => globalEventManager.OnLoadSceneRequested.RaiseEvent(sceneMenuCredits, this);

        private void LoadRank()
            => globalEventManager.OnLoadSceneRequested.RaiseEvent(sceneMenuRank, this);

        private void ExitGame()
            => globalEventManager.OnExitGameRequested.RaiseEvent(this);

        public void OnButtonPressed_Play()
            => Invoke(nameof(LoadChoosePanel), buttonFunctionDelay);

        public void OnButtonPressed_Ranking()
            => Invoke(nameof(LoadRank), buttonFunctionDelay);

        public void OnButtonPressed_Credits()
            => Invoke(nameof(LoadCredits), buttonFunctionDelay);

        public void OnButtonPressed_Exit()
            => Invoke(nameof(ExitGame), buttonFunctionDelay);
    }
}
