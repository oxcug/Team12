using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerController : PlayerController
{
    public new void Update()
    {
        base.Update();
    }

    private void OnMouseUp()
    {
        if (RiskGameManager.Shared().CurrentTurn.Player == this)
        {
            if (SelectedTerritory.Territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
            {
                SelectedTerritory.Territory.highlightMode = TerritoryHighlightMode.PlayerSelected;
            }
            else
            {
                SelectedTerritory.Territory.highlightMode = TerritoryHighlightMode.PlayerHover;
            }
        }
    }


    private void OnMouseUp()
    {
        if (RiskGameManager.Shared().CurrentTurn.Player == this)
        {
            if (Territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
            {
                Territory.highlightMode = TerritoryHighlightMode.PlayerSelected;
                RiskGameManager.Shared().CurrentTurn.Player.SelectedTerritory = this;
            }
            else
            {
                Territory.highlightMode = TerritoryHighlightMode.PlayerHover;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (Territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            Territory.highlightMode = TerritoryHighlightMode.PlayerHover;
        }
    }

    private void OnMouseExit()
    {
        if (Territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            Territory.highlightMode = TerritoryHighlightMode.None;
            RiskGameManager.Shared().CurrentTurn.Player.SelectedTerritory = this;
        }
    }
}
