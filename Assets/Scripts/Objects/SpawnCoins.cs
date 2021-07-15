using UnityEngine;

namespace TowerDungeon.Objects
{
    public class SpawnCoins : MonoBehaviour
    {
        float randomNumbers;
        public GameObject coinPrefab;
        public static SpawnCoins instance;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }

        public void coinSpawn(Transform spawnPos)
        {
            randomNumbers = Random.Range(0, 10);
            if (randomNumbers <= 5)
            {

                Debug.Log(randomNumbers);
                GameObject newPrefab = Instantiate(coinPrefab, spawnPos.position, Quaternion.identity) as GameObject;
            }
            else if (randomNumbers > 5)
            {
                Debug.Log(randomNumbers);
                return;
            }
        }
    }
}