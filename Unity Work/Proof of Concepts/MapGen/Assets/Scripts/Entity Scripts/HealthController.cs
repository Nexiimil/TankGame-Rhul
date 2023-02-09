using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float health; //the current health of the entity
    [SerializeField] private float maximumHealth; //the current health of the entity
    [SerializeField] private float armor;
    [SerializeField] private EntityController entity;

    public float Health { get => health; set => health = value; }
    public float MaximumHealth { get => maximumHealth; set => maximumHealth = value; }
    public float Armor { get => armor; set => armor = value; }

    public EntityController getEntity() {return this.entity;}

    public void TakeDamage(float d){
        Health = Health - d;
        StartCoroutine(DamageTick());
        SendMessage("PullStat");
        if (Health <= 0){  //checks to see if a unit has died
            Destroy(gameObject); //destroys the object, since it no longer has health
        }
    }

    void Start(){
        Stats stat = getEntity().Sa.Find(r => r.statName == "MaxHealth"); //pulls the maximum health
        Health = (stat.flatStat * (1+stat.percentageStat));
        stat = getEntity().Sa.Find(r => r.statName == "EntityArmor"); //pulls the armor of the unit
        Armor = (stat.flatStat * (1+stat.percentageStat));
    }
    void PullStat()
    {
        Stats stat = getEntity().Sa.Find(r => r.statName == "MaxHealth"); //pulls the maximum health
        MaximumHealth = stat.flatStat * (1+stat.percentageStat);
        
    }
    IEnumerator DamageTick(){
        Color c = gameObject.GetComponent<Renderer>().material.color;
        c.a = 0;
        gameObject.GetComponent<Renderer>().material.color = c;
        yield return new WaitForSeconds(1/4);
        c.a = 1;
        gameObject.GetComponent<Renderer>().material.color = c;
    }
}
