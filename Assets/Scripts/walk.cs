using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walk : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 7.5f;
    public float maxSpeed = 15f;
    public Vector3 vel;
    public float canJump = 0f;
    public float stamina = 30f;
    private float maxStamina = 30f;
    GameObject staminaBar;
    public GameObject marker;
    public Vector3 test;
    public float playerX, playerZ;
    public int spawnPoint = 0;
    GameObject canvas;
    // Use this for initialization
    void Start()
    {
        staminaBar = GameObject.Find("StaminaBar");
        rb = GetComponent<Rigidbody>();



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

        if (!Input.GetKey(KeyCode.LeftShift) && stamina < maxStamina)
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

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    void OnTriggerEnter(Collider collider)
    {
        //Awake();
        if (collider.gameObject.tag == "KillZone")
        {
            gameObject.transform.position = new Vector3(-31.72f, 2.14f, -15.06f);
        }

        if(collider.gameObject.tag == "JumpComplete")
        {
            maxStamina += 10f;
            SceneManager.LoadScene("idk2");
            gameObject.transform.position = new Vector3(-9.8f, 1.87f, 19.3f);
        }
    }





}
