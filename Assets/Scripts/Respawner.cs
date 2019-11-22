using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public bool inTrigger = false;
    public GameObject player;
    private Transform playerTransform;
    public GameObject relocater;
    private Transform relocaterTransform;

    void Start() 
    {
        playerTransform = player.transform;
        relocaterTransform = relocater.transform;
    }


    /*
    Respawns the player at the position of the provided object once they
    enter the trigger.
     */
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        Debug.Log("Respawning...");
        Debug.Log("Player Position: " + playerTransform.position);
        Debug.Log("Respawn Position: " + relocaterTransform.position);
        Teleport(player);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited");
    }

    // Sets player's position to that of the target object.
    void Teleport(GameObject obj)
    {
        obj.transform.SetPositionAndRotation(relocaterTransform.position, relocaterTransform.rotation);
    }
}