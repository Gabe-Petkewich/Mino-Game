using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minotaurSpawner : MonoBehaviour
{
    public bool spawnFlag;
    public float spawn;
    public GameObject minotaur;


    // Start is called before the first frame update
    void Start()
    {
        spawn = 0;
        spawnFlag = false;

    }

    void Awake()
    {
        //spawnFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawn += Time.deltaTime * 1;

        if (spawn >= 10f &&  spawn < 12f && spawnFlag == false)
        {
            spawnFlag = true;
            Instantiate(minotaur, new Vector3(-28.2f, 1.5f, -12.5f), Quaternion.identity);
        }

        if (spawn >= 20f && spawnFlag == false)
        {
            spawnFlag = true;
            Instantiate(minotaur, new Vector3(56.69f, 1.5f, 11.16952f), Quaternion.identity);
            minotaur.transform.eulerAngles = new Vector3(0, 90f, 0);
        }
    }


    public void dontSpawnMinotaur()
    {
        spawnFlag = true;
        spawn = 0;
    }

    public void resetMinotaur(float time)
    {
        spawnFlag = false;
        spawn = time;
    }


}
