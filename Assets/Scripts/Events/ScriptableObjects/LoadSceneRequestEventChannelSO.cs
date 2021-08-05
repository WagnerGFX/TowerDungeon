using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    /// <summary>
    /// This class is used for scene-loading events.
    /// Takes a GameSceneSO of the location or menu that needs to be loaded, and a bool to specify if a loading screen needs to display.
    /// </summary>
    [CreateAssetMenu(menuName = "Tower Dungeon/Events/Load Scene Event Channel", order = 1)]
    public class LoadSceneRequestEventChannelSO : EventChannelBaseSO<LoadSceneEventArgs>
    {
        protected override void EventRaisedWithNoListeners(LoadSceneEventArgs value)
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
                             "Check why there is no Scene Loader already present, " +
                             "and make sure it's listening on this LoadScene Event Channel.");
        }
    }
}
