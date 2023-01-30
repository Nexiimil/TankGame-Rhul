using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using UnityEngine;
public class ItemFactory : MonoBehaviour
{
    [SerializeField] private GameObject item; //item prefab
    [SerializeField] private Transform parent; //the room that holds the item
    
    public void Create(int num){
        int spawnRadius = 2; //determines how far away from the unit circle an item drop can spawn
        for(int i=0; i<num; i++){ //for n items
            ItemPoolGeneration itemPool =(ItemPoolGeneration)GameObject.FindWithTag("ItemPool").GetComponent("ItemPoolGeneration");
            Item gen = itemPool.generateRandomDrop();
            Vector2 spawnPoint = new Vector2(parent.position.x, parent.position.y) + Random.insideUnitCircle * spawnRadius; //sets up the spawn point
            GameObject itemDrop = Instantiate(item, spawnPoint, Quaternion.identity, parent); //spawn an item given the various distances
            ItemDrop id = (ItemDrop)itemDrop.GetComponent("ItemDrop");
            id.Me = gen;
            string dir =  System.IO.Directory.GetCurrentDirectory() + "/DataPacks/" + gen.Origin + "/" + gen.Name + ".png";
            byte[] spriteData = File.ReadAllBytes(dir);
            Texture2D texture2D = new Texture2D(2,2);
            texture2D.LoadImage(spriteData);
            Sprite spr = Sprite.Create(texture2D, new Rect(0,0,16,16),new Vector2(0.5f,0.5f), 16f);
            SpriteRenderer sr = (SpriteRenderer)itemDrop.GetComponent("SpriteRenderer");
            sr.sprite = spr;
        }
    }
}
