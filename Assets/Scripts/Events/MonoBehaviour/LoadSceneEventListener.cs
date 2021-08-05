using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    public class LoadSceneEventListener : BaseEventListener<LoadSceneEventArgs>
    {
        [SerializeField]
        protected new LoadSceneRequestEventChannelSO _channel;
    } 
}