using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTester : MonoBehaviour
{

    Shader shader1;
    Vector3 checkpoint;
    bool reached1;

    void OnEnable()
    {
        shader1 = Shader.Find("UI/Unlit/Transparent");
        checkpoint = new Vector3(34.24f, 1.87f, 9.08f);
        reached1 = false;

    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Incorrect":
                gameObject.transform.position = checkpoint;
                break;
            case "Correct":
                collider.GetComponent<MeshRenderer>().material.shader = shader1;
                collider.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
                break;
            case "Checkpoint1":
                if(reached1 == false) 
                {
                    Debug.Log("Entering checkpoint...");
                    checkpoint = new Vector3(36.09f, 1.87f, 42.33f);
                    reached1 = true;
                }
                break;
        }
    }
}
