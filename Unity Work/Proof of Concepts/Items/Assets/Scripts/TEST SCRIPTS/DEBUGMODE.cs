using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGMODE : MonoBehaviour{
    private RoomController _rc;   //Target the enemy factory

    public RoomController Rc { get => _rc; set => _rc = value; }
    void Start(){
        Rc = (RoomController) GetComponent("RoomController");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyUp(KeyCode.O)){ //Check for key input
            Rc.Ef.Create(Enemy.Shooter, 1); //Spawn an enemy     
        }
        if (Input.GetKeyUp(KeyCode.I)){ //Check for key input//Target the enemy factory
            Rc.Itf.Create(5); //Spawn an enemy     
        }
    }
}
