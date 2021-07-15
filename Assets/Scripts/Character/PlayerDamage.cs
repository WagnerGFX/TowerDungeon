using UnityEngine;

namespace TowerDungeon.Character
{
    public class PlayerDamage : MonoBehaviour
    {
        PlayerLife playerLife_script;

        void Start()
        {
            playerLife_script = GetComponentInParent<PlayerLife>();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
                playerLife_script.TakeDamage();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("littleLife"))
            {
                playerLife_script.RestoreLife(2);
            }
            else if (other.gameObject.CompareTag("mediumLife"))
            {
                playerLife_script.RestoreLife(3);
            }
            else if (other.gameObject.CompareTag("fullLife"))
            {
                playerLife_script.RestoreLife(6);
            }
        }
    }
}
