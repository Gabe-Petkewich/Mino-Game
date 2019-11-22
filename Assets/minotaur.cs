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

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        goal = player.transform;
        agent.SetDestination(goal.position);
    }
}
