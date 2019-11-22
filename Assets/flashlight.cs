using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public float timer;
    public Light lt;
    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1f * Time.deltaTime;


        if(timer <= 6f && timer >= 5.9f)
        {
            lt.intensity = 0;
        }
        if (timer <= 5.9f && timer >= 5.8f)
        {
            lt.intensity = 5f;
        }
        if (timer <= 5.8f && timer >= 5.7f)
        {
            lt.intensity = 0;
        }
        if (timer <= 5.7f && timer >= 5.6f)
        {
            lt.intensity = 5f;
        }
        if (timer <= 5.6f && timer >= 5.5f)
        {
            lt.intensity = 0;
        }

        if(timer <= 0)
        {
            lt.intensity = 5f;
            timer = 60f;
        }


    }
}
