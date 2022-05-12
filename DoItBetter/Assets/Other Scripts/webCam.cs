using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class webCam : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture tex;

    public RawImage display;

    public void Start()
    {
        var CurrentScene = SceneManager.GetActiveScene();

        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
        }

        if (tex != null)
        {
            display.texture = null;
            tex.Stop();
            tex = null;
        }

        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
        }   
    }

    public void StopCam()
    {
        if (tex.isPlaying)
        {
            tex.Stop();
        }
    }

    private void Update()
    {
  
    }
}
