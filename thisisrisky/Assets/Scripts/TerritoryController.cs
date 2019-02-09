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

    private void OnMouseEnter()
    {
        territory.highlightMode = TerritoryHighlightMode.PlayerHover;
    }

    private void OnMouseExit()
    {
        territory.highlightMode = TerritoryHighlightMode.None;
    }
}
