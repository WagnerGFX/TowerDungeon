using UnityEngine;

namespace TowerDungeon.Management
{
    public class MusicSwitcher : MonoBehaviour
    {
        [SerializeField]
        private AudioSO MusicToPlay;

        void Start()
        {
            SoundManager.Instance.PlayMusic(MusicToPlay);
        }
    }
}