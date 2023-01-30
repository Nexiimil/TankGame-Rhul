using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BulletEffects : MonoBehaviour
{
    [SerializeField] private string _tag; //the cannon the bullet was shot from
    [SerializeField] private float _damage; //the cannon the bullet was shot from

    public string Tag { get => _tag; set => _tag = value; }
    public float Damage { get => _damage; set => _damage = value; }

    void OnCollisionEnter2D(Collision2D col){ //triggers on bullet colliding with an entity with a collider component
        HealthController healthScript = col.collider.GetComponent<HealthController>(); //fetches the health script of the target
        if(col.collider.tag != Tag){ //damage can only be dealt to entities of a different tag eg. player vs enemy
            if(healthScript != null){ //target can only be damaged if there is a health script attached to it
                healthScript.Health = healthScript.Health - Math.Max(Damage-healthScript.Armor, 1); //inflicts the damage upon the target entities health
                HealthBarParity refresh = GameObject.FindWithTag("Healthbar").GetComponent<HealthBarParity>(); //fetches the health bar
                refresh.PullStat(); //triggers the health bar to update
            }
        }
        Destroy(gameObject); //destroys the bullet on collision, preventing further collisions
    }
}
