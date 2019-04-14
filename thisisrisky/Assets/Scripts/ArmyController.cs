using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyController : MonoBehaviour
{
    public Army Troop;

    public TerritoryController Location;

    public bool Assignable
    {
        get
        {
            return Location == null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Location)
        {
            transform.position = Location.transform.position;
        }
    }
}
