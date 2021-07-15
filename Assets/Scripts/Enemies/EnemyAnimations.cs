using UnityEngine;

namespace TowerDungeon.Enemies
{
    public class EnemyAnimations : MonoBehaviour
    {
        public Animator enemy_animation;
        public GameObject go;
        public Transform player;

        void Start()
        {
            enemy_animation = GetComponent<Animator>();
        }

        public void enemyWalk(bool walk)
        {
            enemy_animation.SetBool("isWalk", walk);
        }
    }
}