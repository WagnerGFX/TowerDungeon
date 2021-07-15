using UnityEngine;

namespace TowerDungeon.Enemies
{
    public class EnemyVision : MonoBehaviour
    {
        [SerializeField]
        Pirsuiter pirsuiterScript;

        void Start()
        {
            pirsuiterScript = transform.GetComponentInChildren<Pirsuiter>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                pirsuiterScript.PirsuitPlayer();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                pirsuiterScript.PirsuitPlayer();
            }
        }
    }
}
