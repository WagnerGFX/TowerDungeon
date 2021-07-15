using TowerDungeon.Enemies;
using UnityEngine;

namespace TowerDungeon.Character
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl playerControlscript;

        void Start()
        {
            playerControlscript = GetComponentInParent<PlayerControl>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
                other.GetComponent<EnemyLife>().TakeDamage(playerControlscript.myPower);
            }
        }
    }
}
