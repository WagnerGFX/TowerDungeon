using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for Events with no arguments. Preffer to use the Basic Event whenever possible.
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/Anonymous Event", order = 0)]
    public class AnonymousEventChannelSO : EventChannelBaseSO { } 
}