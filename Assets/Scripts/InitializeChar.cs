using UnityEngine;
using TowerDungeon.Management;
using TowerDungeon.Events;
using TowerDungeon.Character;

namespace TowerDungeon
{
    public class InitializeChar : MonoBehaviour
    {
        [SerializeField]
        private GameObject warrior, archer, mage;

        [SerializeField]
        private GameStateRequestEventChannelSO gameStateChangeRequestChannel;

        void Awake()
        {
            CharacterClass characterClass = GameSettings.CharacterClass;

            switch (characterClass)
            {
                case CharacterClass.Warrior:
                    warrior.SetActive(true);
                    archer.SetActive(false);
                    mage.SetActive(false);
                    break;

                case CharacterClass.Archer:
                    warrior.SetActive(false);
                    archer.SetActive(true);
                    mage.SetActive(false);
                    break;

                case CharacterClass.Mage:
                    warrior.SetActive(false);
                    archer.SetActive(false);
                    mage.SetActive(true);
                    break;
            }

            Debug.Log($"id: {characterClass}");

            GameSettings.EnemyPoints = 0;

            gameStateChangeRequestChannel?.RaiseEvent(GameState.Playing, this);
        }
    }
}