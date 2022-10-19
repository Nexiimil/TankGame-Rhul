using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField]
    private Transform targetLocation;

    [SerializeField]
    private NavMeshAgent agent;

    void setTargetLocation(Transform targetLocation){this.targetLocation = targetLocation;}
    Transform getTargetLocation(){return this.targetLocation;}

    void setAgent(NavMeshAgent agent){this.agent = agent;}
    NavMeshAgent getAgent(){return this.agent;}

    // Start is called before the first frame update
    void Start(){
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        setAgent(agent);

        setTargetLocation(GameObject.FindGameObjectWithTag("Player").transform);
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(getTargetLocation().position);
    }
}
