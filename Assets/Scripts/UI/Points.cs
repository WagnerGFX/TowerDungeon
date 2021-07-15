using UnityEngine;
using UnityEngine.UI;
using TowerDungeon.Enemies;

namespace TowerDungeon.UI
{
    public class Points : MonoBehaviour
    {
        [SerializeField]
        private EnemySO enemy_scriptable;

        private Text pointsTxt;

        private int pointsNbr, record;

        void Start()
        {
            pointsTxt = GameObject.Find("pointsTxt").GetComponent<Text>();
            pointsNbr = GameSettings.EnemyPoints;
            record = GameSettings.PointsRecord;
        }

        public void AddRewardPoints()
        {
            if (enemy_scriptable.enemy_classification == EnemySpecies.Snake)
            {
                pointsNbr += 5;
                GameSettings.EnemyPoints = pointsNbr;
                pointsTxt.text = pointsNbr.ToString();
                SavePoints();
            }

            if (enemy_scriptable.enemy_classification == EnemySpecies.Skeleton)
            {
                pointsNbr += 10;
                GameSettings.EnemyPoints = pointsNbr;
                pointsTxt.text = pointsNbr.ToString();
                SavePoints();
            }
        }

        public void SavePoints()
        {
            if (record < GameSettings.EnemyPoints)
            {
                record = GameSettings.EnemyPoints;
                GameSettings.PointsRecord = record;
            }
        }
    }
}