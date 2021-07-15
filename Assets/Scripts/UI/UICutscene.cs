using UnityEngine;

namespace TowerDungeon.UI
{
    public class UICutscene : MonoBehaviour
    {
        public GameObject arrow, buttonWarrior, buttonArcher;
        public GameObject unselectedChar;

        public void DisableGO()
        {
            gameObject.SetActive(false);
        }
        public void DisableUnselectedChar()
        {
            unselectedChar.SetActive(false);
        }

        public void ActiveButtonSelect()
        {
            arrow.SetActive(true);
            buttonWarrior.SetActive(true);
        }
    }
}
