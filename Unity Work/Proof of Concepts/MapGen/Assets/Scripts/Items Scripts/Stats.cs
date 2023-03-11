using System.IO;
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
    public static float capFlat(float lower, float value, float upper){
        return Math.Min(Math.Max(value,lower),upper);
    }
    public static float capPerc(float lower, float value, float upper){
        return 1 + Math.Min(Math.Max(value,lower),upper);
    }
    public static float capFlatPerc(float lower, float flat, float perc, float upper){
        return  Stats.capFlat(lower, flat, upper) * Stats.capPerc(0,perc,1);
    }

    public static Sprite GetImage(Stats s){
        string dir =  System.IO.Directory.GetCurrentDirectory() + "/Stats/" + s.statName + ".png";
        byte[] spriteData = File.ReadAllBytes(dir);
        Texture2D texture2D = new Texture2D(2,2);
        texture2D.LoadImage(spriteData);
        texture2D.filterMode = FilterMode.Point;
        return Sprite.Create(texture2D, new Rect(0,0,16,16),new Vector2(0.5f,0.5f), 16f);
    }
}