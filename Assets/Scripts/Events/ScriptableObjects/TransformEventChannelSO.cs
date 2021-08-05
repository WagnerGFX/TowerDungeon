using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for Events that have one transform argument.
    /// Example: Spawn system initializes player and fire event, where the transform is the position of player.
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Events/Transform Event Channel", order = 1)]
    public class TransformEventChannelSO : EventChannelBaseSO<Transform> { } 
}
