using UnityEngine;
using TowerDungeon.Management;

namespace TowerDungeon.Objects
{
    public class Chest : MonoBehaviour
    {
        [Header("Enemies")]
        public GameObject enemyPrefab;

        [Header("Power Ups")]
        public GameObject[] powerUpPrefab;

        [Header("Foods")]
        public GameObject[] foodsPrefab;

        [Header("Key")]
        public GameObject keyPrefab;

        [Header("Spawn and vizualize settings")]
        public Transform spawnPosition;
        public GameObject chestVizualizer;
        public GameObject keyTarget;
        public GenerateKeyInChest generateKey_script;
        public AudioSource chestFx;

        int randomic, randomicPositions;
        ChestAnimations chestAnimations;

        void Start()
        {
            generateKey_script = GameObject.Find("GameManagerInScene").GetComponent<GenerateKeyInChest>();
            chestAnimations = GetComponent<ChestAnimations>();
            keyTarget = GameObject.FindWithTag("key");
        }

        public void OpenTreasureChest()
        {
            //SoundManager.Instance.PlayChestOpenFx(chestFx);
            chestAnimations.OpenChest();
        }

        public void FinalizeOpenChest()
        {
            GenerateOtherObjects();
        }

        public void GenerateOtherObjects()
        {
            randomic = Random.Range(0, 50);

            if (randomic >= 0 && randomic <= 10)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity) as GameObject;
            }
            else if (randomic > 10 && randomic <= 30)
            {
                randomicPositions = Random.Range(0, 3);
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity) as GameObject;
            }
            else if (randomic > 30 && randomic <= 40)
            {
                GameObject newVelocityPrefab = Instantiate(powerUpPrefab[randomicPositions], spawnPosition.position, Quaternion.identity) as GameObject;
            }
            else if (randomic > 40 && randomic <= 50)
            {
                randomicPositions = Random.Range(0, 1);
                GameObject newLifeItemPrefab = Instantiate(foodsPrefab[randomicPositions], spawnPosition.position, Quaternion.identity) as GameObject;
            }

            Destroy(chestVizualizer);
        }
    }
}
