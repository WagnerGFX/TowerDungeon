using UnityEngine;
using EventSystem;
using TowerDungeon.Management;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/InputActionType Event", order = 4)]
    public class InputActionTypeEventChannelSO : EventChannelBaseSO<InputActionType, object> { } 
}
