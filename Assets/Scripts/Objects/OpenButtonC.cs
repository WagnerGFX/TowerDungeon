using UnityEngine;

namespace TowerDungeon.Objects
{
    public class OpenButtonC : MonoBehaviour
    {
        public Chest chest_script;

        public void btnOpen()
        {
            chest_script.OpenTreasureChest();
        }
    }
}