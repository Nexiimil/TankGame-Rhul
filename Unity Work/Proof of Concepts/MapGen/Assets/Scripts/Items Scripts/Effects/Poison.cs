using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class Poison : IEffect
{
    [SerializeField] private float _timeMod;
    [SerializeField] private float _timePMod;
    [SerializeField] private float _damageMod;
    [SerializeField] private float _damagePMod;
    [SerializeField] private float _chancePMod;
    [SerializeField] private string[] statsModified = {};

    public float TimeMod { get => _timeMod; set => _timeMod = value; }
    public float TimePMod { get => _timePMod; set => _timePMod = value; }
    public float DamageMod { get => _damageMod; set => _damageMod = value; }
    public float DamagePMod { get => _damagePMod; set => _damagePMod = value; }
    public float ChancePMod { get => _chancePMod; set => _chancePMod = value; }
    public string[] StatsModified { get => statsModified; set => statsModified = value; }

    public Poison(float timeMod,float timePMod,float damageMod,float damagePMod,float chancePMod){
        this._timeMod = timeMod;
        this._timePMod = timePMod;
        this._damageMod = damageMod;
        this._damagePMod = damagePMod;
        this._chancePMod = chancePMod;
    }

    public void Aggregate(IEffect aggregate){
        Poison p = (Poison) aggregate;
        this._timeMod += p.TimeMod;
        this._timePMod += p.TimePMod;
        this._damageMod += p.DamageMod;
        this._damagePMod += p.DamagePMod;
        this._chancePMod += p.ChancePMod;
    }
    public void Negate(){
        this._timeMod *= -1;
        this._timePMod *= -1;
        this._damageMod *= -1;
        this._damagePMod *= -1;
        this._chancePMod *= -1;
    }
    public void Afflict(GameObject go, GameObject aff){
        //effects can impact current health this way:
        HealthController hc = go.GetComponent<HealthController>();
        hc.TakeDamage(Stats.capFlatPerc(1, DamageMod, DamagePMod, 100));
    }
    public int ExpireCalc(){
        return (int) Stats.capFlatPerc(1, TimeMod, TimePMod, 10);
    }

    public override string ToString()
    {
        string toReturn = "Poison: \n";
        toReturn += "TimeMod: " + this._timeMod +  "\n";
        toReturn += "TimePMod: " + this._timePMod +  "\n";
        toReturn += "DamageMod: " + this._damageMod +  "\n";
        toReturn += "DamagePMod: " + this._damagePMod +  "\n";
        toReturn += "Chance: " + this._chancePMod +  "\n";
        return toReturn;
    }
}