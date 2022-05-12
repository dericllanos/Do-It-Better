using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Master_Raise : MonoBehaviour
{
    AudioSource audioData;

    public Image gif;
    public RawImage webcam;

    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;

    public int count = 0;
    public int pos_count = 0;
    public int good = 0;
    public int bad = 0;
    public int repcount = 0;
    public int subcounter = 0;
    public int initial = 0;
    public int initial2 = 0;
    public int initial3 = 0;
    public int initial4 = 0;
    public int error_count = 0;
    public int goodsquat = 0;
    public int goodstand = 0;
    public int squat_count = 0;
    public int stand_count = 0;
    public int flat = 0;
    public int totalreps = 0;

    public float neck_ecc, hip_ecc, knee_ecc,
            neck_con, hip_con, knee_con,
            neck_rt, hip_rt, knee_rt,
            wristl_rt, wristr_rt;

    public double angle_rt, angle_ecc, angle_con;

    public float dist_neckhip_ecc, dist_hipknee_ecc, dist_neckknee_ecc,
            dist_neckhip_con, dist_hipknee_con, dist_neckknee_con,
            dist_neckwristl_con, dist_neckwristr_con, dist_wristwrist_con,
            dist_neckwristl_ecc, dist_neckwristr_ecc, dist_wristwrist_ecc,
            dist_neckwristl_rt, dist_neckwristr_rt, dist_wristwrist_rt;

    public float goodneck_ecc, goodhip_ecc, goodknee_ecc,
            goodneck_con, goodhip_con, goodknee_con,
            goodwristl_con, goodwristr_con,
            goodwristl_ecc, goodwristr_ecc;

    public Text textgoodneck_ecc, textgoodwristl_ecc, textgoodwristr_ecc,
            textgoodneck_con, textgoodwristl_con, textgoodwristr_con,
            textneck_rt, textwristl_rt, textwristr_rt,
            textangle_ecc, textangle_con, textangle_rt;

    public float hipdown, neckdown, kneedown;

    public float goodhip, goodneck, goodknee;

    public float trueangle, trueanglert;

    float height_left, height_right;

    float heady, headz, shouldercentery, shoulderleftx, shoulderlefty,
            shoulderrightx, shoulderrighty, hipcentery, hipcenterz,
            elbowleftx, elbowlefty, elbowrightx, elbowrighty,
            wristleftx, wristlefty, wristrightx, wristrighty,
            hipleftx, hiplefty, hiprightx, hiprighty,
            kneeleftx, kneelefty, kneerightx, kneerighty,
            ankleleftx, anklelefty, anklerightx, anklerighty,
            hipleftz, hiprightz;

    float shouldercenterz, kneeleftz, kneerightz;

    float initkneeleftz, initkneerightz;

    public Text textheady, textshouldercentery, textshoulderleftx,
            textshoulderrightx, textankleleftx, textanklerightx,
            texthipcenterz, texthipcentery, texthipleftx, texthiprightx;

    public float magnitude, rt_distance_posture, init_distance_posture,
            rt_distance_kneesbentleft, init_distance_kneesunbentleft,
            rt_distance_kneesbentright, init_distance_kneesunbentright,
            rt_distance_feetright, init_distance_feetright,
            rt_distance_feetleft, init_distance_feetleft,
            rt_distance_extensionleft, init_distance_extensionleft,
            rt_distance_extensionright, init_distance_extensionright,
            rt_distance_alignmentleft, init_distance_alignmentleft,
            rt_distance_alignmentright, init_distance_alignmentright,
            rt_distance_shoulderwidth, init_distance_shoulderwidth,
            rt_distance_anklewidth, init_distance_anklewidth;

    float initheady, initheadz, initshouldercentery, initshoulderleftx, initshoulderlefty,
            initshoulderrightx, initshoulderrighty, inithipcentery, inithipcenterz,
            initelbowleftx, initelbowlefty, initelbowrightx, initelbowrighty,
            initwristleftx, initwristlefty, initwristrightx, initwristrighty,
            inithipleftx, inithiplefty, inithiprightx, inithiprighty,
            initkneeleftx, initkneelefty, initkneerightx, initkneerighty,
            initankleleftx, initanklelefty, initanklerightx, initanklerighty;

    public Text textinitheady, textinitshouldercentery, textinitshoulderleftx,
            textinitshoulderrightx, textinitankleleftx, textinitanklerightx,
            textinithipcenterz, textinithipcentery, textinithipleftx, textinithiprightx;

    float inithandlefty, inithandrighty, handlefty, handrighty;

    public bool running;

    public Text texthipdown, textneckdown, textkneedown,
            texthipdownrt, textneckdownrt, textkneedownrt;

    public Text no1st, no2st, no3st;

    public Text no1sq, no2sq, no3sq,
            no4sq;

    public Text goodreps, badreps,
            reps, comment, status;

    public Text total;

    public Text directions, encouragement;

    public GameObject detect_user;

    public GameObject Head;
    public GameObject Shoulder_Center;
    public GameObject Shoulder_Left;
    public GameObject Shoulder_Right;
    public GameObject Elbow_Left;
    public GameObject Elbow_Right;
    public GameObject Wrist_Left;
    public GameObject Wrist_Right;
    public GameObject Hand_Left;
    public GameObject Hand_Right;
    public GameObject Hip_Center;
    public GameObject Hip_Left;
    public GameObject Hip_Right;
    public GameObject Knee_Left;
    public GameObject Knee_Right;
    public GameObject Ankle_Left;
    public GameObject Ankle_Right;

    // Invoke Coordinates every Half-Second
    public void Start()
    {
        InvokeRepeating("Coordinates", 0.5f, 0.5f);

        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    // Audio Play 
    public void AudioPlayCorrect()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    public void AudioPlayIncorrect()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(1);
    }

    // Rep Analysis per Frame
    public void Update()
    {
        StartCoroutine(Counter());

        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }

    public void Coordinates()
    {
        heady = Head.transform.position.y;
        headz = Head.transform.position.z;

        shouldercentery = Shoulder_Center.transform.position.y;
        shoulderleftx = Shoulder_Left.transform.position.x;
        shoulderlefty = Shoulder_Left.transform.position.y;
        shoulderrightx = Shoulder_Right.transform.position.x;
        shoulderrighty = Shoulder_Right.transform.position.y;

        elbowleftx = Elbow_Left.transform.position.x;
        elbowlefty = Elbow_Left.transform.position.y;
        elbowrightx = Elbow_Right.transform.position.x;
        elbowrighty = Elbow_Right.transform.position.y;

        wristleftx = Wrist_Left.transform.position.x;
        wristlefty = Wrist_Left.transform.position.y;
        wristrightx = Wrist_Right.transform.position.x;
        wristrighty = Wrist_Right.transform.position.y;

        hipcentery = Hip_Center.transform.position.y;
        hipcenterz = Hip_Center.transform.position.z;
        hipleftx = Hip_Left.transform.position.x;
        hiplefty = Hip_Left.transform.position.y;
        hipleftz = Hip_Left.transform.position.z;
        hiprightx = Hip_Right.transform.position.x;
        hiprighty = Hip_Right.transform.position.y;
        hiprightz = Hip_Right.transform.position.z;

        kneeleftx = Knee_Left.transform.position.x;
        kneelefty = Knee_Left.transform.position.y;
        kneeleftz = Knee_Left.transform.position.z;
        kneerightx = Knee_Right.transform.position.x;
        kneerighty = Knee_Right.transform.position.y;
        kneerightz = Knee_Right.transform.position.z;

        ankleleftx = Ankle_Left.transform.position.x;
        anklelefty = Ankle_Left.transform.position.y;
        anklerightx = Ankle_Right.transform.position.x;
        anklerighty = Ankle_Right.transform.position.y;

        handlefty = Hand_Left.transform.position.y;
        handrighty = Hand_Right.transform.position.y;

        textheady.text = string.Format("{0:0.00}", heady);
        textshouldercentery.text = string.Format("{0:0.00}", shouldercentery);
        textshoulderleftx.text = string.Format("{0:0.00}", shoulderleftx);
        textshoulderrightx.text = string.Format("{0:0.00}", shoulderrightx);
        textankleleftx.text = string.Format("{0:0.00}", ankleleftx);
        textanklerightx.text = string.Format("{0:0.00}", anklerightx);
        texthipcenterz.text = string.Format("{0:0.00}", hipcenterz);
        texthipcentery.text = string.Format("{0:0.00}", hipcentery);
        texthipleftx.text = string.Format("{0:0.00}", hipleftx);
        texthiprightx.text = string.Format("{0:0.00}", hiprightx);

        shouldercenterz = Shoulder_Center.transform.position.z;
        kneeleftz = Knee_Left.transform.position.z;

        var rt_heading_extensionright = Shoulder_Right.transform.position - Wrist_Right.transform.position;
        float rt_distance_extensionright = rt_heading_extensionright.magnitude;

        var rt_heading_extensionleft = Shoulder_Left.transform.position - Wrist_Left.transform.position;
        float rt_distance_extensionleft = rt_heading_extensionleft.magnitude;

        var vneck_rt = Shoulder_Center.transform.position;
        var vwristl_rt = Wrist_Left.transform.position;
        var vwristr_rt = Wrist_Right.transform.position;

        neck_rt = vneck_rt.magnitude;
        wristl_rt = vwristl_rt.magnitude;
        wristr_rt = vwristr_rt.magnitude;

        textneck_rt.text = string.Format("{0:0.00}", neck_rt);
        textwristl_rt.text = string.Format("{0:0.00}", wristl_rt);
        textwristr_rt.text = string.Format("{0:0.00}", wristr_rt);

        CalcDistanceRT();
    }

    public void CalcDistanceRT()
    {
        var heading_neckwristl = (Shoulder_Center.transform.position - Wrist_Left.transform.position);
        var heading_wristwrist = (Wrist_Right.transform.position - Wrist_Left.transform.position);
        var heading_neckwristr = (Shoulder_Center.transform.position - Wrist_Right.transform.position);

        float dist_neckwristl_rt = heading_neckwristl.magnitude;
        float dist_wristwrist_rt = heading_wristwrist.magnitude;
        float dist_neckwristr_rt = heading_neckwristr.magnitude;

        float angleTanrt = (dist_wristwrist_rt / dist_neckwristl_rt);
        double anglert = Mathf.Atan(angleTanrt);
        angle_rt = anglert * (180 / Math.PI);

        textangle_rt.text = string.Format("{0:0.00}°", angle_rt);

        if (squat_count < 1)
        {
            if (angle_rt <= angle_con && angle_con != 0)
            {
                textangle_rt.color = Color.green;
            }
            else
            {
                textangle_rt.color = Color.white;
            }
        }
        else if (squat_count > 1)
        {
            if (angle_rt > angle_con && angle_rt >= angle_ecc * 0.95 && angle_ecc != 0)
            {
                textangle_rt.color = Color.green;
            }
            else
            {
                textangle_rt.color = Color.white;
            }
        }
    }

    public void Storegooddrop()
    {
        if (initial3 == 0)
        {
            var heading_neckwristl = (Shoulder_Center.transform.position - Wrist_Left.transform.position);
            var heading_wristwrist = (Wrist_Right.transform.position - Wrist_Left.transform.position);
            var heading_neckwristr = (Shoulder_Center.transform.position - Wrist_Right.transform.position);

            float dist_neckwristl_ecc = heading_neckwristl.magnitude;
            float dist_wristwrist_ecc = heading_wristwrist.magnitude;
            float dist_neckwristr_ecc = heading_neckwristr.magnitude;

            var vgoodneck_ecc = Shoulder_Center.transform.position;
            var vgoodwristl_ecc = Wrist_Left.transform.position;
            var vgoodwristr_ecc = Wrist_Right.transform.position;

            float goodneck_ecc = vgoodneck_ecc.magnitude;
            float goodwristl_ecc = vgoodwristl_ecc.magnitude;
            float goodwristr_ecc = vgoodwristr_ecc.magnitude;

            float angleTan = (dist_wristwrist_ecc / dist_neckwristl_ecc);
            double angle = Mathf.Atan(angleTan);
            angle_ecc = angle * (180 / Math.PI);

            textangle_ecc.text = string.Format("{0:0.00}°", angle_ecc);

            textgoodwristl_ecc.text = string.Format("{0:0.00}", goodwristl_ecc);
            textgoodneck_ecc.text = string.Format("{0:0.00}", goodneck_ecc);
            textgoodwristr_ecc.text = string.Format("{0:0.00}", goodwristr_ecc);

            initial3++;
        }
    }

    public void Storegoodstand()
    {
        if (initial4 == 0)
        {
            var heading_neckwristl = (Shoulder_Center.transform.position - Wrist_Left.transform.position);
            var heading_wristwrist = (Wrist_Right.transform.position - Wrist_Left.transform.position);
            var heading_neckwristr = (Shoulder_Center.transform.position - Wrist_Right.transform.position);

            float dist_neckwristl_con = heading_neckwristl.magnitude;
            float dist_wristwrist_con = heading_wristwrist.magnitude;
            float dist_neckwristr_con = heading_neckwristr.magnitude;

            var vgoodneck_con = Shoulder_Center.transform.position;
            var vgoodwristl_con = Wrist_Left.transform.position;
            var vgoodwristr_con = Wrist_Right.transform.position;

            float goodneck_con = vgoodneck_con.magnitude;
            float goodwristl_con = vgoodwristl_con.magnitude;
            float goodwristr_con = vgoodwristr_con.magnitude;

            float angleTan = (dist_wristwrist_con / dist_neckwristl_con);
            double angle = Mathf.Atan(angleTan);
            angle_con = angle * (180 / Math.PI);

            textangle_con.text = string.Format("{0:0.00}°", angle_con);

            textgoodwristl_con.text = string.Format("{0:0.00}", goodwristl_con);
            textgoodneck_con.text = string.Format("{0:0.00}", goodneck_con);
            textgoodwristr_con.text = string.Format("{0:0.00}", goodwristr_con);

            initial4++;
        }
    }

    public void Storehipdown()
    {
        if (initial2 == 0)
        {
            hipdown = Hip_Center.transform.position.z;
            neckdown = Shoulder_Center.transform.position.z;
            kneedown = Knee_Left.transform.position.z;

            initial2++;
        }
        texthipdown.text = string.Format("{0:0.00}", hipdown);
        textneckdown.text = string.Format("{0:0.00}", neckdown);
        textkneedown.text = string.Format("{0:0.00}", kneedown);
    }

    public void Initialize()
    {
        if (initial == 0)
        {
            initheady = Head.transform.position.y;
            initheadz = Head.transform.position.z;

            initshouldercentery = Shoulder_Center.transform.position.y;
            initshoulderleftx = Shoulder_Left.transform.position.x;
            initshoulderlefty = Shoulder_Left.transform.position.y;
            initshoulderrightx = Shoulder_Right.transform.position.x;
            initshoulderrighty = Shoulder_Right.transform.position.y;

            initelbowleftx = Elbow_Left.transform.position.x;
            initelbowlefty = Elbow_Left.transform.position.y;
            initelbowrightx = Elbow_Right.transform.position.x;
            initelbowrighty = Elbow_Right.transform.position.y;

            initwristleftx = Wrist_Left.transform.position.x;
            initwristlefty = Wrist_Left.transform.position.y;
            initwristrightx = Wrist_Right.transform.position.x;
            initwristrighty = Wrist_Right.transform.position.y;

            inithipcentery = Hip_Center.transform.position.y;
            inithipcenterz = Hip_Center.transform.position.z;
            inithipleftx = Hip_Left.transform.position.x;
            inithiplefty = Hip_Left.transform.position.y;
            inithiprightx = Hip_Right.transform.position.x;
            inithiprighty = Hip_Right.transform.position.y;

            initkneeleftx = Knee_Left.transform.position.x;
            initkneelefty = Knee_Left.transform.position.y;
            initkneeleftz = Knee_Left.transform.position.z;
            initkneerightx = Knee_Right.transform.position.x;
            initkneerighty = Knee_Right.transform.position.y;
            initkneerightz = Knee_Right.transform.position.z;

            initankleleftx = Ankle_Left.transform.position.x;
            initanklelefty = Ankle_Left.transform.position.y;
            initanklerightx = Ankle_Right.transform.position.x;
            initanklerighty = Ankle_Right.transform.position.y;

            inithandlefty = Hand_Left.transform.position.y;
            inithandrighty = Hand_Right.transform.position.y;

            var init_heading_extensionright = Shoulder_Right.transform.position - Wrist_Right.transform.position;
            float init_distance_extensionright = init_heading_extensionright.magnitude;

            var init_heading_extensionleft = Shoulder_Left.transform.position - Wrist_Left.transform.position;
            float init_distance_extensionleft = init_heading_extensionleft.magnitude;

            initial++;
        }
        textinitheady.text = string.Format("{0:0.00}", initheady);
        textinitshouldercentery.text = string.Format("{0:0.00}", initshouldercentery);
        textinitshoulderleftx.text = string.Format("{0:0.00}", initshoulderleftx);
        textinitshoulderrightx.text = string.Format("{0:0.00}", initshoulderrightx);
        textinitankleleftx.text = string.Format("{0:0.00}", initankleleftx);
        textinitanklerightx.text = string.Format("{0:0.00}", initanklerightx);
        textinithipcenterz.text = string.Format("{0:0.00}", inithipcenterz);
        textinithipcentery.text = string.Format("{0:0.00}", inithipcentery);
        textinithipleftx.text = string.Format("{0:0.00}", inithipleftx);
        textinithiprightx.text = string.Format("{0:0.00}", inithiprightx);
    }

    public void Evaluate_Down()
    {
        //Posture, Feet Distance, Feet Planted, Hip-Hinge 
        var posture_down = (heady - shouldercentery >= (initheady - initshouldercentery) * 0.9); //Good Posture
        var distance_down = (anklerightx - ankleleftx <= (shoulderrightx - shoulderleftx * 1.3)); //Feet Shoulder Width
        var arms_down = (wristlefty <= initwristlefty * 1.05 && wristrighty <= initwristrighty * 1.05); //arms down

        if ((posture_down && distance_down && arms_down) || goodstand > 0)
        {
            goodstand++;
            no1st.color = Color.green;
            no2st.color = Color.green;
            no3st.color = Color.green;

            error_count = 0;
            Storegoodstand();
        }

        else
        {
            if (posture_down)
            {
                no1st.color = Color.green;
            }
            else
            {
                no1st.color = Color.red;
                directions.text = "Mind your posture.";
                encouragement.text = "...";
                error_count++;
            }

            if (distance_down)
            {
                no2st.color = Color.green;
            }
            else
            {
                no2st.color = Color.red;
                directions.text = "Feet should be around shoulder width apart,";
                encouragement.text = "...";
                error_count++;
            }

            if (arms_down)
            {
                no3st.color = Color.green;
            }
            else
            {
                no3st.color = Color.red;
                directions.text = "Bring your arms back down.";
                encouragement.text = "...";
                error_count++;
            }
        }
        if (error_count > 1)
        {
            directions.text = "You got multiple things wrong that time.";
            encouragement.text = "Let's look at the checklist.";

            count = 0;
        }
    }

    public void Evaluate_Raise()
    {
        //Posture, Feet Distance, Feet Planted, Knees Outward, Squat Depth 
        var posture_raise = (heady - shouldercentery >= (initheady - initshouldercentery) * 0.9); //Good Posture
        var distance_raise = (anklerightx - ankleleftx <= (shoulderrightx - shoulderleftx * 1.3)); //Feet Shoulder Width
        var arms_raise = ((wristlefty >= shoulderlefty * 0.95 && wristlefty <= shouldercentery) && (wristrighty >= shoulderrighty * 0.95 && wristrighty <= shouldercentery) 
                            && (wristleftx <= ankleleftx * 1.2 && wristrightx >= anklerightx * 1.2)); //Arm Placement
        var extend_raise = ((rt_distance_extensionleft >= init_distance_extensionleft * 0.9) && (rt_distance_extensionright >= init_distance_extensionright * 0.9)); //Extensions

        if ((posture_raise && distance_raise && arms_raise && extend_raise) || goodsquat > 0)
        {
            goodsquat++;
            no1sq.color = Color.green;
            no2sq.color = Color.green;
            no3sq.color = Color.green;
            no4sq.color = Color.green;

            error_count = 0;
            Storegooddrop();
        }

        else
        {
            if (posture_raise)
            {
                no1sq.color = Color.green;
            }
            else
            {
                no1sq.color = Color.red;
                directions.text = "Mind your posture.";
                encouragement.text = "...";
                error_count++;
            }

            if (distance_raise)
            {
                no2sq.color = Color.green;
            }
            else
            {
                no2sq.color = Color.red;
                directions.text = "Feet should be around shoulder width apart.";
                encouragement.text = "...";
                error_count++;
            }

            if (arms_raise)
            {
                no3sq.color = Color.green;
            }
            else
            {
                no3sq.color = Color.red;
                directions.text = "Don't raise your arms farther than your neck.";
                encouragement.text = "...";
                error_count++;
            }

            if (extend_raise)
            {
                no4sq.color = Color.green;
            }
            else
            {
                no4sq.color = Color.red;
                directions.text = "Keep your arms extended.";
                encouragement.text = "...";
                error_count++;
            }
        }
        if (error_count > 1)
        {
            directions.text = "You got multiple things wrong that time.";
            encouragement.text = "Let's look at the checklist.";

            count = 0;
        }
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(0.5f);
        running = true;

        // Infinite Loop
        if (running == true)
        {
            // Find User
            if (hipleftz != 0 && hiprightz != 0)
            {
                detect_user.gameObject.SetActive(false);

                directions.text = "Wait a second.";

                // Initial User-Skeleton as Basis for Conditions
                Invoke("Initialize", 1.0f);

                if (good < 10)
                {
                    // Ankle-distance >= Shoulder-distance before Starting
                    if ((anklerightx - ankleleftx) <= (shoulderrightx - shoulderleftx * 1.3))
                    {
                        // Initial Directions || Every Rep after
                        if (good == 0)
                        {
                            directions.text = "Begin the exercise.";
                            encouragement.text = "...";
                        }
                        else
                        {
                            directions.text = "Do that again.";
                            encouragement.text = "...";
                        }

                        // Shoulder-Center height < % of Initial Shoulder-Center height
                        // Hip-Center (Butt) was pushed out
                        // Hip-Center height < % of Initial Hip-Center height
                        // Basically, starting the Squat Motion.
                        // CONCENTRIC
                        if ((wristrighty >= shoulderrighty * 0.95 && wristrighty <= heady) && (wristlefty >= shoulderlefty * 0.95 && wristlefty <= heady) && (stand_count < 1))
                        {
                            directions.text = "You're on the right path.";
                            encouragement.text = "...";

                            Evaluate_Raise();
                            error_count = 0;

                            squat_count++;
                        }

                        // ECCENTRIC
                        if ((squat_count > 0) && (wristrighty <= initwristrighty * 1.1 && wristlefty <= initwristlefty * 1.1))
                        {
                            subcounter++;
                            //Default_squat();

                            // Stand evaluation
                            Evaluate_Down();
                            //error_count = 0;

                            stand_count++;
                        }
                        else
                        {
                            directions.text = "Start the exercise.";
                            encouragement.text = "Raise your arms sideways until they're parralel to the ground.";
                        }

                        // Counter that limits the update speed
                        // Based on current FPS
                        // Reset counter to 0 so it isn't infinite    
                        //if (subcounter > 30 && (squat_count == 1 && stand_count == 1))    
                        if (subcounter >= fps && (squat_count > 0 && stand_count > 0))
                        {
                            //FPS
                            subcounter = 0;

                            // Perfect Squat & Stand = Perfect rep
                            // Else Bad rep
                            if ((goodsquat > 0 && goodstand > 0) && (error_count == 0))
                            {
                                good++;
                                directions.text = "Good job!";
                                encouragement.text = "Please return to standing position.";
                                AudioPlayCorrect();
                                //yield return new WaitForSeconds(1.0f); 

                                Default_lift();
                                Default_stand();

                                //Show_perfect();

                                //reps.text = repcount.ToString();
                                reps.text = good.ToString();
                                //badreps.text = bad.ToString();       

                                error_count = 0;
                                squat_count = 0;
                                stand_count = 0;
                                goodsquat = 0;
                                goodstand = 0;
                                flat = 0;
                            }
                            else //if ((!((goodsquat + goodstand) % 2 == 0) && (goodsquat != 0) && (goodstand != 0)) && (bad > 0))
                            {
                                bad++;
                                directions.text = "Let's try that again.";
                                encouragement.text = "You can do better than that!";
                                //AudioPlayIncorrect();

                                Default_lift();
                                Default_stand();

                                error_count = 0;
                                squat_count = 0;
                                stand_count = 0;
                                goodsquat = 0;
                                goodstand = 0;
                                flat = 0;
                            }
                            // Only increase total rep count after both evaluations
                            // Basically after completing the Rep (Squat & Stand)
                            //repcount++;
                            initial2 = 0;
                            totalreps++;
                            total.text = totalreps.ToString();
                        }
                    }

                    else
                    {
                        directions.text = "Please stand with your feet shoulder width apart.";
                        encouragement.text = "...";
                    }
                }
                else
                {
                    // After completing 10 reps
                    // Try again if imperfect
                    // Praise if perfect
                    GameObject.Find("evaluation").transform.localScale = new Vector3(1, 1, 1);
                    if (bad > 0 && bad <= 4)
                    {
                        comment.text = "You're getting better!";
                        comment.color = Color.yellow;
                    }
                    else if (bad >= 5)
                    {
                        comment.text = "Let's keep improving!";
                        comment.color = Color.red;
                    }
                    else
                    {
                        comment.text = "Perfect! You have mastered the exercise!";
                        comment.color = Color.green;
                    }
                }
            }
            else
            {
                // Re-Initialize
                initial = 0;
                Default_stand();
                Default_lift();

                if (good != 10)
                {
                    detect_user.gameObject.SetActive(true);
                    status.text = "No User";
                }
            }
        }
    }

    // View Functionality
    public static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    public void Squat_Pos()
    {
        pos_count++;
        if (IsOdd(pos_count))
        {
            GameObject.Find("keypoints_view_stand").transform.localPosition = new Vector3(240, -530, 0);
            GameObject.Find("keypoints_view_squat").transform.localPosition = new Vector3(240, 63, 0);
        }
        else
        {
            GameObject.Find("keypoints_view_stand").transform.localPosition = new Vector3(240, 63, 0);
            GameObject.Find("keypoints_view_squat").transform.localPosition = new Vector3(240, -530, 0);
        }
    }

    public void Default_stand()
    {
        no1st.color = Color.grey;
        no2st.color = Color.grey;
        no3st.color = Color.grey;
    }

    public void Default_lift()
    {
        no1sq.color = Color.grey;
        no2sq.color = Color.grey;
        no3sq.color = Color.grey;
        no4sq.color = Color.grey;
    }

    public void Show_perfect()
    {
        no1st.color = Color.green;
        no2st.color = Color.green;
        no3st.color = Color.green;

        no1sq.color = Color.green;
        no2sq.color = Color.green;
        no3sq.color = Color.green;
        no4sq.color = Color.green;
    }

    public void Toggle_View()
    {
        count++;
        if (IsOdd(count))
        {
            GameObject.Find("acceptable").transform.localPosition = new Vector3(1000, 70, 0);
            GameObject.Find("coordinate_view").transform.localPosition = new Vector3(500, 20, 0);
        }
        else
        {
            GameObject.Find("acceptable").transform.localPosition = new Vector3(500, 70, 0);
            GameObject.Find("coordinate_view").transform.localPosition = new Vector3(1000, 20, 0);
        }
    }

    public void Toggle()
    {
        count++;
        if (IsOdd(count))
        {
            gif.enabled = true;
            webcam.enabled = false;
        }
        else
        {
            gif.enabled = false;
            webcam.enabled = true;
        }
    }

    public void Redo()
    {
        textgoodwristl_con.text = "...";
        textgoodwristl_ecc.text = "...";

        textgoodwristr_con.text = "...";
        textgoodwristr_ecc.text = "...";

        textgoodneck_con.text = "...";
        textgoodneck_ecc.text = "...";

        textangle_con.text = "...";
        textangle_ecc.text = "...";
    }

    public void Retry()
    {
        bad = 0;
        good = 0;
        reps.text = good.ToString();
        Redo();
        GameObject.Find("evaluation").transform.localScale = new Vector3(0, 0, 0);
    }
    public void Giveup()
    {
        GameObject.Find("evaluation").transform.localScale = new Vector3(0, 0, 0);
    }
}
