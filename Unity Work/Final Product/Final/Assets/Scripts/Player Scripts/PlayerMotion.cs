using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour{
    [SerializeField] private EntityController player;
    [SerializeField] private float playerSpeed;

    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }
    public EntityController Player { get => player; set => player = value; }

    void Start(){
        PullStat();
    }
    void Update(){
        player.Rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*PlayerSpeed, Input.GetAxisRaw("Vertical")*PlayerSpeed);
    }
    void PullStat(){
        Stats stat = player.Sa.Find(r => r.statName == "EntitySpeed");
        PlayerSpeed = Stats.capFlatPerc(1, stat.flatStat, stat.percentageStat, 4);
    }
}