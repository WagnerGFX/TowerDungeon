using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon.Menus
{
    public class MainMenu : MonoBehaviour
    {
        //[SerializeField]
        //private GameObject mainPanel;

        [Header("Scene Data")]
        [SerializeField]
        private SceneDataSO sceneMenuChooseChar;
        [SerializeField]
        private SceneDataSO sceneMenuCredits;
        [SerializeField]
        private SceneDataSO sceneMenuRank;

        [Header("Event Channels")]
        [SerializeField]
        private LoadSceneRequestEventChannelSO loadSceneRequestEventChannel;
        [SerializeField]
        private BasicEventChannelSO exitGameRequestEventChannel;

        [SerializeField]
        private float buttonFunctionDelay = 0.5f;

        private void Start()
        {
            //mainPanel.SetActive(false);
        }

        private void LoadChoosePanel()
            => loadSceneRequestEventChannel.RaiseEvent(sceneMenuChooseChar, this);

        private void LoadCredits()
            => loadSceneRequestEventChannel.RaiseEvent(sceneMenuCredits, this);

        private void LoadRank()
            => loadSceneRequestEventChannel.RaiseEvent(sceneMenuRank, this);

        private void ExitGame()
            => exitGameRequestEventChannel.RaiseEvent(this);

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
