using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile; //the projectile prefab to be fired
    [SerializeField] private float damage; //the damage value the projectile asserts on the target
    [SerializeField] private float projectileSpeed; //the rate of travel of the projectile
    [SerializeField] private float fireSpeed; //rate of fire of projectiles
    [SerializeField] private bool canFire = true; //ensures the cannon can fire

    public GameObject Projectile { get => projectile; set => projectile = value;}
    public float Damage { get => damage; set => damage = value;}
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value;}
    public float FireSpeed { get => fireSpeed; set => fireSpeed = value;}
    public bool CanFire { get => canFire; set => canFire = value;}

    void Start(){
        PullStat();
    }

    public void PullStat(){
        EntityController entity = GetComponentInParent<EntityController>();
        Stats stat = entity.Sa.Find(r => r.statName == "BulletDamage");
        Damage = Stats.capFlatPerc(1, stat.flatStat, stat.percentageStat, 100);
        stat = entity.Sa.Find(r => r.statName == "BulletSpeed");
        ProjectileSpeed = Stats.capFlatPerc(1, stat.flatStat, stat.percentageStat, 100);
        stat = entity.Sa.Find(r => r.statName == "EntityFireSpeed");
        FireSpeed = Stats.capFlatPerc(1, stat.flatStat, stat.percentageStat, 100);
    }
    void Update() //called every frame
    {
        if(Input.GetAxisRaw("Fire1") > 0 || gameObject.tag == "Enemy"){ //ensures the flag for being able to fire is true
            StartCoroutine(FireCannon()); //starts the shooting script, and since it uses real time, starts in a coroutine so i can use yield
        }
    }

    IEnumerator FireCannon(){
        Transform cannon = gameObject.transform;
        if(CanFire){
            CanFire = false;
            GameObject projectile = Instantiate(Projectile, cannon.position, cannon.rotation);
            BulletEffects be = projectile.GetComponent<BulletEffects>();
            foreach(IEffect ief in GetComponentInParent<EntityController>().Ef){
                IEffect eff = ief.RollAfflictionChance();
                if(eff != null){
                    be.Transfer.Add(new Affliction(gameObject.transform.parent.gameObject, ief.ExpireCalc(), eff));
                }
            }
            be.Tag = transform.tag;
            be.Damage = Damage;
            projectile.GetComponent<Rigidbody2D>().AddForce(cannon.right * ProjectileSpeed, ForceMode2D.Impulse);
            Destroy(projectile, 30.0f);
            yield return new WaitForSeconds(1/FireSpeed);
            CanFire = true;
        }
    }
}
