using UnityEngine;
using EventSystem;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Events/GameStateChanged Event Channel", order = 1)]
    public class GameStateChangedEventChannelSO : EventChannelBaseSO<GameStateChangedEventArgs> { } 
}
