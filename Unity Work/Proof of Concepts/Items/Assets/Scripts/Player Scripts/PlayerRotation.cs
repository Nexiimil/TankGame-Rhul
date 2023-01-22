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
    void Start(){
        PullStat();
    }
    void Update() //happens every frame
    {
        player.getRB().rotation += (Input.GetAxisRaw("Rotation") * rotationSpeed) % 360; //sets the players rotation, using the stored rotation value
    }
    void PullStat(){
        Stats stat = getPlayer().getStatArray().Find(r => r.statName == "EntityRoSpeed");
        setRotationSpeed(stat.flatStat * (1+stat.percentageStat));
    }
}
