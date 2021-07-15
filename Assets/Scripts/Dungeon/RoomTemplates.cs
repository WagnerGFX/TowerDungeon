using System.Collections.Generic;
using UnityEngine;

namespace TowerDungeon.Dungeon
{
    public class RoomTemplates : MonoBehaviour
    {
        public GameObject[] bottomRooms;

        public GameObject[] topRooms;

        public GameObject[] leftRooms;

        public GameObject[] rightRooms;

        public GameObject[] upRooms;

        public GameObject closedRoom;

        public List<GameObject> rooms;
    }
}
