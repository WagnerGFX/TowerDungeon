using UnityEngine;
using UnityEngine.SceneManagement;
using TowerDungeon.Events;

namespace TowerDungeon.Management
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField]
        private EventManagerSO globalEventManager;

        public GameState GameState { get; private set; } = GameState.None;

        private void OnEnable()
        {
            globalEventManager.OnLoadSceneRequested.Subscribe(OnLoadSceneRequested);
            globalEventManager.OnGameStateRequested.Subscribe(OnGameStateChangeRequested);
            globalEventManager.OnGameStateChanged.Subscribe(OnGameStateChanged);
            globalEventManager.OnExitGameRequested.Subscribe(OnGameExitRequested);
        }

        private void OnDisable()
        {
            globalEventManager.OnLoadSceneRequested.Unsubscribe(OnLoadSceneRequested);
            globalEventManager.OnGameStateRequested.Unsubscribe(OnGameStateChangeRequested);
            globalEventManager.OnGameStateChanged.Unsubscribe(OnGameStateChanged);
            globalEventManager.OnExitGameRequested.Unsubscribe(OnGameExitRequested);
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

            globalEventManager.OnGameStateChanged.RaiseEvent(args, this);
        }

        private void OnGameStateChanged(GameStateChangedEventArgs args, object sender)
        {
            if (args.NewGameState == GameState.GameOver)
            {
                GameSettings.CoinPoints = 0; //Mover para outro script
                //SceneManager.LoadScene(sceneGameOver.SceneName);
                //SoundManager.Instance.StopMusicTheme();
            }
        }

    } 
}