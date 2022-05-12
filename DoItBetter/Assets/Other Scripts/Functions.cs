using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour
{
    public bool running;
    public bool stand;
    public GUIText CalibrationText;

    public Text Textreps, Textsets;
    public int sets = 0;
    public int counter = 0;
    public int reps = 0;

    public Text warning, warning1, announcement, reminder;

    public Text Textvaluex, Textvaluey, Textvaluez,
                Textkvaluex, Textkvaluey, Textkvaluez,
                Textavaluex, Textavaluey, Textavaluez,
                Textshvaluex;

    public Text Textvaluexr, Textvalueyr, Textvaluezr,
                Textkvaluexr, Textkvalueyr, Textkvaluezr,
                Textavaluexr, Textavalueyr, Textavaluezr,
                Textshvaluexr;

    float valuex, valuey, valuez,
          kvaluex, kvaluey, kvaluez,
          avaluex, avaluey, avaluez,
          shvaluex;

    float valuexr, valueyr, valuezr,
          kvaluexr, kvalueyr, kvaluezr,
          avaluexr, avalueyr, avaluezr,
          shvaluexr;

    public GameObject Hip_Left;
    public GameObject Knee_Left;
    public GameObject Ankle_Left;
    public GameObject Hip_Right;
    public GameObject Knee_Right;
    public GameObject Ankle_Right;
    public GameObject Shoulder_Right;
    public GameObject Shoulder_Left;

    public void Start()
    {
        // Reminders
        warning.text = "Keep your feet planted flat on the ground throughout the exercise.";
        warning1.text = "Always keep your chest lifted and head in neutral.";
        InvokeRepeating("Coordinates", 0.5f, 0.5f);
    }

    public void Update()
    {
        StartCoroutine(RepCounter());
    }

    public void Coordinates()
    { 
            valuex = Hip_Left.transform.position.x;
            valuey = Hip_Left.transform.position.y;
            valuez = Hip_Left.transform.position.z;
            kvaluex = Knee_Left.transform.position.x;
            kvaluey = Knee_Left.transform.position.y;
            kvaluez = Knee_Left.transform.position.z;
            avaluex = Ankle_Left.transform.position.x;
            avaluey = Ankle_Left.transform.position.y;
            avaluez = Ankle_Left.transform.position.z;

            shvaluex = Shoulder_Left.transform.position.x;
            shvaluexr = Shoulder_Right.transform.position.x;

            Textvaluex.text = valuex.ToString();
            Textvaluey.text = valuey.ToString();
            Textvaluez.text = valuez.ToString();
            Textkvaluex.text = kvaluex.ToString();
            Textkvaluey.text = kvaluey.ToString();
            Textkvaluez.text = kvaluez.ToString();
            Textavaluex.text = avaluex.ToString();
            Textavaluey.text = avaluey.ToString();
            Textavaluez.text = avaluez.ToString();

            Textshvaluex.text = shvaluex.ToString();
            Textshvaluexr.text = shvaluexr.ToString();

            valuexr = Hip_Right.transform.position.x;
            valueyr = Hip_Right.transform.position.y;
            valuezr = Hip_Right.transform.position.z;
            kvaluexr = Knee_Right.transform.position.x;
            kvalueyr = Knee_Right.transform.position.y;
            kvaluezr = Knee_Right.transform.position.z;
            avaluexr = Ankle_Right.transform.position.x;
            avalueyr = Ankle_Right.transform.position.y;
            avaluezr = Ankle_Right.transform.position.z;

            Textvaluexr.text = valuexr.ToString();
            Textvalueyr.text = valueyr.ToString();
            Textvaluezr.text = valuezr.ToString();
            Textkvaluexr.text = kvaluexr.ToString();
            Textkvalueyr.text = kvalueyr.ToString();
            Textkvaluezr.text = kvaluezr.ToString();
            Textavaluexr.text = avaluexr.ToString();
            Textavalueyr.text = avalueyr.ToString();
            Textavaluezr.text = avaluezr.ToString();
    }

    IEnumerator RepCounter()
    {
        // Gives the user time to read the opening reminder
        // Reminders are key points in the exercise that can't be  
        // fully addressed by the kinect v1 due to it's limitations
        yield return new WaitForSeconds(5f);
      
        running = true;

        reminder.gameObject.SetActive(false);
        warning.text = "";
        warning1.text = "";

        stand = true;

        if (running == true)
        {
            
            // Check if User is detected (by default, left and right hip x == 0)
            if (valuex != 0 && valuexr != 0)
            {
                announcement.text = "User Found.";

                //  Check if user is standing at or near shoulder width apart
                // && (((shvaluexr - shvaluex) - (avaluexr - avaluex)) <= (((shvaluexr - shvaluex) - (avaluexr - avaluex)) / 2))
                if ((avaluexr - avaluex) >= (shvaluexr - shvaluex))
                {
                    warning.text = "Try the exercise.";
                    warning1.text = "...";

                    announcement.text = "";
                    //yield return new WaitForSeconds(1f);

                    // Check if squat form is correct
                    // Hips near enough to ankles while staying above or at knee level
                    if ((valuey - avaluey <= 0.389 && valueyr - avalueyr >= 0.378) && (valuey >= kvaluey && valueyr >= kvalueyr))
                    {  
                        warning.text = "Good job!";
                        warning1.text = "Please return to standing position.";
                        stand = false;

                        // Count successful reps
                        if (stand == false)
                        {
                            counter = counter + 1;
                            
                            if (counter > 30)
                            {
                                counter = 0;                                
                                reps = reps + 1;

                                // 1 Set = 15 Reps
                                if (reps > 15)
                                {
                                    sets = sets + 1;
                                    reps = 0;

                                    // Reaching the 4th Set is considered as completing the exercise
                                    if (sets > 3)
                                    {
                                        announcement.text = "CONGRATULATIONS ON COMPLETING THE EXERCISE!";
                                    }
                                }
                            }
                        }
                        Textreps.text = reps.ToString();
                        Textsets.text = sets.ToString();
                    }
                    else
                    {
                        // Hips are too far away from ankles (Knees arent considered as bent) Vertical
                        if (valuey - avaluey > 0.7 && valueyr - avalueyr > 0.7)
                        {             
                            warning.text = "Start off with bending your knees.";                              
                        }
                        else
                        {                    
                            warning.text = "Bend your knees more.";
                            warning1.text = "You're not working hard enough.";
                              
                            // Hips are too far from knees (Not low enough to be considered a good rep) Vertical
                            if (valuey - kvaluey > 0.4 && valueyr - kvalueyr > 0.4)
                            {                 
                                warning1.text = "Push your butt out.";  
                            }
                            else
                            {
                                warning.text = "Push your butt out more.";
                                warning1.text = "You're almost there.";     
                            }
                        }
                    }
                }
                else
                {
                    warning.text = "Please stand with your feet approximately shoulder width apart.";
                    warning1.text = "...";    
                }
            }
            else
            {
                //announcement.text = "No Users Detected.";
            }
        }
    }
}