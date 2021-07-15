using UnityEngine;

namespace TowerDungeon.Character
{
    [CreateAssetMenu(fileName = "Player Info", menuName = "Tower Dungeon/Player Info", order = 0)]
    public class PlayerSO : ScriptableObject
    {
        public int power;
        public int life;
        public int defense;
    }
}