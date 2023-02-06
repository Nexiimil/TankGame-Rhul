using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slow : IEffect
{
    [SerializeField] private float _timeMod;
    [SerializeField] private float _timePMod;
    [SerializeField] private float _slowMod;
    [SerializeField] private float _slowPMod;
    [SerializeField] private float _chancePMod;
    [SerializeField] private string[] statsModified = {"EntitySpeed", "EntityRoSpeed", "EntityFireSpeed"};

    public float TimeMod { get => _timeMod; set => _timeMod = value; }
    public float TimePMod { get => _timePMod; set => _timePMod = value; }
    public float SlowMod { get => _slowMod; set => _slowMod = value; }
    public float SlowPMod { get => _slowPMod; set => _slowPMod = value; }
    public float ChancePMod { get => _chancePMod; set => _chancePMod = value; }
    public string[] StatsModified { get => statsModified; set => statsModified = value; }

    public Slow(float timeMod,float timePMod,float slowMod,float slowPMod,float chancePMod){
        this._timeMod = timeMod;
        this._timePMod = timePMod;
        this._slowMod = slowMod;
        this._slowPMod = slowPMod;
        this._chancePMod = chancePMod;
    }

    public void Aggregate(IEffect aggregate){
        Slow p = (Slow) aggregate;
        this._timeMod += p.TimeMod;
        this._timePMod += p.TimePMod;
        this._slowMod += p.SlowMod;
        this._slowPMod += p.SlowPMod;
        this._chancePMod += p.ChancePMod;
    }
    public void Negate(){
        this._timeMod *= -1;
        this._timePMod *= -1;
        this._slowMod *= -1;
        this._slowPMod *= -1;
        this._chancePMod *= -1;
    }
    public void Afflict(GameObject go, GameObject aff){
        EntityController ec = go.GetComponent<EntityController>();
        foreach(String s in StatsModified){
            int index = ec.Sa.FindIndex(r => r.statName == s);
            ec.Sa[index].flatStat = Stats.capFlat(0.5f, ec.Sa[index].flatStat-SlowMod, 100);
            ec.Sa[index].percentageStat = Stats.capPerc(0, ec.Sa[index].percentageStat-SlowPMod, 1);
        }
    }
    public int ExpireCalc(){
        return (int) Stats.capFlatPerc(1, TimeMod, TimePMod, 10);
    }

    public override string ToString()
    {
        string toReturn = "Slow: \n";
        toReturn += "TimeMod: " + this._timeMod +  "\n";
        toReturn += "TimePMod: " + this._timePMod +  "\n";
        toReturn += "SlowMod: " + this._slowMod +  "\n";
        toReturn += "SlowPMod: " + this._slowPMod +  "\n";
        toReturn += "Chance: " + this._chancePMod +  "\n";
        return toReturn;
    }
}