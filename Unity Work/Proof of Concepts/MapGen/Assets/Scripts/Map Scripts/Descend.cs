using UnityEngine;

public class Descend : MonoBehaviour{
    [SerializeField] RoomController _rc;

    public RoomController Rc { get => _rc; set => _rc = value; }

    void OnCollisionEnter2D(Collision2D col){ 
        if(col.collider.tag == "Player" && gameObject.transform.Find("Stairs").gameObject.activeSelf){
            Rc.ChangeRoom(Neighbours.Null);
        }
    }
}