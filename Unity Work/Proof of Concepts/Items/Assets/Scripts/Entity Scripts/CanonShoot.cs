using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    [SerializeField] private Transform cannon; //the cannon the bullet was shot from
    [SerializeField] private GameObject projectile; //the projectile prefab to be fired
    [SerializeField] private float damage; //the damage value the projectile asserts on the target
    [SerializeField] private float projectileSpeed; //the rate of travel of the projectile
    [SerializeField] private float fireSpeed; //rate of fire of projectiles
    [SerializeField] private bool canFire = true; //ensures the cannon can fire

    public Transform Cannon { get => cannon; set => cannon = value; }
    public GameObject Projectile { get => projectile; set => projectile = value; }
    public float Damage { get => damage; set => damage = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public float FireSpeed { get => fireSpeed; set => fireSpeed = value; }
    public bool CanFire { get => canFire; set => canFire = value; }

    void PullStat(){
        EntityController entity = (EntityController)GetComponentInParent(typeof(EntityController));
        Stats stat = entity.Sa.Find(r => r.statName == "BulletDamage");
        Damage = stat.flatStat * (1 + stat.percentageStat);
        stat = entity.Sa.Find(r => r.statName == "BulletSpeed");
        ProjectileSpeed = stat.flatStat * (1 + stat.percentageStat);
        stat = entity.Sa.Find(r => r.statName == "EntityFireSpeed");
        FireSpeed = stat.flatStat * (1 + stat.percentageStat);
    }
    void Update() //called every frame
    {
        PullStat();
        if(Input.GetAxisRaw("Fire1") > 0 || gameObject.tag == "Enemy"){ //ensures the flag for being able to fire is true
            StartCoroutine(FireCannon()); //starts the shooting script, and since it uses real time, starts in a coroutine so i can use yield
        }
    }

    IEnumerator FireCannon(){
        if(CanFire){
            CanFire = (false);
            GameObject projectile = Instantiate(Projectile, Cannon.position, Cannon.rotation);
            BulletEffects be = (BulletEffects)projectile.GetComponent("BulletEffects");
            be.Tag = transform.tag;
            be.Damage = Damage;
            projectile.GetComponent<Rigidbody2D>().AddForce(Cannon.right * ProjectileSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1/FireSpeed);
            CanFire = (true);
        }
    }
}
