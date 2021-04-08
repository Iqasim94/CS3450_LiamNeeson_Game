using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyScript : MonoBehaviour
{

    protected NavMeshAgent Agent;
    protected StateEnum State;
    protected Target[] PotentialTargets;
    protected Target target;
    protected float NextState;

    void Awake() {
        
        Agent = GetComponent<NavMeshAgent>();
        PotentialTargets = FindObjectsOfType<Target>();
        target = PotentialTargets[Random.Range(0, PotentialTargets.Length)];
        State = StateEnum.RUN;

    }

    void Update() {

        Agent.updatePosition = false;
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;

        NextState -= Time.deltaTime;

        switch (State) {
            
            case StateEnum.RUN:

                if (Agent.desiredVelocity.magnitude < 0.1f) {
                    State = StateEnum.SHOOT;
                    NextState = Random.Range(1f, 7f);
                }

                break;

            case StateEnum.SHOOT:

                if (NextState < 0) {
                    State = StateEnum.RUN;
                    target = PotentialTargets[Random.Range(0, PotentialTargets.Length)];
                    Agent.SetDestination(target.transform.position);
                }

                break;
        }

        transform.position += Agent.desiredVelocity * Time.deltaTime;

    }

    public enum StateEnum
    {
        RUN,
        SHOOT
    }

}
