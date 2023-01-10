using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarParity : MonoBehaviour
{
    [SerializeField] private GameObject[] fullHeart;//list of full hearts, state 0 for empty, state 1 for damaged, state 2 for full
    [SerializeField] private GameObject[] halfHeart;//list of half hearts, state 0 for empty, state 1 for full (use in case of odd health value)
    [SerializeField] private GameObject player; //the player gameobject
    [SerializeField] private GameObject healthBar; //healthbar GUI gameobject
    [SerializeField] private int currentHealth; //current health of the player, possibly removeable
    [SerializeField] private int maxHealth; //maximum health of the player, possibly removeable

	public GameObject getFullHeart(int x) {return this.fullHeart[x];} //fetches a heart state from the list of full heart states
	public GameObject getHalfHeart(int x) {return this.halfHeart[x];} //fetches a heart state from the list of half heart states
    public GameObject getPlayer() {return this.player;} //fetches the player, likely to pull its health
    public GameObject getHealthBar() {return this.healthBar;} //fetches the healthbar GUI gameobject
	public int getCurrentHealth() {return this.currentHealth;} //fetches the players current health, possibly removeable
    public void setCurrentHealth(float currentHealth) {this.currentHealth = (int)currentHealth;} //sets players current health, possibly removeable
    public int getMaxHealth() {return this.maxHealth;} //fetches the players stored maximum health, possibly removeable
    public void setMaxHealth(float maxHealth) {this.maxHealth = (int)maxHealth;} //stores the players maximum health, possibly removeable

    void Start() //called when the healthbar starts to exist
    {
        renderHealth(); //initial call to set up players health bar
    }
    void updateHealth(){ //called to update pulled health values
        HealthController healthScript = getPlayer().GetComponentInParent<HealthController>(); //pulls in the player health script
        setCurrentHealth(healthScript.getHealth()); //fetches the current health of the player
        setMaxHealth(healthScript.getMaxHealth()); //fetches the maximum health of the player
    }

    public void renderHealth(){
        updateHealth(); //ensures health values are current
        foreach (Transform child in getHealthBar().transform){ //purges the current health bar, by iterating through each heart visible
            GameObject.Destroy(child.gameObject); //deletes each heart object
        }
        //determine heart types required
        int healthyHearts = getCurrentHealth() / 2; //the number of full hearts
        int damagedHeart = 0; //the number of damage hearts, which should only ever be 1
        if((getCurrentHealth() != getMaxHealth()) && (getCurrentHealth() % 2 == 1)){ //checks if a damaged heart should exist, in specific cases
            damagedHeart = 1; //sets the damaged heart to exist if needed
        }
        int emptyHearts = (getMaxHealth() / 2) - (healthyHearts + (int)damagedHeart); //empty hearts are needed to placehold healable health
        int[] hearts = {emptyHearts, damagedHeart, healthyHearts}; //list to iterate through in the for loop later

        int pos = 0; //Initial position of the hearts in the health bar, incremented
        int offset = (int)getFullHeart(0).GetComponent<RectTransform>().rect.width; //fetches the distance the hearts have to be from eachother
        for(int i = 2; i>=0;i--){ //for each type of heart
            for(int h = 0; h<hearts[i]; h++){ //and for n number of hearts within each type of heart
                GameObject heart = Instantiate(getFullHeart(i), getHealthBar().transform.position, getHealthBar().transform.rotation, getHealthBar().transform);
                heart.transform.localPosition += new Vector3(pos,0,0); //very long line above just creates a given heart, and this line positions it right
                pos+=offset; //increments the heart position
            }
        }

        if(getMaxHealth() % 2 == 1){ //checks if a half heart is needed (for odd number of health)
            GameObject heart; //specifies the heart variable to this scope
            if(getCurrentHealth() == getMaxHealth()){ //if health is full
                heart = Instantiate(getHalfHeart(1), getHealthBar().transform.position, getHealthBar().transform.rotation, getHealthBar().transform);
                        //create a filled half heart
            }else{ //if health isnt full
                heart = Instantiate(getHalfHeart(0), getHealthBar().transform.position, getHealthBar().transform.rotation, getHealthBar().transform);
            }       //create an empty half heart
            heart.transform.localPosition += new Vector3(pos,0,0); //heart position is the end of the health bar
        }
    }
}
