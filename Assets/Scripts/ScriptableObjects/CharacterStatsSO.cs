using UnityEngine;

namespace TowerDungeon.Character
{
    [CreateAssetMenu(fileName = "Stats", menuName = "Tower Dungeon/Character Base Stats", order = 0)]
    public class CharacterStatsSO : ScriptableObject
    {
        [SerializeField]
        private CharacterClass characterClass;
        public CharacterClass CharacterClass { get => characterClass; }

        [SerializeField]
        private int basePower;
        public int BasePower { get => basePower; }

        [SerializeField]
        private int baseLife;
        public int BaseLife { get => baseLife; }

        [SerializeField]
        private int baseDefense;
        public int BaseDefense { get => baseDefense; }

        [SerializeField]
        private float baseMoveSpeed;
        public float BaseMoveSpeed { get => baseMoveSpeed; }

        [SerializeField]
        private float baseAttackRate;
        public float BaseAttackRate { get => baseAttackRate; }
    }
}