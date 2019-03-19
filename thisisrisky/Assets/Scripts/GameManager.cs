using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string MinimumPlayersErrorMessage = "Minimum players should be > 1.";
    public PlayerController[] Players;
    public TerritoryController[] RootTerritories;
    public Turn CurrentTurn;

    private static GameManager _SharedMgr;
    public static GameManager Shared()
    {
        return _SharedMgr;
    }

    // Start is called before the first frame update
    void Start()
    {
        _SharedMgr = this;

        // Validate players
        if (Players.Length <= 1)
        {
            Debug.LogError(MinimumPlayersErrorMessage);
        }

        // Initialize first turn
        CurrentTurn = new Turn
        {
            player = Players[0]
        };
    }
}