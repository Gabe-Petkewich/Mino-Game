using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class minotaur : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    public GameObject player;
    private NavMeshAgent agent;
    public float timer, delay, gruntDelay;
    public AudioClip bullGrunt;
    AudioSource audioSource;


    void Start()
    {
        timer = 0;
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        gruntDelay = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= gruntDelay)
        {
            audioSource.PlayOneShot(bullGrunt, 1f);
            timer = 0;
        }
        

        if (delay >= 1)
        {
            goal = player.transform;
            agent.SetDestination(goal.position);
            delay = 0;
        }
        delay += Time.deltaTime * 1;       

    }
}
