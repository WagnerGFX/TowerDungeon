using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon.Management
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [Header("Event Channels")]
        [SerializeField]
        private PlayMusicRequestEventChannelSO playMusicRequestEventChannel;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject BGMAudioSource;

        private AudioPlayer currentMusicPlayer;

        void Awake()
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
            playMusicRequestEventChannel.Subscribe(OnMusicPlayRequested);
        }

        void OnMusicPlayRequested(AudioSO music)
        {
            var instance = Instantiate(BGMAudioSource, this.transform);

            currentMusicPlayer?.FadeOutAndDestroy();
            currentMusicPlayer = instance.GetComponent<AudioPlayer>();
            currentMusicPlayer.Play(music);
        }

        void OnMusicStopRequested()
        {
            currentMusicPlayer.StopAndDestroy();
        }
    }
}