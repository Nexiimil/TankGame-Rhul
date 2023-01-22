using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] activate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("space") && GetComponentInParent<Text>().text.Substring(0,3) == " - "){
            initialiseGame();
        }
    }
    void initialiseGame(){
        Debug.Log("Game initialised");
        PauseCheck pauseTrigger = GameObject.FindWithTag("StateController").GetComponent<PauseCheck>();
        pauseTrigger.TogglePause();
        GameObject menu = GameObject.FindWithTag("StartMenu");
        menu.SetActive(false);
        foreach(GameObject go in activate){
            go.SetActive(true);
        }
        EntityController playerSetup = (EntityController)GameObject.FindWithTag("Player").GetComponent("EntityController");
        playerSetup.setStatArray(new List<Stats>{
                                        new Stats("BulletType", 0, 0),
                                        new Stats("BulletDamage", 1, 0),
                                        new Stats("BulletSpeed", 20, 0),
                                        new Stats("BulletCrit", 0, 0),
                                        new Stats("EntityArmour", 0, 0),
                                        new Stats("EntitySpeed", 2, 0),
                                        new Stats("EntityFireSpeed", 30, 0),
                                        new Stats("EntityRoSpeed", 2, 0),
                                        new Stats("MaxHealth", 5, 0),
                                        new Stats("Cannons", 2,0)
                                    }
                                );

    }
}
