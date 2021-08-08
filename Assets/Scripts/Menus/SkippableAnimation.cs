using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using TowerDungeon.Events;

namespace TowerDungeon
{
    public class SkippableAnimation : MonoBehaviour
    {
        [SerializeField]
        private InputCallbackEventChannelSO animationSkipRequestEventChannel;

        [SerializeField]
        private string skipParameter = "SkipToEnd";

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            animationSkipRequestEventChannel.Subscribe(OnAnimationSkipRequested);
        }

        private void OnDisable()
        {
            animationSkipRequestEventChannel.Unsubscribe(OnAnimationSkipRequested);
        }

        void OnAnimationSkipRequested(CallbackContext context)
        {
            if(context.action.phase == InputActionPhase.Started)
            {
                animator.SetBool(skipParameter, true);
                this.enabled = false;
            }
        }
    }
}
