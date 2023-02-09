using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ice : IEffect
{
    [SerializeField] private float _timeMod;
    [SerializeField] private float _timePMod;
    [SerializeField] private float _chancePMod;
    [SerializeField] private string[] statsModified = {"EntitySpeed", "EntityRoSpeed"};

    public float TimeMod { get => _timeMod; set => _timeMod = value; }
    public float TimePMod { get => _timePMod; set => _timePMod = value; }
    public float ChancePMod { get => _chancePMod; set => _chancePMod = value; }
    public string[] StatsModified { get => statsModified; set => statsModified = value; }

    public Ice(float timeMod,float timePMod,float chancePMod){
        this._timeMod = timeMod;
        this._timePMod = timePMod;
        this._chancePMod = chancePMod;
    }
    
    public void Aggregate(IEffect aggregate){
        Ice i = (Ice) aggregate;
        this._timeMod += i.TimeMod;
        this._timePMod += i.TimePMod;
        this._chancePMod += i.ChancePMod;
    }

    public void Negate(){
        this._timeMod *= -1;
        this._timePMod *= -1;
        this._chancePMod *= -1;
    }

    public void Afflict(GameObject go, GameObject aff){
        EntityController ec = go.GetComponent<EntityController>();
        foreach(String s in StatsModified){
            int index = ec.Sa.FindIndex(r => r.statName == s);
            ec.Sa[index].flatStat = 0;
        }
    }

    public int ExpireCalc(){
        return (int) Stats.capFlatPerc(1, TimeMod, TimePMod, 10);
    }

    public override string ToString()
    {
        string toReturn = "Ice: \n";
        toReturn += "TimeMod: " + this._timeMod +  "\n";
        toReturn += "TimePMod: " + this._timePMod +  "\n";
        toReturn += "Chance: " + this._chancePMod +  "\n";
        return toReturn;
    }
}