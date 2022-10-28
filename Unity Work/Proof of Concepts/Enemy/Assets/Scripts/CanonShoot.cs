using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    [SerializeField] private Transform canon;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float damage;
    [SerializeField] private float projectileSpeed = 20;
    [SerializeField] private float fireSpeed = 20;
    [SerializeField] private bool canFire = true;
    public float getDamage(){return this.damage;}
    public void setDamage(float damage){this.damage = damage;}
    public void setCanon(Transform canon){this.canon = canon;}
    public Transform getCanon(){return this.canon;}  
    public void setProjectile(GameObject projectile){this.projectile = projectile;}
    public GameObject getProjectile(){return this.projectile;}  
    public void setProjectileSpeed(float projectileSpeed){this.projectileSpeed = projectileSpeed;}
    public float getProjectileSpeed(){return this.projectileSpeed;}
    public void setFireSpeed(float fireSpeed){this.fireSpeed = fireSpeed;}
    public float getFireSpeed(){return this.fireSpeed;}  
    public void setCanFire(bool canFire){this.canFire = canFire;}
    public bool getCanFire(){return this.canFire;}      

    void Update()
    {
        if(Input.GetAxisRaw("Fire1") > 0 || gameObject.tag == "Enemy"){
            StartCoroutine(FireCanon());
        }
    }

    IEnumerator FireCanon(){
        if(getCanFire()){
            setCanFire(false);
            GameObject projectile = Instantiate(getProjectile(), getCanon().position, getCanon().rotation, getCanon());
            projectile.GetComponent<Rigidbody2D>().AddForce(getCanon().right * getProjectileSpeed(), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1/getFireSpeed());
            setCanFire(true);
        }
    }
}
