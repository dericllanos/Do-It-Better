using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Master_Pushup : MonoBehaviour
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
    public int initial5 = 0;
    public int error_count = 0;
    public int goodsquat = 0;
    public int goodstand = 0;
    public int squat_count = 0;
    public int stand_count = 0;
    public int flat = 0;
    public int totalreps = 0;

    public float uphead, upshouldercenter,
            upshoulderleft, upshoulderright,
            readyhandleft, readyhandright,
            upelbowlefty, upelbowrighty;

    public float neck_ecc, hip_ecc, knee_ecc,
            neck_con, hip_con, knee_con,
            neck_rt, hip_rt, knee_rt;

    public double angle_rt, angle_ecc, angle_con;

    public float dist_neckhip_ecc, dist_hipknee_ecc, dist_neckknee_ecc,
            dist_neckhip_con, dist_hipknee_con, dist_neckknee_con;

    public float elbowleft_ecc, elbowright_ecc,
            elbowleft_con, elbowright_con,
            elbowleft_rt, elbowright_rt,
            goodelbowleft_ecc, goodelbowright_ecc,
            goodelbowleft_con, goodelbowright_con;

    public Text textelbowleft_rt, textelbowright_rt,
            textgoodelbowleft_ecc, textgoodelbowright_ecc,
            textgoodelbowleft_con, textgoodelbowright_con;

    public float goodneck_ecc, goodhip_ecc, goodknee_ecc,
            goodneck_con, goodhip_con, goodknee_con;

    public Text textgoodneck_ecc, textgoodhip_ecc, textgoodknee_ecc,
            textgoodneck_con, textgoodhip_con, textgoodknee_con,
            textneck_rt, texthip_rt, textknee_rt,
            textangle_ecc, textangle_con, textangle_rt;

    public float hipdown, neckdown, kneedown;

    public float wristupright, wristupleft;

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
            hipleftz, hiprightz, handleftx, handrightx;

    float shouldercenterz, kneeleftz, kneerightz;

    float initkneeleftz, initkneerightz;

    public Text textheady, textshouldercentery, textshoulderleftx,
            textshoulderrightx, textankleleftx, textanklerightx,
            texthipcenterz, texthipcentery, texthipleftx, texthiprightx;

    float initheady, initheadz, initshouldercentery, initshoulderleftx, initshoulderlefty,
            initshoulderrightx, initshoulderrighty, inithipcentery, inithipcenterz,
            initelbowleftx, initelbowlefty, initelbowrightx, initelbowrighty,
            initwristleftx, initwristlefty, initwristrightx, initwristrighty,
            inithipleftx, inithiplefty, inithiprightx, inithiprighty,
            initkneeleftx, initkneelefty, initkneerightx, initkneerighty,
            initankleleftx, initanklelefty, initanklerightx, initanklerighty, initshouldercenterz;

    public Text textinitheady, textinitshouldercentery, textinitshoulderleftx,
            textinitshoulderrightx, textinitankleleftx, textinitanklerightx,
            textinithipcenterz, textinithipcentery, textinithipleftx, textinithiprightx;

    float inithandlefty, inithandrighty, handlefty, handrighty;

    public bool running;

    public Text texthipdown, textneckdown, textkneedown,
            texthipdownrt, textneckdownrt, textkneedownrt;

    public Text no1st, no2st, no3st,
            no4st, no5st, no6st;

    public Text no1sq, no2sq, no3sq,
            no4sq, no5sq, no6sq;

    public Text goodreps, badreps,
            reps, comment, status;

    public Text total;

    public Text textgoodhip, textgoodneck, textgoodknee;

    public Text angleText, angleTextrt;

    public Text directions, encouragement;

    public GameObject detect_user;
    public GameObject cover;

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

        handrightx = Hand_Right.transform.position.x;
        handleftx = Hand_Left.transform.position.x;
        handlefty = Hand_Left.transform.position.y;
        handrighty = Hand_Right.transform.position.y;

        shouldercenterz = Shoulder_Center.transform.position.z;
        kneeleftz = Knee_Left.transform.position.z;

        var velbowleft_rt = Shoulder_Left.transform.position;
        var vneck_rt = Shoulder_Center.transform.position;
        var velbowright_rt = Shoulder_Right.transform.position;

        elbowleft_rt = velbowleft_rt.magnitude;
        neck_rt = vneck_rt.magnitude;
        elbowright_rt = velbowright_rt.magnitude;

        textelbowleft_rt.text = string.Format("{0:0.00}", elbowleft_rt);
        textneck_rt.text = string.Format("{0:0.00}", neck_rt);
        textelbowright_rt.text = string.Format("{0:0.00}", elbowright_rt);

        CalcDistanceRT();
    }

    public void CalcDistanceRT()
    {
        var heading_neckelbowleft = (Shoulder_Center.transform.position - Elbow_Left.transform.position);
        var heading_neckelbowright = (Shoulder_Center.transform.position - Elbow_Right.transform.position);
        var heading_elbowleftright = (Elbow_Left.transform.position - Elbow_Right.transform.position);

        float dist_neckelbowleft_rt = heading_neckelbowleft.magnitude;
        float dist_neckelbowright_rt = heading_neckelbowright.magnitude;
        float dist_elbowleftright_rt = heading_elbowleftright.magnitude;

        float angleTanrt = (dist_elbowleftright_rt / dist_neckelbowleft_rt);
        double anglert = Mathf.Atan(angleTanrt);
        angle_rt = anglert * (180 / Math.PI);

        textangle_rt.text = string.Format("{0:0.00}°", angle_rt);

        if (squat_count < 1)
        {
            if (angle_rt >= angle_ecc && angle_ecc != 0 && (elbowrightx - elbowleftx < ((shoulderrightx - shoulderleftx) * 2)))
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
            if (angle_rt <= angle_con * 1.1 && angle_rt != 0)
            {
                textangle_rt.color = Color.green;
            }
            else
            {
                textangle_rt.color = Color.white;
            }
        }
    }

    public void Storegoodrow()
    {
        if (initial3 == 0)
        {
            var heading_neckelbowleft = (Shoulder_Center.transform.position - Elbow_Left.transform.position);
            var heading_neckelbowright = (Shoulder_Center.transform.position - Elbow_Right.transform.position);
            var heading_elbowleftright = (Elbow_Left.transform.position - Elbow_Right.transform.position);

            float dist_neckelbowleft_ecc = heading_neckelbowleft.magnitude;
            float dist_neckelbowright_ecc = heading_neckelbowright.magnitude;
            float dist_elbowleftright_ecc = heading_elbowleftright.magnitude;

            var vgoodelbowleft_ecc = Shoulder_Left.transform.position;
            var vgoodneck_ecc = Shoulder_Center.transform.position;
            var vgoodelbowright_ecc = Shoulder_Right.transform.position;

            goodelbowleft_ecc = vgoodelbowleft_ecc.magnitude;
            goodneck_ecc = vgoodneck_ecc.magnitude;
            goodelbowright_ecc = vgoodelbowright_ecc.magnitude;

            float angleTan = (dist_elbowleftright_ecc / dist_neckelbowleft_ecc);
            double angle = Mathf.Atan(angleTan);
            angle_ecc = angle * (180 / Math.PI);

            textangle_ecc.text = string.Format("{0:0.00}°", angle_ecc); ;

            textgoodelbowleft_ecc.text = string.Format("{0:0.00}", goodelbowleft_ecc);
            textgoodneck_ecc.text = string.Format("{0:0.00}", goodneck_ecc);
            textgoodelbowright_ecc.text = string.Format("{0:0.00}", goodelbowright_ecc);

            initial3++;
        }
    }

    public void Storegooddrop()
    {
        if (initial4 == 0)
        {
            var heading_neckelbowleft = (Shoulder_Center.transform.position - Elbow_Left.transform.position);
            var heading_neckelbowright = (Shoulder_Center.transform.position - Elbow_Right.transform.position);
            var heading_elbowleftright = (Elbow_Left.transform.position - Elbow_Right.transform.position);

            float dist_neckelbowleft_con = heading_neckelbowleft.magnitude;
            float dist_neckelbowright_con = heading_neckelbowright.magnitude;
            float dist_elbowleftright_con = heading_elbowleftright.magnitude;

            var vgoodelbowleft_con = Shoulder_Left.transform.position;
            var vgoodneck_con = Shoulder_Center.transform.position;
            var vgoodelbowright_con = Shoulder_Right.transform.position;

            goodelbowleft_con = vgoodelbowleft_con.magnitude;
            goodneck_con = vgoodneck_con.magnitude;
            goodelbowright_con = vgoodelbowright_con.magnitude;

            float angleTan = (dist_elbowleftright_con / dist_neckelbowleft_con);
            double angle = Mathf.Atan(angleTan);
            angle_con = angle * (180 / Math.PI);

            textangle_con.text = string.Format("{0:0.00}°", angle_con);

            textgoodelbowleft_con.text = string.Format("{0:0.00}", goodelbowleft_con);
            textgoodneck_con.text = string.Format("{0:0.00}", goodneck_con);
            textgoodelbowright_con.text = string.Format("{0:0.00}", goodelbowright_con);

            initial4++;
        }
    }

    public void StoreReady()
    {
        if (initial5 == 0)
        {
            uphead = Head.transform.position.y;

            upelbowlefty = Elbow_Left.transform.position.y;
            upelbowrighty = Elbow_Right.transform.position.y;

            upshouldercenter = Shoulder_Center.transform.position.y;
            upshoulderleft = Shoulder_Left.transform.position.y;
            upshoulderright = Shoulder_Right.transform.position.y;

            readyhandleft = Hand_Left.transform.position.x;
            readyhandright = Hand_Right.transform.position.x;

            initial5++;
        }
    }

    public void Storehipdown()
    {
        if (initial2 == 0)
        {
            wristupright = Wrist_Right.transform.position.y;
            wristupleft = Wrist_Left.transform.position.y;

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

            initshouldercenterz = Shoulder_Center.transform.position.z;
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

    public void Evaluate_Push()
    {
        //Posture, Feet Distance, Feet Planted, Hip-Hinge 
        var head = (heady < shouldercentery * 1.5 && heady > shouldercentery * 0.5); //Good Posture
        var arms_extended = (shouldercentery >= upshouldercenter * 0.89); //Feet Shoulder Width
        //var hands_same = ((handleftx < readyhandleft * 1.6 && handleftx > readyhandleft * 0.4) && (handrightx < readyhandright * 1.6 && handrightx > readyhandright * 0.4));
        //Wrists dropped and not spread out too far

        if ((head && arms_extended) || goodstand > 0)
        {
            goodstand++;
            no1st.color = Color.green;
            no2st.color = Color.green;
            //no3st.color = Color.green;

            error_count = 0;
            Storegooddrop();
        }

        else
        {
            if (head)
            {
                no1st.color = Color.green;
            }
            else
            {
                no1st.color = Color.red;
                directions.text = "Keep your head neutral.";
                encouragement.text = "...";
                error_count++;
            }

            if (arms_extended)
            {
                no2st.color = Color.green;
            }
            else
            {
                no2st.color = Color.red;
                directions.text = "Fully extend your arms at the top.";
                //audio
                encouragement.text = "...";
                error_count++;
            }
            /*
            if (hands_same)
            {
                no3st.color = Color.green;
            }
            else
            {
                no3st.color = Color.red;
                directions.text = "Keep your hands in the same place.";
                encouragement.text = "...";
                error_count++;
            }
            */
        }
        if (error_count > 1)
        {
            directions.text = "You got multiple things wrong that time.";
            encouragement.text = "Let's look at the checklist.";

            count = 0;
        }
    }

    public void Evaluate_Drop()
    {
        //Posture, Feet Distance, Feet Planted, Knees Outward, Squat Depth 
        var head = (heady < shouldercentery * 1.5 && heady > shouldercentery * 0.5); //Good Posture
        var hand_distance = (wristrightx - wristleftx <= (shoulderrightx - shoulderleftx) * 1.8); //Feet Shoulder Width
        var chest_level = (shouldercentery <= upshouldercenter * 0.82); //Hips out
        var elbow_flair = (elbowrightx - elbowleftx <= (shoulderrightx - shoulderleftx) * 2.2);
        //Elbows pulled back and not spread out too far

        if ((head && hand_distance && chest_level && elbow_flair) || goodsquat > 0)
        {
            goodsquat++;
            no1sq.color = Color.green;
            no2sq.color = Color.green;
            no3sq.color = Color.green;
            no4sq.color = Color.green;

            error_count = 0;
            Storegoodrow();
        }

        else
        {
            if (head)
            {
                no1sq.color = Color.green;
            }
            else
            {
                no1sq.color = Color.red;
                directions.text = "Keep your head in neutral.";
                encouragement.text = "...";
                error_count++;
            }

            if (hand_distance)
            {
                no2sq.color = Color.green;
            }
            else
            {
                no2sq.color = Color.red;
                directions.text = "Hands shouldn't be too far form your shoulders.";
                encouragement.text = "...";
                error_count++;
            }

            if (chest_level)
            {
                no3sq.color = Color.green;
            }
            else
            {
                no3sq.color = Color.red;
                directions.text = "Bring your chest to the ground without disengaging your arms and chest.";
                encouragement.text = "...";
                error_count++;
            }

            if (elbow_flair)
            {
                no4sq.color = Color.green;
            }
            else
            {
                no4sq.color = Color.red;
                directions.text = "Keep your elbows tucked to your sides.";
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
                    // Grounded
                    if (wristlefty <= initanklelefty * 1.05 && wristrighty <= initanklerighty * 1.05)
                    {
                        cover.SetActive(false);
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
                        // ECCENTRIC
                        if (wristrightx - wristleftx <= (shoulderrightx - shoulderleftx) * 2)
                        {
                            StoreReady();

                            directions.text = "You're on the right path.";
                            encouragement.text = "...";                           

                            // Threshold for Minium Squat-depth
                            // Hip height < Knee height means the user is probably crouching or sitting down
                            if ((shouldercentery < upshouldercenter * 0.84) && (stand_count < 1))
                            {
                                //Default_stand();

                                //Storehipdown();

                                directions.text = "Slowly return to your starting position.";

                                // Squat evaluation
                                Evaluate_Drop();
                                error_count = 0;

                                squat_count++;

                                // Hip height > % of Threshold
                                // Shoulder-center >= Initial height of Shoulder-center when you were standing
                                // Basically coming back up from the squat
                            }
                            else
                            {
                                directions.text = "Slowly lower your chest to the ground.";
                                encouragement.text = "Don't flair out your elbows.";
                            }

                            // CONCENTRIC
                            if ((squat_count > 0) && (shouldercentery > upshouldercenter * 0.89))
                            {
                                subcounter++;
                                //Default_squat();

                                // Stand evaluation
                                Evaluate_Push();
                                //error_count = 0;

                                stand_count++;
                                Debug.Log(subcounter);
                            }
                            else
                            {
                                directions.text = "Push upward through your hands.";
                                encouragement.text = "You should also feel your chest squeezing.";
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
                                    encouragement.text = "Please return to starting position.";
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
                            directions.text = "Place your hands at around the width of your shoulders.";
                            encouragement.text = "Don't place your hands too far from your chest.";                            
                        }

                    }

                    else
                    {
                        directions.text = "Please crouch down and put your hands on the ground.";
                        encouragement.text = "Place theme where your feet were.";
                        cover.SetActive(true);
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
                initial5 = 0;
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
        //no3st.color = Color.grey;
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
        //no3st.color = Color.green;

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
        textgoodelbowleft_con.text = "...";
        textgoodelbowleft_ecc.text = "...";

        textgoodneck_con.text = "...";
        textgoodneck_ecc.text = "...";

        textgoodelbowright_con.text = "...";
        textgoodelbowright_ecc.text = "...";

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
