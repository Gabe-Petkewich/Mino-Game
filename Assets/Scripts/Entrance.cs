using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    public GameObject flashLight;
    public GameObject minotaur;
    private GameObject jump1, jump2, jump3;
    private GameObject tile1, tile2;
    public float playerHealth;
    public float minoHealth;
    public bool arenaFlag;


    walk walkScript;
    minotaurSpawner minotaurSpawnerScript;
    flashlight flashlightScript;
    // Start is called before the first frame update
    void Start()
    {
        arenaFlag = false;
        playerHealth = 30;
        flashLight = GameObject.Find("FlashLight");
        jump1 = GameObject.Find("Jump Puzzle 1 Entrance");
        jump2 = GameObject.Find("Jump Puzzle 2 Entrance");
        jump3 = GameObject.Find("Jump Puzzle 3 Entrance");

        tile1 = GameObject.Find("Tile Puzzle 1 Entrance");
        tile2 = GameObject.Find("Tile Puzzle 2 Entrance");
        walkScript = gameObject.GetComponent<walk>();
        minotaurSpawnerScript = gameObject.GetComponent<minotaurSpawner>();
        flashlightScript = flashLight.GetComponent<flashlight>();
    }

    void Update()
    {
        if(playerHealth == 0)
        {
            Debug.Log("You are dead");
            SceneManager.LoadScene("You Died");
            playerHealth = 1;
        }
    }



    void OnTriggerEnter(Collider collider)
    {

        switch (collider.gameObject.tag)
        {
            case "KillZone":
                gameObject.transform.position = new Vector3(-31.72f, 2.14f, -15.06f);
                break;
            case "JumpComplete":
                SceneManager.LoadScene("idk2");
                gameObject.transform.position = new Vector3(-9.8f, 1.87f, 19.3f);
                gameObject.transform.eulerAngles = new Vector3(180f, 0, 0);
                minotaurSpawnerScript.resetMinotaur(0);
                walkScript.increaseStamina();                
                break;
            case "Jump2Complete":
                flashlightScript.setBatteryTime(70f);
                SceneManager.LoadScene("idk2");
                gameObject.transform.position = new Vector3(141.78f, 1.87f, 31.5f);
                minotaurSpawnerScript.resetMinotaur(0); 
                break;
            case "Jump3Complete":
                SceneManager.LoadScene("idk2");
                gameObject.transform.position = new Vector3(99.04f, 1.87f, 187f);
                minotaurSpawnerScript.resetMinotaur(0);
                walkScript.increaseStamina();
                break;
            case "Enemy":
                Debug.Log("You hit minotaur");
                playerHealth -= 10f;
                break;
        }

        switch (collider.gameObject.name)
        {
            case "JumpTrigger":
                SceneManager.LoadScene("JumpPuzzle");
                jump1.SetActive(false);
                minotaurSpawnerScript.dontSpawnMinotaur();
                break;
            case "Jump2Trigger":
                SceneManager.LoadScene("JumpPuzzle 2");
                jump2.SetActive(false);
                minotaurSpawnerScript.dontSpawnMinotaur();
                break;
            case "Jump3Trigger":
                SceneManager.LoadScene("JumpPuzzle 3");
                jump3.SetActive(false);
                minotaurSpawnerScript.dontSpawnMinotaur();
                gameObject.transform.position = new Vector3(-31.52f, 3.629f, -14.62801f);
                break;
            case "TileTrigger":
                SceneManager.LoadScene("TilePuzzle");
                tile1.SetActive(false);
                gameObject.transform.position = new Vector3(34.24f, 1.87f, 9.08f);
                break;
            case "Tile2Trigger":
                SceneManager.LoadScene("TilePuzzle 2");
                tile2.SetActive(false);
                gameObject.transform.position = new Vector3(34.24f, 1.87f, 9.08f);
                break;
            case "TileComplete":        
                SceneManager.LoadScene("idk2");
                gameObject.transform.position = new Vector3(-10.54f, 1.87f, 174f);
                minotaurSpawnerScript.resetMinotaur(0);
                StartCoroutine(walkScript.increaseStamina());
                break;
            case "Tile2Complete":
                SceneManager.LoadScene("idk2");
                gameObject.transform.position = new Vector3(88f, 1.87f, 150.88f);
                minotaurSpawnerScript.resetMinotaur(0);
                StartCoroutine(walkScript.increaseStamina());
                break;
            case "EndTrigger":
                SceneManager.LoadScene("Arena");
                arenaFlag = true;
                gameObject.transform.position = new Vector3(-10f, 1.87f, 11.25f);
                minotaurSpawnerScript.resetMinotaur(39.5f);
                Instantiate(minotaur, new Vector3(-10f, 1.5f, -21f), Quaternion.identity);
                break;
        }

    }
}
