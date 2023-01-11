using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform targetLocation; //Ever changing location to head to
    [SerializeField] private float rotationSpeed = 30; //the speed at which rotation is allowed

    void setTargetLocation(Transform targetLocation){this.targetLocation = targetLocation;} //sets the location to head to
    Transform getTargetLocation(){return this.targetLocation;} //fetches the location to head to

    void setRotationSpeed(float rotationSpeed){this.rotationSpeed = rotationSpeed;} //sets the speed at which rotation is allowed
    float getRotationSpeed(){return this.rotationSpeed;} //fetches the speed at which rotation is allowed

    // Update is called once per frame
    void Update(){
        fetchPlayer(); //ensures the players location is tracked
    }
    void fetchPlayer(){
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //enables check if a player is in play
        if (player != null){ //player presence check
            setTargetLocation(player.transform); //sets the location to head to as the players current location

            Vector3 position = getTargetLocation().position - transform.position; //creates a vector with the distance and direction toward the player
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, position); //the vector acts as the real axis for a quaternion
            rotation *= Quaternion.Euler(0, 0, 90); //correction for the placement of the cannon to face the player
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, getRotationSpeed());
        }       //applies the quaternion rotation to the enemy, to face the payer
    }
}
