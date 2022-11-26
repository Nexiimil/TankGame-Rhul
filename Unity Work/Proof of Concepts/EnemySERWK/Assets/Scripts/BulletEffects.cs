using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffects : MonoBehaviour
{
    [SerializeField] private CanonShoot parentCanon;

    CanonShoot getCanon(){return this.parentCanon;}
	void setCanon(CanonShoot parentCanon){this.parentCanon = parentCanon;}

    void Start(){
        setCanon(gameObject.GetComponentInParent<CanonShoot>());
    }

    void OnCollisionEnter2D(Collision2D col){
        HealthController healthScript = col.collider.GetComponentInParent<HealthController>();;
        if(col.collider.tag != transform.parent.tag){
            if(healthScript != null){
            healthScript.setHealth(healthScript.getHealth() - getCanon().getDamage());
        }
        }
        
        Destroy(gameObject);
    }
}
