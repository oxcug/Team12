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

    public PlayerController[] Players;
    public TerritoryController[] Territories;
    public TextMesh PlayerStatusTextMesh;

    public GameObject PrefabBasicArmy;

    public Turn CurrentTurn { get; private set; }

    private const string _MinimumPlayersErrorMessage = "Minimum players should be > 1.";
    private int _CurrentPlayerIndex;
    private List<Turn> _PreviousTurns = new List<Turn>();
    private static RiskGameManager _SharedMgr;

    public static RiskGameManager Shared()
    {
        return _SharedMgr;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Validate players
        if (Players.Length <= 1)
        {
            Debug.LogError(_MinimumPlayersErrorMessage);
        }

        // Initialize the player armies...
        foreach (PlayerController player in Players)
        {
            List<ArmyController> defaultArmies = new List<ArmyController>();
            for (int i = 0; i < 1; ++i)
            {
                GameObject basicArmyCopy = Instantiate<GameObject>(PrefabBasicArmy);
                ArmyController armyController = basicArmyCopy.GetComponent<ArmyController>();
                defaultArmies.Add(armyController);
            }

            player.Armies = defaultArmies.ToArray();
        }

        // Initialize first turn
        CurrentTurn = new Turn
        {
            Player = Players[0]
        };
    }

    public GameState CurrentGameState()
    {
        return GameState.ChooseTerritories;
    }

    private void Update()
    {
        _SharedMgr = this;

        //
        /// This is the fundamental game logic for our turn based strategy game.
        /// It ensures we rotate through each player, updating our state as we go.
        /// 
        if (CurrentTurn.Completed)
        {

            // move current turn to "previous turns"
            _PreviousTurns.Add(CurrentTurn);
            Turn LastTurn = _PreviousTurns[_PreviousTurns.Count - 1];

            // increment the current player index (looping where necessary)
            _CurrentPlayerIndex++;
            if (_CurrentPlayerIndex > Players.Length)
            {
                _CurrentPlayerIndex = 0;
            }

            PlayerController nextPlayer = Players[_CurrentPlayerIndex];

            // and setup the next turn.
            CurrentTurn = new Turn
            {
                Player = nextPlayer
            };
        }

        // Perform GUI Updates
        string updateText = "";

        switch (CurrentTurn.CurrentPlayerState())
        {
            case Turn.PlayerState.ChooseTerritory:
                updateText = "Player '" + CurrentTurn.Player.displayName + "' is picking a Territory...";
                break;
            case Turn.PlayerState.Reinforce:
                updateText = "Player '" + CurrentTurn.Player.displayName + "' is Reinforcing...";
                break;
            case Turn.PlayerState.Attack:
                updateText = "Player '" + CurrentTurn.Player.displayName + "' is Attacking...";
                break;
            case Turn.PlayerState.Foritfy:
                updateText = "Player '" + CurrentTurn.Player.displayName + "' is Fortifying...";
                break;
        }

        PlayerStatusTextMesh.text = updateText;
    }
}