using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{

    public float speed = 5f;
    public float maxSpeed = 15f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && speed < maxSpeed)
        {
            speed = speed + 10f * Time.deltaTime;
        }

        else if (!Input.GetKey(KeyCode.LeftShift) && speed > 5f)
        {
            speed = speed - 10f * Time.deltaTime;
        }

        if (Input.GetKey("a") )
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -1 * speed);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

    }
}
