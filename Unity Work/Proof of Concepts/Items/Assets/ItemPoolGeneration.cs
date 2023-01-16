using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class ItemPoolGeneration : MonoBehaviour
{
    [SerializeField] private Item[] itemPool;
    [SerializeField] private string JSONFileName;

    void SetItemPool(Item[] itemPool){this.itemPool = itemPool;}
    Item[] GetItemPool(){return this.itemPool;}
    Item GetItem(int x){return this.itemPool[x];}
    void SetJSONfileName(string JSONFileName){this.JSONFileName = JSONFileName;}
    string GetJSONfileName(){return this.JSONFileName;}
    void Start()
    {
        SetJSONfileName("Assets/Scripts/Items Scripts/ItemPool.json");
        using (StreamReader r = new StreamReader(GetJSONfileName()))
        {
            string json = r.ReadToEnd();

            for(i = 0; i<items.Length; i++){
                GetItemPool().add(JsonConvert.DeserializeObject<Item>(json));
            }
        }
    }
    // Update is called once per frame
    //Item generateRandomDrop(string[] options){
        
    //}
}
