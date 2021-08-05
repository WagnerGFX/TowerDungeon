using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDungeon.UI
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField]
        private int time;

        [SerializeField]
        private SceneDataSO sceneMainTitle;

        void Update()
        {
            StartCoroutine(nameof(LoadScene));
        }

        public IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(sceneMainTitle.SceneName);
        }
    }

}
