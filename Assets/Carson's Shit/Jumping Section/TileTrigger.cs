using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GameObject tile;
    [SerializeField]
    GameObject collider;
    [SerializeField]
    bool isDeath;
    Shader shader1;

    void OnEnable() 
    {
        collider = this.gameObject;
        tile = this.transform.parent.gameObject;
        shader1 = Shader.Find("UI/Unlit/Transparent");
        collider.GetComponent<MeshRenderer>().material.shader = shader1;
        collider.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        if(!isDeath)
        {
            collider.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if(isDeath == true)
            tile.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited");
    }
}
