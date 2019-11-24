using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Button startBtn;
    GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Main Menu");
        startBtn = GameObject.Find("Start").GetComponent<Button>();
        startBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Button Clicked");
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
