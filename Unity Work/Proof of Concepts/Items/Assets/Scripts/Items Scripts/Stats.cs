using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stats{
    [SerializeField] private string _statName;
    [SerializeField] private float _flatStat;
    [SerializeField] private float _percentageStat;
    public string statName { get => _statName; set => _statName = value; }
    public float flatStat { get => _flatStat; set => _flatStat = value; }
    public float percentageStat { get => _percentageStat; set => _percentageStat = value; }
    public Stats(string statName, float flatStat, float percentageStat){
        this._statName = statName;
        this._flatStat = flatStat;
        this._percentageStat = percentageStat;
    }

    public override string ToString()
    {
        return this.statName + ", " + this.flatStat + ", " + this.percentageStat + "\n";
    }
}