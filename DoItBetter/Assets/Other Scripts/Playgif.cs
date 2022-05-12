using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playgif : MonoBehaviour
{

    public Sprite[] animatedExercise;
    public Image exerFrames;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exerFrames.sprite = animatedExercise [(int)(Time.time*5)%animatedExercise.Length];
    }
}
