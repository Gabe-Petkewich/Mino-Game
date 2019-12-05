using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walk : MonoBehaviour
{
    Rigidbody rb;
    private float speed = 7.5f;
    private float maxSpeed = 15f;
    private float canJump = 0f;
    private float stamina = 30f;
    private float maxStamina = 30f;
    private float playerX, playerZ;
    
    private GameObject staminaBar;
    private GameObject staminaText;
    public GameObject marker;
    public Vector3 vel;
    private Vector3 test;
    private float staminaTime;
    public AudioClip punchSound;
    private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        staminaBar = GameObject.Find("StaminaBar");
        staminaText = GameObject.Find("StaminaIncreased");
        rb = GetComponent<Rigidbody>();
        staminaText.SetActive(false);
        staminaTime = 0;
        audioSource = GetComponent<AudioSource>();
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

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump)
        {
            rb.AddForce(new Vector3(0, 250, 0), ForceMode.Impulse);
            canJump = Time.time + 1f;
        }

        //Attack on click
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(punchSound, 1f);

        }

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) && speed < maxSpeed && stamina > 0)
        {
            speed += (10f * Time.deltaTime);
            stamina -= (10f * Time.deltaTime);
        }

        //Sprint at max speed
        else if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= (10f * Time.deltaTime);
        }

        //No sprint when stamina = 0
        else if (Input.GetKey(KeyCode.LeftShift) && stamina < 0 && speed > 7.5f)
        {
            speed -= (10f * Time.deltaTime);
        }

        //Reduce speed when shift is not held down
        else if (!Input.GetKey(KeyCode.LeftShift) && speed > 7.5f)
        {
            speed = speed - 10f * Time.deltaTime;
        }

        //Regain stamina when shift not held down
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

    public IEnumerator increaseStamina()
    {
        maxStamina += 10;
        staminaText.SetActive(true);
        yield return new WaitForSeconds(2);
        staminaText.SetActive(false);

    }
}
