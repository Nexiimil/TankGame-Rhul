using UnityEngine;

public class ItemDrop : MonoBehaviour{
    [SerializeField] private Item _me;

    public Item Me { get => _me; set => _me = value; }

    void OnCollisionEnter2D(Collision2D col){ //triggers on player colliding with an item
        InventoryHandler ih = col.collider.GetComponent<InventoryHandler>(); //fetches the inventory script of the target
        if(ih != null){ //checks if the inventory exists
            ih.PickUp(Me); //adds the item to the target inventory
            RoomState s = gameObject.transform.parent.parent.gameObject.GetComponent<RoomController>().Current.State;
            if(s == RoomState.BossCleared){
                gameObject.transform.parent.parent.gameObject.GetComponent<RoomController>().Current.State = RoomState.BossItemPickedUp;
            }else{
                gameObject.transform.parent.parent.gameObject.GetComponent<RoomController>().Current.State = RoomState.StandardItemPickedUp;
            }
            Destroy(gameObject); //destroys the item on collision, preventing duplicate item collection
        }
    }
}
