using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class ItemPoolGeneration : MonoBehaviour
{
    [SerializeField] private static List<Item> itemPool = new List<Item>();
    [SerializeField] private string jsonFileName;

    public static List<Item> ItemPool { get => itemPool; set => itemPool = value; }
    public string JSONFileName { get => jsonFileName; set => jsonFileName = value; }

    void Start(){
        string[] dir =  Directory.GetDirectories(System.IO.Directory.GetCurrentDirectory() + "/DataPacks");
        foreach(string d in dir) {
            JSONFileName = d + "/Items.json";
            using (StreamReader r = new StreamReader(JSONFileName)){
                string json = r.ReadToEnd();
                Debug.Log(json);
                ItemPool.AddRange(JsonConvert.DeserializeObject<List<Item>>(json, new JsonSerializerSettings{
                                                                            TypeNameHandling = TypeNameHandling.Auto
                                                                                }));
            }
        }
        for(int i = 0; i<ItemPool.Count;i++){
            Debug.Log(ItemPool[i].ToString());
        }
    }

    public static Item GenerateRandomDrop(){
        System.Random rand = new();
        Item item = ItemPool[rand.Next(0, ItemPool.Count)];
        return item;
    }
}
