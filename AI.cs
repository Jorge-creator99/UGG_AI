using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;
    
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        //could get component in the states and pass through the gameObject but would not be efficient as we are creating and destroying states all the time
        //WE make sure we get everything right at the beginning of the AI
        currentState = new Idle(this.gameObject, agent, anim, player);
    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
