using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for Events that have no arguments (Example: Exit game event)
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Events/Void Event Channel", order = 1)]
    public class VoidEventChannelSO : EventChannelBaseSO { } 
}