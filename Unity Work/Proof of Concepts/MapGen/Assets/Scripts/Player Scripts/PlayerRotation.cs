using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private EntityController player;
    [SerializeField] private float rotationSpeed; //rotation speed of the player

    EntityController getPlayer(){return this.player;}
    void setRotationSpeed(float rotationSpeed){this.rotationSpeed = rotationSpeed;} //sets the rotation speed
    float getRotationSpeed(){return this.rotationSpeed;} //fetches the rotation speed

    void Update() //happens every frame
    {
        player.getRB().rotation += (Input.GetAxisRaw("Rotation") * rotationSpeed*  Time.deltaTime) % 360; //sets the players rotation, using the stored rotation value
    }
    void PullStat(){
        Stats stat = getPlayer().Sa.Find(r => r.statName == "EntityRoSpeed");
        setRotationSpeed(Stats.capFlatPerc(75, stat.flatStat, stat.percentageStat, 600));
    }
}
