using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarParity : MonoBehaviour
{
    [SerializeField] private GameObject[] fullHeart;//state 0 for empty, state 1 for damaged, state 2 for full
    [SerializeField] private GameObject[] halfHeart;//state 0 for empty, state 1 for full (use in case of odd health value)
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

	public GameObject getFullHeart(int x) {return this.fullHeart[x];}
	public GameObject getHalfHeart(int x) {return this.halfHeart[x];}

    public GameObject getPlayer() {return this.player;}

    public GameObject getHealthBar() {return this.healthBar;}

	public int getCurrentHealth() {return this.currentHealth;}
    public void setCurrentHealth(float currentHealth) {this.currentHealth = (int)currentHealth;}

    public int getMaxHealth() {return this.maxHealth;}
    public void setMaxHealth(float maxHealth) {this.maxHealth = (int)maxHealth;}

    void Start()
    {
        //Set Players Health Bar Up
        renderHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateHealth(){
        HealthController healthScript = getPlayer().GetComponentInParent<HealthController>();
        setCurrentHealth(healthScript.getHealth());
        setMaxHealth(healthScript.getMaxHealth());
    }
    public void renderHealth(){
        updateHealth();
        foreach (Transform child in getHealthBar().transform){
            GameObject.Destroy(child.gameObject);
        }
        //determine heart types required
        int healthyHearts = getCurrentHealth() / 2;
        int damagedHeart = 0;
        if((getCurrentHealth() != getMaxHealth()) && (getCurrentHealth() % 2 == 1)){
            damagedHeart = 1;
        }
        int emptyHearts = (getMaxHealth() / 2) - (healthyHearts + (int)damagedHeart);
        int[] hearts = {emptyHearts, damagedHeart, healthyHearts};
        int pos = 0;
        int offset = (int)getFullHeart(0).GetComponent<RectTransform>().rect.width;
        for(int i = 2; i>=0;i--){
            for(int h = 0; h<hearts[i]; h++){
                GameObject heart = Instantiate(getFullHeart(i), getHealthBar().transform.position, getHealthBar().transform.rotation, getHealthBar().transform);
                heart.transform.localPosition += new Vector3(pos,0,0);
                pos+=offset;
            }
        }

        if(getMaxHealth() % 2 == 1){
            GameObject heart;
            if(getCurrentHealth() == getMaxHealth()){
                heart = Instantiate(getHalfHeart(1), getHealthBar().transform.position, getHealthBar().transform.rotation, getHealthBar().transform);

            }else{
                heart = Instantiate(getHalfHeart(0), getHealthBar().transform.position, getHealthBar().transform.rotation, getHealthBar().transform);
            }
            heart.transform.localPosition += new Vector3(pos,0,0);
        }
    }
}
