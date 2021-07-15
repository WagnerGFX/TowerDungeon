﻿using UnityEngine;
using TowerDungeon.Management;

namespace TowerDungeon
{
    public class InitializeChar : MonoBehaviour
    {
        [SerializeField]
        private GameObject warrior, archer, mage;

        void Awake()
        {
            int characterClass = GameSettings.CharacterClass;

            if (characterClass == 1)
            {
                Debug.Log("id:" + characterClass);
                warrior.SetActive(true);
                archer.SetActive(false);
                mage.SetActive(false);
            }
            else if (characterClass == 2)
            {
                Debug.Log("id:" + characterClass);
                archer.SetActive(true);
                warrior.SetActive(false);
                mage.SetActive(false);
            }
            else if (characterClass == 3)
            {
                mage.SetActive(true);
                archer.SetActive(false);
                warrior.SetActive(false);
            }

            GameSettings.EnemyPoints = 0;

            GameManager.Instance.SetGameStateToPlaying();
        }
    }
}