using UnityEngine;

namespace TowerDungeon.Enemies
{
    public class Pirsuiter : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        public EnemySO enemyScriptableObject;

        [SerializeField]
        Transform player;

        float timeToStop;

        void Start()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();

            speed = enemyScriptableObject.speed;
            timeToStop = enemyScriptableObject.timeToStop;
        }

        public void PirsuitPlayer()
        {
            PirsuitBehaviour();
        }

        public void PirsuitBehaviour()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
            if (player.transform.position.x < gameObject.transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
