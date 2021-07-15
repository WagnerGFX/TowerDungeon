using TowerDungeon.Enemies;
using UnityEngine;

namespace TowerDungeon.Character
{
    public class AttackPlayerMage : MonoBehaviour
    {
        public PlayerControl playerControlscript;

        void Start()
        {
            playerControlscript = GameObject.Find("Mago").GetComponent<PlayerControl>();
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

