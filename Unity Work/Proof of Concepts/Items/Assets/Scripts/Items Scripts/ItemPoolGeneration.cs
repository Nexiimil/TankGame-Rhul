using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

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
        //serialiseAttempt();
        SetJSONfileName("Assets/Scripts/Items Scripts/ItemPool.json");
        using (StreamReader r = new StreamReader(GetJSONfileName()))
        {
            string json = r.ReadToEnd();
            Debug.Log(json);
            SetItemPool(JsonConvert.DeserializeObject<List<Item>>(json, new JsonSerializerSettings{
                                                                            TypeNameHandling = TypeNameHandling.Auto
                                                                        }));
            for(int i = 0; i<GetItemPool().Count;i++){
                Debug.Log(GetItem(i).ToString());
            }

        }

        // using (StreamReader r = new StreamReader("Assets/Scripts/Items Scripts/testJson"))
        // {
        //     string test = r.ReadToEnd();
        //     List<Stats> sa = JsonConvert.DeserializeObject<List<Stats>>(test);
        //     Debug.Log(sa);
        // }
    }
    void serialiseAttempt(){
        List<Stats> stats = new List<Stats>{
                                            new Stats("BulletType", 0, 0),
                                            new Stats("BulletDamage", 1, 0),
                                            new Stats("BulletSpeed", 20, 0),
                                        };
        List<IEffect> effects = new List<IEffect>{new Poison(1,0,1,0,0.2f)};
        Item itemTest = new Item("TestBlade", "Test", stats, effects);
        Debug.Log(itemTest.ToString());
        Debug.Log(JsonConvert.SerializeObject(itemTest, new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto }));
    }
}
