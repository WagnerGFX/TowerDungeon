using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon.Audio
{
    public class MusicSwitcher : MonoBehaviour
    {
        [SerializeField]
        private EventManagerSO globalEventManager;

        [SerializeField]
        private AudioSO MusicToPlay;

        [SerializeField]
        private bool destroyGameObjectAfter = false;

        void Start()
        {
            globalEventManager.OnPlayMusicRequested.RaiseEvent(MusicToPlay, this);

            if (destroyGameObjectAfter)
                Destroy(gameObject);
            else
                Destroy(this);
        }
    }
}