using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour{
    [SerializeField] private float[] position = {0,0};
    [SerializeField] private float playerSpeed = 2;
    Rigidbody2D rb;
    void setPosition(float[] position){this.position = position;}
    void setPositionHorizontal(float horizontal){this.position[0] = horizontal;}
    void setPositionVertical(float vertical){this.position[1] = vertical;}
    float getPositionHorizontal(){return this.position[0];}
    float getPositionVertical(){return this.position[1];}
    void setPlayerSpeed(float playerSpeed){this.playerSpeed = playerSpeed;}
    float getPlayerSpeed(){return this.playerSpeed;}
    void Start(){
        rb = GetComponent<PlayerController>().getRb();
    }
    void FixedUpdate(){
        setPosition(new float[] {Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")});
        rb.velocity = new Vector2(getPositionHorizontal()*getPlayerSpeed(), getPositionVertical()*getPlayerSpeed());
    }
}
