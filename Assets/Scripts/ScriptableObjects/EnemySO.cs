using UnityEngine;

namespace TowerDungeon.Enemies
{
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "Tower Dungeon/Enemy Info", order = 1)]
    public class EnemySO : ScriptableObject
    {
        public float speed;
        public float life;
        public float timeToStop;
        public EnemySpecies enemy_classification;
    }
}