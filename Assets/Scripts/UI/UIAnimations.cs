using UnityEngine;

namespace TowerDungeon.UI
{
    public class UIAnimations : MonoBehaviour
    {
        [SerializeField]
        private GameObject warrior, archer;

        private Animator ui_anim;

        void Start()
        {
            ui_anim = GetComponent<Animator>();
        }

        public void FinalizeMovement(bool finalize)
        {
            ui_anim.SetBool("finalize", finalize);
        }
    }
}
