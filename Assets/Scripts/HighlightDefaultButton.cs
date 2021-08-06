using UnityEngine;
using UnityEngine.UI;

namespace TowerDungeon
{
    public class HighlightDefaultButton : MonoBehaviour
    {
        private Button button;
        private UnityEngine.EventSystems.EventSystem eventSystem;
        
        void Start()
        {
            button = GetComponent<Button>();
            eventSystem = UnityEngine.EventSystems.EventSystem.current;
        }

        void Update()
        {
            if (button.isActiveAndEnabled)
            {
                eventSystem.SetSelectedGameObject(button.gameObject);
                Destroy(this);
            }
        }
    }
}
