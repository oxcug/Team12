using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent : MonoBehaviour
{
    public TerritoryController[] ChildTerritories
    {
        get
        {
            return GetComponentsInChildren<TerritoryController>();
        }
    }

    public uint BonusValue;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
