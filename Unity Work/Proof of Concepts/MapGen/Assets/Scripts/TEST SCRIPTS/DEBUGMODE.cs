using UnityEngine;

public class DEBUGMODE : MonoBehaviour{
    private RoomController _rc;   //Target the enemy factory

    public RoomController Rc { get => _rc; set => _rc = value; }
    void Start(){
        Rc = (RoomController) GetComponent("RoomController");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyUp(KeyCode.I)){ //Check for key input
            Rc.Itf.Create(ItemPoolGeneration.GenerateRandomDrop()); //Spawn an item     
        }
        if (Input.GetKeyUp(KeyCode.H)){ //Check for key input
            GameObject go = GameObject.FindWithTag("Player");
            HealthController hc = go.GetComponent<HealthController>(); //Heal the player
            hc.TakeDamage(-1);
        }
    }
}
