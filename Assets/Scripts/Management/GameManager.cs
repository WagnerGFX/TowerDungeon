using UnityEngine;
using UnityEngine.SceneManagement;
using TowerDungeon.Events;

namespace TowerDungeon.Management
{
    public class GameManager : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField]
        private LoadSceneRequestEventChannelSO loadSceneEventChannel;

        [SerializeField]
        private GameStateChangedEventChannelSO gameStateChangedEventChannel;

        [SerializeField]
        private GameStateRequestEventChannelSO gameStateRequestEventChannel;

        [SerializeField]
        private VoidEventChannelSO exitGameRequestEventChannel;

        [Header("Remove later")]
        [SerializeField]
        private GameObject warrior, archer;

        private int characterClass;

        public GameState GameState { get; private set; } = GameState.InitialState;

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
                SubscribeEvents();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void SubscribeEvents()
        {
            loadSceneEventChannel.Subscribe(OnLoadSceneRequested);
            gameStateRequestEventChannel.Subscribe(OnGameStateChangeRequested);
            gameStateChangedEventChannel.Subscribe(OnGameStateChanged);
            exitGameRequestEventChannel.Subscribe(OnGameExitRequested);
        }

        private void OnLoadSceneRequested(SceneDataSO args)
        {
            SceneManager.LoadScene(args.SceneName);
        }

        private void OnGameExitRequested()
        {
            Application.Quit();
        }

        private void OnGameStateChangeRequested(GameState newGameState)
        {
            var args = new GameStateChangedEventArgs(GameState, newGameState);

            GameState = newGameState;

            gameStateChangedEventChannel.RaiseEvent(args);
        }

        private void OnGameStateChanged(GameStateChangedEventArgs args)
        {
            if (args.NewGameState == GameState.GameOver)
            {
                GameSettings.CoinPoints = 0; //Mover para outro script
                //SceneManager.LoadScene(sceneGameOver.SceneName);
                //SoundManager.Instance.StopMusicTheme();
            }
            else if (args.NewGameState == GameState.Playing)
            {
                InitializePlayer(); //Mover para outro script
            }
        }

        private void SetGameStateToGameOver()
        {
            gameStateRequestEventChannel.RaiseEvent(GameState.GameOver);
        }

        private void GameOn()
        {
            gameStateRequestEventChannel.RaiseEvent(GameState.Playing);
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
    } 
}