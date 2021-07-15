using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDungeon.UI
{
    public class CharacterChoose : MonoBehaviour
    {
        [SerializeField]
        private GameObject warriorbutton, archerbutton, magebutton, archer, warrior, mage;

        [SerializeField]
        private UIAnimations anim_warrior, anim_archer, anim_mage;

        [SerializeField]
        private UICutscene uiCutscene_script;

        [SerializeField]
        private StringDataSO sceneGame;

        public void WarriorBtn()
        {
            Debug.Log("WARRIOR SELECTED!");
            GameSettings.CharacterClass = 1;

            anim_warrior.FinalizeMovement(true);
            // GameManager.instance.GameOn();

            Invoke("GameScene", 2f);
        }

        public void ArcherBtn()
        {
            Debug.Log("ARCHER SELECTED!");
            GameSettings.CharacterClass = 2;
            archer.SetActive(true);
            anim_archer.FinalizeMovement(true);
            //   GameManager.instance.GameOn();

            Invoke("GameScene", 2f);
        }

        public void MageBtn()
        {
            Debug.Log("MAGE SELECTED!");
            GameSettings.CharacterClass = 3;
            mage.SetActive(true);
            anim_mage.FinalizeMovement(true);
            Invoke("GameScene", 2f);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                WarriorBtn();
            }
            if (Input.GetButtonDown("Fire3"))
            {
                ArcherBtn();
            }
        }

        public void btnNext()
        {
            if (warriorbutton.activeSelf)
            {
                warriorbutton.SetActive(false);//desativa o botao do char
                warrior.SetActive(false);//desativa o char
                archerbutton.SetActive(true);
                archer.SetActive(true);
            }
            else if (archerbutton.activeSelf)
            {
                archerbutton.SetActive(false);
                archer.SetActive(false);
                magebutton.SetActive(true);
                mage.SetActive(true);
            }
            else if (magebutton.activeSelf)
            {
                magebutton.SetActive(false);
                mage.SetActive(false);
                warriorbutton.SetActive(true);
                warrior.SetActive(true);
            }
        }

        public void GameScene()
        {
            SceneManager.LoadScene(sceneGame.Text);
        }
    }
}

