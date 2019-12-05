using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTester : MonoBehaviour
{

    Shader shader1;

    void OnEnable()
    {
        shader1 = Shader.Find("UI/Unlit/Transparent")
    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Incorrect":
                collider.GetComponent<MeshRenderer>().material.shader = shader1;
                collider.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
                gameObject.transform.position = new Vector3(34.24f, 1.87f, 9.08f);
                break;
        }
    }
}
