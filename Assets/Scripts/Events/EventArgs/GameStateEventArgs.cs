using UnityEngine;
using TowerDungeon.Management;

namespace TowerDungeon.Events
{
    [System.Serializable]
    public struct GameStateChangedEventArgs
    {
        [SerializeField]
        private GameState previousGameState;
        public GameState PreviousGameState { get => previousGameState; }

        [SerializeField]
        private GameState newGameState;
        public GameState NewGameState { get => newGameState; }

        public GameStateChangedEventArgs(GameState previousGameState, GameState newGameState)
        {
            this.previousGameState = previousGameState;
            this.newGameState = newGameState;
        }
    }
}
