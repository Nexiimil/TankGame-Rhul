using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BulletEffects : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private float _damage; 
    [SerializeField] private List<Affliction> _transfer = new List<Affliction>();

    public string Tag { get => _tag; set => _tag = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public List<Affliction> Transfer { get => _transfer; set => _transfer = value; }


    void PullStat(){
        Stats sa = GetComponent<EntityController>().Sa.Find(r => r.statName == "BulletDamage");
        Damage = Stats.capFlatPerc(1, sa.flatStat, sa.percentageStat, 100);
    }
    void OnCollisionEnter2D(Collision2D col){ //triggers on bullet colliding with an entity with a collider component
        StartCoroutine(DealDamage(col));
    }

    IEnumerator DealDamage(Collision2D col){
        HealthController healthScript = col.collider.GetComponent<HealthController>(); //fetches the health script of the target
        if(col.collider.tag != Tag){ //damage can only be dealt to entities of a different tag eg. player vs enemy
            if(healthScript != null){ //target can only be damaged if there is a health script attached to it
                healthScript.TakeDamage(Math.Max(Damage-healthScript.Armor, 1)); //inflicts the damage upon the target entities health
                foreach(Affliction a in Transfer){
                    EntityController ec = col.collider.GetComponent<EntityController>();
                    int afToChange = ec.Af.FindIndex(r => r.Ief.GetType() == a.GetType());
                    if(afToChange == -1){
                        ec.Af.Add(a);
                    } else {
                        ec.Af[afToChange] = a;
                    }
                }
                if(col.collider.tag == "Player"){
                    HealthBarParity refresh = col.collider.GetComponent<HealthBarParity>(); //fetches the health bar
                    refresh.PullStat(); //triggers the health bar to update
                }
            }
        }

        if(gameObject.GetComponent<HealthController>() == null){
            Destroy(gameObject); //destroys the bullet on collision, preventing further collisions
        } else {
            Stats stat = gameObject.GetComponent<EntityController>().Sa.Find(r => r.statName == "EntityFireSpeed");
            float FireSpeed = Stats.capFlatPerc(1, stat.flatStat, stat.percentageStat, 100);
            yield return new WaitForSeconds(1/FireSpeed);
        }
        yield return null;
    }
}
