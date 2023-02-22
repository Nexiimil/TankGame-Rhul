using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameStart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] activate;
    [SerializeField] private GameObject room;
    [SerializeField] private GameObject player;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("space") && GetComponentInParent<Text>().text.Substring(0,3) == " - "){
            ToggleGame();
        }
    }
    void ToggleGame(){
        Debug.Log("Game Toggled");
        PauseCheck pauseTrigger = GameObject.FindWithTag("StateController").GetComponent<PauseCheck>();
        pauseTrigger.SetPaused(false);
        pauseTrigger.UnpauseGame();
        foreach(GameObject go in activate){
            go.SetActive(!go.activeSelf);
        }
        GameObject enemyPool = GameObject.FindWithTag("Enemies");
        if (enemyPool != null){
            foreach (Transform child in enemyPool?.transform){ //purges the current health bar, by iterating through each heart visible
                GameObject.Destroy(child.gameObject); //deletes each heart object

            }
        }
        room.BroadcastMessage("PullStat");
    }
}

