using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float rotation = 0; //current rotation of the player
    [SerializeField] private float rotationSpeed = 30; //rotation speed of the player
    Rigidbody2D rb; //rigidbody collider of the player, which we are using to move the player
    void setRotation(float rotation){this.rotation = rotation;} //sets the rotation value
    float getRotation(){return this.rotation;} //fetches the stored rotation value
    void setRotationSpeed(float rotationSpeed){this.rotationSpeed = rotationSpeed;} //sets the rotation speed
    float getRotationSpeed(){return this.rotationSpeed;} //fetches the rotation speed
    void Start() //runs when the object starts to exist
    {
        rb = GetComponent<PlayerController>().getRb(); //sets up the rigidbody
    }
    void Update() //happens every frame
    {
        setRotation(getRotation() + Input.GetAxisRaw("Rotation") * rotationSpeed); //sets the rotation of the player to the angle dictated by the player, using arrow keys
        rb.rotation = getRotation(); //sets the players rotation, using the stored rotation value
    }
}
