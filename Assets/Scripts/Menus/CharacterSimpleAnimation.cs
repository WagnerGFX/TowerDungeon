using UnityEngine;

namespace TowerDungeon
{
    public class CharacterSimpleAnimation : MonoBehaviour
    {
        private enum TriggerType { idle, walk, attack, hurt }

        [SerializeField]
        private TriggerType triggerType;

        private Animator myAnimator;

        private void Awake()
        {
            myAnimator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            switch (triggerType)
            {
                case TriggerType.idle:
                    myAnimator.SetTrigger("idle");
                    break;
                case TriggerType.walk:
                    myAnimator.SetTrigger("walk");
                    break;
                case TriggerType.attack:
                    myAnimator.SetTrigger("attack");
                    break;
                case TriggerType.hurt:
                    myAnimator.SetTrigger("hurt");
                    break;
            }
        }
    }
}
