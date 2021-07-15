using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDungeon.Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject warrior, archer;

        [SerializeField]
        private StringDataSO sceneMainMenu, sceneGame, sceneGameOver;

        private int characterClass;

        public GameState GameState { get; private set; } = GameState.InitialState;
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void InitializePlayer()
        {
            characterClass = GameSettings.CharacterClass;
            warrior.SetActive(false);
            archer.SetActive(false);

            if (characterClass == 1)
            {
                warrior.SetActive(true);
            }
            else if (characterClass == 2)
            {
                archer.SetActive(true);
            }
        }

        public void SetGameStateToInitialState()
        {
            GameState = GameState.InitialState;
        }

        public void SetGameStateToPlaying()
        {
            GameState = GameState.Playing;
        }

        public void SetGameStateToGameOver()
        {
            GameState = GameState.GameOver;
            if (GameState == GameState.GameOver)
            {
                Invoke(nameof(LoadGameOver), .1f);
            }
        }

        public void GameOverOptions()
        {
            SceneManager.LoadScene(sceneMainMenu.Text);
        }

        public void BackToGame()
        {
            SceneManager.LoadScene(sceneGame.Text);
        }

        public void GameOn()
        {
            SetGameStateToPlaying();
            InitializePlayer();
        }

        public void LoadGameOver()
        {
            GameSettings.CoinPoints = 0;
            SceneManager.LoadScene(sceneGameOver.Text);
            //SoundManager.Instance.StopMusicTheme();
        }
    } 
}