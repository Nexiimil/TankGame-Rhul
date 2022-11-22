using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float rotation = 0;
    [SerializeField] private float rotationSpeed = 30;
    Rigidbody2D rb;
    void setRotation(float rotation){this.rotation = rotation;}
    float getRotation(){return this.rotation;}
    void setRotationSpeed(float rotationSpeed){this.rotationSpeed = rotationSpeed;}
    float getRotationSpeed(){return this.rotationSpeed;}
    void Start()
    {
        rb = GetComponent<PlayerController>().getRb();
    }
    void fixedUpdate()
    {
        setRotation(getRotation() + Input.GetAxisRaw("Rotation") * rotationSpeed);
        rb.rotation = getRotation();
    }
}
