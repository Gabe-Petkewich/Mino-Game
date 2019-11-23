using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    private float timer;
    public float batteryTime;
    public Light lt;
    // Start is called before the first frame update
    void Start()
    {
        batteryTime = 60f;
        timer = batteryTime;
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1f * Time.deltaTime;


        if(timer <= 4f && timer >= 3.9f)
        {
            lt.intensity = 0;
        }
        if (timer <= 3.9f && timer >= 3.8f)
        {
            lt.intensity = 5f;
        }
        if (timer <= 3.8f && timer >= 3.7f)
        {
            lt.intensity = 0;
        }
        if (timer <= 3.7f && timer >= 3.6f)
        {
            lt.intensity = 5f;
        }
        if (timer <= 3.6f && timer >= 3.5f)
        {
            lt.intensity = 0;
        }

        if(timer <= 0)
        {
            lt.intensity = 5f;
            timer = batteryTime;
        }

    }

    public void setBatteryTime(float time)
    {
        batteryTime = time;
    }
}
