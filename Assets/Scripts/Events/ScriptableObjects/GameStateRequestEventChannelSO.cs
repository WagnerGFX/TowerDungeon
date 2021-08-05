using UnityEngine;
using EventSystem;
using TowerDungeon.Management;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Events/GameState Request Event Channel", order = 1)]
    public class GameStateRequestEventChannelSO : EventChannelBaseSO<GameState> { } 
}
