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

    // Start is called before the first frame update
    void Start()
    {
        Completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.SelectedTerritory)
        {
            if (RiskGameManager.Shared().CurrentGameState() == RiskGameManager.GameState.ChooseTerritories)
            {
                Completed = true;
            }
            else
            {
            }
        }
    }
}
