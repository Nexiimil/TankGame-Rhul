using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Poison : IEffect
{
    private float timeMod;
    private float timePMod;
    private float damageMod;
    private float damagePMod;
    private float chancePMod;

    public void setChancePMod(float chancePMod){this.chancePMod = chancePMod;}
    public float getChancePMod(){return this.chancePMod;}
    public Poison(float timeMod,float timePMod,float damageMod,float damagePMod,float chancePMod){
        this.timeMod = timeMod;
        this.timePMod = timePMod;
        this.damageMod = damageMod;
        this.damagePMod = damagePMod;
        this.chancePMod = chancePMod;
    }

    public IEffect rollAfflicationChance(){
        return this;
    }

    public void Aggregate(IEffect aggregate){
        Poison p = (Poison) aggregate;
        this.timeMod += p.timeMod;
        this.timePMod += p.timePMod;
        this.damageMod += p.damageMod;
        this.damagePMod += p.damagePMod;
        this.chancePMod += p.chancePMod;
    }
    public void Negate(){
        this.timeMod *= -1;
        this.timePMod *= -1;
        this.damageMod *= -1;
        this.damagePMod *= -1;
        this.chancePMod *= -1;
    }
    public void Afflict(){

    }
}