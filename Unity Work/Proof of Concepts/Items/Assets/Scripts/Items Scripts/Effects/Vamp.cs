using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vamp : IEffect
{
    [SerializeField] private float _healMod;
    [SerializeField] private float _healPMod;
    [SerializeField] private float _chancePMod;

    public float HealMod { get => _healMod; set => _healMod = value; }
    public float HealPMod { get => _healPMod; set => _healPMod = value; }
    public float ChancePMod { get => _chancePMod; set => _chancePMod = value; }

    public Vamp(float healMod,float healPMod,float chancePMod){
        this._healMod = healMod;
        this._healPMod = healPMod;
        this._chancePMod = chancePMod;
    }

    public IEffect RollAfflicationChance(){
        return this;
    }

    public void Aggregate(IEffect aggregate){
        Vamp v = (Vamp) aggregate;
        this._healMod += v._healMod;
        this._healPMod += v._healPMod;
        this._chancePMod += v._chancePMod;
    }
    public void Negate(){
        this._healMod *= -1;
        this._healPMod *= -1;
        this._chancePMod *= -1;
    }

    public void Afflict(){
        
    }

    public override string ToString()
    {
        string toReturn = "Vamp: \n";
        toReturn += "HealMod: " + this._healMod +  "\n";
        toReturn += "HealPMod: " + this._healPMod +  "\n";
        toReturn += "Chance: " + this._chancePMod +  "\n";
        return toReturn;
    }
}