using UnityEngine;
using EventSystem;
using TowerDungeon.Management;

namespace TowerDungeon.Events
{
    [CreateAssetMenu(menuName = "Tower Dungeon/Event Channels/GameState Request Event", order = 1)]
    public class GameStateRequestEventChannelSO : EventChannelBaseSO<GameState> { } 
}
