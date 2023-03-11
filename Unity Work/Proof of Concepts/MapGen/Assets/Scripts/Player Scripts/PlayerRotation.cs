using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private EntityController player;
    [SerializeField] private float rotationSpeed; //rotation speed of the player

    public EntityController Player { get => player; set => player = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }

    void Update() //happens every frame
    {
        player.Rb.rotation -= Input.GetAxisRaw("Rotation") * rotationSpeed*  Time.deltaTime % 360; //sets the players rotation, using the stored rotation value
    }
    void PullStat(){
        Stats stat = Player.Sa.Find(r => r.statName == "EntityRoSpeed");
        RotationSpeed = Stats.capFlatPerc(75, stat.flatStat, stat.percentageStat, 600);
    }
}
