using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour{
    [SerializeField] private float playerSpeed;
    [SerializeField] private PlayerController player;
    void setPlayerSpeed(float playerSpeed){this.playerSpeed = playerSpeed;}
    float getPlayerSpeed(){return this.playerSpeed;}
    void Start(){
    }
    void Update(){
        player.getRB().velocity = new Vector2(new float[] {Input.GetAxisRaw("Horizontal")*getPlayerSpeed(), Input.GetAxisRaw("Vertical")*getPlayerSpeed()});
    }
}