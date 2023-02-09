using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class Item {
    [SerializeField] private string _name;
    [SerializeField] private string _rarity;
    [SerializeField] private string _origin;
    [SerializeField] private List<Stats> _stats = new List<Stats>();
    [SerializeReference] private List<IEffect> _effects = new List<IEffect>();

    public Item(string name, string rarity, string origin, List<Stats> stats, List<IEffect> effects){
        this._name = name;
        this._rarity = rarity;
        this._origin = origin;
        if(stats != null){
            this._stats = stats;
        }
        if(effects != null){
        this._effects = effects;
        }
    }

    public string Name { get => _name; set => _name = value; }
    public string Rarity { get => _rarity; set => _rarity = value; }
    public string Origin { get => _origin; set => _origin = value; }
    public List<Stats> Stats { get => _stats; set => _stats = value; }
    public List<IEffect> Effects { get => _effects; set => _effects = value; }

    public override string ToString(){
        string toReturn = this._name + "\n" + this._rarity + "\nStats: \n";
        if(this._stats != null){  
            foreach(Stats stat in this._stats){
                toReturn += stat.ToString();
            }
        }
        if(this._effects != null){
            foreach(IEffect effect in this._effects){
                toReturn += effect.ToString();
            }
        }
        return toReturn;
    }
    public static Sprite GetImage(Item i){
        string dir =  System.IO.Directory.GetCurrentDirectory() + "/DataPacks/" + i.Origin + "/" + i.Name + ".png";
        byte[] spriteData = File.ReadAllBytes(dir);
        Texture2D texture2D = new Texture2D(2,2);
        texture2D.LoadImage(spriteData);
        texture2D.filterMode = FilterMode.Point;
        return(Sprite.Create(texture2D, new Rect(0,0,16,16),new Vector2(0.5f,0.5f), 16f));
    }
    //,
    //   "Slow": {
    //     "TimeMod": 2,
    //     "TimePMod": 0.02,
    //     "SlowMod": 0.03,
    //     "SlowPMod": 0.03,
    //     "ChancePMod": 0.03
    //   }

}
