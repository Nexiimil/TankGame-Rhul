using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    [SerializeField] private Transform cannon; //the cannon the bullet was shot from
    [SerializeField] private GameObject projectile; //the projectile prefab to be fired
    [SerializeField] private float damage; //the damage value the projectile asserts on the target
    [SerializeField] private float projectileSpeed = 20; //the rate of travel of the projectile
    [SerializeField] private float fireSpeed = 20; //rate of fire of projectiles
    [SerializeField] private bool canFire = true; //ensures the cannon can fire
    
    public void setDamage(float damage){this.damage = damage;} //sets the damage value
    public float getDamage(){return this.damage;} //fecthes the damage value
    public void setCannon(Transform cannon){this.cannon = cannon;} //sets the cannon
    public Transform getCannon(){return this.cannon;}  //fetches the cannon
    public GameObject getProjectile(){return projectile;} //fetches the projectile
    public void setProjectileSpeed(float projectileSpeed){this.projectileSpeed = projectileSpeed;} //sets the projectiles speed
    public float getProjectileSpeed(){return this.projectileSpeed;} //fetches the projectiles speed
    public void setFireSpeed(float fireSpeed){this.fireSpeed = fireSpeed;} //sets the fire rate
    public float getFireSpeed(){return this.fireSpeed;}  //fetches the fire rate
    public void setCanFire(bool canFire){this.canFire = canFire;} //sets the fire flag
    public bool getCanFire(){return this.canFire;} //fetches the fire flag

    void Update() //called every frame
    {
        if(Input.GetAxisRaw("Fire1") > 0 || gameObject.tag == "Enemy"){ //ensures the flag for being able to fire is true
            StartCoroutine(FireCannon()); //starts the shooting script, and since it uses real time, starts in a coroutine so i can use yield
        }
    }

    IEnumerator FireCannon(){
        if(getCanFire()){
            setCanFire(false);
            GameObject projectile = Instantiate(getProjectile(), getCannon().position, getCannon().rotation, getCannon());
            projectile.GetComponent<Rigidbody2D>().AddForce(getCannon().right * getProjectileSpeed(), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1/getFireSpeed());
            setCanFire(true);
        }
    }
}
