using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Info", 3.0f);
    }

    // Update is called once per frame
    void Info()
    {
        GameObject.Find("InfoNext").transform.localScale = new Vector3(1, 1, 1);
    }
}
