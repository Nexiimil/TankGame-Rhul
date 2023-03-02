using UnityEngine;

public class EnterDoor : MonoBehaviour{
    [SerializeField] RoomController _rc;

    public RoomController Rc { get => _rc; set => _rc = value; }

    public Neighbours DoorDirection(){
        return (int)gameObject.transform.eulerAngles.z switch
        {
            90 => Neighbours.North,
            0 => Neighbours.East,
            270 => Neighbours.South,
            180 => Neighbours.West,
            _ => Neighbours.Null,
        };
    }

    void OnCollisionEnter2D(Collision2D col){ 
        if(col.collider.tag == "Player" && gameObject.transform.Find("Open").gameObject.activeSelf){
            Rc.ChangeRoom(DoorDirection());
        } else if(col.collider.tag == "Player" && gameObject.transform.Find("Stairs").gameObject.activeSelf){
            Rc.ChangeRoom(Neighbours.Null);
        }
    }
}