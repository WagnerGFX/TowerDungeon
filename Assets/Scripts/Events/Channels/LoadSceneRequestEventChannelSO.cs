using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/SceneData Event", order = 1)]
    public class LoadSceneRequestEventChannelSO : EventChannelBaseSO<SceneDataSO, object>
    {
       /** private void OnEnable()
            => this.OnEventRaisedWithNoListeners += EventRaisedWithNoListeners;
        private void OnDisable()
            => this.OnEventRaisedWithNoListeners -= EventRaisedWithNoListeners;

        private void EventRaisedWithNoListeners(object sender, SceneDataSO value)
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
                             "Check why there is no Scene Loader already present, " +
                             "and make sure it's listening on this Event Channel." +
                             $"\nSender: {sender}");
                            
        }**/
    }
}
