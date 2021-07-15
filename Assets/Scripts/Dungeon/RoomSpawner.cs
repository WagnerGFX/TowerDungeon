using UnityEngine;

namespace TowerDungeon.Dungeon
{
    public class RoomSpawner : MonoBehaviour
    {
        public int openingDirection, rand;
        private RoomTemplates templates;
        private bool spawned;

        void Start()
        {
            templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        }

        void Spawn()
        {
            if (spawned == false)
            {
                if (openingDirection == 1)//UP
                {
                    rand = Random.Range(0, templates.upRooms.Length);
                    Instantiate(templates.upRooms[rand], transform.position, Quaternion.identity);

                }
                else if (openingDirection == 2)//DOWN
                {
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                }
                else if (openingDirection == 3)//LEFT
                {
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);

                }
                else if (openingDirection == 4)//RIGHT
                {
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                }

                spawned = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("SpawnPoint"))
            {
                if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
                {
                    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                spawned = true;
            }
        }
    }
}