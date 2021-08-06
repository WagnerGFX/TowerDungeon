using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon.Management
{
    public class MusicSwitcher : MonoBehaviour
    {
        [SerializeField]
        private PlayMusicRequestEventChannelSO playMusicRequestEventChannel;

        [SerializeField]
        private AudioSO MusicToPlay;

        void Start()
        {
            playMusicRequestEventChannel.RaiseEvent(MusicToPlay);
            Destroy(this);
        }
    }
}