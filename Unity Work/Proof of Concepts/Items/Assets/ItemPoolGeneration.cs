using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System;
using System.Configuration;

public class ItemPoolGeneration : MonoBehaviour
{
    [SerializeField] private List<Item> itemPool = new List<Item>();
    [SerializeField] private string JSONFileName;

    void SetItemPool(List<Item> itemPool){this.itemPool = itemPool;}
    List<Item> GetItemPool(){return this.itemPool;}
    Item GetItem(int x){return this.itemPool[x];}
    void SetJSONfileName(string JSONFileName){this.JSONFileName = JSONFileName;}
    string GetJSONfileName(){return this.JSONFileName;}
    void Start()
    {
        serialiseAttempt();
        SetJSONfileName("Assets/Scripts/Items Scripts/ItemPool.json");
        using (StreamReader r = new StreamReader(GetJSONfileName()))
        {
            string json = r.ReadToEnd();
            Debug.Log(json);
            SetItemPool(JsonConvert.DeserializeObject<List<Item>>(json));
            // List<string> items = new List<string>();
            // int indentation = 0;
            // int iterations = 0;
            // string returnItem ="";
            // do{
            //     string c = json.Substring(iterations, 1);
            //     if (indentation == 1 && c == ","){
            //         iterations++;
            //         continue;
            //     }
            //     Debug.Log("current char: " + c);
            //     if(c == "{"){
            //         indentation++;
            //     } else if(c == "}"){
            //         indentation--;
            //     }
            //     Debug.Log("indentation: " + indentation);
            //     returnItem += c;
            //     if(indentation == 1 && c == "}"){
            //         items.Add(returnItem);
            //         Debug.Log("Item: " + returnItem);
            //         returnItem = "";
            //     }
            //     iterations++;
            // }while(indentation!=0);
            // for(int i = 0; i<items.Count; i++){
            //     GetItemPool().Add(JsonConvert.DeserializeObject<Item>(items[i]));
            // }
        }
    }
    // Update is called once per frame
    //Item generateRandomDrop(string[] options){
        
    //}
    void serialiseAttempt(){
        StatArray stats = new StatArray(new Dictionary<string, float[]>{
                                            {"BulletType", new float[] {0, 0}},
                                            {"BulletDamage", new float[] {1, 0}},
                                            {"BulletSpeed", new float[] {20, 0}},
                                            {"BulletCrit", new float[] {0, 0}}
                                        });
        EffectsArray effects = new EffectsArray(new Dictionary<string, IEffect>{
                                            {"Poison", new Poison(1,0,1,0,0.2f)}
                                        });
        Item itemTest = new Item("TestBlade", "Test", stats, effects);
        Debug.Log(itemTest.ToString());
        Debug.Log(JsonConvert.SerializeObject(itemTest));
    }
}
