using UnityEngine;

namespace TowerDungeon.Objects
{
    public class ChestAnimations : MonoBehaviour
    {
        Animator chest_animator;

        void Start()
        {
            chest_animator = GetComponent<Animator>();
        }

        public void OpenChest()
        {
            chest_animator.SetTrigger("open");
        }
    }
}
