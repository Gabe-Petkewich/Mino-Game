using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterJumpPuzzle : MonoBehaviour
{
    public GameObject player;
    minotaurSpawner minotaurSpawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        minotaurSpawnerScript = player.GetComponent<minotaurSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        minotaurSpawnerScript.dontSpawnMinotaur();
        SceneManager.LoadScene("JumpPuzzle");
    }


}
