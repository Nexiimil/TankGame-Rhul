using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weak : IEffect
{
    [SerializeField] private float _timeMod;
    [SerializeField] private float _timePMod;
    [SerializeField] private float _debuffMod;
    [SerializeField] private float _debuffPMod;
    [SerializeField] private float _chancePMod;

    public float TimeMod { get => _timeMod; set => _timeMod = value; }
    public float TimePMod { get => _timePMod; set => _timePMod = value; }
    public float DebuffMod { get => _debuffMod; set => _debuffMod = value; }
    public float DebuffPMod { get => _debuffPMod; set => _debuffPMod = value; }
    public float ChancePMod { get => _chancePMod; set => _chancePMod = value; }

    public Weak(float timeMod,float timePMod,float debuffMod,float debuffPMod,float chancePMod){
        this._timeMod = timeMod;
        this._timePMod = timePMod;
        this._debuffMod = debuffMod;
        this._debuffPMod = debuffPMod;
        this._chancePMod = chancePMod;
    }

    public IEffect RollAfflicationChance(){
        return this;
    }

    public void Aggregate(IEffect aggregate){
        Weak f = (Weak) aggregate;
        this._timeMod += f.TimeMod;
        this._timePMod += f.TimePMod;
        this._debuffMod += f.DebuffMod;
        this._debuffPMod += f.DebuffPMod;
        this._chancePMod += f.ChancePMod;
    }
    public void Negate(){
        this._timeMod *= -1;
        this._timePMod *= -1;
        this._debuffMod *= -1;
        this._debuffPMod *= -1;
        this._chancePMod *= -1;
    }
    public void Afflict(){

    }

    public override string ToString()
    {
        string toReturn = "Weak: \n";
        toReturn += "TimeMod: " + this._timeMod +  "\n";
        toReturn += "TimePMod: " + this._timePMod +  "\n";
        toReturn += "DebuffMod: " + this._debuffMod +  "\n";
        toReturn += "DebuffPMod: " + this._debuffPMod +  "\n";
        toReturn += "Chance: " + this._chancePMod +  "\n";
        return toReturn;
    }
}