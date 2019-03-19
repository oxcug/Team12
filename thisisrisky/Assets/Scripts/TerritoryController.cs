using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryController : MonoBehaviour
{
    public Territory territory;
    public TerritoryController[] adjacentTerritories;
    public TerritoryController[] childTerritories;
    public ArmyController army;

    // Start is called before the first frame update
    void Start()
    {
        army.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            territory.highlightMode = TerritoryHighlightMode.PlayerSelected;
        }
        else
        {
            territory.highlightMode = TerritoryHighlightMode.PlayerHover;
        }
    }

    private void OnMouseEnter()
    {
        if (territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            territory.highlightMode = TerritoryHighlightMode.PlayerHover;
        }
    }

    private void OnMouseExit()
    {
        if (territory.highlightMode != TerritoryHighlightMode.PlayerSelected)
        {
            territory.highlightMode = TerritoryHighlightMode.None;
        }
    }
}
