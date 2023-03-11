using System.Collections;
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
    public EntityController Entity { get => entity; set => entity = value; }

    public void TakeDamage(float d){
        Health -= d;
        if (Health > MaximumHealth){
            Health = MaximumHealth;
        }
        StartCoroutine(DamageTick());
        SendMessage("PullStat");
        if (Health <= 0){  //checks to see if a unit has died
            Destroy(gameObject); //destroys the object, since it no longer has health
        }
    }

    void Start(){
        PullStat();
        Health = MaximumHealth;
    }

    void PullStat()
    {
        Stats stat = Entity.Sa.Find(r => r.statName == "MaxHealth"); //pulls the maximum health
        MaximumHealth = Stats.capFlatPerc(1, stat.flatStat, stat.percentageStat, 10);
        stat = Entity.Sa.Find(r => r.statName == "EntityArmor"); //pulls the armor of the unit
        Armor = Stats.capFlatPerc(1, stat.flatStat, stat.percentageStat, 10);
        
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
