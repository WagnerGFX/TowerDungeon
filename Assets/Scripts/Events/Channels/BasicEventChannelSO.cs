using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for Events that the argument type is flexible or neglectable. The recommended use is to send the event caller as argument.
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/Basic Event", order = 0)]
    public class BasicEventChannelSO : EventChannelBaseSO<object> { } 
}