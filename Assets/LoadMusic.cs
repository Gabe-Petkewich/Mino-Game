using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        if(SceneManager.GetActiveScene().name == SceneManager.GetSceneByName("idk2").name)
        {
           gameObject.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == SceneManager.GetSceneByName("Start Menu").name)
        {
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
