using UnityEngine;

namespace TowerDungeon.Management
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject BGMAudioSource;

        private AudioPlayer currentMusicPlayer;

        public AudioSource soundFX, chestFx;
        public AudioClip coinsFx;

        public static SoundManager Instance { get; private set; }

        void Awake()
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

        public void PlayMusic(AudioSO music)
        {

            var instance = Instantiate(BGMAudioSource);
            currentMusicPlayer = instance.GetComponent<AudioPlayer>();
            currentMusicPlayer.Play(music);

        }

        public void StopMusic()
        {
            currentMusicPlayer.StopAndDestroy();
        }
    }
}