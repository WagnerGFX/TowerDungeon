using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for Events that have one gameobject argument.
    /// Example: A game object pick up event event, where the GameObject is the object we are interacting with.
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/GameObject Event", order = 1)]
    public class GameObjectEventChannelSO : EventChannelBaseSO<GameObject, object> { } 
}
