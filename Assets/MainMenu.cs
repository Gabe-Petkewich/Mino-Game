using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject theManager;
    public GameObject backgroundMusic;

    void Start()
    {
        Destroy(GameObject.Find("Player"));
        
    }
    public void LoadScene(string name)

    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
        StartCoroutine(LoadCurrentScene());


    }

    IEnumerator LoadCurrentScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
