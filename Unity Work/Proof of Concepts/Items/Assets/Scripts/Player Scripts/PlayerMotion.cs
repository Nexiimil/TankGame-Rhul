using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour{
    [SerializeField] private EntityController player;
    [SerializeField] private float playerSpeed;
    EntityController getPlayer(){return this.player;}
    void setPlayerSpeed(float playerSpeed){this.playerSpeed = playerSpeed;}
    float getPlayerSpeed(){return this.playerSpeed;}
    void Start(){
        PullStat();
    }
    void Update(){
        player.getRB().velocity = new Vector2(Input.GetAxisRaw("Horizontal")*getPlayerSpeed(), Input.GetAxisRaw("Vertical")*getPlayerSpeed());
    }
        void PullStat(){
        Stats stat = getPlayer().Sa.Find(r => r.statName == "EntitySpeed");
        setPlayerSpeed(stat.flatStat * (1+stat.percentageStat));
    }
}