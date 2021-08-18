using UnityEngine;
using UnityEngine.Events;

namespace TowerDungeon.Menus
{
    public class AnimationEnded : MonoBehaviour
    {
        public UnityEvent OnAnimationEnded;

        private void OnAnimationEndedInternal()
        {
            OnAnimationEnded?.Invoke();
        }
    }
}
