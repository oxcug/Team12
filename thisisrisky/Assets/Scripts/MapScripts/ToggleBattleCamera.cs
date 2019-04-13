using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBattleCamera : MonoBehaviour
{
    public Camera MainCamera;
    public Camera BattleCamera;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        MainCamera.enabled = true;
        BattleCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleCamera()
    {
        if (MainCamera.enabled)
        {
            BattleCamera.enabled = true;
            MainCamera.enabled = false;
        }
        else if (!MainCamera.enabled)
        {
            BattleCamera.enabled = false;
            MainCamera.enabled = true;
        }
    }
}
