using UnityEngine;
using TowerDungeon.Audio;
using TowerDungeon.Events;

namespace TowerDungeon.Management
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField]
        private EventManagerSO globalEventManager;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject BGMAudioSource;

        private AudioPlayer currentMusicPlayer;

        private void OnEnable()
        {

            globalEventManager.OnPlayMusicRequested.Subscribe(OnMusicPlayRequested);
        }

        private void OnDisable()
        {
            globalEventManager.OnPlayMusicRequested.Unsubscribe(OnMusicPlayRequested);
        }

        private void OnMusicPlayRequested(AudioSO music, object sender)
        {
            if (currentMusicPlayer != null)
                if (currentMusicPlayer.AudioData.Equals(music))
                    return;

            var instance = Instantiate(BGMAudioSource, this.transform);

            currentMusicPlayer?.StopAndDestroy();
            currentMusicPlayer = instance.GetComponent<AudioPlayer>();
            currentMusicPlayer.Play(music);
        }

        private void OnMusicStopRequested()
        {
            currentMusicPlayer.StopAndDestroy();
        }
    }
}