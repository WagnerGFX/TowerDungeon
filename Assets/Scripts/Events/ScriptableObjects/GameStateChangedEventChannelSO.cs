using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/GameStateChanged Event", order = 1)]
    public class GameStateChangedEventChannelSO : EventChannelBaseSO<GameStateChangedEventArgs> { } 
}
