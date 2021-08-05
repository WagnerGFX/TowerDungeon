using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDungeon.UI
{
    public class CreditsUI : MonoBehaviour
    {
        [SerializeField]
        private SceneDataSO sceneTitleMenu;

        public void Back()
        {
            SceneManager.LoadScene(sceneTitleMenu.SceneName);
        }
    }
}
