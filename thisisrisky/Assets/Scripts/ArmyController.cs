using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyController : MonoBehaviour
{
    Army Troop;

    public TerritoryController Location;

    public PlayerController Player;

    public bool Assignable
    {
        get
        {
            return Location == null;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        RiskGameManager.Shared().RegisterArmy(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Location)
        {
            transform.position = Location.transform.position;
        }
    }

    private void OnDestroy()
    {
        RiskGameManager.Shared().UnregisterArmy(this);
    }
}
