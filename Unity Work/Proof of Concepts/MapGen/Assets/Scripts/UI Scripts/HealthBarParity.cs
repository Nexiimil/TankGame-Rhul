using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarParity : MonoBehaviour
{
    [SerializeField] private GameObject[] fullHeart;//list of full hearts, state 0 for empty, state 1 for damaged, state 2 for full
    [SerializeField] private GameObject[] halfHeart;//list of half hearts, state 0 for empty, state 1 for full (use in case of odd health value)
    [SerializeField] private EntityController player; //the player gameobject
    [SerializeField] private GameObject healthBar; //healthbar GUI gameobject
    [SerializeField] private int currentHealth; //current health of the player, possibly removeable
    [SerializeField] private int maxHealth; //maximum health of the player, possibly removeable

    public GameObject[] FullHeart { get => fullHeart; set => fullHeart = value; }
    public GameObject[] HalfHeart { get => halfHeart; set => halfHeart = value; }
    public EntityController Player { get => player; set => player = value; }
    public GameObject HealthBar { get => healthBar; set => healthBar = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    void Start() //called when the healthbar starts to exist
    {
        PullStat(); //initial call to set up players health bar
    }
    void updateHealth(){ //called to update pulled health values
        HealthController healthScript = Player.GetComponentInParent<HealthController>(); //pulls in the player health script
        CurrentHealth = (int)(healthScript.Health); //fetches the current health of the player
        MaxHealth = (int)(Player.Sa.Find(r => r.statName == "MaxHealth").flatStat); //fetches the maximum health of the player
    }

    public void PullStat(){
        updateHealth(); //ensures health values are current
        foreach (Transform child in HealthBar.transform){ //purges the current health bar, by iterating through each heart visible
            GameObject.Destroy(child.gameObject); //deletes each heart object
        }
        //determine heart types required
        int healthyHearts = CurrentHealth / 2; //the number of full hearts
        int damagedHeart = 0; //the number of damage hearts, which should only ever be 1
        if((CurrentHealth != MaxHealth) && (CurrentHealth % 2 == 1)){ //checks if a damaged heart should exist, in specific cases
            damagedHeart = 1; //sets the damaged heart to exist if needed
        }
        int emptyHearts = (MaxHealth / 2) - (healthyHearts + (int)damagedHeart); //empty hearts are needed to placehold healable health
        int[] hearts = {emptyHearts, damagedHeart, healthyHearts}; //list to iterate through in the for loop later

        int pos = 0; //Initial position of the hearts in the health bar, incremented
        int offset = (int)FullHeart[0].GetComponent<RectTransform>().rect.width; //fetches the distance the hearts have to be from eachother
        for(int i = 2; i>=0;i--){ //for each type of heart
            for(int h = 0; h<hearts[i]; h++){ //and for n number of hearts within each type of heart
                GameObject heart = Instantiate(FullHeart[i], HealthBar.transform.position, HealthBar.transform.rotation, HealthBar.transform);
                heart.transform.localPosition += new Vector3(pos,0,0); //very long line above just creates a given heart, and this line positions it right
                pos+=offset; //increments the heart position
            }
        }

        if(MaxHealth % 2 == 1){ //checks if a half heart is needed (for odd number of health)
            GameObject heart; //specifies the heart variable to this scope
            if(CurrentHealth == MaxHealth){ //if health is full
                heart = Instantiate(HalfHeart[1], HealthBar.transform.position, HealthBar.transform.rotation, HealthBar.transform);
                        //create a filled half heart
            }else{ //if health isnt full
                heart = Instantiate(HalfHeart[0], HealthBar.transform.position, HealthBar.transform.rotation, HealthBar.transform);
            }       //create an empty half heart
            heart.transform.localPosition += new Vector3(pos,0,0); //heart position is the end of the health bar
        }
    }
}