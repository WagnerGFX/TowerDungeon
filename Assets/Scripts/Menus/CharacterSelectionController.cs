using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using TowerDungeon.Events;
using TowerDungeon.Management;

namespace TowerDungeon.Menus
{
    public class CharacterSelectionController : MonoBehaviour
    {
        [SerializeField]
        private CharacterIdentity[] characters;

        [SerializeField]
        private Animator characterMoveAnim;

        [SerializeField]
        private GameObject arrowNext, arrowPrev;

        [Header("Scene Change")]
        [SerializeField]
        private LoadSceneRequestEventChannelSO loadSceneRequestEventChannel;

        [SerializeField]
        private SceneDataSO sceneGame;

        [SerializeField]
        private SceneDataSO sceneMainMenu;

        private int currentCharacter = 0;
        private bool isSelectionCompleted = false;

        private void Start()
        {
            ChangeSelectedCharacter();
        }

        private void OnEnable()
        {
            InputManager.Instance.UI.Navigate.performed += OnChangeCharacter;
            InputManager.Instance.UI.Submit.performed += OnCharacterSelected;
            InputManager.Instance.UI.Cancel.performed += OnReturnToTitleRequested;
        }

        private void OnDisable()
        {
            InputManager.Instance.UI.Navigate.performed -= OnChangeCharacter;
            InputManager.Instance.UI.Submit.performed -= OnCharacterSelected;
            InputManager.Instance.UI.Cancel.performed -= OnReturnToTitleRequested;
        }

        public void OnGameStartRequested()
        {
            loadSceneRequestEventChannel.RaiseEvent(sceneGame, this);
        }

        public void OnChangeCharacter_Next()
        {
            if (!isSelectionCompleted)
            {
                currentCharacter++;
                ChangeSelectedCharacter();
            }
        }

        public void OnChangeCharacter_Prev()
        {
            if (!isSelectionCompleted)
            {
                currentCharacter--;
                ChangeSelectedCharacter();
            }
        }

        private void OnChangeCharacter(CallbackContext context)
        {
            if (!isSelectionCompleted && context.performed)
            {
                Vector2 direction = context.action.ReadValue<Vector2>();

                if (direction.x > 0)
                    OnChangeCharacter_Next();
                else if (direction.x < 0)
                    OnChangeCharacter_Prev();
            }
        }

        private void OnCharacterSelected(CallbackContext context)
        {
            if (!isSelectionCompleted && context.performed)
            {
                arrowNext.SetActive(false);
                arrowPrev.SetActive(false);
                characterMoveAnim.enabled = true;
                isSelectionCompleted = true;

                //Select Character
                GameSettings.CharacterClass = characters[currentCharacter].CharacterClass;
            }
        }

        private void OnReturnToTitleRequested(CallbackContext context)
        {
            if (!isSelectionCompleted && context.performed)
                loadSceneRequestEventChannel.RaiseEvent(sceneMainMenu, this);
        }

        private void ChangeSelectedCharacter()
        {
            if(currentCharacter < 0)
                currentCharacter = characters.Length - 1;

            if (currentCharacter >= characters.Length)
                currentCharacter = 0;

            for (int i = 0; i < characters.Length; i++)
                characters[i].gameObject.SetActive(i == currentCharacter);
        }
    }
}

