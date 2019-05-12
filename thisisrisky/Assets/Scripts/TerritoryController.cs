using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryController : MonoBehaviour
{
    public Territory Territory;
    public TerritoryController[] AdjacentTerritories;

    public bool Occupied
    {
        get
        {
            return RiskGameManager.Shared().LookupOccuantForTerritory(this) != null;
        }
    }

    public PlayerController Player
    {
        get
        {
            return RiskGameManager.Shared().LookupOccuantForTerritory(this).Player;
        }
    }

    private void Start()
    {
        RiskGameManager.Shared().RegisterTerritory(this);
    }

    private void OnMouseEnter()
    {
        if (Territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            Territory.highlightMode = TerritoryHighlightMode.PlayerHover;
        }
    }

    private void OnMouseDown()
    {
        if (Territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            PlayerController player = RiskGameManager.Shared().CurrentTurn.Player;

            if (player.SelectedTerritory == this)
            {
                player.SelectedTerritory = null;
            }
            else
            {
                player.SelectedTerritory = this;
            }
        }
    }

    private void OnMouseExit()
    {
        if (Territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            Territory.highlightMode = TerritoryHighlightMode.None;
        }
    }
}
