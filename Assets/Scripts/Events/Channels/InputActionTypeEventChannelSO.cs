using UnityEngine;
using EventSystem;
using TowerDungeon.Input;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/InputActionType Event", order = 4)]
    public class InputActionTypeEventChannelSO : EventChannelBaseSO<InputActionType, object> { } 
}
