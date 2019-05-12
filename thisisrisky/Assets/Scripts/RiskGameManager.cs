using System.Collections.Generic;
using UnityEngine;

public class RiskGameManager : MonoBehaviour
{
    public enum GameState
    {
        ChooseTerritories,
        Play,
        Complete
    }

    public Continent[] AllContinents
    {
        get
        {
            return GetComponentsInChildren<Continent>();
        }
    }

    public PlayerController[] Players;
    public TextMesh PlayerStatusTextMesh;

    public GameObject PrefabBasicArmy;

    public Turn CurrentTurn {
        get
        {
            return UnderlyingTurn;
        }
    }

    private Turn UnderlyingTurn = null;
    private List<TerritoryController> AllTerritories = new List<TerritoryController>();
    private List<ArmyController> AllArmies = new List<ArmyController>();
    private const string _MinimumPlayersErrorMessage = "Minimum players should be > 1.";
    private int _CurrentPlayerIndex;
    private List<Turn> PreviousTurns = new List<Turn>();
    private static RiskGameManager _SharedMgr;

    public static RiskGameManager Shared()
    {
        return _SharedMgr;
    }

    public PlayerController CurrentPlayer
    {
        get
        {
            if (CurrentTurn != null && CurrentTurn.Player)
            {
                return CurrentTurn.Player;
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Represents the overall game state for a session.
    /// </summary>
    /// <returns>The GameState.</returns>
    public GameState CurrentGameState()
    {
        if (!CurrentPlayer)
        {
            return GameState.ChooseTerritories;
        }

        // If any territory is unassigned, then we're in "Choose Territory" mode.
        foreach (TerritoryController territoryController in AllTerritories)
        {
            if (!territoryController.Occupied)
            {
                return GameState.ChooseTerritories;
            }
        }

        // We're not in "Choose Territory" mode, so now we take the current player,
        // and use the following logic to determine which state we belong in.
        if (CurrentPlayer.OwnedTerritories.Length == AllTerritories.Count)
        {
            return GameState.Complete;
        }
        else
        {
            return GameState.Play;
        }
    }

    public void RegisterTerritory(TerritoryController territory)
    {
        if (!AllTerritories.Contains(territory))
        {
            AllTerritories.Add(territory);
        }
    }

    public void RegisterArmy(ArmyController army)
    {
        if (!AllArmies.Contains(army))
        {
            AllArmies.Add(army);
        }
    }

    public void UnregisterArmy(ArmyController army)
    {
        if (AllArmies.Contains(army))
        {
            AllArmies.Remove(army);
        }
    }

    public ArmyController LookupOccuantForTerritory(TerritoryController territory)
    {
        foreach (ArmyController army in AllArmies)
        {
            if (army.Location == territory)
            {
                return army;
            }
        }

        return null;
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        _SharedMgr = this;

        // Validate players
        if (Players.Length <= 1)
        {
            Debug.LogError(_MinimumPlayersErrorMessage);
        }

        // Initialize first turn
        Turn turn = new Turn(Players[0]);
        UnderlyingTurn = turn;
    }

    private void Update()
    {
        //
        /// This is the fundamental game logic for our turn based strategy game.
        /// It ensures we rotate through each player, updating our state as we go.
        /// 
        if (CurrentTurn.Completed)
        {
            // move current turn to "previous turns"
            PreviousTurns.Add(CurrentTurn);
            Turn LastTurn = PreviousTurns[PreviousTurns.Count - 1];

            // increment the current player index (looping where necessary)
            _CurrentPlayerIndex++;
            if (_CurrentPlayerIndex >= Players.Length)
            {
                _CurrentPlayerIndex = 0;
            }

            PlayerController nextPlayer = Players[_CurrentPlayerIndex];

            // and setup the next turn.
            UnderlyingTurn = new Turn(nextPlayer);
        }
        else
        {
            CurrentTurn.Update();
        }

        ///
        /// Perform GUI Updates
        ///

        // Show/hide "End Attack" button.

        // Update Status Text
        string updateText = "";

        switch (CurrentTurn.CurrentPlayerState())
        {
            case Turn.PlayerState.ChooseTerritory:
                updateText = "Player '" + CurrentPlayer.displayName + "' is picking a Territory...";
                break;
            case Turn.PlayerState.Reinforce:
                updateText = "Player '" + CurrentPlayer.displayName + "' (" + CurrentPlayer.UnassignedArmies.Length + " left) is Reinforcing...";
                break;
            case Turn.PlayerState.Attack:
                updateText = "Player '" + CurrentPlayer.displayName + "' is Attacking...";
                break;
            case Turn.PlayerState.Foritfy:
                updateText = "Player '" + CurrentPlayer.displayName + "' is Fortifying...";
                break;
        }

        PlayerStatusTextMesh.text = updateText;
    }
}