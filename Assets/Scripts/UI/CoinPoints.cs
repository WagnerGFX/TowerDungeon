using TowerDungeon.Management;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDungeon.UI
{
    public class CoinPoints : MonoBehaviour
    {
        [SerializeField]
        private Text pointCoinsTxt;

        [SerializeField]
        private AudioSource coinsFx;

        [SerializeField]
        private AudioClip coinClipFx;

        private int pointCoins, recordPointCoins;

        void Start()
        {
            pointCoinsTxt = GameObject.FindWithTag("coinIUI").GetComponent<Text>();
            recordPointCoins = GameSettings.CoinsRecord;
            pointCoins = GameSettings.CoinPoints;
        }

        public void AddPoints()
        {
            pointCoins += 1;
            GameSettings.CoinPoints = pointCoins;
            pointCoinsTxt.text = pointCoins.ToString();
            SavePointsCoins();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //SoundManager.Instance.PlayGetCoinsFx();
                AddPoints();
            }
        }

        void SavePointsCoins()
        {
            if (pointCoins > recordPointCoins)
            {
                recordPointCoins = pointCoins;
                GameSettings.CoinsRecord = recordPointCoins;
            }
        }
    }
}
