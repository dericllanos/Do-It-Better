using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Master_ReverseLunge : MonoBehaviour
{
    AudioSource audioData;

    public Image gif;
    public RawImage webcam;

    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;

    public int left = 0;
    public int right = 0;
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
    public int checker = 0;
    public int totalreps = 0;

    public float hipleft_ecc, kneeleft_ecc, ankleleft_ecc,
           hipleft_con, kneeleft_con, ankleleft_con,
           hipleft_rt, kneeleft_rt, ankleleft_rt;

    public float hipright_ecc, kneeright_ecc, ankleright_ecc,
          hipright_con, kneeright_con, ankleright_con,
          hipright_rt, kneeright_rt, ankleright_rt;

    public double angle_rt, angle_ecc, angle_con;

    public float dist_kneehipleft_ecc, dist_kneeankleleft_ecc, dist_hipankleleft_ecc,
            dist_kneehipleft_con, dist_kneeankleleft_con, dist_hipankleleft_con;

    public float dist_kneehipright_ecc, dist_kneeankleright_ecc, dist_hipankleright_ecc,
            dist_kneehipright_con, dist_kneeankleright_con, dist_hipankleright_con;

    public float goodhip_ecc, goodknee_ecc, goodankle_ecc,
            goodhip_con, goodknee_con, goodankle_con;

    public Text textgoodhip_ecc, textgoodknee_ecc, textgoodankle_ecc,
            textgoodhip_con, textgoodknee_con, textgoodankle_con,
            texthip_rt, textknee_rt, textankle_rt,
            textangle_ecc, textangle_con, textangle_rt;

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
            rt_distance_anklewidth, init_distance_anklewidth,
            rt_distance_kneewidth;

    public float hipdown, neckdown, kneedown;

    public float neck_ecc, hip_ecc, knee_ecc,
            neck_con, hip_con, knee_con,
            neck_rt, hip_rt, knee_rt;

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
            hipleftz, hiprightz, handrightx, handleftx, hipcenterx;

    float shouldercenterz, shouldercenterx, kneeleftz, kneerightz;

    float initkneeleftz, initkneerightz, initshouldercenterx;

    public Text textheady, textshouldercentery, textshoulderleftx,
            textshoulderrightx, textankleleftx, textanklerightx,
            texthipcenterz, texthipcentery, texthipleftx, texthiprightx;

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

    public Text no1st, no2st, no3st,
            no4st, no5st, no6st;

    public Text no1sq, no2sq, no3sq,
            no4sq, no5sq, no6sq, no7sq;

    public Text goodreps, badreps,
            reps, comment, status;

    public Text total;

    public Text textgoodhip, textgoodneck, textgoodknee;

    public Text angleText, angleTextrt;

    public Text directions, encouragement;

    public Text side;

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
    public GameObject Foot_Left;
    public GameObject Foot_Right;

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

        shouldercenterx = Shoulder_Center.transform.position.x;
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

        hipcenterx = Hip_Center.transform.position.x;
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
        handleftx = Hand_Left.transform.position.x;
        handrightx = Hand_Right.transform.position.x;

        shouldercenterz = Shoulder_Center.transform.position.z;
        kneeleftz = Knee_Left.transform.position.z;

        /*
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
        texthipdownrt.text = string.Format("{0:0.00}", hipcenterz);
        textneckdownrt.text = string.Format("{0:0.00}", shouldercenterz);
        textkneedownrt.text = string.Format("{0:0.00}", kneeleftz);

        var rt_heading_posture = Head.transform.position - Shoulder_Center.transform.position;
        float rt_distance_posture = rt_heading_posture.magnitude;

        var rt_heading_kneesbentleft = Hip_Left.transform.position - Ankle_Left.transform.position;
        float rt_distance_kneesbentleft = rt_heading_kneesbentleft.magnitude;

        var rt_heading_kneesbentright = Hip_Right.transform.position - Ankle_Right.transform.position;
        float rt_distance_kneesbentright = rt_heading_kneesbentright.magnitude;

        var rt_heading_feetright = Ankle_Right.transform.position - Foot_Right.transform.position;
        float rt_distance_feetright = rt_heading_feetright.magnitude;

        var rt_heading_feetleft = Ankle_Left.transform.position - Foot_Left.transform.position;
        float rt_distance_feetleft = rt_heading_feetleft.magnitude;

        var rt_heading_extensionright = Shoulder_Right.transform.position - Hand_Right.transform.position;
        float rt_distance_extensionright = rt_heading_extensionright.magnitude;

        var rt_heading_extensionleft = Shoulder_Left.transform.position - Hand_Left.transform.position;
        float rt_distance_extensionleft = rt_heading_extensionleft.magnitude;

        var rt_heading_alignmentright = Shoulder_Center.transform.position - Hand_Right.transform.position;
        float rt_distance_alignmentright = rt_heading_alignmentright.magnitude;

        var rt_heading_alignmentleft = Shoulder_Center.transform.position - Hand_Right.transform.position;
        float rt_distance_alignmentleft = rt_heading_alignmentleft.magnitude;

        var rt_heading_shoulderwidth = Shoulder_Right.transform.position - Shoulder_Left.transform.position;
        float rt_distance_shoulders = rt_heading_shoulderwidth.magnitude;

        var rt_heading_anklewidth = Ankle_Right.transform.position - Ankle_Left.transform.position;
        float rt_distance_ankles = rt_heading_anklewidth.magnitude;

        var rt_heading_kneewidth = Knee_Right.transform.position - Knee_Left.transform.position;
        float rt_distance_kneewidth = rt_heading_kneewidth.magnitude;
        */


        if (right > 0 && left < 1)
        {
            var vhipright_rt = Hip_Right.transform.position;
            var vkneeright_rt = Knee_Right.transform.position;
            var vankleright_rt = Ankle_Right.transform.position;

            float hipright_rt = vhipright_rt.magnitude;
            float kneeright_rt = vkneeright_rt.magnitude;
            float ankleright_rt = vankleright_rt.magnitude;

            texthip_rt.text = string.Format("{0:0.00}", hipright_rt);
            textknee_rt.text = string.Format("{0:0.00}", kneeright_rt);
            textankle_rt.text = string.Format("{0:0.00}", ankleright_rt);

            texthip_rt.color = Color.cyan;
            textknee_rt.color = Color.cyan;
            textankle_rt.color = Color.cyan;
        }
        else if (left > 0 && right < 1)
        {
            var vhipleft_rt = Hip_Left.transform.position;
            var vkneeleft_rt = Knee_Left.transform.position;
            var vankleleft_rt = Ankle_Left.transform.position;

            float hipleft_rt = vhipleft_rt.magnitude;
            float kneeleft_rt = vkneeleft_rt.magnitude;
            float ankleleft_rt = vankleleft_rt.magnitude;

            texthip_rt.text = string.Format("{0:0.00}", hipleft_rt);
            textknee_rt.text = string.Format("{0:0.00}", kneeleft_rt);
            textankle_rt.text = string.Format("{0:0.00}", ankleleft_rt);

            texthip_rt.color = Color.magenta;
            textknee_rt.color = Color.magenta;
            textankle_rt.color = Color.magenta;
        }

        CalcDistanceRT();
    }

    public void CalcDistanceRT()
    {
        if (right > 0 && left < 1)
        {
            var heading_kneehip = (Knee_Right.transform.position - Hip_Right.transform.position);
            var heading_kneeankle = (Knee_Right.transform.position - Ankle_Right.transform.position);
            var heading_hipankle = (Hip_Right.transform.position - Ankle_Right.transform.position);

            float dist_kneehip_rt = heading_kneehip.magnitude;
            float dist_kneeankle_rt = heading_kneeankle.magnitude;
            float dist_hipankle_rt = heading_hipankle.magnitude;

            float angleTanrt = (dist_hipankle_rt / dist_kneeankle_rt);
            float anglert = Mathf.Atan(angleTanrt);
            double angle_rt = anglert * (180 / Math.PI);

            textangle_rt.text = string.Format("{0:0.00}°", angle_rt);

            if (squat_count < 1)
            {
                if (angle_rt >= angle_ecc && angle_ecc != 0 && checker > 1)
                {
                    textangle_rt.color = Color.green;
                }
                else
                {
                    textangle_rt.color = Color.white;
                }
            }
            else if (squat_count > 0)
            {
                if (angle_rt > angle_ecc && angle_rt >= angle_con * 0.9 && angle_con != 0 && checker > 1)
                {
                    textangle_rt.color = Color.green;
                }
                else
                {
                    textangle_rt.color = Color.white;
                }
            }
        }
        else if (left > 0 && right < 1)
        {
            var heading_kneehip = (Knee_Left.transform.position - Hip_Left.transform.position);
            var heading_kneeankle = (Knee_Left.transform.position - Ankle_Left.transform.position);
            var heading_hipankle = (Hip_Left.transform.position - Ankle_Left.transform.position);

            float dist_kneehip_rt = heading_kneehip.magnitude;
            float dist_kneeankle_rt = heading_kneeankle.magnitude;
            float dist_hipankle_rt = heading_hipankle.magnitude;

            float angleTanrt = (dist_hipankle_rt / dist_kneeankle_rt);
            float anglert = Mathf.Atan(angleTanrt);
            double angle_rt = anglert * (180 / Math.PI);

            textangle_rt.text = string.Format("{0:0.00}°", angle_rt);

            if (squat_count < 1)
            {
                if (angle_rt >= angle_ecc && angle_ecc != 0 && checker > 1)
                {
                    textangle_rt.color = Color.green;
                }
                else
                {
                    textangle_rt.color = Color.white;
                }
            }
            else if (squat_count > 0)
            {
                if (angle_rt > angle_ecc && angle_rt >= angle_con * 0.9 && angle_con != 0 && checker > 1)
                {
                    textangle_rt.color = Color.green;
                }
                else
                {
                    textangle_rt.color = Color.white;
                }
            }
        }
    }

    public void Storegoodlunge()
    {
        if (initial3 == 0)
        {
            if (right > 0 && left < 1)
            {
                var heading_kneehip = (Knee_Right.transform.position - Hip_Right.transform.position);
                var heading_kneeankle = (Knee_Right.transform.position - Ankle_Right.transform.position);
                var heading_hipankle = (Hip_Right.transform.position - Ankle_Right.transform.position);

                float dist_kneehip_ecc = heading_kneehip.magnitude;
                float dist_kneeankle_ecc = heading_kneeankle.magnitude;
                float dist_hipankle_ecc = heading_hipankle.magnitude;

                var vgoodhip_ecc = Hip_Right.transform.position;
                var vgoodknee_ecc = Knee_Right.transform.position;
                var vgoodankle_ecc = Ankle_Right.transform.position;

                float goodknee_ecc = vgoodknee_ecc.magnitude;
                float goodhip_ecc = vgoodhip_ecc.magnitude;
                float goodankle_ecc = vgoodankle_ecc.magnitude;

                float angleTan = (dist_hipankle_ecc / dist_kneeankle_ecc);
                float angle = Mathf.Atan(angleTan);
                angle_ecc = angle * (180 / Math.PI);

                textangle_ecc.text = string.Format("{0:0.00}°", angle_ecc); ;

                textgoodhip_ecc.text = string.Format("{0:0.00}", goodhip_ecc);
                textgoodknee_ecc.text = string.Format("{0:0.00}", goodknee_ecc);
                textgoodankle_ecc.text = string.Format("{0:0.00}", goodankle_ecc);

                initial3++;

                textgoodhip_ecc.color = Color.cyan;
                textgoodknee_ecc.color = Color.cyan;
                textgoodankle_ecc.color = Color.cyan;
                textangle_ecc.color = Color.cyan;
            }
            else if (left > 0 && right < 1)
            {
                var heading_kneehip = (Knee_Left.transform.position - Hip_Left.transform.position);
                var heading_kneeankle = (Knee_Left.transform.position - Ankle_Left.transform.position);
                var heading_hipankle = (Hip_Left.transform.position - Ankle_Left.transform.position);

                float dist_kneehip_ecc = heading_kneehip.magnitude;
                float dist_kneeankle_ecc = heading_kneeankle.magnitude;
                float dist_hipankle_ecc = heading_hipankle.magnitude;

                var vgoodhip_ecc = Hip_Left.transform.position;
                var vgoodknee_ecc = Knee_Left.transform.position;
                var vgoodankle_ecc = Ankle_Left.transform.position;

                float goodknee_ecc = vgoodknee_ecc.magnitude;
                float goodhip_ecc = vgoodhip_ecc.magnitude;
                float goodankle_ecc = vgoodankle_ecc.magnitude;

                float angleTan = (dist_hipankle_ecc / dist_kneeankle_ecc);
                float angle = Mathf.Atan(angleTan);
                angle_ecc = angle * (180 / Math.PI);

                textangle_ecc.text = string.Format("{0:0.00}°", angle_ecc); ;

                textgoodhip_ecc.text = string.Format("{0:0.00}", goodhip_ecc);
                textgoodknee_ecc.text = string.Format("{0:0.00}", goodknee_ecc);
                textgoodankle_ecc.text = string.Format("{0:0.00}", goodankle_ecc);

                initial3++;

                textgoodhip_ecc.color = Color.magenta;
                textgoodknee_ecc.color = Color.magenta;
                textgoodankle_ecc.color = Color.magenta;
                textangle_ecc.color = Color.magenta;
            }
        }
    }

    public void Storegoodstand()
    {
        if (initial4 == 0)
        {
            if (right > 0 && left < 1)
            {
                var heading_kneehip = (Knee_Right.transform.position - Hip_Right.transform.position);
                var heading_kneeankle = (Knee_Right.transform.position - Ankle_Right.transform.position);
                var heading_hipankle = (Hip_Right.transform.position - Ankle_Right.transform.position);

                float dist_kneehip_con = heading_kneehip.magnitude;
                float dist_kneeankle_con = heading_kneeankle.magnitude;
                float dist_hipankle_con = heading_hipankle.magnitude;

                var vgoodhip_con = Hip_Right.transform.position;
                var vgoodknee_con = Knee_Right.transform.position;
                var vgoodankle_con = Ankle_Right.transform.position;

                float goodknee_con = vgoodknee_con.magnitude;
                float goodhip_con = vgoodhip_con.magnitude;
                float goodankle_con = vgoodankle_con.magnitude;

                float angleTan = (dist_hipankle_con / dist_kneeankle_con);
                float angle = Mathf.Atan(angleTan);
                angle_con = angle * (180 / Math.PI);

                textangle_con.text = string.Format("{0:0.00}°", angle_con); ;

                textgoodhip_con.text = string.Format("{0:0.00}", goodhip_con);
                textgoodknee_con.text = string.Format("{0:0.00}", goodknee_con);
                textgoodankle_con.text = string.Format("{0:0.00}", goodankle_con);

                initial4++;

                textgoodhip_con.color = Color.cyan;
                textgoodknee_con.color = Color.cyan;
                textgoodankle_con.color = Color.cyan;
                textangle_con.color = Color.cyan;
            }
            else if (left > 0 && right < 1)
            {
                var heading_kneehip = (Knee_Left.transform.position - Hip_Left.transform.position);
                var heading_kneeankle = (Knee_Left.transform.position - Ankle_Left.transform.position);
                var heading_hipankle = (Hip_Left.transform.position - Ankle_Left.transform.position);

                float dist_kneehip_con = heading_kneehip.magnitude;
                float dist_kneeankle_con = heading_kneeankle.magnitude;
                float dist_hipankle_con = heading_hipankle.magnitude;

                var vgoodhip_con = Hip_Left.transform.position;
                var vgoodknee_con = Knee_Left.transform.position;
                var vgoodankle_con = Ankle_Left.transform.position;

                float goodknee_con = vgoodknee_con.magnitude;
                float goodhip_con = vgoodhip_con.magnitude;
                float goodankle_con = vgoodankle_con.magnitude;

                float angleTan = (dist_hipankle_con / dist_kneeankle_con);
                float angle = Mathf.Atan(angleTan);
                angle_con = angle * (180 / Math.PI);

                textangle_con.text = string.Format("{0:0.00}°", angle_con); ;

                textgoodhip_con.text = string.Format("{0:0.00}", goodhip_con);
                textgoodknee_con.text = string.Format("{0:0.00}", goodknee_con);
                textgoodankle_con.text = string.Format("{0:0.00}", goodankle_con);

                initial4++;

                textgoodhip_con.color = Color.magenta;
                textgoodknee_con.color = Color.magenta;
                textgoodankle_con.color = Color.magenta;
                textangle_con.color = Color.magenta;
            }
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

            initshouldercenterx = Shoulder_Center.transform.position.x; 
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

            var init_heading_posture = Head.transform.position - Shoulder_Center.transform.position;
            float init_distance_posture = init_heading_posture.magnitude;

            var init_heading_kneesunbentleft = Hip_Left.transform.position - Ankle_Left.transform.position;
            float init_distance_kneesunbentleft = init_heading_kneesunbentleft.magnitude;

            var init_heading_kneesunbentright = Hip_Right.transform.position - Ankle_Right.transform.position;
            float init_distance_kneesunbentright = init_heading_kneesunbentright.magnitude;

            var init_heading_feetright = Ankle_Right.transform.position - Foot_Right.transform.position;
            float init_distance_feetright = init_heading_feetright.magnitude;

            var init_heading_feetleft = Ankle_Left.transform.position - Foot_Left.transform.position;
            float init_distance_feetleft = init_heading_feetleft.magnitude;

            var init_heading_extensionright = Shoulder_Right.transform.position - Hand_Right.transform.position;
            float init_distance_extensionright = init_heading_extensionright.magnitude;

            var init_heading_extensionleft = Shoulder_Left.transform.position - Hand_Left.transform.position;
            float init_distance_extensionleft = init_heading_extensionleft.magnitude;

            var init_heading_alignmentright = Shoulder_Center.transform.position - Hand_Left.transform.position;
            float init_distance_alignmentright = init_heading_alignmentright.magnitude;

            var init_heading_alignmentleft = Shoulder_Center.transform.position - Hand_Right.transform.position;
            float init_distance_alignmentleft = init_heading_alignmentleft.magnitude;

            var init_heading_shoulderwidth = Shoulder_Right.transform.position - Shoulder_Left.transform.position;
            float init_distance_shoulders = init_heading_shoulderwidth.magnitude;

            var init_heading_anklewidth = Ankle_Right.transform.position - Ankle_Left.transform.position;
            float init_distance_ankles = init_heading_anklewidth.magnitude;

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

    public void Evaluate_Stand()
    {
        //POSTURE
        var posture_stand = (heady - shouldercentery >= (initheady - initshouldercentery) * 0.85);
        //STANCE
        var stance_stand = (anklerightx - ankleleftx <= shoulderrightx - shoulderleftx);
        //FEET FLAT
        var feet_flat = (anklerighty <= initanklerighty * 1.2 && anklelefty <= initanklelefty * 1.2);
        //ALIGNMENT
        var body_alignment = (shouldercenterx > hipleftx && shouldercenterx < hiprightx);

        if ((posture_stand && stance_stand && feet_flat && body_alignment) || goodstand > 0)
        {
            goodstand++;
            no1st.color = Color.green;
            no2st.color = Color.green;
            no3st.color = Color.green;
            no4st.color = Color.green;

            error_count = 0;
            Storegoodstand();
        }

        else
        {
            if (posture_stand)
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

            if (stance_stand)
            {
                no2st.color = Color.green;
            }
            else
            {
                no2st.color = Color.red;
                directions.text = "Feet should be around shoulder width apart and not more.";
                encouragement.text = "...";
                error_count++;
            }

            if (feet_flat)
            {
                no3st.color = Color.green;
            }
            else
            {
                no3st.color = Color.red;
                directions.text = "Keep your feet flat.";
                encouragement.text = "...";
                error_count++;
            }

            if (body_alignment)
            {
                no4st.color = Color.green;
            }
            else
            {
                no4st.color = Color.red;
                directions.text = "Keep your torso aligned to center.";
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

    public void Evaluate_Lunge_Left()
    {
        //POSTURE
        var posture = (heady - shouldercentery >= (initheady - initshouldercentery) * 0.85);
        //STANCE
        var stance = (kneerightx - kneeleftx <= (shoulderrightx - shoulderleftx) * 1.1);
        //FRONT FOOT FLAT
        var foot_flat = (anklelefty <= initanklelefty * 1.2);
        //FRONT FOOT SAME SPOT
        var same_spot = (anklerightx > hipcenterx && anklerightx < shoulderrightx);
        //BODY ALIGNMENT
        var alignment = (shouldercenterx > hipleftx && shouldercenterx < hiprightx);

        if ((posture && stance && foot_flat && same_spot && alignment) || goodsquat > 0)
        {
            goodsquat++;
            no1sq.color = Color.green;
            no2sq.color = Color.green;
            no3sq.color = Color.green;
            no4sq.color = Color.green;
            no5sq.color = Color.green;

            error_count = 0;
            Storegoodlunge();
        }

        else
        {
            if (posture)
            {
                no1sq.color = Color.green;
            }
            else
            {
                no1sq.color = Color.red;
                directions.text = "Keep your back straight and your chest raised.";
                encouragement.text = "...";
                error_count++;
            }

            if (stance)
            {
                no2sq.color = Color.green;
            }
            else
            {
                no2sq.color = Color.red;
                directions.text = "Feet should be around shoulder width apart and not more.";
                encouragement.text = "...";
                error_count++;
            }

            if (foot_flat)
            {
                no3sq.color = Color.green;
            }
            else
            {
                no3sq.color = Color.red;
                directions.text = "Keep your front foot flat.";
                encouragement.text = "...";
                error_count++;
            }

            if (same_spot)
            {
                no4sq.color = Color.green;
            }
            else
            {
                no4sq.color = Color.red;
                directions.text = "Don't move your front foot from where it was.";
                encouragement.text = "...";
                error_count++;
            }

            if (alignment)
            {
                no5sq.color = Color.green;
            }
            else
            {
                no5sq.color = Color.red;
                directions.text = "Keep your torso in the center.";
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

    public void Evaluate_Lunge_Right()
    {
        //POSTURE
        var posture = (heady - shouldercentery >= (initheady - initshouldercentery) * 0.85);
        //STANCE
        var stance = (kneerightx - kneeleftx <= (shoulderrightx - shoulderleftx) * 1.1);
        //FRONT FOOT FLAT
        var foot_flat = (anklerighty <= initanklerighty * 1.2);
        //FRONT FOOT SAME SPOT
        var same_spot = (ankleleftx > shoulderleftx && ankleleftx < hipcenterx);
        //BODY ALIGNMENT
        var alignment = (shouldercenterx > hipleftx && shouldercenterx < hiprightx);

        if ((posture && stance && foot_flat && same_spot && alignment) || goodsquat > 0)
        {
            goodsquat++;
            no1sq.color = Color.green;
            no2sq.color = Color.green;
            no3sq.color = Color.green;
            no4sq.color = Color.green;
            no5sq.color = Color.green;

            error_count = 0;
            Storegoodlunge();
        }

        else
        {
            if (posture)
            {
                no1sq.color = Color.green;
            }
            else
            {
                no1sq.color = Color.red;
                directions.text = "Keep your back straight and your legs raised.";
                encouragement.text = "...";
                error_count++;
            }

            if (stance)
            {
                no2sq.color = Color.green;
            }
            else
            {
                no2sq.color = Color.red;
                directions.text = "Feet should be around shoulder width apart and not more.";
                encouragement.text = "...";
                error_count++;
            }

            if (foot_flat)
            {
                no3sq.color = Color.green;
            }
            else
            {
                no3sq.color = Color.red;
                directions.text = "Keep your front foot flat.";
                encouragement.text = "...";
                error_count++;
            }

            if (same_spot)
            {
                no4sq.color = Color.green;
            }
            else
            {
                no4sq.color = Color.red;
                directions.text = "Don't move your front foot from where it was when you were standing.";
                encouragement.text = "...";
                error_count++;
            }

            if (alignment)
            {
                no5sq.color = Color.green;
            }
            else
            {
                no5sq.color = Color.red;
                directions.text = "Keep your torso in the center.";
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
                    var choose_left = (handrightx >= anklerightx && handrighty >= heady);
                    var choose_right = (handleftx <= ankleleftx && handlefty >= heady);

                    if (choose_right)
                    {
                        initial3 = 0;
                        initial4 = 0;
                        right++;
                        left = 0;
                        stand_count = 0;
                        squat_count = 0;
                        side.text = "RIGHT-SIDE";
                        side.color = Color.cyan;
                    }

                    else if (choose_left)
                    {
                        initial3 = 0;
                        initial4 = 0;
                        left++;
                        right = 0;
                        stand_count = 0;
                        squat_count = 0;
                        side.text = "LEFT-SIDE";
                        side.color = Color.magenta;
                    }

                    else if (choose_left && choose_right)
                    {
                        right = 0;
                        left = 0;
                        side.text = "CHOOSE A SIDE";
                    }

                    // Ankle-distance >= Shoulder-distance before Starting
                    if (kneerightx - kneeleftx <= (shoulderrightx - shoulderleftx) * 1.1)
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

                        if (right > 0 && left < 1)
                        {
                            if ((kneelefty < kneerighty * 0.9 && shouldercentery < initshouldercentery * 0.9) && (stand_count < 1))
                            {
                                // Squat evaluation
                                Evaluate_Lunge_Right();
                                error_count = 0;

                                checker++;
                                squat_count++;
                                // Hip height > % of Threshold
                                // Shoulder-center >= Initial height of Shoulder-center when you were standing
                                // Basically coming back up from the squat
                            }
                            else
                            {
                                directions.text = "Lower your right knee to the ground.";
                                encouragement.text = "Keep your left foot in place.";
                            }

                            if ((squat_count > 0) && (shouldercentery >= initshouldercentery * 0.9))
                            {
                                subcounter++;
                                //Default_squat();

                                // Stand evaluation
                                Evaluate_Stand();
                                //error_count = 0;

                                stand_count++;
                                Debug.Log(subcounter);
                            }
                            else
                            {
                                directions.text = "Stand back up.";
                                encouragement.text = "Keep your left foot in place.";
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

                                    checker = 0;
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

                                    checker = 0;
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

                        else if (left > 0 && right < 1)
                        {
                            if ((stand_count < 1) && (kneerighty < kneelefty * 0.9 && shouldercentery < initshouldercentery * 0.9))
                            {
                                // Squat evaluation
                                Evaluate_Lunge_Left();
                                error_count = 0;

                                checker++;
                                squat_count++;
                                // Hip height > % of Threshold
                                // Shoulder-center >= Initial height of Shoulder-center when you were standing
                                // Basically coming back up from the squat
                            }
                            else
                            {
                                directions.text = "Lower your left knee to the ground.";
                                encouragement.text = "Keep your right foot in place.";
                            }

                            if ((squat_count > 0) && (shouldercentery >= initshouldercentery * 0.9))
                            {
                                subcounter++;
                                //Default_squat();

                                // Stand evaluation
                                Evaluate_Stand();
                                //error_count = 0;

                                stand_count++;
                                Debug.Log(subcounter);
                            }
                            else
                            {
                                directions.text = "Stand back up.";
                                encouragement.text = "Keep your right foot in place.";
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

                                    checker = 0;
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

                                    checker = 0;
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
        no4st.color = Color.grey;
    }

    public void Default_lift()
    {
        no1sq.color = Color.grey;
        no2sq.color = Color.grey;
        no3sq.color = Color.grey;
        no4sq.color = Color.grey;
        no5sq.color = Color.grey;
    }

    public void Show_perfect()
    {
        no1st.color = Color.green;
        no2st.color = Color.green;
        no3st.color = Color.green;
        no4st.color = Color.green;

        no1sq.color = Color.green;
        no2sq.color = Color.green;
        no3sq.color = Color.green;
        no4sq.color = Color.green;
        no5sq.color = Color.green;
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
        textgoodhip_con.text = "...";
        textgoodhip_ecc.text = "...";

        textgoodknee_con.text = "...";
        textgoodknee_ecc.text = "...";

        textgoodankle_con.text = "...";
        textgoodankle_ecc.text = "...";

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
