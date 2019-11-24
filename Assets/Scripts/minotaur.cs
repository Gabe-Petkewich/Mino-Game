using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class minotaur : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform goal;
    public GameObject player;
    private NavMeshAgent agent;
    private float timer, delay, audioClipDelay;
    private float minoGrunt1Delay, minoGrunt2Delay, minoCmereDelay;
    private bool minoGrunt1Played, minoGrunt2Played, minoCmerePlayed;
    public AudioClip minoGrunt1, minoGrunt2, minoCmere;
    private AudioSource audioSource;


    void Start()
    {
        audioClipDelay = 0;
        timer = 0;
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        minoGrunt1Delay = 20f;
        minoGrunt2Delay = 21f;
        minoCmereDelay = 22f;
        minoGrunt1Played = minoGrunt2Played = minoCmerePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        audioClipDelay += Time.deltaTime;

        if ((timer % minoGrunt1Delay >= 0 && timer % minoGrunt1Delay <= 0.1f) && audioClipDelay >= 5f && minoGrunt1Played == false)
        {
            audioSource.PlayOneShot(minoGrunt1, 1f);
            audioClipDelay = 0;
            minoGrunt1Played = true;
            minoGrunt2Played = false;
            minoCmerePlayed = false;
        }

        if ((timer % minoGrunt2Delay >= 0 && timer % minoGrunt2Delay <= 0.1f) && audioClipDelay >= 5f && minoGrunt2Played == false)
        {
            audioSource.PlayOneShot(minoGrunt2, 1f);
            audioClipDelay = 0;
            minoGrunt1Played = false;
            minoGrunt2Played = true;
            minoCmerePlayed = false;
        }

        if ((timer % minoCmereDelay >= 0 && timer % minoCmereDelay <= 0.1f) && audioClipDelay >= 5f && minoCmerePlayed == false)
        {
            audioSource.PlayOneShot(minoCmere, 1f);
            audioClipDelay = 0;
            minoGrunt1Played = false;
            minoGrunt2Played = false;
            minoCmerePlayed = true;
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
