using TowerDungeon.Objects;
using TowerDungeon.Events;
using TowerDungeon.Management;
using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace TowerDungeon.Character
{
    public class PlayerControl : MonoBehaviour, IPlayer
    {
        [Header("Character Data")]
        [SerializeField]
        private CharacterClass characterClass;

        [SerializeField]
        private CharacterStatsSO characterBaseStats;

        [Header("References")]
        [SerializeField]
        private EventManagerSO globalEventManager;

        [SerializeField]
        private AudioSource attackFx;

        [SerializeField]
        private GameObject firePrefab;

        [SerializeField]
        private GameObject arrowPrefab;

        [SerializeField]
        private Transform projectileSpawnPos;

        private Rigidbody2D playerRb;
        private PlayerAnimations playerAnimationsScript;
        Vector2 moveDirection;
        private float dirX;
        private bool isAttack;
        private bool flipX;

        [HideInInspector]
        public float moveSpeedModifier = 0;
        [HideInInspector]
        public float attackRateModifier = 0f;
        [HideInInspector]
        public int powerModifier = 0;
        
        public float MoveSpeed { get => characterBaseStats.BaseMoveSpeed + moveSpeedModifier; }
        public float AttackRate { get => characterBaseStats.BaseAttackRate + attackRateModifier; }
        public int CurrentPower { get => characterBaseStats.BasePower + powerModifier; }

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody2D>();
            playerAnimationsScript = GetComponent<PlayerAnimations>();
        }

        private void OnEnable()
        {
            InputManager.Instance.Player.Move.performed += OnMovementPerformed;
            InputManager.Instance.Player.Move.canceled += OnMovementCanceled;
            InputManager.Instance.Player.Attack.performed += OnAttackPerformed;
        }

        private void OnDisable()
        {
            InputManager.Instance.Player.Move.performed -= OnMovementPerformed;
            InputManager.Instance.Player.Move.canceled -= OnMovementCanceled;
            InputManager.Instance.Player.Attack.performed += OnAttackPerformed;
        }

        private void Update()
        {
            if(moveDirection != Vector2.zero)
            {
                Vector2 finalMove = moveDirection * MoveSpeed * Time.deltaTime;

                playerRb.MovePosition(playerRb.position + finalMove);
            }
        }


        private void OnMovementPerformed(CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();
        }

        private void OnMovementCanceled(CallbackContext context)
        {
            moveDirection = Vector2.zero;
        }

        private void OnAttackPerformed(CallbackContext context)
        {
            //Should attack
        }

        private void OnAttackCanceled(CallbackContext context)
        {
            //Stop attacking
        }

        private void IdlePosition()
        {
            if (playerRb.velocity == Vector2.zero)
            {
                playerAnimationsScript.StateMovement(0);
            }
        }

        private void Flip()
        {
            if (flipX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private IEnumerator InvokeArrow()
        {
            isAttack = true;
            GameObject arrowTemp = Instantiate(arrowPrefab, projectileSpawnPos.position, Quaternion.identity) as GameObject;
            arrowTemp.transform.localScale = transform.localScale;

            if (flipX)
            {
                arrowTemp.GetComponent<Arrow>().VerifyArrowPosition(Vector2.left);
            }
            else
            {
                arrowTemp.GetComponent<Arrow>().VerifyArrowPosition(Vector2.right);
            }

            Destroy(arrowTemp, 3f);
            yield return new WaitForSeconds(AttackRate);
            isAttack = false;
        }

        private IEnumerator InvokeFire()
        {
            isAttack = true;
            GameObject fireTemp = Instantiate(firePrefab, projectileSpawnPos.position, Quaternion.identity) as GameObject;
            firePrefab.transform.localScale = transform.localScale;

            if (flipX)
            {
                fireTemp.GetComponent<Fire>().VerifyFirePosition(Vector2.left);
            }
            else
            {
                fireTemp.GetComponent<Fire>().VerifyFirePosition(Vector2.right);
            }

            yield return new WaitForSeconds(AttackRate);
            isAttack = false;
        }

        private IEnumerator WarriorAttackRate()
        {
            isAttack = true;
            yield return new WaitForSeconds(AttackRate);
            isAttack = false;
        }

        private void PCMovement()
        {
            IdlePosition();
            //if (Input.GetKeyDown(KeyCode.Space))
            //    SimpleAttack();

            //if (Input.GetKey(KeyCode.UpArrow))
            //    MoveUp();

            //if (Input.GetKey(KeyCode.DownArrow))
            //    MoveDown();

            //if (Input.GetKey(KeyCode.LeftArrow))
            //    MoveLeft();

            //if (Input.GetKey(KeyCode.RightArrow))
            //    MoveRight();
        }

        public void SimpleAttack()
        {
            if (!isAttack)
            {
                //SoundManager.Instance.PlayAttackFx(attackFx);
                playerAnimationsScript.Attack();

                if (characterClass == CharacterClass.Archer)
                    StartCoroutine(nameof(InvokeArrow));

                else if (characterClass == CharacterClass.Warrior)
                    StartCoroutine(nameof(WarriorAttackRate));

                else if (characterClass == CharacterClass.Mage)
                    StartCoroutine(nameof(InvokeFire));
            }
        }

        public void MoveUp()
        {
            playerAnimationsScript.StateMovement(1);
            Flip();
            transform.position += MoveSpeed * Time.deltaTime * Vector3.up;
        }

        public void MoveDown()
        {
            playerAnimationsScript.StateMovement(2);
            Flip();
            transform.position += MoveSpeed * Time.deltaTime * Vector3.down;
        }

        public void MoveLeft()
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flipX = true;
            playerAnimationsScript.StateMovement(3);

            transform.position += MoveSpeed * Time.deltaTime * Vector3.left;
        }

        public void MoveRight()
        {
            transform.localScale = new Vector3(1, 1, 1);
            flipX = false;
            playerAnimationsScript.StateMovement(4);
            transform.position += MoveSpeed * Time.deltaTime * Vector3.right;
        }
    }
}
