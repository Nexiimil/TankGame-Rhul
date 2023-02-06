using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Affliction
{
    [SerializeField] private GameObject _afflictor;
    [SerializeField] private int _time;
    [SerializeReference] private IEffect _ief;
    [SerializeField] List<Stats> backup = new List<Stats>();
    public int Time { get => _time; set => _time = value; }
    public IEffect Ief { get => _ief; set => _ief = value; }
    public List<Stats> Backup { get => backup; set => backup = value; }
    public GameObject Afflictor { get => _afflictor; set => _afflictor = value; }

    public Affliction(GameObject afflictor, int time, IEffect ief)
    {
        Afflictor = afflictor;
        Time = time;
        Ief = ief;
    }

    public void Afflict(GameObject go){
        EntityController ec = go.GetComponent<EntityController>();
        if(Ief.StatsModified.Length > 0){
            foreach(string sm in Ief.StatsModified){
                Backup.Add(ec.Sa.Find(r => r.statName == sm));
            }
        }
        Ief.Afflict(go, Afflictor);
    }
    public void Restore(GameObject go){
        EntityController ec = go.GetComponent<EntityController>();
        if(Backup.Count > 0){
            foreach(Stats backedUp in Backup){
                int index = ec.Sa.FindIndex(r => r.statName == backedUp.statName);
                ec.Sa[index] = backedUp;
            }
        }
    }
}