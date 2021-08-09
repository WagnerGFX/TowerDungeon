﻿using UnityEngine;
using UnityEngine.UI;

namespace TowerDungeon.UI
{
    public class LoadRankingData : MonoBehaviour
    {
        [SerializeField]
        private Text pointsTxt, coinsTxt;

        void Start()
        {
            int points = GameSettings.PointsRecord;
            int coins = GameSettings.CoinsRecord;

            pointsTxt.text = points.ToString();
            coinsTxt.text = coins.ToString();
        }
    }
}