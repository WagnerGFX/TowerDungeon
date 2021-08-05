using UnityEngine;
using TowerDungeon.Events;

namespace TowerDungeon
{
    public class TestScript : MonoBehaviour
    {
        [SerializeField]
        private LoadSceneRequestEventChannelSO eventChannel;
        [SerializeField]
        private LoadSceneEventArgs eventArgs;

        private void Start()
        {
            eventChannel?.RaiseEvent(eventArgs);
        }

        public void Test()
        {
            Debug.Log("No Value");
        }

        public void TestLoadArgs(LoadSceneEventArgs value)
        {
            Debug.Log(value);
        }
    }
}
