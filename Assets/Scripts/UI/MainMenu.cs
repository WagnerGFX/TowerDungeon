using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDungeon.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject mainPanel;

        [SerializeField]
        private StringDataSO sceneMenuChooseChar;

        [SerializeField]
        private StringDataSO sceneMenuCredits;

        [SerializeField]
        private StringDataSO sceneMenuRank;

        private float timeToLoad = 0.5f;
        private int whichPlayerIsOn = 1;

        private void Start()
        {
            mainPanel.SetActive(false);
        }

        public void LoadChoosePanel()
        {
            SceneManager.LoadScene(sceneMenuChooseChar.Text);
        }

        public void LoadCredits()
        {
            SceneManager.LoadScene(sceneMenuCredits.Text);
        }

        public void LoadRank()
        {
            SceneManager.LoadScene(sceneMenuRank.Text);
        }

        public void LoadExit()
        {
            Application.Quit();
        }

        public void PlayButton()
        {
            Invoke(nameof(LoadChoosePanel), timeToLoad);
        }

        public void RankButton()
        {
            Invoke(nameof(LoadRank), timeToLoad);
        }

        public void Credits()
        {
            Invoke(nameof(LoadCredits), timeToLoad);
        }

        public void ExitGame()
        {
            Invoke(nameof(LoadExit), timeToLoad);
        }

        public void SwitchCharacter()
        {
            switch (whichPlayerIsOn)
            {
                case 1:
                    GameSettings.CharacterClass = 1;
                    break;

                case 2:
                    GameSettings.CharacterClass = 2;
                    break;
            }
        }
    }
}
