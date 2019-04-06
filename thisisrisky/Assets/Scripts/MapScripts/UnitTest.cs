using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTest : MonoBehaviour
{

    public int UnitCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        UnitCount++;
        Debug.Log("Unit Count: " + UnitCount);
    }

    public void Subtract()
    {
        UnitCount--;
        Debug.Log("Unit Count: " + UnitCount);
    }
}
