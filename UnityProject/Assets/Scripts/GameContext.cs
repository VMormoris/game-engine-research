using UnityEngine;
using System.Collections;

public enum GameState
{
    Playing = 0,
    Building = 1,
    Paused = 2
}

public class GameContext : MonoBehaviour
{
    public static Transform[] sWaypoints;
    public static Transform sSpawn;
    public static ArrayList sEnemies = new ArrayList();
    public static GameState sState = GameState.Playing;
    public static BuildManager sBuildManager = null; 
}