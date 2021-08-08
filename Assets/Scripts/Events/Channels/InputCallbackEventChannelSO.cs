using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using EventSystem;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/CallbackContext Event", order = 1)]
    public class InputCallbackEventChannelSO : EventChannelBaseSO<CallbackContext>
    {

    }
}
