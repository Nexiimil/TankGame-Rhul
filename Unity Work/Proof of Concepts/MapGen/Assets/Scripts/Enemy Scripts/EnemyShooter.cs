using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform targetLocation; //Ever changing location to head to
    [SerializeField] private float rotationSpeed; //the speed at which rotation is allowed

    public Transform TargetLocation { get => targetLocation; set => targetLocation = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }

    // Update is called once per frame
    void Start(){
        PullStat();
    }
    void Update(){
        FetchPlayer(); //ensures the players location is tracked
    }
    void FetchPlayer(){
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //enables check if a player is in play
        if (player != null){ //player presence check
            TargetLocation = player.transform; //sets the location to head to as the players current location

            Vector3 position = TargetLocation.position - transform.position; //creates a vector with the distance and direction toward the player
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, position); //the vector acts as the real axis for a quaternion
            rotation *= Quaternion.Euler(0, 0, 90); //correction for the placement of the cannon to face the player
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
        }       //applies the quaternion rotation to the enemy, to face the payer
    }
    void PullStat(){
        Stats stat = gameObject.GetComponent<EntityController>().Sa.Find(r => r.statName == "EntityRoSpeed");
        RotationSpeed = Stats.capFlatPerc(75, stat.flatStat, stat.percentageStat, 600);
    }
}
