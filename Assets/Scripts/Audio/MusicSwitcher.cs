using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon.Audio
{
    public class MusicSwitcher : MonoBehaviour
    {
        [SerializeField]
        private PlayMusicRequestEventChannelSO playMusicRequestEventChannel;

        [SerializeField]
        private AudioSO MusicToPlay;

        [SerializeField]
        private bool destroyGameObjectAfter = false;

        void Start()
        {
            playMusicRequestEventChannel.RaiseEvent(MusicToPlay, this);

            if (destroyGameObjectAfter)
                Destroy(gameObject);
            else
                Destroy(this);
        }
    }
}