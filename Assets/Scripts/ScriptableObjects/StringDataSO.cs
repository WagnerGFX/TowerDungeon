using UnityEngine;

namespace TowerDungeon
{
    [CreateAssetMenu(fileName = "String Data", menuName = "Tower Dungeon/String Data", order = 1)]
    public class StringDataSO : ScriptableObject
    {
        [SerializeField]
        private string text;

        public string Text { get { return text; } }
    }
}