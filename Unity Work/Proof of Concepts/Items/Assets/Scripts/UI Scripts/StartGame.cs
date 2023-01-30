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
            BroadcastMessage("PullStat");
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
    }
}
