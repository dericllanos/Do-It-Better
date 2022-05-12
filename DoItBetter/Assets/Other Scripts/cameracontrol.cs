using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    public int count = 0;

    public Camera MainCamera;
    public Camera SideCam;

    // Call this function to disable __FPS__ camera,
    // and enable overhead camera.
    public void ShowSide()
    {
        MainCamera.enabled = false;
        SideCam.enabled = true;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFront()
    {
        MainCamera.enabled = true;
        SideCam.enabled = false;
    }

    public static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            count++;
            if (IsOdd(count))
            {
                ShowSide();
            }
            else
            {
                ShowFront();
            }
        }
    }
}