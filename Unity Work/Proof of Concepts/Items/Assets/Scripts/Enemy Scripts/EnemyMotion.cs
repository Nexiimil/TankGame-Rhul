using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField] private Transform targetLocation; //Ever changing location to head to
    [SerializeField] private NavMeshAgent agent; //identifies this entity as an agent,
                            //possessing some degree of automonomous ability to respond to a scenario
    void setTargetLocation(Transform targetLocation){this.targetLocation = targetLocation;} //sets the location to head to
    Transform getTargetLocation(){return this.targetLocation;} //fetches the location to head to

    void setAgent(NavMeshAgent agent){this.agent = agent;} //sets the agent after some adjustment perhaps
    NavMeshAgent getAgent(){return this.agent;} //fetches the stored agent

    // Start is called before the first frame update
    void Start(){
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        setAgent(agent);
        setTargetLocation(GameObject.FindGameObjectWithTag("Player").transform);
    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            setTargetLocation(player.transform);
            agent.SetDestination(getTargetLocation().position);
        }
    }
}
