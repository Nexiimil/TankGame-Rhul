using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField] private Transform targetLocation; //Ever changing location to head to
    [SerializeField] private NavMeshAgent agent; //identifies this entity as an agent,

    public Transform TargetLocation { get => targetLocation; set => targetLocation = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }

    //possessing some degree of automonomous ability to respond to a scenario


    // Start is called before the first frame update
    void Start(){
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Agent = agent;
        TargetLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            TargetLocation = player.transform;
            agent.SetDestination(TargetLocation.position);
        }
    }
}
