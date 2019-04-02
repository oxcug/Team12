using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryController : MonoBehaviour
{
    public Territory Territory;
    public TerritoryController[] AdjacentTerritories;
    public ArmyController Army;

    void Update()
    {
        if (Army)
        {
            Army.transform.position = transform.position;
        }
    }
}
