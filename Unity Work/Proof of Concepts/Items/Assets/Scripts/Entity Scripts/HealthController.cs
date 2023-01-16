using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float health; //the current health of the entity
    [SerializeField] private EntityController entity;
    public float getHealth(){return this.health;} //fetches the current health
    public void setHealth(float health){this.health = health;} //sets the current health
    public EntityController getEntity() {return this.entity;}
    void Start()
    {
        setHealth(getEntity().getStatArray().getStat("MaxHealth")); //for the sake of testing, all units start with 5 health
    }

    void Update(){ //called every second, may be worth putting on the bullet, rather than checking every second
        if (getHealth() <= 0){  //checks to see if a unit has died
            Destroy(gameObject); //destroys the object, since it no longer has health
        }
    }
}
