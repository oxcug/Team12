using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerController : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        if (GameManager.Shared().CurrentTurn.player == this) {
            if (selectedTerritory.territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
            {
                selectedTerritory.territory.highlightMode = TerritoryHighlightMode.PlayerSelected;
            }
            else
            {
                selectedTerritory.territory.highlightMode = TerritoryHighlightMode.PlayerHover;
            }
        }
    }
}
