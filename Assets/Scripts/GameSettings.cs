using UnityEngine;
using TowerDungeon.Character;

namespace TowerDungeon
{
    public class GameSettings
    {
        private static readonly string characterClass = "CharacterClass";
        private static readonly string enemyPoints = "EnemyPoints";
        private static readonly string coinsRecord = "CoinsRecord";
        private static readonly string coinPoints = "CoinPoints";
        private static readonly string pointsRecord = "PointsRecord";

        public static CharacterClass CharacterClass
        {
            get => (CharacterClass)PlayerPrefs.GetInt(characterClass);
            set => PlayerPrefs.SetInt(characterClass, (int)value);
        }

        public static int EnemyPoints
        {
            get => PlayerPrefs.GetInt(enemyPoints);
            set => PlayerPrefs.SetInt(enemyPoints, value);
        }

        public static int CoinsRecord
        {
            get => PlayerPrefs.GetInt(coinsRecord);
            set => PlayerPrefs.SetInt(coinsRecord, value);
        }

        public static int CoinPoints
        {
            get => PlayerPrefs.GetInt(coinPoints);
            set => PlayerPrefs.SetInt(coinPoints, value);
        }

        public static int PointsRecord
        {
            get => PlayerPrefs.GetInt(pointsRecord);
            set => PlayerPrefs.SetInt(pointsRecord, value);
        }


        //TODO: Split between preferences, game saves and session saves.
    }
}
