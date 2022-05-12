using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chose : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1;
    }   
    public void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void IntroSquat()
    {
        SceneManager.LoadScene("IntroScreen_Squat");
    }
    public void PerformSquat()
    {
        SceneManager.LoadScene("PerformScreen_Squat");
    }

    public void IntroDeadlift()
    {
        SceneManager.LoadScene("IntroScreen_Deadlift");
    }
    public void PerformDeadlift()
    {
        SceneManager.LoadScene("PerformScreen_Deadlift");
    }

    public void IntroWood()
    {
        SceneManager.LoadScene("IntroScreen_Wood");
    }
    public void PerformWood()
    {
        SceneManager.LoadScene("PerformScreen_Wood");
    }

    public void IntroPushup()
    {
        SceneManager.LoadScene("IntroScreen_Pushup");
    }
    public void PerformPushup()
    {
        SceneManager.LoadScene("PerformScreen_Pushup");
    }

    public void IntroLunge()
    {
        SceneManager.LoadScene("IntroScreen_Lunge");
    }
    public void PerformLunge()
    {
        SceneManager.LoadScene("PerformScreen_ReverseLunge");
    }

    public void IntroRow()
    {
        SceneManager.LoadScene("IntroScreen_Row");
    }
    public void PerformRow()
    {
        SceneManager.LoadScene("PerformScreen_BentoverRow");      
    }

    public void IntroRaise()
    {
        SceneManager.LoadScene("IntroScreen_Lateral");
    }
    public void PerformRaise()
    {
        SceneManager.LoadScene("PerformScreen_Lateral");
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
