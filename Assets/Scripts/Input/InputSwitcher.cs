using UnityEngine;
using TowerDungeon.Events;
using TowerDungeon.Management;

namespace TowerDungeon.Input
{
    public class InputSwitcher : MonoBehaviour
    {
        [SerializeField]
        private EventManagerSO globalEventManager;

        [SerializeField]
        private InputActionType inputActionType = InputActionType.Disabled;

        [SerializeField]
        private bool destroyGameObjectAfter = false;

        void Start()
        {
            globalEventManager.OnInputChangeRequested.RaiseEvent(inputActionType, this);

            if (destroyGameObjectAfter)
                Destroy(gameObject);
            else
                Destroy(this);
        }
    }
}
