using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    
    [SerializeField]
    private Transform targetLocation;

    [SerializeField]
    private float rotation = 0;

    [SerializeField]
    private float rotationSpeed = 30;

    void setRb(Rigidbody2D rb){this.rb = rb;}
    Rigidbody2D getRb(){return this.rb;}

    void setTargetLocation(Transform targetLocation){this.targetLocation = targetLocation;}
    Transform getTargetLocation(){return this.targetLocation;}
    void setRotationSpeed(float rotationSpeed){this.rotationSpeed = rotationSpeed;}
    float getRotationSpeed(){return this.rotationSpeed;}
    void setRotation(float rotation){this.rotation = rotation;}
    float getRotation(){return this.rotation;}

    // Start is called before the first frame update
    void Start()
    {
        setRb(GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void FixedUpdate(){
        fetchPlayer();
    }
    void fetchPlayer(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            setTargetLocation(player.transform);

            Vector3 position = getTargetLocation().position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, position);
            rotation *= Quaternion.Euler(0, 0, 90);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }
}
