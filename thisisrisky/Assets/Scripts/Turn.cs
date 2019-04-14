using UnityEngine;

public class Turn : Object
{ 
    
    public enum PlayerState
    {
        ChooseTerritory,
        Reinforce,
        Attack,
        Foritfy
    }
    
    public PlayerController Player;

    public bool Completed;

    //private PlayerState _PlayerState = PlayerState.ChooseTerritory;

    public PlayerState CurrentPlayerState()
    {
        if (RiskGameManager.Shared().CurrentGameState() == RiskGameManager.GameState.ChooseTerritories)
        {
            return PlayerState.ChooseTerritory;
        }
        else
        {
            return PlayerState.Reinforce;
        }
    }

    public Turn()
    {
        Completed = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Player.SelectedTerritory)
        {
            if (RiskGameManager.Shared().CurrentGameState() == RiskGameManager.GameState.ChooseTerritories)
            {
                // if the user has selected their territory, advance the game state.
                Player.PlaceUnassignedArmyAtTerritory(Player.SelectedTerritory);
                Player.SelectedTerritory = null; // reset the player selected territory after turn is finished.
                Completed = true;
                Debug.Log("Assigned Army to territory " + Player.SelectedTerritory + " for player " + Player);
            }
            else
            {
            }
        }
    }
}
