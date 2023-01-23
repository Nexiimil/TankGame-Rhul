using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    [SerializeField] private string _name;
    [SerializeField] private string _rarity;
    [SerializeField] private List<Stats> _stats = null;
    [SerializeField] private List<IEffect> _effects = null;

    public Item(string name, string rarity, List<Stats> stats, List<IEffect> effects){
        this._name = name;
        this._rarity = rarity;
        this._stats = stats;
        this._effects = effects;
    }

    public string Name { get => _name; set => _name = value; }
    public string Rarity { get => _rarity; set => _rarity = value; }
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
    //,
    //   "Slow": {
    //     "TimeMod": 2,
    //     "TimePMod": 0.02,
    //     "SlowMod": 0.03,
    //     "SlowPMod": 0.03,
    //     "ChancePMod": 0.03
    //   }

}
