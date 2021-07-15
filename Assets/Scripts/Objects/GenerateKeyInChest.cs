using UnityEngine;

namespace TowerDungeon.Objects
{
    public class GenerateKeyInChest : MonoBehaviour
    {
        public GameObject[] chests;

        public int randKey;

        public GameObject keyPrefab;

        void Start()
        {
            chests = GameObject.FindGameObjectsWithTag("chestVision");
            InitializeKeyGenerator();
        }

        void FixedUpdate()
        {
            //chests = GameObject.FindGameObjectsWithTag("chestVision");
        }

        public void InitializeKeyGenerator()
        {
            randKey = Random.Range(0, chests.Length);
        }

        public void GenerateKey()
        {
            for (int i = 0; i < chests.Length; i++)
            {
                if (chests[i] == chests[randKey])
                {
                    Instantiate(keyPrefab, gameObject.transform.position, Quaternion.identity);
                    Destroy(chests[randKey]);
                }
            }
        }
    }
}
