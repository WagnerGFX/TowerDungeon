using UnityEngine;

namespace TowerDungeon.Dungeon
{
    public class AddRoom : MonoBehaviour
    {
        private RoomTemplates templates;

        void Start()
        {
            templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            templates.rooms.Add(this.gameObject);
        }
    } 
}
