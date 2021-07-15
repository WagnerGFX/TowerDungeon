using System.Collections;
using TowerDungeon.Objects;
using TowerDungeon.UI;
using UnityEngine;

namespace TowerDungeon.Enemies
{
    public class EnemyLife : MonoBehaviour
    {
        public EnemySO enemy_scriptable;
        public SpriteRenderer enemy_sprite;
        public float life, strenght;
        public GameObject enemy_vizualizer;

        //bool damaged;
        Transform spawnPos;
        Points points_script;
        Transform player;

        void Start()
        {
            points_script = GetComponent<Points>();
            enemy_sprite = GetComponent<SpriteRenderer>();
            life = enemy_scriptable.life;

            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            spawnPos = GetComponent<Transform>();
        }

        void Update()
        {
            VerifyLoseCondition();
        }

        public float TakeDamage(float damagePower)
        {
            StartCoroutine(nameof(BlinkEnemy));

            life -= damagePower;
            //damaged = false;
            Debug.Log("VIDA INIMIGO" + life);
            return life;
        }

        IEnumerator BlinkEnemy()
        {
            enemy_sprite.color = Color.red;
            yield return new WaitForSeconds(.1f);
            enemy_sprite.color = Color.white;
        }

        void VerifyLoseCondition()
        {
            if (life <= 0)
            {
                SpawnCoins.instance.coinSpawn(spawnPos);
                points_script.AddRewardPoints();
                Destroy(enemy_vizualizer);
            }
        }
    }
}