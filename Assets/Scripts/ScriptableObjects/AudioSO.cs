using UnityEngine;

namespace TowerDungeon
{
    [CreateAssetMenu(fileName = "Audio", menuName = "Tower Dungeon/Audio Info", order = 0)]
    public class AudioSO : ScriptableObject
    {
        [SerializeField]
        private AudioClip audioClip;

        [SerializeField]
        private AudioType audioType;

        public AudioClip AudioClip
        {
            get => audioClip;
        }

        public AudioType AudioType
        {
            get => audioType;
        }
    }
}
