using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walk : MonoBehaviour
{
    Rigidbody rb;
    private float speed = 7.5f;
    private float maxSpeed = 15f;
    public Vector3 vel;
    private float canJump = 0f;
    private float stamina = 30f;
    private float maxStamina = 30f;
    GameObject staminaBar;
    public GameObject marker;
    private Vector3 test;
    private float playerX, playerZ;
    private int spawnPoint = 0;
    public GameObject flashLight;
    flashlight flashlightScript;
    // Use this for initialization
    void Start()
    {
        staminaBar = GameObject.Find("StaminaBar");
        rb = GetComponent<Rigidbody>();
        flashLight = GameObject.Find("FlashLight");
        flashlightScript = flashLight.GetComponent<flashlight>();
       

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

        switch (collider.gameObject.tag)
        {
            case "KillZone":
                gameObject.transform.position = new Vector3(-31.72f, 2.14f, -15.06f);
                break;
            case "JumpComplete":
                maxStamina += 10f;
                SceneManager.LoadScene("idk2");
                gameObject.transform.position = new Vector3(-9.8f, 1.87f, 19.3f);
                break;
            case "Jump2Complete":
                flashlightScript.setBatteryTime(70f);
                SceneManager.LoadScene("idk2");
                gameObject.transform.position = new Vector3(141.78f, 1.87f, 31.5f);
                break;


        }

    }





}
