using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<GameState> OnGameStateChange = null;

    public static void ReportGameStateChange(GameState _gamestate)
    {
        OnGameStateChange?.Invoke(_gamestate);
    }
}
