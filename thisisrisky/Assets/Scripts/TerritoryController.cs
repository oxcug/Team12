using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryController : MonoBehaviour
{
    public Territory Territory;
    public TerritoryController[] AdjacentTerritories;

    void Update()
    {
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
