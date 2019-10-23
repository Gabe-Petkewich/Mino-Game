using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    public float maxSpeed = 15f;
    public Vector3 vel;
    public float canJump = 0f;
    public float stamina = 30f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vel = rb.velocity;
        rb.angularVelocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump)
        {
            rb.AddForce(new Vector3(0, 250, 0), ForceMode.Impulse);
            canJump = Time.time + 0.7f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && speed < maxSpeed && stamina > 0)
        {
            speed += (10f * Time.deltaTime);
            stamina -= (10f * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= (10f * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftShift) && stamina < 0 && speed > 5f)
        {
            speed -= (10f * Time.deltaTime);
        }

        else if (!Input.GetKey(KeyCode.LeftShift) && speed > 5f)
        {
            speed = speed - 10f * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.LeftShift) && stamina < 30f)
        {
            stamina += 5f * Time.deltaTime;
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
