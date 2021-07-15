using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDungeon
{
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
        private AudioSO audioData;

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

        public void FadeOutAndDestroy(float fadeTime = 1000)
        {
            StartCoroutine(FadeOut(fadeTime));

            StopAndDestroy();
        }

        private IEnumerator FadeOut(float fadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

                yield return null;
            }
        }
    }
}
