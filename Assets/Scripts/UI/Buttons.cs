using TowerDungeon.Character;
using UnityEngine;

namespace TowerDungeon.UI
{
    public class Buttons : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl playerControl_script;
        
        [SerializeField]
        private GameObject warrior_go;
        
        [SerializeField]
        private PlayerAnimations playerAnimations_script;

        private bool moveUp, moveDown, moveLeft, moveRight;
        //float dirX;
        //float moveSpeed = 5f;

        void Start()
        {
            int characterClass = GameSettings.CharacterClass;

            if (characterClass == 1)
            {
                playerControl_script = GameObject.Find("Guerreiro").GetComponent<PlayerControl>();
                playerAnimations_script = GameObject.Find("Guerreiro").GetComponent<PlayerAnimations>();
            }
            else if (characterClass == 2)
            {
                playerControl_script = GameObject.Find("Arqueiro").GetComponent<PlayerControl>();
                playerAnimations_script = GameObject.Find("Arqueiro").GetComponent<PlayerAnimations>();
            }
            else if (characterClass == 3)
            {

                playerControl_script = GameObject.Find("Mago").GetComponent<PlayerControl>();
                playerAnimations_script = GameObject.Find("Mago").GetComponent<PlayerAnimations>();
            }
            InitializeBooleanDirections();
        }

        private void Update()
        {
            PlayerMovement();
        }

        void InitializeBooleanDirections()
        {
            moveUp = false;
            moveDown = false;
            moveLeft = false;
            moveRight = false;
        }

        public void PlayerMovement()
        {
            if (moveUp)
            {
                playerAnimations_script.StateMovement(1);
                playerControl_script.MoveUp();
            }
            if (moveDown)
            {
                playerAnimations_script.StateMovement(1);
                playerControl_script.MoveDown();
            }
            if (moveLeft)
            {
                playerAnimations_script.StateMovement(3);
                playerControl_script.MoveLeft();
            }
            if (moveRight)
            {
                playerAnimations_script.StateMovement(4);
                playerControl_script.MoveRight();
            }
        }

        //INPUT BUTTONS
        public void UnclickMoveUp()
        {
            playerAnimations_script.StateMovement(0);
            moveUp = false;
        }
        public void ClickMoveUp()
        {

            moveUp = true;
        }
        public void ClickMoveDown()
        {
            moveDown = true;
        }
        public void UnclickMoveDown()
        {
            playerAnimations_script.StateMovement(0);
            moveDown = false;
        }
        public void CLickMoveLeft()
        {

            moveLeft = true;
        }
        public void UnclickMoveLeft()
        {
            playerAnimations_script.StateMovement(0);
            moveLeft = false;
        }
        public void ClickMoveRight()
        {
            moveRight = true;
        }
        public void UnclickMoveRight()
        {
            playerAnimations_script.StateMovement(0);
            moveRight = false;
        }
        public void AttackBtn()
        {
            playerControl_script.SimpleAttack();
        }
    }
}

