using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Incorrect":
                collider.GetComponent<MeshRenderer>().material.color = Color.red;
                gameObject.transform.position = new Vector3(34.24f, 1.87f, 9.08f);
                break;
        }
    }
}
