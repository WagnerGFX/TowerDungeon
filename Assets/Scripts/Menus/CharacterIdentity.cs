using TowerDungeon.Character;
using UnityEngine;

namespace TowerDungeon.Menus
{
    public class CharacterIdentity : MonoBehaviour
    {
        [SerializeField]
        private CharacterClass characterClass;
        public CharacterClass CharacterClass { get => characterClass; }
    }
}
