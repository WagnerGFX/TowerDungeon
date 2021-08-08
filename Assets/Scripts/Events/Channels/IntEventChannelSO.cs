using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for Events that have one int argument.
    /// Example: An Achievement unlock event, where the int is the Achievement ID.
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/Int Event", order = 1)]
    public class IntEventChannelSO : EventChannelBaseSO<int, object> { } 
}
