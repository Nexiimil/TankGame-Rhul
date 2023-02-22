using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class ItemFactory : MonoBehaviour
{
    [SerializeField] private GameObject item; //item prefab
    [SerializeField] private Transform parent; //the room that holds the item
    
    public void Create(Item toGen){
        int spawnRadius = 2; //determines how far away from the unit circle an item drop can spawn
        ItemPoolGeneration itemPool =(ItemPoolGeneration)GameObject.FindWithTag("ItemPool").GetComponent("ItemPoolGeneration");
        Vector2 spawnPoint = new Vector2(parent.position.x, parent.position.y) + Random.insideUnitCircle * spawnRadius; //sets up the spawn point
        GameObject itemDrop = Instantiate(item, spawnPoint, Quaternion.identity, parent); //spawn an item given the various distances
        ItemDrop id = (ItemDrop)itemDrop.GetComponent("ItemDrop");
        id.Me = toGen;
        SpriteRenderer sr = (SpriteRenderer)itemDrop.GetComponent("SpriteRenderer");
        sr.sprite = Item.GetImage(toGen);
    }
}
