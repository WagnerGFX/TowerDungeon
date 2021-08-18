using UnityEngine;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Global Event Manager", order = 0)]
    public class EventManagerSO : ScriptableObject
    {
        [Header("Event Channels")]

        [SerializeField]
        private GameStateRequestEventChannelSO onGameStateRequested;
        public GameStateRequestEventChannelSO OnGameStateRequested { get => onGameStateRequested; }

        [SerializeField]
        private GameStateChangedEventChannelSO onGameStateChanged;
        public GameStateChangedEventChannelSO OnGameStateChanged { get => onGameStateChanged; }

        [SerializeField]
        private LoadSceneRequestEventChannelSO onLoadSceneRequested;
        public LoadSceneRequestEventChannelSO OnLoadSceneRequested { get => onLoadSceneRequested; }

        [SerializeField]
        private BasicEventChannelSO onExitGameRequested;
        public BasicEventChannelSO OnExitGameRequested { get => onExitGameRequested; }

        [SerializeField]
        private PlayMusicRequestEventChannelSO onPlayMusicRequested;
        public PlayMusicRequestEventChannelSO OnPlayMusicRequested { get => onPlayMusicRequested; }

        [SerializeField]
        private InputActionTypeEventChannelSO onInputChangeRequested;
        public InputActionTypeEventChannelSO OnInputChangeRequested { get => onInputChangeRequested; }
    }
}
