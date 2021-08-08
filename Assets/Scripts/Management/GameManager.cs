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
        private BasicEventChannelSO exitGameRequestEventChannel;

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

        private void OnLoadSceneRequested(SceneDataSO args, object sender)
        {
            SceneManager.LoadScene(args.SceneName);
        }

        private void OnGameExitRequested(object sender)
        {
            Application.Quit();
#if UNITY_EDITOR
            Debug.Log("Application.Quit()");
#endif
        }

        private void OnGameStateChangeRequested(GameState newGameState, object sender)
        {
            var args = new GameStateChangedEventArgs(GameState, newGameState);

            GameState = newGameState;

            gameStateChangedEventChannel.RaiseEvent(args, this);
        }

        private void OnGameStateChanged(GameStateChangedEventArgs args, object sender)
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