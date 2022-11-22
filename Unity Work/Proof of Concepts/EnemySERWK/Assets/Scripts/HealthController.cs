using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float health;

    public float getHealth(){return this.health;}
    public void setHealth(float health){this.health = health;}

    void Start()
    {
        setHealth(5);
    }

    void Update(){
        if (getHealth() <= 0){
            Destroy(gameObject);
        }
    }
}
