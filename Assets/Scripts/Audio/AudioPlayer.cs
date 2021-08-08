using System.Collections;
using UnityEngine;

namespace TowerDungeon.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
        private AudioSO audioData;
        public  AudioSO AudioData { get => audioData; }

        void Awake()
        {
            audioSource = this.GetComponent<AudioSource>();
        }

        public void Play(AudioSO audioData)
        {
            this.audioData = audioData;
            audioSource.clip = audioData.AudioClip;
            audioSource.Play();
        }


        public void Pause()
        {
            audioSource.Pause();
        }

        public void Resume()
        {
            if (audioSource.clip != null)
                audioSource.Play();
        }

        public void StopAndDestroy()
        {
            audioSource.Stop();
            Destroy(this.gameObject);
        }

        public void FadeOutAndDestroy(float fadeOutTime = 1000)
        {
            StartCoroutine(FadeOut(fadeOutTime));

            StopAndDestroy();
        }

        private IEnumerator FadeOut(float fadeOutTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeOutTime;

                yield return null;
            }
        }
    }
}
