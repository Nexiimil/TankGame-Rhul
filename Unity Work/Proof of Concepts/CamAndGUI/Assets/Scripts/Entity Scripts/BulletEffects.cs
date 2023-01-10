using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletEffects : MonoBehaviour
{
    [SerializeField] private CanonShoot parentCanon; //the cannon the bullet was shot from
    CanonShoot getCanon(){return this.parentCanon;} //fetches the parent cannon of the bullet
	void setCanon(CanonShoot parentCanon){this.parentCanon = parentCanon;} //sets the parent cannon of the bullet

    void Start(){
        setCanon(gameObject.GetComponentInParent<CanonShoot>()); //sets up the parent cannon for use per frame
    }

    void OnCollisionEnter2D(Collision2D col){ //triggers on bullet colliding with an entity with a collider component
        HealthController healthScript = col.collider.GetComponentInParent<HealthController>(); //fetches the health script of the target
        if(col.collider.tag != transform.parent.tag){ //damage can only be dealt to entities of a different tag eg. player vs enemy
            if(healthScript != null){ //target can only be damaged if there is a health script attached to it
                healthScript.setHealth(healthScript.getHealth() - getCanon().getDamage()); //inflicts the damage upon the target entities health
                HealthBarParity refresh = GameObject.FindWithTag("Healthbar").GetComponent<HealthBarParity>(); //fetches the health bar
                refresh.renderHealth(); //triggers the health bar to update
            }
        }
        Destroy(gameObject); //destroys the bullet on collision, preventing further collisions
    }
}
