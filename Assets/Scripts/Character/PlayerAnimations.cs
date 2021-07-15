using UnityEngine;

namespace TowerDungeon.Character
{
    public class PlayerAnimations : MonoBehaviour
    {
        public Animator player_anim;
        public PlayerState playerState;

        void Start()
        {
            player_anim = GetComponent<Animator>();
        }

        public void StateMovement(int stateP)
        {
            player_anim.SetInteger("state", stateP);
        }

        public void Attack()
        {
            player_anim.SetTrigger("attack");
        }

        public void DamageAnim()
        {
            player_anim.SetTrigger("hurt");
        }
    }
}
