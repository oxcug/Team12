using UnityEngine;

public class Turn
{ 
    
    public enum PlayerState
    {
        ChooseTerritory,
        Reinforce,
        Attack,
        Foritfy
    }
    
    public PlayerController Player { get; private set; }

    public bool Completed;

    //private PlayerState _PlayerState = PlayerState.ChooseTerritory;

    public PlayerState CurrentPlayerState()
    {
        if (RiskGameManager.Shared().CurrentGameState() == RiskGameManager.GameState.ChooseTerritories)
        {
            return PlayerState.ChooseTerritory;
        }
        else if (Player.UnassignedArmies.Length > 0)
        {
            return PlayerState.Reinforce;
        }
        else if (Player.Reinforcing)
        {
            return PlayerState.Attack;
        }
        else
        {
            return PlayerState.Foritfy;
        }
    }

    public Turn(PlayerController playerController)
    {
        Player = playerController;
        Completed = false;

        // if this is a reinforce turn, then distribute the bonus armies
        if (CurrentPlayerState() == PlayerState.Reinforce)
        {
            Player.AddArmies(BonusArmyValueFromContinents + NormalArmyValueFromOwnedTerritories);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Player.SelectedTerritory)
        {
            switch (CurrentPlayerState())
            {
                case PlayerState.ChooseTerritory:
                    // During the choose territory phase, all players have "infinite" armies until the map is full.
                    if (Player.UnassignedArmies.Length == 0)
                    {
                        Player.AddArmies(1);
                    }

                    // fallthrough to placing logic...
                    goto case PlayerState.Reinforce;

                case PlayerState.Reinforce:

                    // if the user has selected their territory, advance the game state.
                    if (Player.PlaceUnassignedArmyAtTerritory(Player.SelectedTerritory))
                    {
                        // reset the player selected territory after turn is finished.
                        Player.SelectedTerritory = null;
                        Completed = true;
                        Debug.Log("Assigned Army to territory " + Player.SelectedTerritory + " for player " + Player);
                    }
                    break;
                    
                case PlayerState.Attack:
                    break;
                case PlayerState.Foritfy:
                    break;
            }
        }
        else
        {

        }
    }

    private uint BonusArmyValueFromContinents
    {
        get
        {
            uint total = 0;

            foreach (Continent continent in Player.OwnedContinents)
            {
                total += continent.BonusValue;
            }

            return total;
        }
    }

    private uint NormalArmyValueFromOwnedTerritories
    {
        get
        {
            return (uint)Mathf.Floor(Player.OwnedTerritories.Length / 3);
        }
    }
}
