using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName != "PerformScreen_Squat")
        {
            Invoke("FadeIn", 3.0f);
        } 
    }
    public void Update()
    {
        Cursor.lockState = CursorLockMode.None;      
    }

    public void Prev()
    {
        SceneManager.LoadScene("SelectScreen");
    }
    public void FadeIn()
    {
        GameObject.Find("view").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("select_screen").transform.localScale = new Vector3(1, 1, 1);
        //GameObject.Find("Continue").transform.localScale = new Vector3(1, 1, 1);    
    }
}
