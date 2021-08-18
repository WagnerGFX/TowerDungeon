using UnityEngine;
using TowerDungeon.Input;
using TowerDungeon.Events;

namespace TowerDungeon.Management
{
    public enum InputActionType
    {
        Disabled,
        UI,
        Player
    }

    public class InputManager : MonoSingleton<InputManager>
    {
        [SerializeField]
        private EventManagerSO globalEventManager;

        public TowerDungeonInputActions InputActions { get; private set; }
        public TowerDungeonInputActions.PlayerActions Player { get => InputActions.Player; }
        public TowerDungeonInputActions.UIActions UI { get => InputActions.UI; }

        protected override void OnAwake()
        {
            InputActions = new TowerDungeonInputActions();
        }

        private void OnEnable()
        {
            globalEventManager.OnInputChangeRequested.Subscribe(OnInputChangeRequest);
        }

        private void OnDisable()
        {
            globalEventManager.OnInputChangeRequested.Unsubscribe(OnInputChangeRequest);
        }

        private void OnInputChangeRequest(InputActionType inputType, object sender)
        {
            switch (inputType)
            {
                case InputActionType.Disabled:
                    InputActions.Player.Disable();
                    InputActions.UI.Disable();
                    break;

                case InputActionType.UI:
                    InputActions.Player.Disable();
                    InputActions.UI.Enable();
                    break;

                case InputActionType.Player:
                    InputActions.Player.Enable();
                    InputActions.UI.Disable();
                    break;
            }
        }
    }
}
