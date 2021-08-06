using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/Audio Event", order = 1)]
    public class PlayMusicRequestEventChannelSO : EventChannelBaseSO<AudioSO> { }
}
