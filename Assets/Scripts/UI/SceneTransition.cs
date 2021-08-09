using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon.UI
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] [Min(0)]
        private float functionDelay = 0.5f;

        [SerializeField]
        private SceneDataSO sceneToLoad;

        [SerializeField]
        private LoadSceneRequestEventChannelSO loadSceneRequestEventChannel;

        public void OnButtonPress_LoadScene()
            => Invoke(nameof(LoadScene), functionDelay);

        private void LoadScene()
            => loadSceneRequestEventChannel.RaiseEvent(sceneToLoad, this);
    }
}
