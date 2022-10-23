using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    [SerializeField]
    private Transform canon;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float projectileSpeed = 20;

    [SerializeField]
    private float fireSpeed = 20;

    [SerializeField]
    private bool canFire = true;

    void setCanon(Transform canon){this.canon = canon;}
    Transform getCanon(){return this.canon;}  
    void setProjectile(GameObject projectile){this.projectile = projectile;}
    GameObject getProjectile(){return this.projectile;}  
    void setProjectileSpeed(float projectileSpeed){this.projectileSpeed = projectileSpeed;}
    float getProjectileSpeed(){return this.projectileSpeed;}
    void setFireSpeed(float fireSpeed){this.fireSpeed = fireSpeed;}
    float getFireSpeed(){return this.fireSpeed;}  
    void setCanFire(bool canFire){this.canFire = canFire;}
    bool getCanFire(){return this.canFire;}      

    void Update()
    {
        if(Input.GetAxisRaw("Fire1") > 0){
            StartCoroutine(FireCanon());
        }
    }

    IEnumerator FireCanon(){
        if(getCanFire()){
            setCanFire(false);
            GameObject projectile = Instantiate(getProjectile(), getCanon().position, getCanon().rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(getCanon().up * getProjectileSpeed(), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1/getFireSpeed());
            setCanFire(true);
        }
    }
}
