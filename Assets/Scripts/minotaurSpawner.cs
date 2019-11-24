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
        spawnFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawn += Time.deltaTime * 1;

        if (spawn >= 10f && spawnFlag == false)
        {
            spawnFlag = true;
            Instantiate(minotaur, new Vector3(-28.2f, 1.5f, -12.5f), Quaternion.identity);
        }
    }

    public void dontSpawnMinotaur()
    {
        spawnFlag = true;
        spawn = 0;
    }

    public void resetMinotaur()
    {
        spawnFlag = false;
        spawn = 0;
    }


}
