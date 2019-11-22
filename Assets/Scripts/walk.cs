using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 7.5f;
    public float maxSpeed = 15f;
    public Vector3 vel;
    public float canJump = 0f;
    public float stamina = 30f;
    GameObject staminaBar;
    public GameObject marker;
    public Vector3 test;
    public float playerX, playerZ;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        staminaBar = GameObject.Find("StaminaBar");
        
    }

    // Update is called once per frame
    void Update()
    {
        vel = rb.velocity;
        rb.angularVelocity = Vector3.zero;
        test = transform.position;
        playerX = test.x;
        playerZ = test.z;
        staminaBar.transform.localScale = new Vector3((stamina * 0.2f), 0.3f, 1f);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump)
        {
            rb.AddForce(new Vector3(0, 250, 0), ForceMode.Impulse);
            canJump = Time.time + 1f;
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

        else if (Input.GetKey(KeyCode.LeftShift) && stamina < 0 && speed > 7.5f)
        {
            speed -= (10f * Time.deltaTime);
        }

        else if (!Input.GetKey(KeyCode.LeftShift) && speed > 7.5f)
        {
            speed = speed - 10f * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.LeftShift) && stamina < 30f)
        {
            stamina += 5f * Time.deltaTime;
        }


        Vector3 input = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 2f))
        {
            input = Vector3.ProjectOnPlane(input, hitInfo.normal);
        }

        transform.Translate(input * Time.deltaTime * speed, Space.World);

        
        if (Input.GetKeyDown("t"))
        {
            Instantiate(marker, new Vector3(playerX, -0.5f, playerZ), Quaternion.identity);
        }
        


    }

    


}
