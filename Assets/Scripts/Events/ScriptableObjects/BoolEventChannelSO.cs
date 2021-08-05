using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for Events that have a bool argument.
    /// Example: An event to toggle a UI interface
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Events/Bool Event Channel", order = 1)]
    public class BoolEventChannelSO : EventChannelBaseSO<bool> { } 
}
