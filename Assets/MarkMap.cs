using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkMap : MonoBehaviour
{
    public GameObject marking;

    // Start is called before the first frame update
    void Start()
    {
        marking = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerExit(Collider collider)
    {
        marking.GetComponent<Renderer>().enabled = true;
        Debug.Log("Entered Trigger");
    }
}
