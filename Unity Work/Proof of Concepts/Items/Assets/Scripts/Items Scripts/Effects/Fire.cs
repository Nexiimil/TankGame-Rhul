using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fire : IEffect
{
    [SerializeField] private float _timeMod;
    [SerializeField] private float _timePMod;
    [SerializeField] private float _damageMod;
    [SerializeField] private float _damagePMod;
    [SerializeField] private float _chancePMod;

    public float TimeMod { get => _timeMod; set => _timeMod = value; }
    public float TimePMod { get => _timePMod; set => _timePMod = value; }
    public float DamageMod { get => _damageMod; set => _damageMod = value; }
    public float DamagePMod { get => _damagePMod; set => _damagePMod = value; }
    public float ChancePMod { get => _chancePMod; set => _chancePMod = value; }

    public Fire(float timeMod,float timePMod,float damageMod,float damagePMod,float chancePMod){
        this._timeMod = timeMod;
        this._timePMod = timePMod;
        this._damageMod = damageMod;
        this._damagePMod = damagePMod;
        this._chancePMod = chancePMod;
    }

    public IEffect RollAfflicationChance(){
        return this;
    }

    public void Aggregate(IEffect aggregate){
        Fire f = (Fire) aggregate;
        this._timeMod += f.TimeMod;
        this._timePMod += f.TimePMod;
        this._damageMod += f.DamageMod;
        this._damagePMod += f.DamagePMod;
        this._chancePMod += f.ChancePMod;
    }
    public void Negate(){
        this._timeMod *= -1;
        this._timePMod *= -1;
        this._damageMod *= -1;
        this._damagePMod *= -1;
        this._chancePMod *= -1;
    }
    public void Afflict(){

    }

    public override string ToString()
    {
        string toReturn = "Fire: \n";
        toReturn += "TimeMod: " + this._timeMod +  "\n";
        toReturn += "TimePMod: " + this._timePMod +  "\n";
        toReturn += "DamageMod: " + this._damageMod +  "\n";
        toReturn += "DamagePMod: " + this._damagePMod +  "\n";
        toReturn += "Chance: " + this._chancePMod +  "\n";
        return toReturn;
    }
}