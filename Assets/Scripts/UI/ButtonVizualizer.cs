using UnityEngine;

namespace TowerDungeon.UI
{
    public class ButtonVizualizer : MonoBehaviour
    {
        [SerializeField]
        private GameObject button;

        void Start()
        {
            button.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                button.SetActive(true);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                button.SetActive(false);
            }
        }
    }
}