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
    public float delay;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(delay >= 1)
        {
            goal = player.transform;
            agent.SetDestination(goal.position);
            delay = 0;
        }
        delay += Time.deltaTime * 1;       

    }
}
